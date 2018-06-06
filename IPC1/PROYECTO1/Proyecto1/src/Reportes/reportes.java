package Reportes;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Vector;

import javax.swing.*;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.data.category.DefaultCategoryDataset;
import org.jfree.data.general.DefaultPieDataset;

import com.itextpdf.text.*;
import com.itextpdf.text.Font;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import Auxiliares.MatrizHere;
import Auxiliares.MyModel;
import Auxiliares.Ordenamiento;
import Auxiliares.VecVentas;

public class reportes extends JFrame {
	private JTabbedPane pesta�as;
	private JList lista;
	private DefaultListModel listmodel;
	private MatrizHere ventas;
	private JPanel panel1,panel2,panel3,panel4,panel5,panel6,panel7,panel8,panel9,panel11;
	private Container container;
	private  JScrollPane scrollPane,scrollLista,scrollPane2,scrollPane3,scrollPane4,scrollPane5,scrollPane6,scrollPane7;
	private MyModel tablemodel,tablemodel2,tablemodel3,tablemodel4,tablemodel5,tablemodel6,tablemodel7;
	private JTable tabla,tabla2,tabla3,tabla4,tabla5,tabla6,table7;
	private JButton generar,generar2,generar3,generar4,generargraf1,generar5,generargraf2,generar6,generar7,generar8,buscar;
	private JButton generar9,generar10,buscar2;
	private Vector productos;
	private JComboBox mes,dia;
	
	public reportes(){
		super("Reportes");
		setSize(650,450);
		dispose();
		setResizable(false);
		Pesta�as();
		Run();
	}
	
	
	//Encargado de las Pesta�as
	private void Pesta�as(){
		//Instancias
		pesta�as= new JTabbedPane();
		container= getContentPane();
		
		
		panel1= new JPanel();
		panel2= new JPanel();
		panel3= new JPanel();
		panel4= new JPanel();
		panel5= new JPanel();
		panel6= new JPanel();
		panel7= new JPanel();
		panel8= new JPanel();
		panel9= new JPanel();
		panel11= new JPanel();
		
		//Layout de los Paneles
		panel1.setLayout(null);

		
		//Agregar Componentes a pesta�as
		pesta�as.addTab("Inventario",null,panel1,"Inventario");
		pesta�as.addTab("Ventas..",null, panel2,"Ventas Realizadas");
		pesta�as.addTab("Compras..",null, panel3,"Compras Realizadas");
		pesta�as.addTab("Mas Vendido",null, panel4,"Mas Vendido Por Categoria");
		pesta�as.addTab("Venta de",null, panel5,"Venta de Productos por Categoria");
		pesta�as.addTab("Existencia",null, panel6,"Productos con poca Existencia");
		pesta�as.addTab("Menos Vendido",null,panel7,"Producto Menos Vendido");
		pesta�as.addTab("Total Mes", null,panel8,"Total de Ventas por Mes");
		pesta�as.addTab("Total Dia", null,panel9,"Total de Ventas por Dia");
		pesta�as.addTab("Servicios",null, panel11,"Servicios Prestados");
		
		//Click sobre las pesta�as
		pesta�as.addChangeListener(new ChangeListener(){
			public void stateChanged(ChangeEvent e){
				 switch(pesta�as.getSelectedIndex()){
				 
				 //Inventario
				 case 0:
					 panel1.add(scrollLista);
			     break;
			     
			     
				//Ventas Realizadas
				 case 1:
						//Vista de los Objetos
						panel2.setLayout(null);
						
						tabla.setPreferredScrollableViewportSize(tabla.getPreferredSize());
						tabla.setFillsViewportHeight(true);
						scrollPane.setViewportView(tabla);
						
					 panel2.add(scrollPane);
					 panel2.add(generar2);
					 WriteTable(0);
				 break;
				 
				 
				 //Compras
				 case 2:
					 panel3.setLayout(null);
						//Vista de los Objetos
						tabla.setPreferredScrollableViewportSize(tabla.getPreferredSize());
						tabla.setFillsViewportHeight(true);
						scrollPane.setViewportView(tabla);
						
					 panel3.add(scrollPane);
					 WriteTable(1);
					 panel3.add(generar3);
			     break;
			     
			     
			     //Mas vendido por Categoria
				 case 3:
					 panel4.setLayout(null);
					 tabla2.setPreferredScrollableViewportSize(tabla2.getPreferredSize());
					 tabla2.setFillsViewportHeight(true);
                     scrollPane2.setViewportView(tabla2);
                     panel4.add(scrollPane2);
                     panel4.add(generar4);
                     panel4.add(generargraf1);
                     WriteTable(2);
                     break;
                     
                     //Vendido Por Categoria
				 case 4:
					 panel5.setLayout(null);
					 tabla4.setPreferredScrollableViewportSize(tabla4.getPreferredSize());
					 tabla4.setFillsViewportHeight(true);
                     scrollPane4.setViewportView(tabla4);
                     panel5.add(scrollPane4);
                     panel5.add(generar6);
                     WriteTable(4);
					 break;
					 
					 //Productos por Escacez
				 case 5:
					 panel6.setLayout(null);
					 tabla5.setPreferredScrollableViewportSize(tabla5.getPreferredSize());
					 tabla5.setFillsViewportHeight(true);
                     scrollPane5.setViewportView(tabla5);
                     panel6.add(scrollPane5);
                     panel6.add(generar7);
                     WriteTable(5);
					 break;
                     
					//Menos Vendido
				 case 6:
					 panel7.setLayout(null);
					 tabla6.setPreferredScrollableViewportSize(tabla6.getPreferredSize());
					 tabla6.setFillsViewportHeight(true);
                     scrollPane6.setViewportView(tabla6);
                     panel7.add(scrollPane6);
                     panel7.add(generar8);
                     WriteTable(6);
					 break;
					 
					 
					 
				//Vendido por Mes
				 case 7:
					 panel8.setLayout(null);
					 table7.setPreferredScrollableViewportSize(table7.getPreferredSize());
					 table7.setFillsViewportHeight(true);
                     scrollPane7.setViewportView(table7);
                     LimpiarTalble6();
                     panel8.add(scrollPane7);
                     panel8.add(mes);
                     panel8.add(buscar);
                     panel8.add(generar9);
					 break;
					 
				//Vendido Por Mes y Dia
					 
				 case 8:
					 panel9.setLayout(null);
					 table7.setPreferredScrollableViewportSize(table7.getPreferredSize());
					 table7.setFillsViewportHeight(true);
                     scrollPane7.setViewportView(table7);
                     LimpiarTalble6();
                     panel9.add(scrollPane7);
                     panel9.add(generar10);
                     panel9.add(dia);
                     panel9.add(mes);
                     panel9.add(buscar2);
					 break;
					 
					 
					 //Servicios
				 case 9:
					 panel11.setLayout(null);
					 tabla3.setPreferredScrollableViewportSize(tabla3.getPreferredSize());
					 tabla3.setFillsViewportHeight(true);
                     scrollPane3.setViewportView(tabla3);
                     panel11.add(scrollPane3);
                     panel11.add(generargraf2);
                     panel11.add(generar5);
                     WriteTable(3);
					 break;
				 }
			}
		});
		
		//Agregar a container
		container.add(pesta�as);

	}
	
	
	
	
	/*
	 * Metodos para Objetos
	 */
	//Tabla para la mayoria de Opciones
	private void Run(){
		
		//Instancias
		tablemodel= new MyModel();
		tabla= new JTable(tablemodel);
		scrollPane= new JScrollPane();
		
		listmodel= new DefaultListModel();
		lista= new JList();
		scrollLista= new JScrollPane();
		
		generar= new JButton("");
		
		generar2= new JButton("");
		
		tablemodel2= new MyModel();
		tabla2=new JTable(tablemodel2);
		scrollPane2= new JScrollPane();
		
		generar3= new JButton("");
		
		generar4= new JButton("");
		generargraf1= new JButton("");
		
		generar5= new JButton("");
		generargraf2= new JButton("");
		
		
		tablemodel3= new MyModel();
		tabla3=new JTable(tablemodel3);
		scrollPane3= new JScrollPane();
		
		tablemodel4= new MyModel();
		tabla4=new JTable(tablemodel4);
		scrollPane4= new JScrollPane();
		
		tablemodel5= new MyModel();
		tabla5=new JTable(tablemodel5);
		scrollPane5= new JScrollPane();
		
		tablemodel6= new MyModel();
		tabla6=new JTable(tablemodel6);
		scrollPane6= new JScrollPane();
		
		tablemodel7= new MyModel();
		table7=new JTable(tablemodel7);
		scrollPane7= new JScrollPane();
		
		generar6= new JButton();
		
		generar7= new JButton();
		
		generar8= new JButton();
		
		buscar= new JButton();
		
		generar9= new JButton();
		
		generar10= new JButton();
		buscar2= new JButton();
		//Datos de ComboBox mes
		Object[] mothnumbers = {"Seleccione el Mes", 1,2,3,4,5,6,7,8,9,10,11,12};
		Object[] daynumbers = {"Seleccione el Dia", 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31};
		
		//Seguir con instacias
		mes= new JComboBox(mothnumbers);
		dia=new JComboBox(daynumbers);
		
		
		//Configuraciones de JComboBox
		mes.setSelectedIndex(0);
		dia.setSelectedIndex(0);
		
		//Agregar Columna
		tablemodel.addColumn("No. Factura");
		tablemodel.addColumn("Producto");
		tablemodel.addColumn("Monto");
		tablemodel.addColumn("Fecha");
		tablemodel.addColumn("Cantidad");
		
		tablemodel2.addColumn("categoria");
		tablemodel2.addColumn("producto");
		tablemodel2.addColumn("cantidad");
		
		tablemodel3.addColumn("Servicio");
		tablemodel3.addColumn("Precio");
		tablemodel3.addColumn("Cantidad");
		
		tablemodel4.addColumn("Categoria");
		tablemodel4.addColumn("Cantidad");
		
		tablemodel5.addColumn("Producto");
		tablemodel5.addColumn("Cantidad");
		
		tablemodel6.addColumn("Categoria");
		tablemodel6.addColumn("Producto");
		tablemodel6.addColumn("Cantidad");
	
		tablemodel7.addColumn("No. Factura");
		tablemodel7.addColumn("Producto");
		tablemodel7.addColumn("Monto");
		tablemodel7.addColumn("Fecha");
		tablemodel7.addColumn("Cantidad");
		
		scrollLista.setViewportView(lista);
		
		//Estilos
		generar.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));		generar.setToolTipText("Generar PDF");
		generar.setToolTipText("Generar PDF");
		
		generar2.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar2.setToolTipText("Generar PDF");
		
		generar3.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar3.setToolTipText("Generar PDF");
		
		generar4.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar4.setToolTipText("Generar PDF");
		generargraf1.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/grafica.png")));
		generargraf1.setToolTipText("Generar Grafica");
		
		generar5.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar5.setToolTipText("Generar PDF");
		generargraf2.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/grafica.png")));
		generargraf2.setToolTipText("Generar Grafica");
		
		generar6.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar6.setToolTipText("Generar PDF");
		
		generar7.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar7.setToolTipText("Generar PDF");
		
		generar8.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar8.setToolTipText("Generar PDF");
		
		buscar.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/buscar.png")));
		buscar.setToolTipText("Buscar");
		
		generar9.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar9.setToolTipText("Generar PDF");
		
		generar10.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/pdf.png")));
		generar10.setToolTipText("Generar PDF");
		buscar2.setIcon(new ImageIcon(this.getClass().getResource("/imagenes/buscar.png")));
		buscar2.setToolTipText("Buscar");
		
		//Posicion de Objetos
		scrollPane.setBounds(115,40,400,200);
		scrollLista.setBounds(115,40,400,200);
		
		generar.setBounds(280,240,70,70);
		
		generar2.setBounds(280,240,70,70);
		
		generar3.setBounds(280,240,70,70);
		
		scrollPane2.setBounds(115,40,400,200);
		
		generar4.setBounds(380,240,70,70);
		generargraf1.setBounds(200,240,70,70);
		
		generar5.setBounds(380,240,70,70);
		generargraf2.setBounds(200,240,70,70);
		
		scrollPane3.setBounds(115,40,400,200);
		
		scrollPane4.setBounds(115,40,400,200);
		
		scrollPane5.setBounds(115,40,400,200);
		
		scrollPane6.setBounds(115,40,400,200);
		
		scrollPane7.setBounds(115,50,400,200);
		
		generar6.setBounds(280,240,70,70);
		
		generar7.setBounds(280,240,70,70);
		
		generar8.setBounds(280,240,70,70);
		
		mes.setBounds(5, 20, 100, 20);
		
		dia.setBounds(150,20,100,20);
		
		buscar.setBounds(250, 5, 40, 40);
		
		generar9.setBounds(280,250,70,70);
		
		generar10.setBounds(280,250,70,70);
		buscar2.setBounds(250, 5, 40, 40);
		
		/*
		 * Onclicks sobre botones
		 */
		//Clic sobre el boton generar
		
		generar.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				try{
					Document documento= new Document(PageSize.A4,35,30,50,50);
					FileOutputStream fileoutputstream= new FileOutputStream("inventario.pdf");
					PdfWriter.getInstance(documento,fileoutputstream);
					documento.open();
					BufferedReader br = null;
					//HTML
				
					  FileWriter fr = new FileWriter(new File("inventario.html"));
					  fr.write("<html><head><title>Inventario</title></head>");
					  fr.write("<body><center><font size='30'>REPORTE DE INVENTARIO</font></center>");
					  fr.write("<br><br><center><table border='1' width='800'><tr><td width='200'><b>Categoria</td><td><b>Productos</td><td><b>Cantidad</td></tr>");

					        
					   
					
					
					
					//Font para titulos
					Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
					Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
					
					//Crear Tabla
					PdfPTable pdftable= new PdfPTable(3);
					
					//Titulo Principa�
					Paragraph paragraph= new Paragraph();
					paragraph.add(new Phrase("Inventario de Stock",Tituloprin));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.setAlignment(Element.ALIGN_CENTER);
					documento.add(paragraph);
					
					//Agregar celdas
					pdftable.addCell(new Paragraph("Categoria",fonTitulos));
					pdftable.addCell(new Paragraph("Productos",fonTitulos));
					pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
					
					//Obtener datos
					
					ventas= new MatrizHere();
					String[][] dato= ventas.getMatriz();
					
					//celdas
					for(int i=0;i<40;i++)
					{
						pdftable.addCell(dato[1][i]);
						pdftable.addCell(dato[0][i]);
						pdftable.addCell(dato[3][i]);
						fr.write("<tr><td>"+dato[1][i]+"</td><td>"+dato[0][i]+"</td><td>"+dato[3][i]+"</td></tr>");
					}
			        fr.write("</table></body></html>");
					fr.close();
					
					documento.add(pdftable);
					
					
					
					documento.close();
					File file= new File("inventario.pdf");
					Desktop.getDesktop().open(file);
				}catch(Exception a){
					
				}
			}
		});
		
		
		//Onclic sobbre generar 2
		generar2.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				try{

					Document documento= new Document(PageSize.A4,35,30,50,50);
					FileOutputStream fileoutputstream= new FileOutputStream("ventadm.pdf");
					PdfWriter.getInstance(documento,fileoutputstream);
					documento.open();

					
					
					//Font para titulos
					Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
					Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
					
					//Crear Tabla
					PdfPTable pdftable= new PdfPTable(3);
					
					//Titulo Principa�
					Paragraph paragraph= new Paragraph();
					paragraph.add(new Phrase("VENTAS REALIZADAS",Tituloprin));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.setAlignment(Element.ALIGN_CENTER);
					documento.add(paragraph);
					
					//Agregar celdas
					pdftable.addCell(new Paragraph("Fecha",fonTitulos));
					pdftable.addCell(new Paragraph("Productos",fonTitulos));
					pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
								
					//celdas
					for(int j=0;j<tabla.getRowCount();j++)
					{

						pdftable.addCell(tabla.getValueAt(j, 3).toString());
						pdftable.addCell(tabla.getValueAt(j, 1).toString());
						pdftable.addCell(tabla.getValueAt(j, 4).toString());
					}
					
					
					documento.add(pdftable);
					
					
					
					documento.close();
					File file= new File("ventadm.pdf");
					Desktop.getDesktop().open(file);
				}catch(Exception a){
					
				}
				
				
				
			}
		});
		
		
		
		//Click en Generar 3
		
		generar3.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				try{

					Document documento= new Document(PageSize.A4,35,30,50,50);
					FileOutputStream fileoutputstream= new FileOutputStream("comprasdm.pdf");
					PdfWriter.getInstance(documento,fileoutputstream);
					documento.open();
					
					//Font para titulos
					Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
					Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
					
					//Crear Tabla
					PdfPTable pdftable= new PdfPTable(3);
					
					//Titulo Principa�
					Paragraph paragraph= new Paragraph();
					paragraph.add(new Phrase("COMPRAS REALIZADAS",Tituloprin));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.setAlignment(Element.ALIGN_CENTER);
					documento.add(paragraph);
					
					//Agregar celdas
					pdftable.addCell(new Paragraph("Fecha",fonTitulos));
					pdftable.addCell(new Paragraph("Productos",fonTitulos));
					pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
								
					//celdas
					for(int j=0;j<tabla.getRowCount();j++)
					{

						pdftable.addCell(tabla.getValueAt(j, 3).toString());
						pdftable.addCell(tabla.getValueAt(j, 1).toString());
						pdftable.addCell(tabla.getValueAt(j, 4).toString());
					}
					
					
					documento.add(pdftable);
					
					
					
					documento.close();
					File file= new File("comprasdm.pdf");
					Desktop.getDesktop().open(file);
				}catch(Exception a){
					
				}
				
				
				
			}
		});
		
		
		//Click en Generar 4
		
		generar4.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				try{

					Document documento= new Document(PageSize.A4,35,30,50,50);
					FileOutputStream fileoutputstream= new FileOutputStream("ventacatego.pdf");
					PdfWriter.getInstance(documento,fileoutputstream);
					documento.open();
					
					//Font para titulos
					Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
					Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
					
					//Crear Tabla
					PdfPTable pdftable= new PdfPTable(3);
					
					//Titulo Principa�
					Paragraph paragraph= new Paragraph();
					paragraph.add(new Phrase("PRODUCTOS MAS VENDIDOS POR CATEGORIA",Tituloprin));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.setAlignment(Element.ALIGN_CENTER);
					documento.add(paragraph);
					
					//Agregar celdas
					pdftable.addCell(new Paragraph("Categoria",fonTitulos));
					pdftable.addCell(new Paragraph("Producto",fonTitulos));
					pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
								
					//celdas
					for(int j=0;j<tabla2.getRowCount();j++)
					{

						pdftable.addCell(tabla2.getValueAt(j, 0).toString());
						pdftable.addCell(tabla2.getValueAt(j, 1).toString());
						pdftable.addCell(tabla2.getValueAt(j, 2).toString());
					}
					
					
					documento.add(pdftable);
					
					
					
					documento.close();
					File file= new File("ventacatego.pdf");
					Desktop.getDesktop().open(file);
				}catch(Exception a){
					
				}
				
				
				
			}
		});
		
		//Boton para agregar Grafica 1
		generargraf1.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				JFreeChart Grafica;
				DefaultCategoryDataset Datos= new DefaultCategoryDataset();
				for(int j=0;j<tabla2.getRowCount();j++)
				{

					
					
					Datos.addValue((int)tabla2.getValueAt(j, 2), tabla2.getValueAt(j, 0).toString(), tabla2.getValueAt(j, 1).toString());
				}
				Grafica=ChartFactory.createBarChart("PRODUCTOS MAS VENDIDOS POR CATEGORIA", "Productos", "Cantidad", Datos,
						PlotOrientation.HORIZONTAL,true,true,false);
				ChartPanel Panel = new ChartPanel(Grafica);
				JFrame Ventana= new JFrame("PRODUCTOS MAS VENDIDOS POR CATEGORIA");
				Ventana.getContentPane().add(Panel);
				Ventana.pack();
				Ventana.setVisible(true);
			}
		});
		
		//Para generar Grafica 2
		generargraf2.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				JFreeChart Grafica;
				DefaultPieDataset  Datos= new DefaultPieDataset();
				for(int j=0;j<tabla3.getRowCount();j++)
				{
					String ca=tabla3.getValueAt(j, 2).toString();
					Datos.setValue(tabla3.getValueAt(j, 0).toString(),Integer.parseInt(ca) );
				}
				Grafica=ChartFactory.createPieChart("SERVICIOS VENDIDOS", Datos,true,true,false);
				ChartPanel Panel = new ChartPanel(Grafica);
				JFrame Ventana= new JFrame("SERVICIOS VENDIDOS");
				Ventana.getContentPane().add(Panel);
				Ventana.pack();
				Ventana.setVisible(true);
			}
		});
		
		
		//Generar Boton 5
		
		generar5.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				try{

					Document documento= new Document(PageSize.A4,35,30,50,50);
					FileOutputStream fileoutputstream= new FileOutputStream("servicios.pdf");
					PdfWriter.getInstance(documento,fileoutputstream);
					documento.open();
					
					//Font para titulos
					Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
					Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
					
					//Crear Tabla
					PdfPTable pdftable= new PdfPTable(3);
					
					//Titulo Principa�
					Paragraph paragraph= new Paragraph();
					paragraph.add(new Phrase("SERVICIOS VENDIDOS",Tituloprin));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.setAlignment(Element.ALIGN_CENTER);
					documento.add(paragraph);
					
					//Agregar celdas
					pdftable.addCell(new Paragraph("Servicio",fonTitulos));
					pdftable.addCell(new Paragraph("Precio",fonTitulos));
					pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
								
					//celdas
					for(int j=0;j<tabla3.getRowCount();j++)
					{

						pdftable.addCell(tabla3.getValueAt(j, 0).toString());
						pdftable.addCell(tabla3.getValueAt(j, 1).toString());
						pdftable.addCell(tabla3.getValueAt(j, 2).toString());
					}
					
					
					documento.add(pdftable);
					
					
					
					documento.close();
					File file= new File("servicios.pdf");
					Desktop.getDesktop().open(file);
				}catch(Exception a){
					
				}
				
				
				
			}
		});
		
		
		
		//Generar 6
		
		generar6.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				try{

					Document documento= new Document(PageSize.A4,35,30,50,50);
					FileOutputStream fileoutputstream= new FileOutputStream("ventaporcategoria.pdf");
					PdfWriter.getInstance(documento,fileoutputstream);
					documento.open();
					
					//Font para titulos
					Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
					Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
					
					//Crear Tabla
					PdfPTable pdftable= new PdfPTable(2);
					
					//Titulo Principa�
					Paragraph paragraph= new Paragraph();
					paragraph.add(new Phrase("VENTA DE PRODUCTOS POR CATEGORIA",Tituloprin));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.add(new Phrase(Chunk.NEWLINE));
					paragraph.setAlignment(Element.ALIGN_CENTER);
					documento.add(paragraph);
					
					//Agregar celdas
					pdftable.addCell(new Paragraph("Categoria",fonTitulos));
					pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
								
					//celdas
					for(int j=0;j<tabla4.getRowCount();j++)
					{

						pdftable.addCell(tabla4.getValueAt(j, 0).toString());
						pdftable.addCell(tabla4.getValueAt(j, 1).toString());
					}
					
					
					documento.add(pdftable);
					
					
					
					documento.close();
					File file= new File("ventaporcategoria.pdf");
					Desktop.getDesktop().open(file);
				}catch(Exception a){
					
				}
				
				
				
			}
		});
		
		
		
		//Generar 7
		
				generar7.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						try{

							Document documento= new Document(PageSize.A4,35,30,50,50);
							FileOutputStream fileoutputstream= new FileOutputStream("pocaexistencia.pdf");
							PdfWriter.getInstance(documento,fileoutputstream);
							documento.open();
							
							//Font para titulos
							Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
							Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
							
							//Crear Tabla
							PdfPTable pdftable= new PdfPTable(2);
							
							//Titulo Principa�
							Paragraph paragraph= new Paragraph();
							paragraph.add(new Phrase("PRODUCTOS DE POCA EXISTENCIA",Tituloprin));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.setAlignment(Element.ALIGN_CENTER);
							documento.add(paragraph);
							
							//Agregar celdas
							pdftable.addCell(new Paragraph("Producto",fonTitulos));
							pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
										
							//celdas
							for(int j=0;j<tabla5.getRowCount();j++)
							{

								pdftable.addCell(tabla5.getValueAt(j, 0).toString());
								pdftable.addCell(tabla5.getValueAt(j, 1).toString());
							}
							
							
							documento.add(pdftable);
							
							
							
							documento.close();
							File file= new File("pocaexistencia.pdf");
							Desktop.getDesktop().open(file);
						}catch(Exception a){
							
						}
						
						
						
					}
				});
				
				
				
				
				
				//Generar 8
				
				generar8.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						try{

							Document documento= new Document(PageSize.A4,35,30,50,50);
							FileOutputStream fileoutputstream= new FileOutputStream("menosvendido.pdf");
							PdfWriter.getInstance(documento,fileoutputstream);
							documento.open();
							
							//Font para titulos
							Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
							Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
							
							//Crear Tabla
							PdfPTable pdftable= new PdfPTable(3);
							
							//Titulo Principa�
							Paragraph paragraph= new Paragraph();
							paragraph.add(new Phrase("PRODUCTOS DE POCA VENTA",Tituloprin));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.setAlignment(Element.ALIGN_CENTER);
							documento.add(paragraph);
							
							//Agregar celdas
							pdftable.addCell(new Paragraph("Categoria",fonTitulos));
							pdftable.addCell(new Paragraph("Producto",fonTitulos));
							pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
										
							//celdas
							for(int j=0;j<tabla6.getRowCount();j++)
							{

								pdftable.addCell(tabla6.getValueAt(j, 0).toString());
								pdftable.addCell(tabla6.getValueAt(j, 1).toString());
								pdftable.addCell(tabla6.getValueAt(j, 2).toString());
							}
							
							
							documento.add(pdftable);
							
							
							
							documento.close();
							File file= new File("menosvendido.pdf");
							Desktop.getDesktop().open(file);
						}catch(Exception a){
							System.out.println(a.getMessage());
						}
						
						
						
					}
				});
		
		//Click en buscar 1 solo mes
				buscar.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						int mesnum= mes.getSelectedIndex();
						DiaMes("mes",0,mesnum);
						
					}
				});
				
				
				//Click en buscar 2 dia y mes
				buscar2.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						int mesnum= mes.getSelectedIndex();
						int dianum=dia.getSelectedIndex();
						DiaMes("diames",dianum,mesnum);
						
					}
				});
				
				
				
				//Onclic sobbre generar 9
				generar9.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						try{

							Document documento= new Document(PageSize.A4,35,30,50,50);
							FileOutputStream fileoutputstream= new FileOutputStream("ordenmes.pdf");
							PdfWriter.getInstance(documento,fileoutputstream);
							documento.open();

							
							
							//Font para titulos
							Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
							Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
							
							//Crear Tabla
							PdfPTable pdftable= new PdfPTable(3);
							
							//Titulo Principa�
							Paragraph paragraph= new Paragraph();
							paragraph.add(new Phrase("REPORTE POR MES",Tituloprin));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.setAlignment(Element.ALIGN_CENTER);
							
							//Agregar celdas
							pdftable.addCell(new Paragraph("Fecha",fonTitulos));
							pdftable.addCell(new Paragraph("Productos",fonTitulos));
							pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
							documento.add(paragraph);
										
							//celdas
							int total=0;
							for(int j=0;j<table7.getRowCount();j++)
							{

								pdftable.addCell(table7.getValueAt(j, 3).toString());
								pdftable.addCell(table7.getValueAt(j, 1).toString());
								pdftable.addCell(table7.getValueAt(j, 4).toString());
								total=total+(int)table7.getValueAt(j, 4);
							}
							JOptionPane.showMessageDialog(null, total);
							documento.add(pdftable);
							Paragraph paragraph2= new Paragraph();
							paragraph2.add(new Phrase("Total: "));
							paragraph2.add(new Phrase(String.valueOf(total)));
							documento.add(paragraph2);
							
							documento.close();
							File file= new File("ordenmes.pdf");
							Desktop.getDesktop().open(file);
						}catch(Exception a){
							
						}
						
						
						
					}
				});
				
				//Generar 10
				
				generar10.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						try{

							Document documento= new Document(PageSize.A4,35,30,50,50);
							FileOutputStream fileoutputstream= new FileOutputStream("ordenmesdia.pdf");
							PdfWriter.getInstance(documento,fileoutputstream);
							documento.open();

							
							
							//Font para titulos
							Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
							Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
							
							//Crear Tabla
							PdfPTable pdftable= new PdfPTable(3);
							
							//Titulo Principa�
							Paragraph paragraph= new Paragraph();
							paragraph.add(new Phrase("REPORTE POR MES y DIA",Tituloprin));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.add(new Phrase(Chunk.NEWLINE));
							paragraph.setAlignment(Element.ALIGN_CENTER);
							
							//Agregar celdas
							pdftable.addCell(new Paragraph("Fecha",fonTitulos));
							pdftable.addCell(new Paragraph("Productos",fonTitulos));
							pdftable.addCell(new Paragraph("Cantidad",fonTitulos));
							documento.add(paragraph);
										
							//celdas
							int total=0;
							for(int j=0;j<table7.getRowCount();j++)
							{

								pdftable.addCell(table7.getValueAt(j, 3).toString());
								pdftable.addCell(table7.getValueAt(j, 1).toString());
								pdftable.addCell(table7.getValueAt(j, 4).toString());
								total=total+(int)table7.getValueAt(j, 4);
							}
							JOptionPane.showMessageDialog(null, total);
							documento.add(pdftable);
							Paragraph paragraph2= new Paragraph();
							paragraph2.add(new Phrase("Total: "));
							paragraph2.add(new Phrase(String.valueOf(total)));
							documento.add(paragraph2);
							
							documento.close();
							File file= new File("ordenmesdia.pdf");
							Desktop.getDesktop().open(file);
						}catch(Exception a){
							
						}
						
						
						
					}
				});
		
		//Agregar objeto inicial al panel
		panel1.add(scrollLista);
		panel1.add(generar);
		WriteList();


	}
	
	
	/*
	 * Metodos Auxiliares
	 */
	
	//Rellenar Tabla
	public void WriteTable(int opcion){
		LimpiarTabla();
		ventas=new MatrizHere();
		//Inventario
		if(opcion==0)
		{
			DayMonth("ventas");
		}else if(opcion==1)//Ventas Realizadas
		{
			DayMonth("compras");
		}else if(opcion==2){
			OrdenarTipo();
		}else if(opcion==3){
			Services();
		}else if(opcion==4){
			Cantidad_Categoria();
		}else if(opcion==5){
			Stock_minimo();
		}else if(opcion==6){
			MenosVendido();
		}

	}

	//Limpiar tabla
	public void LimpiarTabla()
	{
			for(int i=0;i<tabla.getRowCount();i++){
				tablemodel.removeRow(i);
				i-=1;
			}
		

	}
	
	
	//Rellenar Lista
	public void WriteList(){
		ventas= new MatrizHere();
		String [][] stock= ventas.getMatriz();
		listmodel.clear();
		lista.setModel(listmodel);
		listmodel.addElement("<html><b><font size='3'>* "+stock[1][0]+"</font></b></html>");
		for(int i=0;i<10;i++){
			listmodel.addElement("<html><table width='300'><td width='200'>"
					+stock[0][i] +"</td><td>"+stock[3][i]+"</td>"
					+"</table></html>");
		}
		
		listmodel.addElement("<html><b>* "+stock[1][10]+"</b></html>");
		for(int i=10;i<20;i++){
			listmodel.addElement("<html><table width='300'><td width='200'>"
					+stock[0][i] +"</td><td>"+stock[3][i]+"</td>"
					+"</table></html>");
			
		}
		
		listmodel.addElement("<html><b>* "+stock[1][20]+"</b></html>");
		for(int i=20;i<30;i++){
			listmodel.addElement("<html><table width='300'><td width='200'>"
					+stock[0][i] +"</td><td>"+stock[3][i]+"</td>"
					+"</table></html>");
			
		}
		
		listmodel.addElement("<html><b>* "+stock[1][30]+"</b></html>");
		for(int i=30;i<40;i++){
			listmodel.addElement("<html><table width='300'><td width='200'>"
					+stock[0][i] +"</td><td>"+stock[3][i]+"</td>"
					+"</table></html>");
			
		}
		
		lista.setModel(listmodel);
	}
	
	//Ordenar por Dia y Mes
	public void DayMonth(String seleccion){
		ventas= new MatrizHere();
		if(seleccion=="ventas"){
			 productos= ventas.getRegistro();
		}else if(seleccion=="compras"){
			 productos= ventas.getCompras();
		}
		
		int tres,dos,uno;
		tres=0;dos=0;uno=0;
		Object[][] temporal= new Object[productos.size()][6];
		for(int i=0;i<productos.size();i++){
			Object[] registro=(Object[])productos.elementAt(i);
			temporal[i][0]=registro[0];
			temporal[i][1]=registro[1];
			temporal[i][2]=registro[2];
			temporal[i][3]=registro[3];
			temporal[i][4]=registro[4];
			temporal[i][5]=registro[5];
			if(((int)registro[4])==3){
				tres=tres+1;
			}else if(((int)registro[4])==2){
				dos=dos+1;
			}else if(((int)registro[4])==1){
				uno=uno+1;
			}
		}
		Ordenamiento orden= new Ordenamiento();
		//Ordenar Por mes
		temporal=orden.OrdenarPorMes(temporal);
		//ordenar el mes 3
		temporal=orden.OrdenarPorDia(0, tres, temporal);
		
		//ordenar el mes 2
		temporal=orden.OrdenarPorDia(tres, (dos+tres), temporal);
		//ordenar el mes 1
		temporal=orden.OrdenarPorDia((dos+tres), (dos+tres+uno), temporal);
		
		AgregarATabla(temporal);
	}
	
	//Tipo de Producto
	private void OrdenarTipo(){
		int tres,dos,uno,cuatro;
		tres=0;dos=0;uno=0;cuatro=0;
		ventas= new MatrizHere();
		 productos= ventas.getRegistro();
		Object[][] temporal= new Object[productos.size()][7];
		for(int i=0;i<productos.size();i++){
			Object[] registro=(Object[])productos.elementAt(i);
			temporal[i][0]=registro[0];
			temporal[i][1]=registro[1];
			temporal[i][2]=registro[2];
			temporal[i][3]=registro[3];
			temporal[i][4]=registro[4];
			temporal[i][5]=registro[5];
			temporal[i][6]=registro[6];
			if(((int)registro[6])==1){
				uno=uno+1;
			}else if(((int)registro[6])==2){
				dos=dos+1;
			}else if(((int)registro[6])==3){
				tres=tres+1;
			}else if(((int)registro[6])==4){
				cuatro=cuatro+1;
			}

		}
		Ordenamiento orden= new Ordenamiento();
		temporal=orden.OrdenarPorTipo(temporal);
		//Digital Music Ordenado
		temporal=orden.OrdenarPorCant(0, uno, temporal);
		//Electronics Ordenado
		temporal=orden.OrdenarPorCant(uno, (uno+dos), temporal);
		//GifCards
		temporal=orden.OrdenarPorCant((uno+dos), (uno+dos+tres), temporal);
		//PC Games
		temporal=orden.OrdenarPorCant((uno+dos+tres), (uno+dos+tres+cuatro), temporal);
		AgregarATablaCate(temporal,uno,dos,tres,cuatro);
	}
	
	
	
	//Guardar En tabla
	public void AgregarATabla(Object[][] objeto){
		LimpiarTabla();
		for(int i=0;i<objeto.length;i++){
			Object [] newRow={((int)objeto[i][3]+(int)objeto[i][4]),objeto[i][0],objeto[i][2],(objeto[i][3]+"/"+objeto[i][4]),objeto[i][1]};
			tablemodel.addRow(newRow);
		}
	}
	
	//Agregar a tabla de por Categoria
	public void AgregarATablaCate(Object[][] objeto,int uno,int dos,int tres,int cuatro){
		LimpiarTalble2();
			Object [] newRow={"Digital Music",objeto[0][0],objeto[0][1]};
			Object [] newRow2={"Electronics",objeto[uno][0],objeto[uno][1]};
			Object [] newRow3={"Gift Card",objeto[(uno+dos)][0],objeto[dos][1]};
			Object [] newRow4={"PC GAME",objeto[(uno+dos+tres)][0],objeto[tres][1]};
			tablemodel2.addRow(newRow);
			tablemodel2.addRow(newRow2);
			tablemodel2.addRow(newRow3);
			tablemodel2.addRow(newRow4);
	}
	
	//Servicios
	public void Services(){
		CleanTable();
		ventas= new MatrizHere();
		Vector servicios=ventas.getServicios();

			for(int i=0;i<servicios.size();i++){
				Object[] producto=(Object[])servicios.elementAt(i);
				tablemodel3.addRow(producto);

			}
			
	
	}
	
	//Cantidad por Categoria General
	public void Cantidad_Categoria(){
		LimpiarTalble3();
		int numero=(int)(Math.random()*300)+200;
		Object[] producto={"Digital Music",numero};
		tablemodel4.addRow(producto);
		
		int numero2=(int)(Math.random()*300)+200;
		Object[] producto2={"Electronics",numero2};
		tablemodel4.addRow(producto2);
		
		int numero3=(int)(Math.random()*300)+200;
		Object[] producto3={"Gift Card",numero3};
		tablemodel4.addRow(producto3);
		
		int numero4=(int)(Math.random()*300)+200;
		Object[] producto4={"PC GAME",numero4};
		tablemodel4.addRow(producto4);
	}
	
	//Stock casi vacio
	public void Stock_minimo(){
		LimpiarTalble4();
		ventas= new MatrizHere();
		String[][] productos= ventas.getMatriz();
		for(int i=0;i<40;i++){
			if((Integer.parseInt(productos[3][i]))<60){
				Object[] rowData={productos[0][i],productos[3][i]};
				tablemodel5.addRow(rowData);
			}
		}
	}
	
	
	//Menos Vendido
	public void MenosVendido(){
		LimpiarTalble5();
		int numero=(int)(Math.random()*10)+10;
		Object[] producto={"Digital Music","La Gran Calabaza",numero};
		tablemodel6.addRow(producto);
		
		int numero2=(int)(Math.random()*10)+10;
		Object[] producto2={"Electronics","HTC one 9",numero2};
		tablemodel6.addRow(producto2);
		
		int numero3=(int)(Math.random()*10)+10;
		Object[] producto3={"Gift Card","Mercado Libre",numero3};
		tablemodel6.addRow(producto3);
		
		int numero4=(int)(Math.random()*10)+10;
		Object[] producto4={"PC GAME","Watch Dogs",numero4};
		tablemodel6.addRow(producto4);
	}
	
	
	
	//Rellenar con dia o solo con mes
	public void DiaMes(String seleccion,int dia, int mes){
		LimpiarTalble6();
		if(seleccion=="mes"){
			ventas= new MatrizHere();
			Vector ven= ventas.getRegistro();
			for(int i=0;i<ven.size();i++){
				Object[] subven=(Object[])ven.elementAt(i);
				int month=(int)subven[4];
				if(month==mes){
					Object[] save={subven[5],subven[0],subven[2],(subven[3]+"/"+subven[4]),subven[1]};
					tablemodel7.addRow(save);
				}
			}
		}else if(seleccion=="diames"){
			ventas= new MatrizHere();
			Vector ven= ventas.getRegistro();
			for(int i=0;i<ven.size();i++){
				Object[] subven=(Object[])ven.elementAt(i);
				int month=(int)subven[4];
				int daty=(int)subven[3];
				if(month==mes && daty==dia){
					Object[] save={subven[5],subven[0],subven[2],(subven[3]+"/"+subven[4]),subven[1]};
					tablemodel7.addRow(save);
				}
			}
		}
	}
	
	
	
	
	/*
	 * Limpiadores
	 */
	
	public void CleanTable()
	{
			for(int i=0;i<tabla3.getRowCount();i++){
				tablemodel3.removeRow(i);
				i-=1;
			}
		
	}
	
	
	public void LimpiarTalble2()
	{
			for(int i=0;i<tabla2.getRowCount();i++){
				tablemodel2.removeRow(i);
				i-=1;
			}
	}
	
	public void LimpiarTalble3()
	{
			for(int i=0;i<tabla4.getRowCount();i++){
				tablemodel4.removeRow(i);
				i-=1;
			}
	}
	
	public void LimpiarTalble4()
	{
			for(int i=0;i<tabla5.getRowCount();i++){
				tablemodel5.removeRow(i);
				i-=1;
			}
	}
	
	public void LimpiarTalble5()
	{
			for(int i=0;i<tabla6.getRowCount();i++){
				tablemodel6.removeRow(i);
				i-=1;
			}
	}
	
	public void LimpiarTalble6()
	{
			for(int i=0;i<table7.getRowCount();i++){
				tablemodel7.removeRow(i);
				i-=1;
			}
	}

	
}
