using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorJson
{
    class GenerarHtml
    {
        //-------------------------------------------Declarar Variables------------------------------------------
        private String html;
        private int estado;
        private int save;
        private int posicion;
        private String lex;
        private String token;
        private ArrayList lista_lexema = new ArrayList();
        private ArrayList lista_token = new ArrayList();
        private ArrayList lista_etiquetas = new ArrayList();
        private ArrayList lista_retornar = new ArrayList();
        //-----------------------------------------------------Fin Declarar Variables----------------------------
        //-------------------------------------------------Constructor--------------------------------------------
        public GenerarHtml(ArrayList lista_lexema, ArrayList lista_token, int save)
        {
            html = "";
            estado = 0;
            posicion = 0;
            this.lista_lexema = lista_lexema;
            this.lista_token = lista_token;
            this.save = save;
            lista_etiquetas.Clear();
            lista_retornar.Clear();
            TraductorHtml();
            saveHtml();
        }
        //-----------------------------------------------Metodo que traduce-------------------------------------

        public void TraductorHtml()
        {
            for (int i = posicion; i>-1 && i < lista_lexema.Count;)
            {
                Object[] data = (Object[])lista_lexema[posicion];
                lex = (String)data[0];
                token = (String)lista_token[posicion];
                switch (estado)
                {

                    //---------------------------------------------ESTADO PARA INICIO----------------------------------
                    case 0:
                        if (lex.Trim() == "Inicio")
                        {
                            html += "<html>";
                        }
                        else if (lex.Trim() == "Encabezado")
                        {
                            html += "<head>";
                            saveTemporal("</head>", "Reservada");
                            estado = 1;
                        }
                        else if (lex.Trim() == "Cuerpo")
                        {
                            html += "<body>";
                            estado = 2;
                        }
                        break;
                    //--------------------------------------------ESTADO PARA ENCABEZADO------------------------------------
                    case 1:
                        if (lex.Trim() == "TituloPagina")
                        { //Atributo TituloPagina
                            html += "<title>";
                            saveTemporal("</title>", "Atributo");
                        }
                        else if (lex.Trim() == "}")
                        { // Finaliza las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (token == "TX_Cadena")
                        { // si es un simple texto
                                html += lex;
                        }

                        break;
                    //-------------------------------------------ESTADO PARA CUERPO---------------------------------------
                    case 2:
                        if (lex.Trim() == "Cuerpo")
                        { // Estado Cuerpo
                            html += "<body>";
                        }
                        else if (lex.Trim() == "Fondo")
                        { // Atributo Fondo
                            html = html.Substring(0, html.IndexOf("<body>"));
                            posicion += 4;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<body bgcolor=\"" + lexx + "\">";
                            posicion -= 4;
                        }
                        else if (lex.Trim() == "Array")
                        { // Objeto Array
                            saveTemporal("", "Reservada");
                        }
                        else if (lex.Trim() == "Texto")
                        { // Estado Texto	
                            estado = 3;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font face=\"" + lexx + "\">";
                            saveTemporal("", "Reservada");
                            saveTemporal("</font>", "Reservada");
                        }
                        else if (lex.Trim() == "Titulo")
                        { //Estado Titulo
                            estado = 4;
                            saveTemporal("", "Reservada");
                            html += "<h1 align = \"center\" style = \"color: black; \">";
                            saveTemporal("</h1>", "Atributo");
                        }
                        else if (lex.Trim() == "Centro" || lex.Trim() == "Izquierda" || lex.Trim() == "Derecha")
                        { //ESTADO CENTRO,DERECHA,IZQUIEDA
                            if (lex.Trim() == "Centro")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"display:table;margin:auto;\"> ";
                            }
                            else if (lex.Trim() == "Derecha")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:right;\"> ";
                            }
                            if (lex.Trim() == "Izquierda")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:left;\"> ";
                            }
                            estado = 5;
                            saveTemporal("</div></div>", "Reservada");
                        }
                        else if (lex.Trim() == "Negrita")
                        { // ESTADOOO NEGRITA
                            estado = 6;
                            html += "<b>";
                            saveTemporal("</b>", "Reservada");
                        }
                        else if (lex.Trim() == "Cursiva")
                        { // ESTADOOO CURSIVA
                            estado = 7;
                            html += "<em>";
                            saveTemporal("</em>", "Reservada");
                        }
                        else if (lex.Trim() == "Subrayado")
                        { // ESTADOOO Subrayado
                            estado = 8;
                            html += "<u>";
                            saveTemporal("</u>", "Reservada");
                        }
                        else if (lex.Trim() == "Color")
                        { // ESTADO PARA COLOR
                            estado = 9;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font color=\"" + lexx + "\">";
                            saveTemporal("","Reservada");
                            saveTemporal("</font>", "Reservada");
                        }
                        else if (lex.Trim() == "Parrafo")
                        { //PARA ESTADO PARRAFO
                            estado = 10;
                            html += "<p>";
                            saveTemporal("</p>", "Reservada");
                        }
                        else if (lex.Trim() == "Tabla")
                        { //ESTADO PARA TABLA
                            estado = 11;
                            html += "<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
                            saveTemporal("</table>", "Reservada");
                        }
                        else if (lex.Trim() == "Imagen")
                        {
                            estado = 12;
                            saveTemporal("", "Reservada");
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                        }
                        else if (lex.Trim() == "}")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        break;
                    //-----------------------------------------ESTADO PARA TEXTO--------------------------------------------
                    case 3:
                         if (token.Trim() == "TX_Cadena")
                        { // Es una simple cadena
                            lex = lex.Replace("\\n", "</br>");
                            html += lex;
                        }
                        else if (lex.Trim() == "}" || lex.Trim()==",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (lex.Trim() == "Centro" || lex.Trim() == "Izquierda" || lex.Trim() == "Derecha")
                        { //ESTADO CENTRO,DERECHA,IZQUIEDA
                            if (lex.Trim() == "Centro")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"display:table;margin:auto;\"> ";
                            }
                            else if (lex.Trim() == "Derecha")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:right;\"> ";
                            }
                            if (lex.Trim() == "Izquierda")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:left;\"> ";
                            }
                            lista_retornar.Insert(0, 3);
                            estado = 5;
                            saveTemporal("</div></div>", "Reservada");
                        }
                        else if (lex.Trim() == "Negrita")
                        { // ESTADOOO NEGRITA
                            estado = 6;
                            html += "<b>";
                            saveTemporal("</b>", "Reservada");
                            lista_retornar.Insert(0, 3);
                        }
                        else if (lex.Trim() == "Cursiva")
                        { // ESTADOOO CURSIVA
                            estado = 7;
                            html += "<em>";
                            saveTemporal("</em>", "Reservada");
                            lista_retornar.Insert(0, 3);
                        }
                        else if (lex.Trim() == "Subrayado")
                        { // ESTADOOO Subrayado
                            estado = 8;
                            html += "<u>";
                            saveTemporal("</u>", "Reservada");
                            lista_retornar.Insert(0, 3);
                        }
                        else if (lex.Trim() == "Color")
                        { // ESTADO PARA COLOR
                            estado = 9;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font color=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 3);
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 3);
                        }
                        break;
                    //-----------------------------------------ESTADO PARA Titulo------------------------------------------
                    case 4:
                        if (lex.Trim() == "Tamaño")
                        { // Atributo para el tamaño del titulo
                            posicion += 4;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            lexx = lexx.Replace("t", "h");
                            cambiar_palabra("h1", lexx);
                            lista_etiquetas.RemoveAt(0);
                            saveTemporal("</" + lexx + ">", "Atributo");
                        }
                        else if (lex.Trim() == "Posicion")
                        { //Atributo para la orientacion del titulo
                            posicion += 4;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            if (lexx.Trim() == "centro")
                            {
                                cambiar_palabra("center", "center");
                            }
                            else if (lexx.Trim() == "izquierda")
                            {
                                cambiar_palabra("center", "left");
                            }
                            else if (lexx.Trim() == "derecha")
                            {
                                cambiar_palabra("center", "right");
                            }

                        }
                        else if (lex.Trim() == "color")
                        { //Atributo Color
                            posicion += 4;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            cambiar_palabra("black", lexx);
                        }
                        else if (lex.Trim() == "Text")
                        { 
                        }
                        else if (token.Trim() == "TX_Cadena")
                        { // SOLO EL TEXTO simple
                            lex = lex.Replace("\\n", "</br>");
                            html += lex;
                        }
                        else if (lex.Trim() == "}")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        break;
                    //-------------------------------------------------------ESTADO PARA CENTRADO,DERECHA,IZQUIERDA---------------------------------------------------
                    case 5:

                        if (lex.Trim() == "Texto")
                        { // ESTADO TEXTO
                            estado = 3;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font face=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 5);

                        }
                        else if (lex.Trim() == "Tabla")
                        { //Estado TABLA
                          //Falta Estado
                            posicion--;
                            estado = 11;
                            html += "<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
                            saveTemporal("</table>", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "Imagen")
                        {//Estado Imagen
                         //Falta Estado
                            estado = 12;
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "}" || lex.Trim() == ",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (lex.Trim() == "Negrita")
                        { // ESTADOOO NEGRITA
                            estado = 6;
                            html += "<b>";
                            saveTemporal("</b>", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "Cursiva")
                        { // ESTADOOO CURSIVA
                            estado = 7;
                            html += "<em>";
                            saveTemporal("</em>", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "Subrayado")
                        { // ESTADOOO Subrayado
                            estado = 8;
                            html += "<u>";
                            saveTemporal("</u>", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "Color")
                        { // ESTADO PARA COLOR
                            estado = 9;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font color=\"" + lexx + "\">";
                            saveTemporal("", "Reservada");
                            saveTemporal("</font>", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "Parrafo")
                        { //PARA ESTADO PARRAFO
                            estado = 10;
                            html += "<p>";
                            saveTemporal("</p>", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "Tabla")
                        { //ESTADO PARA TABLA
                            estado = 11;
                            html += "<table border=\"1\" CELLPADDING=10 CELLSPACING=0>";
                            saveTemporal("</table>", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 5);
                        }
                        break;
                    //--------------------------------------------------------ESTADO PARA NEGRITA--------------------------------------------------------------------
                    case 6:
                        if (token.Trim() == "TX_Cadena")
                        { // SOLO EL TEXTO simple
                            lex = lex.Replace("\\n", "</br>");
                            html += lex;
                        }
                        else if (lex.Trim() == "Parrafo")
                        { // PARA ESTADO PARRAFO
                            estado = 10;
                            html += "<p>";
                            saveTemporal("</p>", "Reservada");
                            lista_retornar.Insert(0, 6);
                        }
                        else if (lex.Trim() == "Cursiva")
                        { // PARA ESTADO CURSIVA
                            estado = 7;
                            html += "<em>";
                            saveTemporal("</em>", "Reservada");
                            lista_retornar.Insert(0, 6);
                        }
                        else if (lex.Trim() == "Texto")
                        { //PARA ESTADO TEXTO
                            estado = 3;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font face=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 6);
                        }
                        else if (lex.Trim() == "Subrayado")
                        { //PARA ESTADO SUBRAYADO
                            estado = 8;
                            html += "<u>";
                            saveTemporal("</u>", "Reservada");
                            lista_retornar.Insert(0, 6);
                        }
                        else if (lex.Trim() == "Color")
                        { // ESTADO PARA COLOR
                            estado = 9;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font color=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 6);
                        }
                        else if (lex.Trim() == "Centro" || lex.Trim() == "Izquierda" || lex.Trim() == "Derecha")
                        { //ESTADO CENTRO,DERECHA,IZQUIEDA
                            if (lex.Trim() == "Centro")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"display:table;margin:auto;\"> ";
                            }
                            else if (lex.Trim() == "Derecha")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:right;\"> ";
                            }
                            if (lex.Trim() == "Izquierda")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:left;\"> ";
                            }
                            estado = 5;
                            saveTemporal("</div></div>", "Reservada");
                            lista_retornar.Insert(0, 6);
                        }
                        else if (lex.Trim() == "}" || lex.Trim() == ",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 6);
                        }
                        break;

                    //--------------------------------------------------------CURSIVA-------------------------------------------------------------
                    case 7:
                        if (token.Trim() == "TX_Cadena")
                        { // SOLO EL TEXTO simple
                            lex = lex.Replace("\\n", "</br>");
                            html += lex;
                        }
                        else if (lex.Trim() == "Parrafo")
                        { // PARA ESTADO PARRAFO
                            estado = 10;
                            html += "<p>";
                            saveTemporal("</p>", "Reservada");
                            lista_retornar.Insert(0, 7);
                        }
                        else if (lex.Trim() == "Negrita")
                        { // PARA ESTADO Negrita
                            estado = 6;
                            html += "<b>";
                            saveTemporal("</b>", "Reservada");
                            lista_retornar.Insert(0, 7);
                        }
                        else if (lex.Trim() == "Texto")
                        { //PARA ESTADO TEXTO
                            estado = 3;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font face=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 7);
                        }
                        else if (lex.Trim() == "Subrayado")
                        { //PARA ESTADO SUBRAYADO
                            estado = 8;
                            html += "<u>";
                            saveTemporal("</u>", "Reservada");
                            lista_retornar.Insert(0, 7);
                        }
                        else if (lex.Trim() == "Color")
                        { // ESTADO PARA COLOR
                            estado = 9;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font color=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 7);
                        }
                        else if (lex.Trim() == "Centro" || lex.Trim() == "Izquierda" || lex.Trim() == "Derecha")
                        { //ESTADO CENTRO,DERECHA,IZQUIEDA
                            if (lex.Trim() == "Centro")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"display:table;margin:auto;\"> ";
                            }
                            else if (lex.Trim() == "Derecha")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:right;\"> ";
                            }
                            if (lex.Trim() == "Izquierda")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:left;\"> ";
                            }
                            estado = 5;
                            saveTemporal("</div></div>", "Reservada");
                            lista_retornar.Insert(0, 7);
                        }
                        else if (lex.Trim() == "}" || lex.Trim() == ",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 7);
                        }
                        break;
                    //-------------------------------------------------------------ESTADO SUBRAYADO-------------------------------------------------------------
                    case 8:
                        if (token.Trim() == "TX_Cadena")
                        { // SOLO EL TEXTO simple
                            lex = lex.Replace("\\n", "</br>");
                            html += lex;
                        }
                        else if (lex.Trim() == "Parrafo")
                        { // PARA ESTADO PARRAFO
                            estado = 10;
                            html += "<p>";
                            saveTemporal("</p>", "Reservada");
                            lista_retornar.Insert(0, 8);
                        }
                        else if (lex.Trim() == "Negrita")
                        { // PARA ESTADO Negrita
                            estado = 6;
                            html += "<b>";
                            saveTemporal("</b>", "Reservada");
                            lista_retornar.Insert(0, 8);
                        }
                        else if (lex.Trim() == "Texto")
                        { //PARA ESTADO TEXTO
                            estado = 3;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font face=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 8);
                        }
                        else if (lex.Trim() == "Cursiva")
                        { //PARA ESTADO Cursiva
                            estado = 7;
                            html += "<em>";
                            saveTemporal("</em>", "Reservada");
                            lista_retornar.Insert(0, 8);
                        }
                        else if (lex.Trim() == "Color")
                        { // ESTADO PARA COLOR
                            estado = 9;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font color=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 8);
                        }
                        else if (lex.Trim() == "Centro" || lex.Trim() == "Izquierda" || lex.Trim() == "Derecha")
                        { //ESTADO CENTRO,DERECHA,IZQUIEDA
                            if (lex.Trim() == "Centro")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"display:table;margin:auto;\"> ";
                            }
                            else if (lex.Trim() == "Derecha")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:right;\"> ";
                            }
                            if (lex.Trim() == "Izquierda")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:left;\"> ";
                            }
                            estado = 5;
                            saveTemporal("</div></div>", "Reservada");
                            lista_retornar.Insert(0, 8);
                        }
                        else if (lex.Trim() == "}" || lex.Trim() == ",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 8);
                        }
                        break;
                    //----------------------------------------------------Estado Color------------------------------------------------------
                    case 9:
                        if (token.Trim() == "TX_Cadena")
                        { // SOLO EL TEXTO simple
                            lex = lex.Replace("\\n", "</br>");
                            html += lex;
                        }
                        else if (lex.Trim() == "Parrafo")
                        { // PARA ESTADO PARRAFO
                            estado = 10;
                            html += "<p>";
                            saveTemporal("</p>", "Reservada");
                            lista_retornar.Insert(0, 9);
                        }
                        else if (lex.Trim() == "Negrita")
                        { // PARA ESTADO Negrita
                            estado = 6;
                            html += "<b>";
                            saveTemporal("</b>", "Reservada");
                            lista_retornar.Insert(0, 9);
                        }
                        else if (lex.Trim() == "Texto")
                        { //PARA ESTADO TEXTO
                            estado = 3;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font face=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 9);
                        }
                        else if (lex.Trim() == "Cursiva")
                        { //PARA ESTADO Cursiva
                            estado = 7;
                            html += "<em>";
                            saveTemporal("</em>", "Reservada");
                            lista_retornar.Insert(0, 9);
                        }
                        else if (lex.Trim() == "Subrayado")
                        { //PARA ESTADO Subrayado
                            estado = 8;
                            html += "<u>";
                            saveTemporal("</u>", "Reservada");
                            lista_retornar.Insert(0, 9);
                        }
                        else if (lex.Trim() == "Centro" || lex.Trim() == "Izquierda" || lex.Trim() == "Derecha")
                        { //ESTADO CENTRO,DERECHA,IZQUIEDA
                            if (lex.Trim() == "Centro")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"display:table;margin:auto;\"> ";
                            }
                            else if (lex.Trim() == "Derecha")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:right;\"> ";
                            }
                            if (lex.Trim() == "Izquierda")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:left;\"> ";
                            }
                            estado = 5;
                            saveTemporal("</div></div>", "Reservada");
                            lista_retornar.Insert(0, 9);
                        }
                        else if (lex.Trim() == "}" || lex.Trim() == ",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 9);
                        }
                        break;
                    //----------------------------------------------------ESTADO PARA PARRAFO----------------------------------------------------------
                    case 10:
                        if (lex.Trim() == "Text")
                        { // Atributo Text
                            posicion += 4;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            lexx = lexx.Replace("\\n", "</br>");
                            html += lexx;
                        }
                        else if (token.Trim() == "TX_Cadena")
                        { // Es una simple cadena
                            lex = lex.Replace("\\n", "</br>");
                            html += lex;
                        }
                        else if (lex.Trim() == "}" || lex.Trim() == ",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }
                        else if (lex.Trim() == "Centro" || lex.Trim() == "Izquierda" || lex.Trim() == "Derecha")
                        { //ESTADO CENTRO,DERECHA,IZQUIEDA
                            if (lex.Trim() == "Centro")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"display:table;margin:auto;\"> ";
                            }
                            else if (lex.Trim() == "Derecha")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:right;\"> ";
                            }
                            if (lex.Trim() == "Izquierda")
                            {
                                html += "<div style=\"overflow: hidden; \"><div style =\"float:left;\"> ";
                            }
                            estado = 5;
                            saveTemporal("</div></div>", "Reservada");
                            lista_retornar.Insert(0, 10);
                        }
                        else if (lex.Trim() == "Negrita")
                        { // ESTADOOO NEGRITA
                            estado = 6;
                            html += "<b>";
                            saveTemporal("</b>", "Reservada");
                            lista_retornar.Insert(0, 10);
                        }
                        else if (lex.Trim() == "Cursiva")
                        { // ESTADOOO CURSIVA
                            estado = 7;
                            html += "<em>";
                            saveTemporal("</em>", "Reservada");
                            lista_retornar.Insert(0, 10);
                        }
                        else if (lex.Trim() == "Subrayado")
                        { // ESTADOOO Subrayado
                            estado = 8;
                            html += "<u>";
                            saveTemporal("</u>", "Reservada");
                            lista_retornar.Insert(0, 10);
                        }
                        else if (lex.Trim() == "Color")
                        { // ESTADO PARA COLOR
                            estado = 9;
                            posicion += 5;
                            Object[] datas = (Object[])lista_lexema[posicion];
                            String lexx = (String)datas[0];
                            html += "<font color=\"" + lexx + "\">";
                            saveTemporal("</font>", "Reservada");
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 10);
                        }
                        else if (lex.Trim() == "Salto")
                        {
                            estado = 13;
                            saveTemporal("", "Reservada");
                            lista_retornar.Insert(0, 10);
                        }
                        break;

                    //-------------------------------------------------ESTADO PARA TABLA--------------------------------------------
                    case 11:
                        if (lex.Trim() == "Fila")
                        {
                            html += "<tr>";
                        }
                        else if (token.Trim() == "TX_Cadena")
                        { // Es una simple cadena
                            lex = lex.Replace("\\n", "</br>");
                            String[] separa = lex.Split(',');
                            for (int j = 0; j < separa.Length; j++)
                            {
                                html += "<td>" + separa[j] + "</td>";
                            }
                            posicion++;
                            String token2 = (String)lista_token[posicion];
                            if (token2.Trim() == "SG_comillas")
                            {
                                html += "</tr>";
                            }
                            else
                            {
                                posicion--;
                            }
                        }
                        else if (lex.Trim() == "}")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }

                        break;

                    // ---------------------------------------------ESTADO PARA IMAGEN---------------------------------------------
                    case 12:
                        if (token.Trim() == "TX_Cadena")
                        { // SOLO EL TEXTO simple
                            lex = lex.Replace("\\n", "</br>");
                            html += "<img src=\"" + lex + "\"/>";
                            estado = 2;
                        }
                        break;

                    //----------------------------------------------Estado Para Salto----------------------------------------------
                    case 13:
                        if (token.Trim() == "TX_Cadena")
                        {
                            int repeticion = Convert.ToInt32(lex);
                            for(int j = 0; j < repeticion; j++)
                            {
                                html += "</br>";
                            }
                        }
                        else if (lex.Trim() == "}" || lex.Trim() == ",")
                        { // Cierra todas las etiquetas
                            eliminarEtiquetas();
                        }

                        break;


                    default:
                        break;
                }

                posicion++;
                i = posicion;
                if (posicion >= lista_lexema.Count)
                {
                    if (lex == "}")
                    {
                    }
                    html += "</body></html>";
                }
            }
        }
        //------------------------------------------Metodo para guardar en arraylist temporal-------------------
        private void saveTemporal(String etiqueta, String tipo)
        {
            Object[] save = new Object[] { etiqueta, tipo };
            lista_etiquetas.Insert(0, save);
        }



        //-----------------------------------------Metodo para cerrar etiquetas-------------------------------
        private void eliminarEtiquetas()
        {
            Boolean veve = false;
            while (veve == false)
            {
                if (lista_etiquetas.Count > 0)
                {
                    Object[] etiquet = (Object[])lista_etiquetas[0];
                    String ett = (String)etiquet[1];
                    html += (String)etiquet[0];
                    lista_etiquetas.RemoveAt(0);
                    if (ett == "Reservada")
                    {
                        veve = true;
                    }
                    if (lista_retornar.Count > 0)
                    {
                        estado = (int)lista_retornar[0];
                        lista_retornar.RemoveAt(0);
                    }
                    else
                    {
                        estado = 2;

                    }
                }
                else
                {
                    veve = true;
                }

            }

        }



        //---------------------------------------METODO PARA SOLO CERRAR UNA ETIQUETA-----------------------------
        private void cerrarEtiqueta()
        {
            if (lista_etiquetas.Count > 0)
            {
                Object[] etiquet = (Object[])lista_etiquetas[0];
                html += (String)etiquet[0];
                lista_etiquetas.Remove(0);
            }
        }

       

        //--------------------------------------------------Para Errores Sintacticos---------------------------------
        private void Errores_Sintacticos(String signo, String descripcion, int ir)
        {
            Object[] obtener = (Object[])lista_lexema[posicion];
            Console.Write(descripcion + "  " + signo + " fila: " + obtener[1] + " columna: " + obtener[2] + "\n");
        }









        //-----------------------------------------Genera el HTML------------------------------------------------------
        private void saveHtml()
        {
            if (save == 0) //-------------Guardado normal
            {
                TextWriter archivo;
                archivo = new StreamWriter("SALIDA.html");
                archivo.WriteLine(html);
                archivo.Close();
            } else if (save == 1)//-----------------------Guardado como
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    TextWriter archivo;
                    archivo = new StreamWriter(saveFileDialog1.FileName);
                    archivo.WriteLine(html);
                    archivo.Close();
                }
            }

        }


        //------------------------------------------------------Devuelve la ultima coincidencia------------------------------
        private  void cambiar_palabra(String buscado, String cambiar)
        {
            String retorno = "";
            int index = strrpos(html, buscado);
            if (index != 0)
            {
                html = ReplaceAt(html, index, buscado.Length, cambiar);
            }
        }

        public static int strrpos(string haystack, string needle, int? offset = null)
        {
            if (offset.HasValue)
            {
                return haystack.LastIndexOf(needle, offset.Value);
            }
            else
            {
                return haystack.LastIndexOf(needle);
            }
        }

        public String ReplaceAt( string cadena, int index, int length, string replace)
        {
            return cadena.Remove(index, Math.Min(length, cadena.Length - index)).Insert(index, replace);
        }

    }



    
}

    

