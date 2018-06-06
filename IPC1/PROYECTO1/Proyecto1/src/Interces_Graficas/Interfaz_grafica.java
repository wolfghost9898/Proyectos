package Interces_Graficas;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Vector;

import javax.swing.*;
import javax.swing.UIManager.*;

import Auxiliares.Matricez;
import Auxiliares.MatrizHere;
import Auxiliares.VecCompras;
import Auxiliares.VecVentas;
import Compras.Compras;
import Ofertas.Ofertas;
import Reportes.reportes;
import servicios.Servicios;
public class Interfaz_grafica extends JFrame{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	public Interfaz_grafica(){
		super("AMAZONIC DE GUATEMALA");
		setSize(370,500);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocationRelativeTo(null);
		setResizable(false);
		estilo();
		//Guardar Matricez
		//Stock
		Matricez matriz= new Matricez();
		String[][] productos= matriz.Productos();
		MatrizHere objetomatriz= new MatrizHere();
		objetomatriz.setMatriz(productos);
		
		//Descuentos
		Vector v= new Vector();
		objetomatriz.setDescuentos(v);
		
		//Registro de Ventas
		VecVentas ventas=new VecVentas();
		Vector registro= ventas.VentasDelMes();
		objetomatriz.setRegistro(registro);
		
		//Registro de Compras
		VecCompras compras= new VecCompras();
		Vector comregistro=compras.ComprasDelMes();
		objetomatriz.setCompras(comregistro);
		
		//Registro de Servicios
		Vector servicios= new Vector(0,5);
		objetomatriz.setServicios(servicios);
		
		PanelBotones();
	}
	/*
	 * Panel con Informacion Inicial
	 */
	public void PanelBotones(){
		
		Container cp= getContentPane();
		 //Boton Ventas
		JButton ventas=new JButton();
		ventas.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/ventas.png")));
		ventas.setBounds(30,150,125,75);
		ventas.setToolTipText("Vender Productos");
		
		//Boton Compras
		JButton compras= new JButton();
		compras.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/compras.png")));
		compras.setBounds(200,150,125,75);
		compras.setToolTipText("Editar o Comprar Productos");
		//Boton Servicios
		
		JButton servicios= new JButton();
		servicios.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/servicios.png")));
		servicios.setBounds(30,250,125,80);
		servicios.setToolTipText("Vender Servicios");
		
		//Boton Promociones
		JButton Promociones= new JButton();
		Promociones.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/Promociones.png")));
		Promociones.setBounds(200,250,125,80);
		Promociones.setToolTipText("Editar Promociones");
		
		//Boton Reportes
		JButton Reportes= new JButton();
		Reportes.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/reportes.png")));
		Reportes.setBounds(120,350,125,80);
		Reportes.setToolTipText("Generar Reportes");
		/*
		 * Listeners de Los Botones
		 */
		//Ventas
		ventas.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				Ventas ventas= new Ventas();
				ventas.setLocationRelativeTo(null);
				ventas.setVisible(true);
			}
			
		});
		//Compras
		compras.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				Compras compras= new Compras();
				compras.setVisible(true);
				compras.setLocationRelativeTo(null);
			}
		});
		
		//Servicios
		servicios.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				Servicios services= new Servicios();
				services.setVisible(true);
				services.setLocationRelativeTo(null);
			}
		});
		
		//Promociones
		Promociones.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				Ofertas ofertas= new Ofertas();
				ofertas.setLocationRelativeTo(null);
				ofertas.setVisible(true);
			}
		});
		
		//Reportes
		Reportes.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				reportes reportes= new reportes();
				reportes.setLocationRelativeTo(null);
				reportes.setVisible(true);
			}
		});
		//Fin Listeners
		
		//Panel
		JPanel botones= new JPanel();
		botones.setLayout(null);
		//Agregar Botones
		botones.add(ventas);
		botones.add(compras);
		botones.add(servicios);
		botones.add(Promociones);
		botones.add(Reportes);
		//Agregar panel al contenedor
		cp.add(botones, BorderLayout.CENTER);
	}
	
	
	/*
	 * Estilos para la aplicacion
	 */
	
	
	//Look And Feel
	public void estilo(){
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
