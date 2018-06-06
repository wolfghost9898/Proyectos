package Interces_Graficas;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.font.TextAttribute;
import java.util.Calendar;
import java.util.Map;
import java.util.Vector;

import javax.swing.*;
import javax.swing.UIManager.*;
import javax.swing.table.DefaultTableModel;

import Auxiliares.MatrizHere;
import Auxiliares.MyModel;
import Auxiliares.VecVentas;
public class Ventas extends JFrame {
	private JList productos;
	private int row,cantidad,contador,contador2;
	private float precio,descuento,totalmulti,totalpa,totalapagar,subtotal;
	private DefaultListModel modelo;
	private JScrollPane scrolllista,scrollPane;
	private MyModel tablemodel;
	private JTable ventable;
	private JTextField ingmoney;
	private JLabel title,pro_name,pro_precio,payment,money,totaldi,cambio;
	private Object[] newRow;
	private ButtonGroup tipopago;
	private JRadioButton credito,debito,cheque,efectivo;
	private boolean retornar;
	private JButton saldo,codigo;
	public Ventas(){
		super("Ventas");
		setSize(800,600);
		dispose();
		setResizable(false);
		VentasShow();
	}
	
	
	/*
	 * Interfaz Grafica de Ventas
	 */
	public void VentasShow(){
		//Herencia
		MatrizHere matriz= new MatrizHere();
		String objeto[][]=matriz.getMatriz();
		
		//Instancia Objetos
		Container cp= getContentPane();
		JPanel inter= new JPanel();
		inter.setLayout(null);
		JComboBox lista= new JComboBox();
		tablemodel= new MyModel();
		ventable= new JTable(tablemodel);
		title= new JLabel();
		pro_name= new JLabel();
		pro_precio= new JLabel();
		codigo= new JButton("Codigo Desc.");
		payment= new JLabel();
		money= new JLabel();
		tipopago= new ButtonGroup();
		credito= new JRadioButton("Credito");
		debito= new JRadioButton("Debito");
		cheque=new JRadioButton("Cheque");
		efectivo= new JRadioButton("Efectivo");
		ingmoney= new JTextField();
		totaldi=new JLabel();
		cambio=new JLabel();
		
		saldo= new JButton("Pagar");
		

		//Lista
		productos= new JList();
		productos.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		
		//Modelo
		modelo= new DefaultListModel();
		
		//Scroll
		scrolllista= new JScrollPane();
		
		//TABLA DE PRODUCTOS
		/*
		 * Agregar Columnas a la tabla
		 */
		tablemodel.addColumn("Cantidad");
		tablemodel.addColumn("Producto");
		tablemodel.addColumn("Precio");
		tablemodel.addColumn("Descuento");
		tablemodel.addColumn("Total");
		tablemodel.addColumn("Accion");
		
		//Tamaño de la Tabla
		scrollPane = new JScrollPane();
		ventable.setPreferredScrollableViewportSize(ventable.getPreferredSize());
		ventable.setFillsViewportHeight(true);
		//
		
		//Posicion de Objetos
		title.setBounds(80,50,220,21);
		pro_name.setBounds(5,70,300,21);
		pro_precio.setBounds(5,90,300,21);
		lista.setBounds(240,10,540,20);
		scrolllista.setBounds(240,40,540,200);
		scrollPane.setBounds(240,250,540,200);
		codigo.setBounds(50, 10, 110, 25);
		payment.setBounds(80,170,220,21);
		credito.setBounds(5,190,100,20);
		debito.setBounds(105,190,100,20);
		cheque.setBounds(5,210,100,20);
		efectivo.setBounds(105,210,100,20);
		money.setBounds(15,290,100,20);
		ingmoney.setBounds(5, 310, 200, 30);
		totaldi.setBounds(270,450,400,50);
		cambio.setBounds(270,500,400,50);
		scrollPane.setViewportView(ventable);
		scrolllista.setViewportView(productos);
		saldo.setBounds(5,500,200,50);
		
		//Otras Acciones
		title.setText("PRODUCTO");
		payment.setText("TIPO DE PAGO:");
		money.setText("Cantidad(Dinero)");
		totaldi.setText("TOTAL: ");
		cambio.setText("CAMBIO: ");
		tipopago.add(credito);
		tipopago.add(debito);
		tipopago.add(cheque);
		tipopago.add(efectivo);
		Font font= title.getFont();
		title.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		payment.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		money.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		totaldi.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		totaldi.setFont(new Font("Tahoma",0,36));
		cambio.setFont(font.deriveFont(font.getStyle() | Font.BOLD));
		cambio.setFont(new Font("Tahoma",0,36));
		
		
		//Agregar
		lista.addItem("Digital Music");
		lista.addItem("Electronics");
		lista.addItem("Gift Card");
		lista.addItem("PC GAME");
		
		//Agregar Objetos a la Vista
		inter.add(lista);
		inter.add(pro_name);
		inter.add(payment);
		inter.add(pro_precio);
		inter.add(scrolllista);
		inter.add(scrollPane);
		inter.add(title);
		inter.add(credito);
		inter.add(debito);
		inter.add(cheque);
		inter.add(efectivo);
		inter.add(money);
		inter.add(ingmoney);
		inter.add(totaldi);
		inter.add(cambio);
		inter.add(saldo);
		inter.add(codigo);
		/*
		 * Click sobre comboBox y Jlist
		 */
		lista.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				String seleccion= (String)lista.getSelectedItem();
				MostrarProductos(seleccion);		//Agregar Items de lista
			}
		});;
		
		productos.addMouseListener(new MouseAdapter(){
			public void mouseClicked(MouseEvent evt){
				JList subproducto=(JList)evt.getSource();
				if(evt.getClickCount()==1){
					int index=subproducto.locationToIndex(evt.getPoint());
					Object o= subproducto.getModel().getElementAt(index);
					MostrarRow(o.toString());
				}
				if(evt.getClickCount()==2){
					int index=subproducto.locationToIndex(evt.getPoint());
					Object o= subproducto.getModel().getElementAt(index);
					BuscarRow(o.toString());
					
				}
			}
		});
		/*
		 * Click sobre la tabla
		 */
		ventable.addMouseListener(new MouseAdapter(){
			public void mouseClicked(MouseEvent e){
				int fila=ventable.rowAtPoint(e.getPoint());
				int columna=ventable.columnAtPoint(e.getPoint());
				if(columna==5)
				{
					int dialogResult=JOptionPane.showConfirmDialog(null, "Realmente desea eliminar el producto");
					if(dialogResult==JOptionPane.YES_OPTION)
					{
						tablemodel.removeRow(fila);
					}
				}
			}
		});
		//Fin Click sobre la tabla
		
		//Click sobre saldo
		saldo.addActionListener(new ActionListener(){//Click sobre ComboBox
			@Override
			public void actionPerformed(ActionEvent e){
				Float saldo=Descuentos();
				if(saldo!=0)
				{
					totalapagar=saldo;
					
				}else
				{
					 subtotal = 0;
					for(int i=0;i<ventable.getRowCount();i++)
					{	
						 subtotal= subtotal+ (Float)ventable.getValueAt(i, 4);
						
					}
					totalapagar=subtotal;
				}
				//Descuento Sobre el Monto obteniendo el mayor
				MatrizHere herencia= new MatrizHere();
				Vector v= herencia.getDescuentos();
				Object[][] descuentos= new Object[1][4];
				//For buscando solo montos para saber de cuanto sera la matriz
				contador2=0;
				for(int i=0;i<v.size();i++){
					descuentos=(Object[][]) v.elementAt(i);
					if(descuentos[0][0]=="Monto"){
						contador2=contador2+1;
					}
				}
				Object[][] monto= new Object[2][contador2];
				//For agregando numeros
				int fila=0;
				for(int i=0;i<v.size();i++){
					descuentos=(Object[][]) v.elementAt(i);
					if(descuentos[0][0]=="Monto"){
						monto[0][fila]=descuentos[0][1];
						monto[1][fila]=descuentos[0][2];
						fila++;
					}
				}
				
				//For que ordene los montos
				if(contador2>0)
				{
					for(int i=0; i<contador2;i++){
						for(int j=0;j<contador2;j++){
							if(contador2!=1)
							{
								if(((int)monto[0][i])>((int)monto[0][j])){
									int aux=(int)monto[0][i];
									float auxdescu=(float)monto[1][i];
									monto[0][i]=monto[0][j];
									monto[1][i]=monto[1][j];;
									monto[0][j]=aux;
									monto[1][j]=auxdescu;
								}
							}
						}
					}
					if(((int)monto[0][contador2-1])<=totalapagar){
						for(int k=0;k<contador2;k++){
							if(((int)monto[0][k])<=totalapagar)
							{
								Float descuto=1-((Float)monto[1][k]);
								Float newto=(totalapagar*descuto);
								Float concambio=(Float.parseFloat(ingmoney.getText())) - newto;
								totaldi.setText("TOTAL: "+newto);
								cambio.setText("CAMBIO: " + concambio);
								JOptionPane.showMessageDialog(null, "Descuento de "+(1-descuto)+" por monto de compra");
								break;
							}
							
						}
						
					}else{
						Float concambio=(Float.parseFloat(ingmoney.getText())) - totalapagar;
						totaldi.setText("TOTAL: "+totalapagar);
						cambio.setText("CAMBIO: " + concambio);
					}

				}else
				{
					Float concambio=(Float.parseFloat(ingmoney.getText())) - totalapagar;
					totaldi.setText("TOTAL: "+totalapagar);
					cambio.setText("CAMBIO: " + concambio);
				}
				
				DescontardeMatriz();
				GuardarEnVector();
				LimpiarTabla();
				JOptionPane.showMessageDialog(null, "Venta Realizada con exito");
				
			}
		});;
		//Agregar panel al contenedor
		cp.add(inter, BorderLayout.CENTER);
	}
	
	
	/*
	 * Metodo para Agregar Objetos a la lista de mostrarObjetos
	 */
	public void MostrarProductos(String tipo)
	{		//Agregar Items de lista
		MatrizHere matriz= new MatrizHere();
		String mapro[][]=matriz.getMatriz();
		modelo.clear();
		productos.setModel(modelo);
			for(int j=0;j<40;j++){
				if(mapro[1][j]==tipo){
					modelo.addElement(mapro[0][j]);
					productos.setModel(modelo);
				}		
			}
	}
	
	
	//Buscar si un producto ya existe y solo sumar la cantidad
	public void BuscarRow(String producto)
	{
		if(ventable.getRowCount()>0)
		{
			for(int i=0;i<ventable.getRowCount();i++)
			{	
				String encotrado= (String)ventable.getValueAt(i, 1);
				if(producto.equals(encotrado))
				{
					contador=contador+1;
					row=i;
					cantidad=(int)ventable.getValueAt(i, 0);
					break;
				}else
				{
					contador=0;
				}
			}
			boolean verificar=BuscarMatriz(cantidad+1,producto);
			if(verificar==true){
				JOptionPane.showMessageDialog(null,"Se ha llegado al Stock minimo");
				}
				if(contador>0)
				{
					totalmulti=	(Float)ventable.getValueAt(row, 2) * (cantidad+1);
					tablemodel.setValueAt(cantidad+1, row, 0);
					tablemodel.setValueAt(totalmulti, row, 4);
				}else
				{
					MatrizHere matriz= new MatrizHere();
					String mapro[][]=matriz.getMatriz();
					for(int i=0;i<mapro[0].length;i++)
					{
						if(mapro[0][i].equals(producto))
						{
							precio=Float.parseFloat(mapro[2][i]);
							descuento=Float.parseFloat(mapro[4][i]);
							break;
						}
					}
					Object [] newRow={1,producto,precio,descuento,precio,"x"};
					AgregarRow(newRow);
				}
				
		}else
		{
			boolean verificar=BuscarMatriz(1,producto);
			if(verificar==true)
			{
				JOptionPane.showMessageDialog(null,"Se ha llegado al Stock minimo");
					
				}
				MatrizHere matriz= new MatrizHere();
				String mapro[][]=matriz.getMatriz();
				for(int i=0;i<mapro[0].length;i++)
				{
					if(mapro[0][i].equals(producto))
					{
						precio=Float.parseFloat(mapro[2][i]);
						descuento=Float.parseFloat(mapro[4][i]);
						break;
					}
				}
				Object [] newRow={1,producto,precio,descuento,precio,"x"};
				AgregarRow(newRow);

		}
			
	}
	
	
	//Buscar producto en Matriz
	public boolean BuscarMatriz(int cantidad,String Producto)
	{
		MatrizHere matriz= new MatrizHere();
		String mapro[][]=matriz.getMatriz();
		retornar=false;
		for(int i=0;i<mapro[0].length;i++)
		{
			if(mapro[0][i].equals(Producto))
			{
				if((Integer.parseInt(mapro[3][i])-cantidad)<60)
				{
					retornar=true;
				
				}
				break;
			}
				
		}
		return retornar;
	}
	
	
	//Agregar Producto
	public void AgregarRow(Object[] row)
	{
		tablemodel.addRow(row);
	}
	
	//Mostrar Producto a la izquierda
	public void MostrarRow(String producto)
	{
		MatrizHere matriz= new MatrizHere();
		String mapro[][]=matriz.getMatriz();
		for(int i=0;i<mapro[0].length;i++){
			if(mapro[0][i]==producto){
				pro_name.setText("Producto: "+producto);
				pro_precio.setText("Precio: "+mapro[2][i]);
				break;
			}
		}
	}
	
	
	/*
	 * Aplicar Descuentos
	 */
	public Float Descuentos(){
		MatrizHere herencia= new MatrizHere();
		Vector v= herencia.getDescuentos();
		Object[][] descuentos= new Object[1][4];
		for(int i=0;i<v.size();i++)
		{//Recorre vector
			 totalpa=0;
			for(int k=0;k<ventable.getRowCount();k++){
				descuentos=(Object[][]) v.elementAt(i);
				String pronom=(String)ventable.getValueAt(k,1);
				if(pronom==descuentos[0][0])
				{
					int obcanti=(int) ventable.getValueAt(k,0);
					int cantdescu=(int)descuentos[0][1];
					if(obcanti>=cantdescu){
						Float descu=(Float)descuentos[0][2];
						Float oldpreci=(Float)ventable.getValueAt(k,2);
						Float newpreci=(float) (oldpreci *(1-descu ));
						Float total= obcanti*newpreci;
						tablemodel.setValueAt(descuentos[0][2], k, 3);
						tablemodel.setValueAt(total, k, 4);
					}
					
				}
				 totalpa=totalpa+ ((Float)ventable.getValueAt(k,4));
			}
			
		}
		return totalpa;
	}
	
	//Quita los productos Guardados
	public void DescontardeMatriz()
	{
		MatrizHere herencia= new MatrizHere();
		String[][] ma= herencia.getMatriz();
		for(int i=0;i<ventable.getRowCount();i++){
			 String o=ventable.getValueAt(i, 0).toString();
			int restar=Integer.parseInt(o) ;
			String pro=(String)ventable.getValueAt(i, 1);
			for(int j=0;j<40;j++){
				if(ma[0][j].equals(pro)){
					int can= Integer.parseInt(ma[3][j]);
					ma[3][j]=String.valueOf(can-restar);
					herencia.setMatriz(ma);
					break;
				}
			}
		}
	}
	
	//Guarda en Vector de Productos vendidos
	public void GuardarEnVector()
	{	VecVentas clave= new VecVentas();
		MatrizHere herencia= new MatrizHere();
		Vector productos= herencia.getRegistro();
		Calendar fecha= Calendar.getInstance();
		int mes= fecha.get(Calendar.MONTH)+1;
		int dia= fecha.get(Calendar.DAY_OF_MONTH);
		for(int i=0;i<ventable.getRowCount();i++)
		{
			String name=(String)ventable.getValueAt(i, 1);
			int cant=(int)ventable.getValueAt(i, 0);
			String preci=ventable.getValueAt(i, 2).toString();
			Double preci2=Double.valueOf(preci);
			int tipo=clave.BuscarCategoria(name);
			Object[] proguardar={name,cant,preci2,dia,mes,(dia+mes),tipo};
			productos.add(proguardar);
		}
		herencia.setRegistro(productos);
	}
	
	
	//Limpiar Tabla
	public void LimpiarTabla()
	{
			for(int i=0;i<ventable.getRowCount();i++){
				tablemodel.removeRow(i);
				i-=1;
			}
		

	}
	
}
