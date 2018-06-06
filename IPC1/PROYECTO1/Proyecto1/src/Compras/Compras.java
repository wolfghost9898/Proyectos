package Compras;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Vector;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JSeparator;
import javax.swing.JTextField;

import Auxiliares.MatrizHere;

public class Compras extends JFrame {
	private JLabel titulo1,nombre,cantidad,precio,nueva_cantidad;
	private JSeparator separador;
	private Container cp;
	private JPanel panel;
	private JComboBox categoria,productos;
	private JTextField tnombre,tcantidad,tprecio,tnueva_cantidad;
	private JButton guardar;
	public Compras(){
		super("PRODUCTOS");
		setSize(400,400);
		dispose();
		setResizable(false);
		Editar();
	}
	
	public void Editar(){
		//Graficos
		cp= getContentPane();
		panel=new JPanel();
		panel.setLayout(null);
		
		//Instancias
		titulo1=new JLabel();
		separador= new JSeparator();
		
		categoria= new JComboBox();
		productos= new JComboBox();
		
		nombre= new JLabel();
		cantidad= new JLabel();
		precio= new JLabel();
		nueva_cantidad= new JLabel();
		tnombre= new JTextField();
		tcantidad= new JTextField();
		tprecio= new JTextField();
		tnueva_cantidad= new JTextField();
		
		guardar= new JButton();

		//Asignaciones
		titulo1.setText("Datos Del Producto");
		
		categoria.addItem("Digital Music");
		categoria.addItem("Electronics");
		categoria.addItem("Gift Card");
		categoria.addItem("PC GAME");
		
		nombre.setText("Producto : ");
		cantidad.setText("Stock :");
		precio.setText("Precio :");
		nueva_cantidad.setText("<html>Ingreso de<br>Nuevos Productos :</html>");
		
		//Colores o Especiales
		Font font= titulo1.getFont();
		titulo1.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		
		nombre.setFont(font.deriveFont(font.getStyle() | Font.BOLD));	
		cantidad.setFont(font.deriveFont(font.getStyle() | Font.BOLD));	
		precio.setFont(font.deriveFont(font.getStyle() | Font.BOLD));	
		nueva_cantidad.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		
		guardar.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/guardar2.png")));
		
		//OTROS
		tcantidad.setEnabled(false);
		tnombre.setEnabled(false);
		
		//Tamaños y Posiciones
		titulo1.setBounds(5,15,135,30);
		separador.setBounds(140,30,500,10);
		
		categoria.setBounds(5,45,150,30);
		productos.setBounds(190,45,150,30);
		
		nombre.setBounds(5,110,200,20);
		cantidad.setBounds(5,140,200,20);
		precio.setBounds(5,170,200,20);
		nueva_cantidad.setBounds(5,195,200,40);
		tnombre.setBounds(120,110, 150, 25);
		tcantidad.setBounds(120, 140, 150, 25);
		tprecio.setBounds(120, 170, 150, 25);
		tnueva_cantidad.setBounds(120, 210, 150, 25);
		
		guardar.setBounds(160, 260, 60, 60);
		
		//Clicks sobre Objetos
		categoria.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				String seleccion= (String)categoria.getSelectedItem();
				AgregarAProductos(seleccion);		//Agregar Items de lista
			}
		});;
		
		productos.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				String seleccion=(String)productos.getSelectedItem();
				BuscarProducto(seleccion);
			}
		});
		
		guardar.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				MatrizHere herencia= new MatrizHere();
				String[][] objeto= herencia.getMatriz();
				int dialogResult=JOptionPane.showConfirmDialog(null, "Desea Guardar Sus Cambios");
				if(dialogResult==JOptionPane.YES_OPTION)
				{
					for(int i=0;i<40;i++){
						if(objeto[0][i].equals(tnombre.getText())){
							objeto[2][i]=tprecio.getText();
							objeto[3][i]=String.valueOf((Integer.parseInt(tcantidad.getText()))+(Integer.parseInt(tnueva_cantidad.getText())));
							herencia.setMatriz(objeto);
							break;
						}
					}
					
				}
				
			}
		});
		
		
		//Agregar a Panel
		panel.add(titulo1);
		panel.add(separador);
		
		panel.add(categoria);
		panel.add(productos);
		
		panel.add(nombre);
		panel.add(cantidad);
		panel.add(precio);
		panel.add(nueva_cantidad);
		panel.add(tnombre);
		panel.add(tcantidad);
		panel.add(tprecio);
		panel.add(tnueva_cantidad);
		
		panel.add(guardar);
		
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
	
	
	public void BuscarProducto(String seleccion){
		 //Agregar a ComboBox
		 MatrizHere matriz= new MatrizHere();
			String mapro[][]=matriz.getMatriz();
				for(int j=0;j<mapro[0].length;j++){
					if(mapro[0][j]==seleccion){
						tnombre.setText(seleccion);
						tcantidad.setText(mapro[3][j]);
						tprecio.setText(mapro[2][j]);
						break;
					}		
				}
		    
	}
}
