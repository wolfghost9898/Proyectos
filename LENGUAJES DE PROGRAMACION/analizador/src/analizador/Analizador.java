package analizador;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import java.awt.Color;
import java.awt.Font;
import javax.swing.JEditorPane;
import javax.swing.JFileChooser;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.awt.event.ActionEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;

public class Analizador {
	private ArrayList<String> palabras;
	private  ArrayList<Integer> cantidad;
	private  int cant_letras;
	private JFrame frame;
	private JEditorPane editorPane;
	private String ruta;
	private  String correcion;
	private int cant_errores;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Analizador window = new Analizador();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public Analizador() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setResizable(false);
		frame.getContentPane().setBackground(new Color(51, 153, 255));
		frame.setBounds(100, 100, 570, 408);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		JMenuBar menuBar = new JMenuBar();
		menuBar.setBorderPainted(false);
		menuBar.setBackground(new Color(255, 255, 255));
		menuBar.setBounds(0, 0, 564, 21);
		frame.getContentPane().add(menuBar);
		
		JMenu mnMenuArchivo = new JMenu("Menu Archivo");
		mnMenuArchivo.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mnMenuArchivo.setBackground(new Color(255, 255, 255));
		mnMenuArchivo.setForeground(new Color(102, 102, 102));
		menuBar.add(mnMenuArchivo);
		
		JMenuItem mntmNewMenuItem = new JMenuItem("Nuevo");
//-----------------------------------------------------------------Nuevo Archivo------------------------------------------------
		mntmNewMenuItem.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				editorPane.setText("");
				ruta="";
			}
		});
	
		mnMenuArchivo.add(mntmNewMenuItem);
		
		JMenuItem mntmAbrir = new JMenuItem("Abrir");
//------------------------------------------------------------------Abrir Archivos-----------------------------------------------		
		mntmAbrir.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JFileChooser abrir=new JFileChooser();
				BufferedReader br;
				try{
					if(abrir.showOpenDialog(null)==abrir.APPROVE_OPTION){
						ruta=abrir.getSelectedFile().getAbsolutePath();
						File fileDir = new File(ruta);
						br = new BufferedReader(new InputStreamReader(new FileInputStream(fileDir), StandardCharsets.UTF_8));
						editorPane.read(br, null);
				         
					}
				}catch(Exception ex){
					ex.printStackTrace();
				}
			}
		});
		mnMenuArchivo.add(mntmAbrir);
//------------------------------------------------------------------------Guardar Archivo------------------------------------------------		
		JMenuItem mntmGuardar = new JMenuItem("Guardar");
		mntmGuardar.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				 try(FileOutputStream fos=new FileOutputStream(ruta)){
			            String texto=editorPane.getText().toString();		 
			            byte codigos[]=texto.getBytes();	 
			            fos.write(codigos);
			        }catch(IOException ee){}

			}
		});
		mnMenuArchivo.add(mntmGuardar);
//---------------------------------------------------------------------Guardar Como----------------------------------------------------		
		JMenuItem mntmGuardarComo = new JMenuItem("Guardar Como");
		mntmGuardarComo.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JFileChooser guardar=new JFileChooser();
				try{ 
					if(guardar.showSaveDialog(null)==guardar.APPROVE_OPTION){ 
						ruta = guardar.getSelectedFile().getAbsolutePath(); 
						try(FileOutputStream fos=new FileOutputStream(ruta)){			 
				            String texto=editorPane.getText().toString();
				            byte codigos[]=texto.getBytes();			 
				            fos.write(codigos);			 
				        	}catch(IOException ee){}
						} 
					}catch (Exception ex){} 

				
			}
		});
		mnMenuArchivo.add(mntmGuardarComo);
		
		//---------------------------------------------------------------Click en Analizar-----------------------------------------------
		JMenuItem mntmAnalizar = new JMenuItem("Analizar");
		mntmAnalizar.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				cantidad= new ArrayList<Integer>();
				Palabras();
				Oraciones();
				Signos_Puntuacion();
				Letras_tildadas();
				Caracteres();
				Tipo();
				Monosilaba();
				Guardar();
			}
		});
		//----------------------------------------------------------Fin click analizar-------------------------------------------
		mnMenuArchivo.add(mntmAnalizar);
//-----------------------------------------------------------------Salir--------------------------------------------------------		
		JMenuItem mntmSalir = new JMenuItem("Salir");
		mntmSalir.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int i =JOptionPane.showConfirmDialog(null,"¿Realmente Desea Salir del Analizador?","Confirmar Salida",JOptionPane.YES_NO_OPTION);
				if(i==0){
				System.exit(0);
				}
			}
		});
		mnMenuArchivo.add(mntmSalir);
		
		JMenu mnMenuDocumentacion = new JMenu("Menu Documentacion");
		mnMenuDocumentacion.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mnMenuDocumentacion.setBackground(new Color(51, 153, 255));
		mnMenuDocumentacion.setForeground(new Color(102, 102, 102));
		menuBar.add(mnMenuDocumentacion);
		
		JMenuItem mntmManualUsuario = new JMenuItem("Manual de Usuario");
		mntmManualUsuario.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					Runtime.getRuntime().exec("rundll32 url.dll,FileProtocolHandler "+"Manual-de-usuario.pdf");
					System.out.println("Final");
					} catch (IOException e) {
					// TODO Auto-generated catch block
					}
				
			}
		});
		mnMenuDocumentacion.add(mntmManualUsuario);
		
		JMenuItem mntmMenuDocumentacion = new JMenuItem("Menu Tecnico");
		mntmMenuDocumentacion.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				try {
					Runtime.getRuntime().exec("rundll32 url.dll,FileProtocolHandler "+"Manual-técnico.pdf");
					System.out.println("Final");
					} catch (IOException ee) {
					// TODO Auto-generated catch block
					}
				
			}
		});
		mnMenuDocumentacion.add(mntmMenuDocumentacion);
		
		 editorPane = new JEditorPane();
		editorPane.setBorder(null);
		editorPane.setBounds(10, 32, 544, 336);
		
		JScrollPane scrollBar = new JScrollPane(editorPane);
		scrollBar.setBorder(null);
		scrollBar.setFont(new Font("Star Jedi", Font.PLAIN, 11));
		scrollBar.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_NEVER);
		scrollBar.setBounds(10, 32, 544, 336);
		frame.getContentPane().add(scrollBar);

	}
	
//----------------------------------------------------Cuenta Palabras y Letras----------------------------------------------	
	private void Palabras(){
		 palabras= new ArrayList<String>();
		 String texto=editorPane.getText().toString();
		 String palabra="";
		 
		int contador=0;
		int findeLinea=texto.length()-1;
		int iniciop=0;
		int finalp=0;
		 cant_letras=0;
		boolean estado=false;
		for(int i=0;i<texto.length();i++){
			if(Character.isLetterOrDigit(texto.charAt(i))&& i!=findeLinea){
				estado=true;
				finalp++;
				palabra=palabra+String.valueOf(texto.charAt(i));
			}else if(!(Character.isLetterOrDigit(texto.charAt(i))) && estado){
				estado=false;
				cant_letras=cant_letras+(finalp-iniciop);
					iniciop=finalp;
						contador++;
						palabras.add(palabra);
					palabra="";
			}else if(Character.isLetterOrDigit(texto.charAt(i)) && i==findeLinea){	
				cant_letras=cant_letras+(finalp+1-iniciop);
				contador++;
				palabra=palabra+String.valueOf(texto.charAt(i));
				palabras.add(palabra);
				palabra="";
			}
		}
		cantidad.add(contador);
		}

	
//---------------------------------------------------------Contar oraciones y Parrafos------------------------------------------------------------
	private void Oraciones(){
		int cant_oraciones=0;
		int cant_parrafos=0;
		char[] texto=editorPane.getText().toString().toCharArray();
		for(int i=0;i<texto.length;i++){
			switch(texto[i]){
			case '.':
				cant_oraciones++;
				break;
			case'\n':
				try{
					if(((int)texto[i-1]==13) && ((int)texto[i+1]==13))
						cant_parrafos++;
				}catch(ArrayIndexOutOfBoundsException  error){
					
				}

				break;
			}
		}
		cantidad.add(cant_oraciones);
		cantidad.add(cant_parrafos);
	}
//-----------------------------------------------------Signos de Puntuacion y Errores lexicos----------------------------------------------------------------------
	private void Signos_Puntuacion(){
		 correcion="No se reconocen los siguientes caracteres: ";
		int cant_signos=0;
		 cant_errores=0;
		boolean estado=true;
		Matriz matriz= new Matriz();
		int[] signos=matriz.signos();
		char[] texto=editorPane.getText().toString().toCharArray();
		for(int i=0;i<texto.length;i++){
			if(!Character.isLetterOrDigit(texto[i])){
				if(!(((int)texto[i]==10) || ((int)texto[i]==32) || ((int)texto[i]==13))){
					estado=false;
					int ascii=(int)texto[i];
					for(int j=0;j<signos.length;j++){
						if(signos[j]==ascii){
							cant_signos++;
							estado=true;
							break;
						}
					}
				}

			}
			if(estado==false){
				cant_errores++;
				estado=true;
				correcion=correcion+" "+texto[i];
			}
		}
		cantidad.add(cant_signos);
	}
	
//---------------------------------------------------Letras Tildadas-----------------------------------------------------------------------------
	public void Letras_tildadas(){
		int cant_tildadas=0;
		char[] texto=editorPane.getText().toString().toCharArray();
		for(int i=0;i<texto.length;i++){
			if(texto[i]=='á' || texto[i]=='é'|| texto[i]=='í'|| texto[i]=='ó'|| texto[i]=='ú'){
				cant_tildadas++;
			}else if(texto[i]=='Á' || texto[i]=='É'|| texto[i]=='Í'|| texto[i]=='Ó'|| texto[i]=='Ú'){
				cant_tildadas++;
			}
			
		}
		cantidad.add(cant_tildadas);
	}
//--------------------------------------------------Caracteres Ingresados--------------------------------------------------------------------------
	public void Caracteres(){
		int cant_caracteres=0;
		char[] texto=editorPane.getText().toString().toCharArray();
		for(int i=0;i<texto.length;i++){
			if(!(((int)texto[i]==10) || ((int)texto[i]==32) || ((int)texto[i]==13))){
				cant_caracteres++;
			}	
		}
		cantidad.add(cant_caracteres);
	}
//-------------------------------------------------Diptongos,Triptongos e hiatos-------------------------------------------------------------------
	public void Tipo(){
		int cant_diptongos=0;
		int cant_triptongo=0;
		int cant_hiatos=0;
		for(int j=0;j<palabras.size();j++){
			//-------------------------------------Triptongo--------------------------------------------------------------------

			if(palabras.get(j).contains("iai") || palabras.get(j).contains("iái")){
				cant_triptongo++;
			}else if(palabras.get(j).contains("iei") || palabras.get(j).contains("iéi")){
				cant_triptongo++;
			}else if(palabras.get(j).contains("uai") || palabras.get(j).contains("uái")){
				cant_triptongo++;
			}else if(palabras.get(j).contains("uei") || palabras.get(j).contains("uéi")){
				cant_triptongo++;
			}else if(palabras.get(j).contains("ioi") || palabras.get(j).contains("iói")){
				cant_triptongo++;
				//----------------------------------Diptongos--------------------------------------

			}else if(palabras.get(j).contains("ai") || palabras.get(j).contains("ia") ){
				cant_diptongos++;
			}else if(palabras.get(j).contains("ei") || palabras.get(j).contains("ie") ){
				cant_diptongos++;
			}else if(palabras.get(j).contains("oi") || palabras.get(j).contains("io") ){
				cant_diptongos++;
			}else if(palabras.get(j).contains("au") || palabras.get(j).contains("ua") ){
				cant_diptongos++;
			}else if(palabras.get(j).contains("eu") || palabras.get(j).contains("ue") ){
				cant_diptongos++;
			}else if(palabras.get(j).contains("ou") || palabras.get(j).contains("uo") ){
				cant_diptongos++;
			}else if(palabras.get(j).contains("iu") || palabras.get(j).contains("ui") ){
				cant_diptongos++;
			//----------------------------------------Hiatos------------------------------------------------------------------------
			}else if(palabras.get(j).contains("aí") || palabras.get(j).contains("óa") || palabras.get(j).contains("ae") || palabras.get(j).contains("íu")){
				cant_hiatos++;
			}else if(palabras.get(j).contains("aú") || palabras.get(j).contains("úa") || palabras.get(j).contains("ea") || palabras.get(j).contains("úi")){
				cant_hiatos++;
			}else if(palabras.get(j).contains("eí") || palabras.get(j).contains("íe") || palabras.get(j).contains("ao")){
				cant_hiatos++;
			}else if(palabras.get(j).contains("eú") || palabras.get(j).contains("úe") || palabras.get(j).contains("oa")){
				cant_hiatos++;
			}else if(palabras.get(j).contains("oí") || palabras.get(j).contains("ío") || palabras.get(j).contains("eo")){
				cant_hiatos++;
			}else if(palabras.get(j).contains("úo") || palabras.get(j).contains("oú") || palabras.get(j).contains("oe")){
				cant_hiatos++;
			}
			
		}
		cantidad.add(cant_diptongos);
		cantidad.add(cant_triptongo);
		cantidad.add(cant_hiatos);
	}
	
//---------------------------------------------------Monosilaba----------------------------------------------------------
	public void Monosilaba(){
		int cantidad_mono=0;
		int contador=0;
		for(int j=0;j<palabras.size();j++){
			String palabra=palabras.get(j);
			if(!esHiato(palabra)){
				contador=0;
				for(int i=0;i<palabra.length();) {
					if(Character.isLetter(palabra.charAt(i))) {
						try{
							if(  (!(esVocal(palabra.charAt(i))) && esVocal(palabra.charAt(i+1))) ||  (esVocal(palabra.charAt(i)) && !(esVocal(palabra.charAt(i+1))))   ||  !(esVocal(palabra.charAt(i)) && !(esVocal(palabra.charAt(i+1))))   ){
								contador++;							}
						}catch(StringIndexOutOfBoundsException error) {}
					}
					i+=2;
					}
			}else{
				contador=2;
			}
			if(contador>1) {
			}else {
				cantidad_mono++;
			}

		}
		cantidad.add(cantidad_mono);
		
	}
	
	public  boolean esVocal(char c){
		String vocal="aeiouAEIOU";
		if(vocal.indexOf(c)!=-1) return true;
		else return false;
	}
	
	public boolean esHiato(String palabra){
	 if(palabra.contains("aí") || palabra.contains("óa") || palabra.contains("ae") || palabra.contains("íu")){
		 return true;
	}else if(palabra.contains("aú") || palabra.contains("úa") || palabra.contains("ea") || palabra.contains("úi")){
		return true;
	}else if(palabra.contains("eí") || palabra.contains("íe") || palabra.contains("ao")){
		return true;
	}else if(palabra.contains("eú") || palabra.contains("úe") || palabra.contains("oa")){
		return true;
	}else if(palabra.contains("oí") || palabra.contains("ío") || palabra.contains("eo")){
		return true;
	}else if(palabra.contains("úo") || palabra.contains("oú") || palabra.contains("oe")){
		return true;
	}else {
		return false;
	}

	}
	
	//-----------------------------------------------Guardar Todos los Datos----------------
	private void Guardar(){
		Interface inter= new Interface();
		inter.setCantidad(cantidad);
		inter.setCant_errores(cant_errores);
		inter.setCant_letras(cant_letras);
		inter.setCorrecion(correcion);
		
		Resultados resultados= new Resultados();
		resultados.setVisible(true);
	}
	
}
