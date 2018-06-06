import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.JFileChooser;

public class GenerarHtml {
private String html;
private int estado;
private int save;
private int posicion;
private String ruta;
private ArrayList lista_lexema= new ArrayList();
private ArrayList lista_token= new ArrayList();
private ArrayList lista_etiquetas=new ArrayList();
private ArrayList lista_colores= new ArrayList();
private String orientacion="";
	public GenerarHtml(ArrayList lista_lexema,ArrayList lista_token,int save) {
		html="";
		estado=0;
		posicion=0;
		this.lista_lexema=lista_lexema;
		this.lista_token=lista_token;
		this.save=save;
		lista_etiquetas.clear();
		lista_colores.clear();
		LlenarColores();
		TraductorHtml();
		Imprimir();
		
	}
	
	private void TraductorHtml() {
		for(int i=posicion;i<lista_lexema.size();){
		Object[] data=(Object[]) lista_lexema.get(posicion);
		String lex=(String)data[0];
		String token=(String) lista_token.get(posicion);
		switch(estado) {
	//---------------------------------------------ESTADO PARA INICIO----------------------------------
		case 0: 
			if(lex.trim().equals("Inicio")) {
				html+="<html>";
			}else if(lex.trim().equals("Encabezado")) {
				estado=1;
				posicion--;
			}else if(lex.trim().equals("Cuerpo")){
				estado=2;
				posicion--;
			}
			break;
	//--------------------------------------------ESTADO PARA ENCABEZADO------------------------------------
		case 1:
			if(lex.trim().equals("Encabezado")) { //Estado encabezado
				html+="<head>";
				saveTemporal("</head>","Reservada");
			}else if(lex.trim().equals("TituloPagina")) { //Atributo TituloPagina
				html+="<title>";
				saveTemporal("</title>","Atributo");
			}else if(lex.trim().equals("}")) { // Finaliza las etiquetas
				eliminarEtiquetas();
			}else if(token.equals("TX_Cadena")){ // si es un simple texto
				html+=lex;
			}else if(lex.trim().equals("Cuerpo")) { // Estado Cuerpo
				estado=2;
				posicion--;
			}
			break;
	//-------------------------------------------ESTADO PARA CUERPO---------------------------------------
		case 2:
			if(lex.trim().equals("Cuerpo")) { //Estado Cuerpo
				html+="<body>";
			}else if(lex.trim().equals("Fondo")) { // Atributo Fondo
				html=html.substring(0, html.indexOf("<body>"));
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<body bgcolor=\""+lexx+"\">";
			}else if(lex.trim().equals("Array")){ // Objeto Array
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Texto")) { // Estado Texto	
				estado=3;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIEDA
				if(lex.trim().equals("Centro")) {
					html+="<p align=\"center\">";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Negrita")) { // ESTADOOO NEGRITA
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Cursiva")) { // ESTADOOO CURSIVA
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Subrayado")) { // ESTADOOO Subrayado
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Parrafo")) { //PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}else if(lex.trim().equals("Imagen")) {
				estado=12;
				saveTemporal("","Reservado");
			}
			break;
	//-----------------------------------------ESTADO PARA TEXTO--------------------------------------------
		case 3:
			if(lex.trim().equals("Face")) { // Atributo Face
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font face=\""+lexx+"\">";
				saveTemporal("</font>","Atributo");
			}else if(lex.trim().equals("Text")) { // Atributo Text
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				lexx=lexx.replace("\\n", "</br>");
				html+=lexx;
			}else if(token.trim().equals("TX_Cadena")) { // Es una simple cadena
					lex=lex.replace("\\n", "</br>");
					html+=lex;
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIEDA
				if(lex.trim().equals("Centro")) {
					html+="<p align=\"center\">";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Negrita")) { // ESTADOOO NEGRITA
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Cursiva")) { // ESTADOOO CURSIVA
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Subrayado")) { // ESTADOOO Subrayado
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Parrafo")) { //PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			break;
	//-----------------------------------------ESTADO PARA Titulo------------------------------------------
		case 4:
			if(lex.trim().equals("Tamaño")){ // Atributo para el tamaño del titulo
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				lexx=lexx.replaceAll("t","h");
				html+="<"+lexx+">";
				saveTemporal("</"+lexx+">","Atributo");
			}else if(lex.trim().equals("Posicion")) { //Atributo para la orientacion del titulo
				html=html.substring(0, html.length()-1);
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				if(lexx.trim().equals("centro")){
					html+=" align=\"center\" >";
				}else if(lexx.trim().equals("izquierda")){
					html+=" align=\"left\" >";
				}else if(lexx.trim().equals("derecha")){
					html+=" align=\"right\" >";
				}
			}else if(lex.trim().equals("Color")) { //Atributo Color
				html=html.substring(0,(html.length())-1);
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+=" style=\"color:"+lexx+";\">";
			}else if(lex.trim().equals("Text")){ //Atributo Texto
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				lexx=lexx.replace("\\n", "</br>");
				html+=lexx;
			}else if(token.trim().equals("TX_Cadena")) { // SOLO EL TEXTO simple
				lex=lex.replace("\\n", "</br>");
				html+=lex;
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIERDA
				if(lex.trim().equals("Centro")) {
					html+="<p align=\"center\">";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Texto")) { // Estado Texto	
				estado=3;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Negrita")) { // ESTADOOO NEGRITA
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Cursiva")) { // ESTADOOO CURSIVA
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Subrayado")) { // ESTADOOO Subrayado
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Parrafo")) { //PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			break;
	//-------------------------------------------------------ESTADO PARA CENTRADO,DERECHA,IZQUIERDA---------------------------------------------------
		case 5:

			if(lex.trim().equals("Texto")) { // ESTADO TEXTO
				estado=3;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Tabla")) { //Estado TABLA
				//Falta Estado
				posicion--;
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}else if(lex.trim().equals("Imagen")) {//Estado Imagen
				//Falta Estado
				estado=12;
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(lex.trim().equals("Negrita")) { // ESTADOOO NEGRITA
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Cursiva")) { // ESTADOOO CURSIVA
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Subrayado")) { // ESTADOOO Subrayado
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Parrafo")) { //PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			break;
	//--------------------------------------------------------ESTADO PARA NEGRITA--------------------------------------------------------------------
		case 6:
			if(token.trim().equals("TX_Cadena")) { // SOLO EL TEXTO simple
				lex=lex.replace("\\n", "</br>");
				html+=lex;
			}else if(lex.trim().equals("Parrafo")) { // PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Cursiva")) { // PARA ESTADO CURSIVA
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Texto")){ //PARA ESTADO TEXTO
				estado=3;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Subrayado")) { //PARA ESTADO SUBRAYADO
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIERDA
				if(lex.trim().equals("Centro")) {
					html+="<p align=\"center\">";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(token.trim().equals("SG_coma")) { // Cierra todas las etiquetas
				cerrarEtiqueta();
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			break;
			
	//--------------------------------------------------------CURSIVA-------------------------------------------------------------
		case 7:
			if(token.trim().equals("TX_Cadena")) { // SOLO EL TEXTO simple
				lex=lex.replace("\\n", "</br>");
				html+=lex;
			}else if(lex.trim().equals("Parrafo")) { // PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Negrita")) { // PARA ESTADO Negrita
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Texto")){ //PARA ESTADO TEXTO
				estado=3;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Subrayado")) { //PARA ESTADO SUBRAYADO
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIERDA
				if(lex.trim().equals("Centro")) {
					html+="<p align=\"center\">";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(lex.trim().equals(",")) { // Cierra todas las etiquetas
				cerrarEtiqueta();
			}else if(token.trim().equals("SG_coma")) { // Cierra todas las etiquetas
				cerrarEtiqueta();
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			break;
//-------------------------------------------------------------ESTADO SUBRAYADO-------------------------------------------------------------
		case 8:
			if(token.trim().equals("TX_Cadena")) { // SOLO EL TEXTO simple
				lex=lex.replace("\\n", "</br>");
				html+=lex;
			}else if(lex.trim().equals("Parrafo")) { // PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Negrita")) { // PARA ESTADO Negrita
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Texto")){ //PARA ESTADO TEXTO
				estado=3;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Cursiva")) { //PARA ESTADO Cursiva
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIERDA
				if(lex.trim().equals("Centro")) {
					html+="<p align=\"center\">";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(token.trim().equals("SG_coma")) { // Cierra todas las etiquetas
				cerrarEtiqueta();
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			break;
			//----------------------------------------------------Estado Color------------------------------------------------------
		case 9:
			if(token.trim().equals("TX_Cadena")) { // SOLO EL TEXTO simple
				lex=lex.replace("\\n", "</br>");
				html+=lex;
			}else if(lex.trim().equals("Parrafo")) { // PARA ESTADO PARRAFO
				estado=10;
				html+="<p>";
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Negrita")) { // PARA ESTADO Negrita
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Texto")){ //PARA ESTADO TEXTO
				estado=3;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Cursiva")) { //PARA ESTADO Cursiva
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Subrayado")) { //PARA ESTADO Subrayado
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIERDA
				if(lex.trim().equals("Centro")) {
					html+="<p align=\"center\">";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(token.trim().equals("SG_coma")) { // Cierra todas las etiquetas
				cerrarEtiqueta();
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			break;
	//----------------------------------------------------ESTADO PARA PARRAFO----------------------------------------------------------
		case 10:
			if(lex.trim().equals("Text")) { // Atributo Text
				posicion+=4;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				lexx=lexx.replace("\\n", "</br>");
				html+=lexx;
			}else if(token.trim().equals("TX_Cadena")) { // Es una simple cadena
					lex=lex.replace("\\n", "</br>");
					html+=lex;
			}else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}else if(lex.trim().equals("Titulo")) { //Estado Titulo
				estado=4;
				saveTemporal("","Reservado");
			}else if(lex.trim().equals("Centro") || lex.trim().equals("Izquierda") || lex.trim().equals("Derecha")) { //ESTADO CENTRO,DERECHA,IZQUIEDA
				if(lex.trim().equals("Centro")) {
					html+="<center>";
				}else if(lex.trim().equals("Derecha")) {
					html+="<p align=\"right\">";
				}if(lex.trim().equals("Izquierda")) {
					html+="<p align=\"left\">";
				}
				estado=5;
				saveTemporal("</p>","Reservado");
			}else if(lex.trim().equals("Negrita")) { // ESTADOOO NEGRITA
				estado=6;
				html+="<b>";
				saveTemporal("</b>","Reservado");
			}else if(lex.trim().equals("Cursiva")) { // ESTADOOO CURSIVA
				estado=7;
				html+="<em>";
				saveTemporal("</em>","Reservado");
			}else if(lex.trim().equals("Subrayado")) { // ESTADOOO Subrayado
				estado=8;
				html+="<u>";
				saveTemporal("</u>","Reservado");
			}else if(lex.trim().equals("Color")) { // ESTADO PARA COLOR
				estado=9;
				posicion+=5;
				Object[] datas=(Object[]) lista_lexema.get(posicion);
				String lexx=(String)datas[0];
				html+="<font color=\""+lexx+"\">";
				saveTemporal("</font>","Reservado");
			}else if(lex.trim().equals("Tabla")) { //ESTADO PARA TABLA
				estado=11;
				html+="<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
				saveTemporal("</table>","Reservado");
			}
			
			break;
			
	//-------------------------------------------------ESTADO PARA TABLA--------------------------------------------
		case 11:
			if(lex.trim().equals("Fila")) {
				html+="<tr>";
			}else if(token.trim().equals("TX_Cadena")) { // Es una simple cadena
				lex=lex.replace("\\n", "</br>");
				String[] separa=lex.split(",");
				for(int j=0;j<separa.length;j++) {
					html+="<td>"+separa[j]+"</td>";
				}
				posicion++;
				String token2=(String) lista_token.get(posicion);
				if(token2.trim().equals("SG_comillas")) {
					html+="</tr>";
				}else{
					posicion--;
				}
		    }else if(lex.trim().equals("}")) { // Cierra todas las etiquetas
				eliminarEtiquetas();
			}
			break;
			
	// ---------------------------------------------ESTADO PARA IMAGEN---------------------------------------------
		case 12:
			if(token.trim().equals("TX_Cadena")) { // SOLO EL TEXTO simple
				lex=lex.replace("\\n", "</br>");
				html+="<img src=\""+lex+"\"/>";
				estado=2;
			}
			break;
			
			
			
			default:
				break;
		}
		
		posicion++;
		i=posicion;
		if(posicion>=lista_lexema.size()){
			if(lex=="}") {
			}
			html+="</body></html>";
		}	
		}
	}
	
	//------------------------------------------Metodo para guardar en arraylist temporal-------------------
	private void saveTemporal(String etiqueta,String tipo) {
		Object[] save=new Object[]{etiqueta,tipo};
		lista_etiquetas.add(0,save);
	}
	
	//-----------------------------------------Metodo para cerrar etiquetas-------------------------------
	private void eliminarEtiquetas() {
		boolean veve=false;
		while(veve==false) {
			if(lista_etiquetas.size()>0) {
				Object[] etiquet= (Object[]) lista_etiquetas.get(0);
				html+=(String)etiquet[0];
				lista_etiquetas.remove(0);
				if(etiquet[1].equals("Reservada")) {
					veve=true;
				}
				estado=2;
			}else {
				veve=true;
			}

		}
			
	}
	//---------------------------------------METODO PARA SOLO CERRAR UNA ETIQUETA-----------------------------
	private void cerrarEtiqueta() {
		if(lista_etiquetas.size()>0) {
			Object[] etiquet= (Object[]) lista_etiquetas.get(0);
			html+=(String)etiquet[0];
			lista_etiquetas.remove(0);
		}
	}
	//---------------------------------------Metodo Para Llenar Colores--------------------------------------
	private void LlenarColores() {
		lista_colores.add("red");
		lista_colores.add("green");
		lista_colores.add("blue");
		lista_colores.add("gray");
		lista_colores.add("yellow");
		lista_colores.add("orange");
		lista_colores.add("brown");
		lista_colores.add("black");
		lista_colores.add("white");
	}
	private void Imprimir() {
		if(save==1){
			JFileChooser guardar=new JFileChooser();
			try{ 
				if(guardar.showSaveDialog(null)==guardar.APPROVE_OPTION){ 
					ruta = guardar.getSelectedFile().getAbsolutePath(); 
					try(FileOutputStream fos=new FileOutputStream(ruta+".html")){			 
			            byte codigos[]=html.getBytes();			 
			            fos.write(codigos);			 
			        	}catch(IOException ee){}
					} 
				}catch (Exception ex){}
		}else if(save==0){
			File miDir = new File (".");
	        try {
	            String ruta = miDir.getCanonicalPath()+"\\SALIDA.html";
	        	File archivo = new File(ruta);
	            BufferedWriter bw;
	            if(archivo.exists()) {
	                bw = new BufferedWriter(new FileWriter(archivo));
	                bw.write(html);
	            } else {
	                bw = new BufferedWriter(new FileWriter(archivo));
	                bw.write(html);
	            }
	            bw.close();
	          }
	        catch(Exception e) {
	          e.printStackTrace();
	          }
		}


	}

}
