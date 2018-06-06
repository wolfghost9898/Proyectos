package Ofertas;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Vector;

import javax.swing.*;

import Auxiliares.MatrizHere;

public class Ofertas extends JFrame {
	private Container cp;
	private JPanel panel;
	private JLabel titulo1,tDescuento,tCantidad,titulo3,tCantidadMi,tDescuento2;
	private JSeparator separador,separador2;
	private JComboBox categoria,productos;
	private JTextField textDescuento,textCantidad,textCantidadMi,textDescuento2;
	private JButton guardar,guardar2;
	public Ofertas()
	{
		super("Ofertas");
		setSize(650,450);
		dispose();
		setResizable(false);
		Promociones();
	}
	
	public void Promociones()
	{
		//Graficos
		cp= getContentPane();
		panel=new JPanel();
		panel.setLayout(null);
		
		//Instancias
		titulo1=new JLabel();
		separador= new JSeparator();
		
		categoria= new JComboBox();
		productos= new JComboBox();
		
		tCantidad= new JLabel();
		tDescuento= new JLabel();
		
		textCantidad= new JTextField();
		textDescuento= new JTextField();
		guardar= new JButton();
		
		titulo3= new JLabel();
		separador2=new JSeparator();
		
		tCantidadMi=new JLabel();
		tDescuento2= new JLabel();
		guardar2= new JButton();
		textCantidadMi= new JTextField();
		textDescuento2= new JTextField();
		
		//Asignaciones
		titulo1.setText("Productos");
		
		categoria.addItem("Digital Music");
		categoria.addItem("Electronics");
		categoria.addItem("Gift Card");
		categoria.addItem("PC GAME");
		
		tCantidad.setText("Cantidad: ");
		tDescuento.setText("<html>Descuento <br> (en decimales): </html>");
		
		titulo3.setText("Por Cantidad");
		
		tCantidadMi.setText("<html>Monto<br>Minimo</html>");
		tDescuento2.setText("<html>Descuento<br>(en decimales)</html>");
		
		//Colores o Especiales
		Font font= titulo1.getFont();
		titulo1.setFont(font.deriveFont(font.getStyle() | Font.BOLD));	
		
		tCantidad.setFont(font.deriveFont(font.getStyle() | Font.BOLD));	
		tDescuento.setFont(font.deriveFont(font.getStyle() | Font.BOLD));	
		guardar.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/guardar.png")));
		
		titulo3.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		
		tCantidadMi.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		tDescuento2.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		guardar2.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/guardar.png")));
		
		//Tamaños y Posiciones
		titulo1.setBounds(5,15,90,30);
		separador.setBounds(65,30,600,10);
		
		categoria.setBounds(5,45,150,30);
		productos.setBounds(5,85,150,30);
		
		tCantidad.setBounds(300,45,90,30);
		tDescuento.setBounds(300,85,300,30);
		
		textCantidad.setBounds(400, 50, 100, 25);
		textDescuento.setBounds(400, 90, 100, 25);
		guardar.setBounds(550,60,50,50);
		
		titulo3.setBounds(5,200,90,30);
		separador2.setBounds(85,220,600,10);
		
		tCantidadMi.setBounds(5,250,90,30);
		tDescuento2.setBounds(5,310,90,30);
		textCantidadMi.setBounds(110,260,100,25);
		textDescuento2.setBounds(110,320,100,25);
		guardar2.setBounds(250,270,50,50);
		
		//Clicks Sobre Objetos
		categoria.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				String seleccion= (String)categoria.getSelectedItem();
				AgregarAProductos(seleccion);		//Agregar Items de lista
			}
		});;
		
		//Click Boton Guardar
		guardar.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				MatrizHere herencia= new MatrizHere();
				Object[][] objeto= new Object[1][4];
				Vector v= herencia.getDescuentos();
				int ultimo= v.size();
				objeto[0][0]=(String)productos.getSelectedItem().toString();
				objeto[0][1]=Integer.parseInt(textCantidad.getText());
				objeto[0][2]=Float.parseFloat(textDescuento.getText());
				objeto[0][3]=0;
				v.addElement(objeto);
				herencia.setDescuentos(v);
				textCantidad.setText("");
				textDescuento.setText("");
			}
		});
		//Click en el boton Guardar 2(por cantidad)
		guardar2.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				MatrizHere herencia= new MatrizHere();
				Object[][] objeto= new Object[1][4];
				Vector v= herencia.getDescuentos();
				int ultimo= v.size();
				objeto[0][0]="Monto";
				objeto[0][1]=Integer.parseInt(textCantidadMi.getText());
				objeto[0][2]=Float.parseFloat(textDescuento2.getText());
				objeto[0][3]=1;
				v.addElement(objeto);
				herencia.setDescuentos(v);
				textCantidadMi.setText("");
				textDescuento2.setText("");
			}
		});
		
		
		//Agregar a Panel
		panel.add(titulo1);
		panel.add(separador);
		
		panel.add(categoria);
		panel.add(productos);
		
		panel.add(tCantidad);
		panel.add(tDescuento);
		
		panel.add(textCantidad);
		panel.add(textDescuento);
		panel.add(guardar);
		
		panel.add(titulo3);
		panel.add(separador2);
		
		panel.add(tCantidadMi);
		panel.add(tDescuento2);
		panel.add(textCantidadMi);
		panel.add(textDescuento2);
		panel.add(guardar2);
		
		cp.add(panel, BorderLayout.CENTER);
	}
	
	/*
	 * Metodos Extras de Ayuda
	 */
	
	public void AgregarAProductos(String seleccion){
		// Limpiar productos
		 int itemCount = productos.getItemCount();
		 for(int i=0;i<itemCount;i++)
		 {
		    productos.removeItemAt(0);
		 }
		 //Agregar a ComboBox
		 MatrizHere matriz= new MatrizHere();
			String mapro[][]=matriz.getMatriz();
				for(int j=0;j<mapro[1].length;j++){
					if(mapro[1][j]==seleccion){
						productos.addItem(mapro[0][j]);
					}		
				}
		    
	}
	
	
	
}
