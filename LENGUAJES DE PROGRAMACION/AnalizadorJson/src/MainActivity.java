import java.awt.EventQueue;

import javax.swing.Box;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;

import java.awt.Color;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.event.CaretEvent;
import javax.swing.event.CaretListener;
import java.awt.Font;
import java.awt.Insets;
import java.awt.Toolkit;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.awt.event.ActionEvent;
import java.awt.Dimension;
import java.awt.Component;
import java.awt.Desktop;

public class MainActivity {

	private JFrame frmAnalizador;
	private JTextArea textArea;
	private ArrayList lista_lexema;
	private ArrayList<String> lista_token;
	private int estado=0;
	private int posicion=0;
	private String cadena="";
	private String direccion="";
	private String lexema="";
	private PalabrasReservadas reservadas=new PalabrasReservadas();
	private int fila=1;
	private int columna=0;
	private int num_col;
	private char caracter;
	private 	Object[] data;
	private ArrayList lista_errores;
	private int type=0;
	private String token="";
	private String[][] palabras_reservadas;
	private String[][] palabras_atributos;
	private Runtime garbage;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MainActivity window = new MainActivity();
					window.frmAnalizador.setLocationRelativeTo(null);
					window.frmAnalizador.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public MainActivity() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frmAnalizador = new JFrame();
		frmAnalizador.setUndecorated(true);
		frmAnalizador.setResizable(false);
		frmAnalizador.getContentPane().setLayout(null);

		
		 textArea = new JTextArea();
		 textArea.setFont(new Font("Segoe UI", Font.BOLD, 12));
		 textArea.setEditable(false);
		 textArea.setBorder(null);
		 textArea.setMargin(new Insets(0, 0, 0, 0));
		textArea.setBounds(0, 393, 597, 22);
		frmAnalizador.getContentPane().add(textArea);
		
		JTextArea textArea_1 = new JTextArea();
		textArea_1.setAutoscrolls(false);
		textArea_1.setWrapStyleWord(true);
		textArea_1.setLineWrap(true);
		textArea_1.setCaretColor(new Color(255, 255, 255));
		textArea_1.setMargin(new Insets(0, 0, 0, 0));
		textArea_1.setBorder(null);
		textArea_1.setFont(new Font("Consolas", Font.BOLD, 13));
		textArea_1.setBackground(new Color(33, 63, 86));
		textArea_1.setForeground(Color.WHITE);
		textArea_1.setBounds(0, 0, 528, 298);
		
		JScrollPane scrollBar = new JScrollPane(textArea_1);
		scrollBar.setBorder(null);
		scrollBar.setAlignmentY(0.0f);
		scrollBar.setAlignmentX(0.0f);
		scrollBar.setBounds(0, 0, 599, 392);
		frmAnalizador.getContentPane().add(scrollBar);
		frmAnalizador.setTitle("Analizador");
		frmAnalizador.setBounds(100, 100, 599, 436);
		frmAnalizador.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JMenuBar menuBar = new JMenuBar();
		menuBar.setAlignmentX(0.0f);
		menuBar.setBorderPainted(false);
		menuBar.setBorder(null);
		menuBar.setBackground(new Color(22, 42, 57));
		menuBar.setForeground(Color.BLACK);
		menuBar.add(Box.createRigidArea(new Dimension(23, 24)));
		frmAnalizador.setJMenuBar(menuBar);
		
		JMenu mnArchivo = new JMenu("Archivo");
		mnArchivo.setBorder(null);
		mnArchivo.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mnArchivo.setForeground(new Color(230, 230, 250));
		mnArchivo.setBackground(new Color(0, 0, 255));
		menuBar.add(mnArchivo);
		
		JMenuItem mntmNewMenuItem = new JMenuItem("Nuevo");
		mntmNewMenuItem.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mntmNewMenuItem.setBorder(null);
//---------------------------------------------------------------------------------------Metodo Nuevo--------------------------------
		mntmNewMenuItem.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				textArea_1.setText("");
				direccion="";
			}
		});
		mnArchivo.add(mntmNewMenuItem);
		
		JMenuItem mntmAbrir = new JMenuItem("Abrir");
		mntmAbrir.setBorder(null);
		mntmAbrir.setFont(new Font("Segoe UI", Font.BOLD, 12));
	//-----------------------------------------------------------------------------------Metodo Abrir Archivo------------------------------------------	
		mntmAbrir.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				JFileChooser abrir=new JFileChooser();
				BufferedReader br;
				try{
					if(abrir.showOpenDialog(null)==abrir.APPROVE_OPTION){
						direccion=abrir.getSelectedFile().getAbsolutePath();
						File fileDir = new File(direccion);
						br = new BufferedReader(new InputStreamReader(new FileInputStream(fileDir), "UTF-8"));
						textArea_1.read(br, null);
				         
					}
				}catch(Exception ex){
					ex.printStackTrace();
				}
			}
		});
		mnArchivo.add(mntmAbrir);
			
		JMenuItem mntmGuardar = new JMenuItem("Guardar");
		mntmGuardar.setFont(new Font("Segoe UI", Font.BOLD, 12));
	//-----------------------------------------------------------------Guardar----------------------------------------------------	
		mntmGuardar.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try{ 
						try(FileOutputStream fos=new FileOutputStream(direccion)){			 
				            byte codigos[]=textArea_1.getText().getBytes();			 
				            fos.write(codigos);			 
				        	}catch(IOException ee){}
 
					}catch (Exception ex){}
			}
		});
		mnArchivo.add(mntmGuardar);
	//----------------------------------------------------------------GUARDAR COMO-----------------------------------------------------	
		JMenuItem mntmGuardarComo = new JMenuItem("Guardar Como");
		mntmGuardarComo.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mntmGuardarComo.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Object opciones = JOptionPane.showInputDialog(null,"Seleccione una forma de guardar",
						   "COLORES", JOptionPane.QUESTION_MESSAGE, null,
						  new Object[] { "Seleccione","HTML", "LFP" },"Seleccione");
				if(opciones.equals("HTML")){
					estado=0;
					posicion=0;
					lexema="";
					lista_lexema.clear();
					lista_token.clear();
					lista_errores.clear();
					cadena="";
					cadena=textArea_1.getText();
					cadena=cadena.trim();
					reservadas= new PalabrasReservadas();
					fila=1;
					columna=0;
					Analizar();
					generarTablas();
					generarErrores();
					GenerarHtml generarhtml= new GenerarHtml(lista_lexema,lista_token,1);
				}else if(opciones.equals("LFP")){
					JFileChooser guardar=new JFileChooser();
					try{ 
						if(guardar.showSaveDialog(null)==guardar.APPROVE_OPTION){ 
						String	rutas = guardar.getSelectedFile().getAbsolutePath(); 
							try(FileOutputStream fos=new FileOutputStream(rutas+".lfp")){			 
					            byte codigos[]=textArea_1.getText().getBytes();			 
					            fos.write(codigos);			 
					            direccion=rutas;
					        	}catch(IOException ee){}
							} 
						}catch (Exception ex){}
				}
			}
		});
		mnArchivo.add(mntmGuardarComo);
//---------------------------------------------------------------------Click en Traducir-------------------------------------------------		
		JMenuItem mntmTraducir = new JMenuItem("Traducir");
		mntmTraducir.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mntmTraducir.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				garbage= Runtime.getRuntime();
				estado=0;
				posicion=0;
				lexema="";
				lista_lexema= new ArrayList();
				lista_token=new ArrayList();
				lista_errores=new ArrayList();
				cadena=textArea_1.getText();
				fila=1;
				columna=0;
				garbage.gc();

				Analizar();

				generarTablas();
				generarErrores();
				//Imprimir();
				GenerarHtml generarhtml= new GenerarHtml(lista_lexema,lista_token,0);
			}
			

		});
//-------------------------------------------------------------Fin click en Traducir------------------------------------------------------		
		mnArchivo.add(mntmTraducir);
		
		JMenuItem mntmSalir = new JMenuItem("Salir");
		mntmSalir.setFont(new Font("Segoe UI", Font.BOLD, 12));
//----------------------------------------------------------------SALIR---------------------------------------------------------------		
		mntmSalir.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int i =JOptionPane.showConfirmDialog(null,"¿Realmente Desea Salir del Analizador?","Confirmar Salida",JOptionPane.YES_NO_OPTION);
				if(i==0){
				System.exit(0);
				}
			}
		});
		mnArchivo.add(mntmSalir);
		
		Component rigidArea = Box.createRigidArea(new Dimension(43, 24));
		menuBar.add(rigidArea);
		
		JMenu mnAtuda = new JMenu("Ayuda");
		mnAtuda.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mnAtuda.setForeground(new Color(230, 230, 250));
		menuBar.add(mnAtuda);
		
		JMenuItem mntmManualUsuario = new JMenuItem("Manual Usuario");
		mntmManualUsuario.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				File miDir = new File (".");
				try {
					 String ruta = miDir.getCanonicalPath()+"\\Manual Usuario.pdf";
		            File objetofile = new File (ruta);
		            Desktop.getDesktop().open(objetofile);

		     }catch (IOException ex) {

		            System.out.println(ex);

		     }
				
			}
		});
		mntmManualUsuario.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mnAtuda.add(mntmManualUsuario);
		
		JMenuItem mntmManualTecnico = new JMenuItem("Manual Tecnico");
	//----------------------------------------------------------------------Abrir manual tecnico-------------------------------	
		mntmManualTecnico.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				File miDir = new File (".");
				try {
					 String ruta = miDir.getCanonicalPath()+"\\Manual Tecnico.pdf";
		            File objetofile = new File (ruta);
		            Desktop.getDesktop().open(objetofile);

		     }catch (IOException ex) {

		            System.out.println(ex);

		     }
			}
		});
		mntmManualTecnico.setFont(new Font("Segoe UI", Font.BOLD, 12));
		mnAtuda.add(mntmManualTecnico);
		
		
		
		textArea_1.addCaretListener(new CaretListener() {
            public void caretUpdate(CaretEvent e) {
                JTextArea editArea = (JTextArea)e.getSource();
                int linenum = 1;
                int columnnum = 1;
                try {
                    int caretpos = editArea.getCaretPosition();
                    linenum = editArea.getLineOfOffset(caretpos);
                    columnnum = caretpos - editArea.getLineStartOffset(linenum);
                    linenum += 1;
                }
                catch(Exception ex) { }
                updateStatus(linenum, columnnum);
            }
        });		
		
		
	
	}
	
//--------------------------------------------------Guardar Token y Lexema-----------------------------------------------
	private void Analizar(){
		for(int i=0;i<cadena.length();i++){
		 caracter=cadena.charAt(posicion);
		switch(estado){
			case 0: // Para simbolos  
				if(caracter=='{'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_llave_apertura");
					lexema="";
				}else if( caracter=='}'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_llave_clausura");
					lexema="";
				}else if(caracter==':'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_dspuntos");
					lexema="";
				}else if(caracter=='.'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_punto");
					lexema="";
				}else if(caracter==','){
					saveArray(",",fila,columna);
					lista_token.add("SG_coma");
					lexema="";
				}else if(caracter=='['){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_corchete_apertura");
					lexema="";
				}else if(caracter==']'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_corchete_clausura");
					lexema="";
				}else if(caracter=='('){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_parentesis_apertura");
					lexema="";
				}else if(caracter==')'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_parentesis_clausura");
					lexema="";
				}else if(caracter=='-'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_guion");
					lexema="";
				}else if(caracter=='_'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_guion_bajo");
					lexema="";
				}else if(caracter=='!'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_admiracion_1");
					lexema="";
				}else if(caracter=='¡'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_admiracion_0");
					lexema="";
				}else if(caracter=='¿'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_pregunta_0");
					lexema="";
				}else if(caracter=='?'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_pregunta_1");
					lexema="";
				}else if(caracter=='/'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_contradiagonal");
					lexema="";
				}else if(caracter== '\t' || caracter == ' '|| caracter ==(int)13){
					lexema="";
					estado=0;
				}else if(caracter == '\n' ){
					estado=0;
					lexema="";
					fila++;
					columna=0;	
				}else if(caracter=='\"'){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_comillas");
					lexema="";
				}else if(caracter=='\''){
					lexema=lexema+Character.toString(caracter);
					saveArray(lexema,fila,columna);
					lista_token.add("SG_comillas_simples");
					lexema="";
				}else if(Character.isLetterOrDigit(caracter)){
					estado=1;
					lexema=Character.toString(caracter);
				}else{
					error();
				}
				break;
			
			case 1: // para letras
				if(caracter=='{'){
					saveArray(lexema,fila,columna);
					lista_token.add(typeToken(lexema));
					
					saveArray(Character.toString(caracter),fila,columna);
					lista_token.add("SG_llave_apertura");
					lexema="";
					estado=0;
				}else if( caracter=='}'){
					saveArray(lexema,fila,columna);
					lista_token.add(typeToken(lexema));
					
					saveArray(Character.toString(caracter),fila,columna);
					lista_token.add("SG_llave_clausura");
					lexema="";
					estado=0;
				}else if(caracter==':'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='.'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter==','){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='['){
					saveArray(lexema,fila,columna);
					lista_token.add(typeToken(lexema));
					
					saveArray(Character.toString(caracter),fila,columna);
					lista_token.add("SG_corchete_apertura");
					lexema="";
					estado=0;
				}else if(caracter==']'){
					saveArray(lexema,fila,columna);
					lista_token.add(typeToken(lexema));
					
					saveArray(Character.toString(caracter),fila,columna);
					lista_token.add("SG_corchete_clausura");
					lexema="";
					estado=0;
				}else if(caracter=='/'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='\"'){
					saveArray(lexema,fila,columna-1);
					lista_token.add(typeToken(lexema));

					saveArray(Character.toString(caracter),fila,columna);
					lista_token.add("SG_comillas");
					lexema="";
					estado=0;
				}else if(caracter=='\''){
					saveArray(lexema,fila,columna);
					lista_token.add(typeToken(lexema));
					
					saveArray(Character.toString(caracter),fila,columna);
					lista_token.add("SG_comillas_simples");
					lexema="";
					estado=0;
				}else if(caracter=='('){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter==')'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='-'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='_'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='!'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='¡'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='¿'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter=='?'){
					lexema = lexema + Character.toString(caracter);
				}else if(caracter == '\n' ){
					fila++;
					columna=0;
				}else if( caracter== '\t' || caracter == ' ' || (int)caracter ==00 || (int)caracter==92){
					lexema = lexema + Character.toString(caracter);
				}else if(Character.isDigit(caracter)||Character.isLetter(caracter)){
					lexema = lexema + Character.toString(caracter);
				}else{
					error();
				}
				break;
				
			default:
				break;
			}
		posicion++;
		columna++;
		}
				
	}
	
//---------------------------------------------------Fin Guardar token y lexema-----------------------------------------	



private void error(){
	data=new Object[]{Character.toString(caracter),fila,columna-1,"PK_ERROR"};
	saveArray(lexema,fila,columna-1);
	lista_token.add(typeToken(lexema));
	lista_errores.add(data);
	lexema="";
}

	
    private void updateStatus(int linenumber, int columnnumber) {
    	textArea.setText("Linea: " + linenumber + " Columna: " + columnnumber);
    }
   //--------------------------------------------------------Verificar que tipo de Token es------------------------------------------------------- 
    private String typeToken(String lexema){
    	 type=0;
    	 token="";
		palabras_reservadas=reservadas.GuardarDatos();
		 palabras_atributos=reservadas.Atributo();
		for(int i=0;i<palabras_reservadas.length;i++){
			if(palabras_reservadas[i][0].equals(lexema)){
				type=1;
				token="PR_"+lexema;
			}				
		}
			for(int i=0;i<palabras_atributos.length;i++){
				if(palabras_atributos[i][0].equals(lexema)){
					token="AT_"+lexema;
					type=2;
				}				
			}
		if(type!=1 && type!=2) {
			token="TX_Cadena";
		}


		return token;
    }
    
    
    //----------------------------------------------Guardar en Arrays-------------------------------------------------------------------------------
	private void saveArray(String lexem,int line,int column){
		num_col=column-lexem.length();
		Object[] data;
		if(num_col<0){
			data=new Object[]{lexem,line,0};
		}else{
			data=new Object[]{lexem,line,num_col};
		}
		lista_lexema.add(data);
	}
	
	
//---------------------------------------------------------------GENERAR HTML DE SALIDA LEXEMAS,TOKENS-----------------------------------------------------------------------
	private void generarTablas(){
		String salida="";
		salida+="<center><b><h1>Lista de Lexemas y Tokens</h1></b></center><center><table border=\"1\" style=\"BORDER:DOUBLE 10PX Black\">"
				+ "<tr style=\"font-weight:bold\"><td>No.</td><td>Lexema</td><td>Token</td><td>Fila</td><td>Columna</td></tr>";
		for(int i=0;i<lista_lexema.size();i++){
			Object[] data=(Object[]) lista_lexema.get(i);
			salida+="<tr><td>"+i+"</td><td>"+data[0]+"</td><td>"+lista_token.get(i)+"</td><td>"+data[1]+"</td><td>"+data[2]+"</td></tr>";
		}
		salida+="</table></center>";
        File miDir = new File (".");
        try {
            String ruta = miDir.getCanonicalPath()+"\\lista_lexema.html";
        	File archivo = new File(ruta);
            BufferedWriter bw;
            if(archivo.exists()) {
                bw = new BufferedWriter(new FileWriter(archivo));
                bw.write(salida);
            } else {
                bw = new BufferedWriter(new FileWriter(archivo));
                bw.write(salida);
            }
            bw.close();
          }
        catch(Exception e) {
          e.printStackTrace();
          }
        
    
	}

	//---------------------------------------------------------------GENERAR HTML DE SALIDA ERRORES-----------------------------------------------------------------------
		private void generarErrores(){
			String salida="";
			salida+="<center><b><h1>Lista de Errores</h1></b></center><center><table border=\"1\" style=\"BORDER:DOUBLE 10PX Black\">"
					+ "<tr style=\"font-weight:bold\"><td>No.</td><td>Error</td><td>Token</td><td>Fila</td><td>Columna</td></tr>";
			for(int i=0;i<lista_errores.size();i++){
				Object[] data=(Object[]) lista_errores.get(i);
				salida+="<tr><td>"+i+"</td><td>"+data[0]+"</td><td>"+data[3]+"</td><td>"+data[1]+"</td><td>"+data[2]+"</td></tr>";
			}
			salida+="</table></center>";
			File miDir = new File (".");
	        try {
	            String ruta = miDir.getCanonicalPath()+"\\lista_errores.html";
	        	File archivo = new File(ruta);
	            BufferedWriter bw;
	            if(archivo.exists()) {
	                bw = new BufferedWriter(new FileWriter(archivo));
	                bw.write(salida);
	            } else {
	                bw = new BufferedWriter(new FileWriter(archivo));
	                bw.write(salida);
	            }
	            bw.close();
	          }
	        catch(Exception e) {
	          e.printStackTrace();
	          }
		}	
	
}