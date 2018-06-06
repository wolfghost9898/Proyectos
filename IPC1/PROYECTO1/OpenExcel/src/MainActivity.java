import java.awt.Color;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.io.IOException;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.SwingConstants;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;
import javax.swing.UIManager.LookAndFeelInfo;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import AuxiliarTabla.MyTable;


public class MainActivity  {
	static JFrame frame;
	static JPanel body,cabecera;
	static JButton negrita,cursiva,subrayado,copiar,pegar,pegadoes;
	static JButton guardar,abrir,pie,barras;
	static JComboBox typeText,operaciones,aritmeticas;
	static MyTable tabla;
	static String ruta;
	static boolean estado;
	
	
	
	public static void main(String[] args) {
		frame= new JFrame();
		frame.setTitle("OpenExcel");
		frame.setExtendedState(frame.MAXIMIZED_BOTH);
		frame.setLocationRelativeTo(null);
		frame.setLayout(null);
		frame.pack();

		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
		frame.getContentPane().setBackground(new Color(Integer.parseInt("009688",16)));
		
		
		Cabesera();
		Cuerpo();
		estilo();
		
		frame.add(body);	
		frame.add(cabecera);
		frame.setVisible(true);
		
		
		 frame.addKeyListener(new KeyAdapter() {

	            @Override
	            public void keyTyped(KeyEvent e) {
	            }

	            @Override
	            public void keyPressed(KeyEvent e) {
	                if(e.getKeyCode() == KeyEvent.VK_CONTROL){
	                	estado=true; 
	                }else{
	                	if(estado && e.getKeyCode() == KeyEvent.VK_Z){
	                    	System.out.println("anterior");
	                		estado=false; 
	                    }
	                	
	                	if(estado && e.getKeyCode() == KeyEvent.VK_X){
	                    	System.out.println("Siguiente");
	                		estado=false; 
	                    }
	                }

	            }

	            @Override
	            public void keyReleased(KeyEvent e) {
	            }

	        });
		
	}
	
	public static void Cabesera(){
		cabecera=new JPanel();
		cabecera.setLayout(null);
		cabecera.setLocation(0,0);
		cabecera.setSize(1360,100);
		cabecera.setBackground(new Color(Integer.parseInt("009688",16)));
		//Diseño de las tabs
		UIManager.put("TabbedPane.tabsOverlapBorder", true);
		UIManager.put("TabbedPane.selected", new Color(Integer.parseInt("00BFA5",16)));
		UIManager.put("TabbedPane.light", new Color(Integer.parseInt("009688",16)));
		UIManager.put("TabbedPane.darkShadow", new Color(Integer.parseInt("009688",16)));
		UIManager.put("TabbedPane.selectHighlight", new Color(Integer.parseInt("00BFA5",16)));
		UIManager.put("TabbedPane.borderHightlightColor",  new Color(Integer.parseInt("00BFA5",16)));
		UIManager.put("TabbedPane.focus",  new Color(Integer.parseInt("00BFA5",16)));
		UIManager.getDefaults().put("TabbedPane.contentBorderInsets", new Insets(0,0,0,0));
		UIManager.getDefaults().put("TabbedPane.tabsOverlapBorder", true);
		//Fin diseño de las tabs
		JTabbedPane pestañas=new JTabbedPane();	
		pestañas.setBackground(new Color(Integer.parseInt("009688",16)));
		pestañas.setForeground(Color.WHITE);
		
		//Pestaña de Inicio
		JPanel Inicio=new JPanel();
		Inicio.setLayout(null);
		Inicio.setBackground(new Color(Integer.parseInt("009688",16)));
		negrita=new JButton("Negrita");
		negrita.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/negrita.png")));
		negrita.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		negrita.setBounds(340,25,120,20);
		
		cursiva=new JButton("Cursiva");
		cursiva.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/cursiva.png")));
		cursiva.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		cursiva.setBounds(480,25,120,20);
		
		subrayado=new JButton("Subrayado");
		subrayado.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/subrayado.png")));
		subrayado.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		subrayado.setBounds(620,25,120,20);
		
		copiar=new JButton("Copíar");
		copiar.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/copiar.png")));
		copiar.setHorizontalTextPosition( SwingConstants.CENTER );
		copiar.setVerticalTextPosition( SwingConstants.BOTTOM );
		copiar.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		copiar.setBounds(5,5,80,60);
		
		pegar=new JButton("Pegar");
		pegar.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/pegar.png")));
		pegar.setHorizontalTextPosition( SwingConstants.CENTER );
		pegar.setVerticalTextPosition( SwingConstants.BOTTOM );
		pegar.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		pegar.setBounds(90,5,80,60);
		
		pegadoes=new JButton("<html><font size='1'><p>Pegado</p><p>especial</p></font></html>");
		pegadoes.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/pegadoes.png")));
		pegadoes.setHorizontalTextPosition( SwingConstants.CENTER );
		pegadoes.setVerticalTextPosition( SwingConstants.BOTTOM );
		pegadoes.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		pegadoes.setBounds(175,5,80,60);
		
		String[] textStrings = { "Tipo de Texto","Numero", "Porcentaje", "Texto"};
		typeText= new JComboBox(textStrings);
		typeText.setSelectedIndex(0);
		typeText.setBounds(800, 25, 150, 20);
		
		String[] textOperaciones = { "Operaciones","Sumar Todo", "Promedio", "Contar","Valor maximo","Valor minimo"};
		operaciones= new JComboBox(textOperaciones);
		operaciones.setSelectedIndex(0);
		operaciones.setBounds(1000, 25, 150, 20);
		
		String[] textAritmeticas = { "Operaciones Aritmeticas","Sumar", "Restar", "Multiplicar","Dividir"};
		aritmeticas= new JComboBox(textAritmeticas);
		aritmeticas.setSelectedIndex(0);
		aritmeticas.setBounds(1200, 25, 150, 20);
		
		/*Onclics sobre los botones
		 * 
		 */
		
		//---------------------------------Negrita---------------------------------------
		negrita.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				tabla.Negrita();
			}
			
		});
		//------------------------------------Fin Negrita------------------------------
		
		//---------------------------------Subrayado---------------------------------------
		subrayado.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				tabla.Subrayado();
			}
			
		});
		//------------------------------------Fin Subrayado------------------------------
		//---------------------------------Cursiva---------------------------------------
		cursiva.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				tabla.Cursiva();
			}
			
		});
		//------------------------------------Fin Cursiva------------------------------
		
		//--------------------------------Operaciones Aritmeticas-------------------
		aritmeticas.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				String seleccion= (String)aritmeticas.getSelectedItem();
				if(seleccion=="Sumar"){
					tabla.sumarsetSelected();
				}else if(seleccion=="Restar"){
					tabla.restarGetSelected();
				}else if(seleccion=="Multiplicar"){
					tabla.multiplicarsetSelected();
				}else if(seleccion=="Dividir"){
					tabla.dividirsetSelected();
				}
			}
		});;
		//----------------------------------Fin Operaciones Aritmeticas---------------
		
		
		//--------------------------------Tipos de Texto-------------------
		typeText.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				String seleccion= (String)typeText.getSelectedItem();
				if(seleccion=="Numero"){
					tabla.Numero();
				}else if(seleccion=="Restar"){
					tabla.restarGetSelected();
				}else if(seleccion=="Porcentaje"){
					tabla.Porcentaje();
				}else if(seleccion=="Dividir"){
					tabla.dividirsetSelected();
				}
			}
		});;
		//----------------------------------Fin Tipos de Texto--------------
		
		
		//--------------------------------Operaciones--------------------------------------
		operaciones.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				String seleccion= (String)operaciones.getSelectedItem();
				 tabla.clickTable(seleccion);
			}
		});;
		
		//-------------------------------Fin Operaciones-----------------------------------
		
		//-------------------------------Copiar-------------------------------------------
		copiar.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				tabla.Copiar();
			}
		});;
		//-----------------------------Fin Copiar-----------------------------------------
		
		//-------------------------------Pegar Especial-------------------------------------------
		pegadoes.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				tabla.pegarEspecial();
			}
		});;
		//-----------------------------Fin Pegar Especial-----------------------------------------
		
		//-------------------------------Pegar -------------------------------------------
		pegar.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				 tabla.pegar();
			}
		});;
		//-----------------------------Fin Pegar -----------------------------------------
		
		
		/*
		 * Fin de Onclicks
		 * */
		
		
        Inicio.add(negrita);  
        Inicio.add(cursiva);
        Inicio.add(subrayado);
        Inicio.add(copiar);
        Inicio.add(pegar);
        Inicio.add(pegadoes);
        Inicio.add(typeText);
        Inicio.add(operaciones);
        Inicio.add(aritmeticas);
     //Fin Pestaña de Inicio
		
        //----------------------------------------------------PESTAÑA ARCHIVO----------------------------------------------
        
        JPanel panel2=new JPanel();
        panel2.setBackground(new Color(Integer.parseInt("009688",16)));
        
        guardar=new JButton("Guardar");
        guardar.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/guardar.png")));
        guardar.setHorizontalTextPosition( SwingConstants.CENTER );
        guardar.setVerticalTextPosition( SwingConstants.BOTTOM );
        guardar.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
        guardar.setBounds(5,5,80,60);
		
		abrir=new JButton("Abrir");
		abrir.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/abrir.png")));
		abrir.setHorizontalTextPosition( SwingConstants.CENTER );
		abrir.setVerticalTextPosition( SwingConstants.BOTTOM );
		abrir.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		abrir.setBounds(90,5,80,60);
		
		
		/*
		 * Inicio Onclis segunda pestaña
		 */
		
		//-------------------------------Guardar Archivo-------------------------------------------
		guardar.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
			JFileChooser guardar= new JFileChooser();	
			try{
				if(guardar.showSaveDialog(null)==guardar.APPROVE_OPTION){
					ruta=guardar.getSelectedFile().getAbsolutePath();
				}
			}catch(Exception ex){};
			try {
				tabla.Guardar(ruta);
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			}
		});;
				//-----------------------------Fin Guardar Archivo-----------------------------------------
		abrir.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
			JFileChooser guardar= new JFileChooser();	
			try{
				if(guardar.showOpenDialog(null)==guardar.APPROVE_OPTION){
					ruta=guardar.getSelectedFile().getAbsolutePath();
				}
			}catch(Exception ex){};
			try {
				tabla.abrir(ruta);
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			}
		});;
		
		
		
		
		/*
		 * Fin Oncliks segunda pestaña
		 */
        panel2.add(guardar);
        panel2.add(abrir);
        
        
        
        //----------------------------------------------------FIN PESTAÑA ARCHIVO------------------------------------------
        
 //----------------------------------------------------PESTAÑA Graficas----------------------------------------------
        
        JPanel grafic=new JPanel();
        grafic.setBackground(new Color(Integer.parseInt("009688",16)));
        grafic.setLayout(null);
        
        pie=new JButton("Pie");
        pie.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/pie.png")));
        pie.setHorizontalTextPosition( SwingConstants.CENTER );
        pie.setVerticalTextPosition( SwingConstants.BOTTOM );
        pie.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
        pie.setBounds(350,5,80,60);
		
		barras=new JButton("Barras");
		barras.setIcon(new ImageIcon(frame.getClass().getResource("/imagenes/barras.png")));
		barras.setHorizontalTextPosition( SwingConstants.CENTER );
		barras.setVerticalTextPosition( SwingConstants.BOTTOM );
		barras.setBackground(new Color(Integer.parseInt("E0E0E0",16)));
		barras.setBounds(750,5,80,60);
		
		grafic.add(barras);
		grafic.add(pie);
		/*
		 *------------------------------------------- ONCLIKS------------------------------------------------------------------------
		 */
		//--------------------------------------------PIE---------------------------------------------------------------------------
		pie.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				String titulo = JOptionPane.showInputDialog ( "Introduzca el nombre de la grafica" );
				JFileChooser guardar=new JFileChooser();
				ruta="";
				try{
					if(guardar.showSaveDialog(null)==guardar.APPROVE_OPTION){
						ruta=guardar.getSelectedFile().getAbsolutePath();
					}
				}catch(Exception ex){
					ex.printStackTrace();
				}
				tabla.pie(titulo,ruta);
			}
		});;
		//----------------------------------------------FIN PIE-------------------------------------------------------------------------
		
		//--------------------------------------------BARRAS---------------------------------------------------------------------------
				barras.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						String titulo = JOptionPane.showInputDialog ( "Introduzca el nombre de la grafica" );
						JFileChooser guardar=new JFileChooser();
						ruta="";
						try{
							if(guardar.showSaveDialog(null)==guardar.APPROVE_OPTION){
								ruta=guardar.getSelectedFile().getAbsolutePath();
							}
						}catch(Exception ex){
							ex.printStackTrace();
						}
						tabla.barras(titulo,ruta);
					}
				});;
				//----------------------------------------------FIN BARRAS-------------------------------------------------------------------------
		
		
		/*
		 * -------------------------------------------FIN ONCLIKCS-------------------------------------------------------------------
		 */
		
		
		
		//--------------------------------------------------------Fin PESTAÑAS GRAFICAS----------------------------------------------
        
        
        
        
        pestañas.addTab("Inicio", Inicio);
        pestañas.addTab("Archivo", panel2);
        pestañas.addTab("Graficas", grafic);
        
        pestañas.addChangeListener(new ChangeListener() {
            public void stateChanged(ChangeEvent e) {
                
            }
        });
        
        
        pestañas.setBounds(0, 0, 1360, 100);
        
        cabecera.add(pestañas);
        
        //---------------------------------------------KEY LISTENERS--------
       
        
       
        
	}
	
	
	
	public static void Cuerpo(){
		body=new JPanel();
		body.setLayout(null);
		body.setLocation(0,100);
		body.setSize(1360,600);
		tabla= new MyTable(body);
		
	}
	
	//-------------------------------------------------ESTILO
	public static void estilo(){
		try {
		    for (LookAndFeelInfo info : UIManager.getInstalledLookAndFeels()) {
		        if ("Nimbus".equals(info.getName())) {
		            UIManager.setLookAndFeel(info.getClassName());
		            break;
		        }
		    }
		} catch (UnsupportedLookAndFeelException e) {
		    // handle exception
		} catch (ClassNotFoundException e) {
		    // handle exception
		} catch (InstantiationException e) {
		    // handle exception
		} catch (IllegalAccessException e) {
		    // handle exception
		}
	}



}
