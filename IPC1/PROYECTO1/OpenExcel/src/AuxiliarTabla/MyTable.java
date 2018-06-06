package AuxiliarTabla;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import javax.swing.Box;
import javax.swing.JComboBox;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.event.TableModelEvent;
import javax.swing.event.TableModelListener;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.CategoryPlot;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.data.category.DefaultCategoryDataset;
import org.jfree.data.general.DefaultPieDataset;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.FontFactory;
import com.itextpdf.text.Image;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import Helpers.LetterNumbers;
import Listas.Lista;
import Text.copyData;

public class MyTable implements KeyListener {

	Object[][] data= new Object[100][100];
	Object[][] datam= new  Object[100][100];
	String[] columnNames = new String[100];
	String[] mat;
	JTable table;
	TableModel modelo;
	Lista lista;
	 boolean estado;


	
	public MyTable(JPanel panel) {
		  lista= new Lista();
		for(int cono=0;cono<100;cono++){
	           data[cono][0]=(cono+1);  
	       }
		 for(int con1=0;con1<100;con1++){
	         for(int con2=1;con2<100;con2++){
	           data[con1][con2]=("");  
	       } }
		 
		 for(int con1=0;con1<100;con1++){
	         for(int con2=1;con2<100;con2++){
	           datam[con1][con2]=(1);  
	       } }
		 
		 char letra;
	        

	        for(int l=1;l<27;l++){
	          letra=(char)(64+l);
	          columnNames[0]="No";
	          columnNames[l]=String.valueOf(letra);
	          }
	        for(int l=27;l<53;l++){
	          letra=(char)(64+l-26);
	          columnNames[l]="A"+String.valueOf(letra);
	          }
	        for(int l=53;l<79;l++){
	          letra=(char)(64+l-52);
	          columnNames[l]="B"+String.valueOf(letra);
	          }
	         for(int l=79;l<100;l++){
	          letra=(char)(64+l-78);
	          columnNames[l]="C"+String.valueOf(letra);
	          }
	         
	          modelo= new TableModel(data,columnNames);
	          table= new JTable(modelo);
	          
	          table.setCellSelectionEnabled(true);
	         table.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
	         
	       //-------------------------------------Detecta el cambio en la tabla-------------
	          modelo.addTableModelListener(new TableModelListener(){
	        	  public void tableChanged(TableModelEvent e){
	        			
	        		  int rw=e.getFirstRow();
	        		  int cw=e.getColumn();
	        		  
	        		  copyData copy ;
	        		  copy= new copyData();
	        		  Object data[]= copy.getChange();
	        		  
	        		  if(copy.estado()){
		        		  lista.ingresarDato(copy.getChange());
		        		  lista.Mostrar();
		        		  copy.setEstado(true);
	        		  }else{
	        			  copy.setEstado(true);
	        		  }
	        		  
	        		  
	        		 
	        	  }
	          });
	         //---------------------Fin detectar Cambi-----------------------------------------
	            
	         JScrollPane scroll = new JScrollPane(table);
	         scroll.setViewportView(table);
	         scroll.setBounds(0,0,1360,600);
	         panel.add(scroll, BorderLayout.CENTER);
	         
	         table.addKeyListener(new KeyAdapter() {

		            @Override
		            public void keyTyped(KeyEvent e) {
		            }

		            @Override
		            public void keyPressed(KeyEvent e) {
		                if(e.getKeyCode() == KeyEvent.VK_CONTROL){
		                	estado=true; 
		                }else{
		                	if(estado && e.getKeyCode() == KeyEvent.VK_C){
		                    	Object[] data=lista.Ultimo();
		                    	int roww=(int)data[0];
		                    	int cow=(int)data[1];
		                    	table.setValueAt(data[2], roww, cow);
		                		estado=false; 
		                    }
		                	
		                	if(estado && e.getKeyCode() == KeyEvent.VK_X){
		                    	Object[] data=lista.Primero();
		                    	int roww=(int)data[0];
		                    	int cow=(int)data[1];
		                    	table.setValueAt(data[2], roww, cow);
		                		estado=false; 
		                    }
		                }

		            }

		            @Override
		            public void keyReleased(KeyEvent e) {
		            }

		        });
	         
	         
	         
		
	}
	//---------------------------------------------------RESTAR--------------------------------------------------------------------------
	public void restarGetSelected(){
		try{
		 int x=table.getSelectedRow();
         int y=table.getSelectedColumn();
         int v = 0,w = 0;
           int[] s = table.getSelectedRows();
           int[] ss = table.getSelectedColumns();   
           
           //Obtener Solo los numeros
           String num=(String) table.getValueAt(x,y);
           String numero="";
           for(int i=0; i <num.length() ; i++)
           { if (Character.isDigit(num.charAt(i))){
        		   numero=numero+num.charAt(i);    	   
           } 
           } 
           //-----------fin--------
           
           int val=Integer.parseInt(numero);
             for(int i=0;i< s.length ;i++){
                    for(int ii=0;ii< ss.length ;ii++){
                        if(!(i==0&&ii==0)){
                      v=x+i;
                      w=y+ii;
                      
                      //Obtener Solo los numeros
                      String num2=(String) table.getValueAt(v,w);
                      String numero2="";
                      for(int j=0; j <num2.length() ; j++)
                      { if (Character.isDigit(num2.charAt(j))){
                    	  numero2=numero2+num2.charAt(j);    	   
                      } 
                      } 
                      //-----------fin--------
                      
                       val -= Integer.parseInt(numero2);
                       }
                       
                    }
                 
             }
             
            	 if((int)ss.length>1){
                	 table.setValueAt(val, v, w+1);
                 }else{
                	 table.setValueAt(val, v+1, w);
                 }	
             }catch(Exception  e){}

	}
	//-------------------------------------------------------SUMAR---------------------------------------------------------------
	public void sumarsetSelected(){
		try{
			 int x=table.getSelectedRow();
	         int y=table.getSelectedColumn();
	         int v = 0,w = 0;
	           int[] s = table.getSelectedRows();
	           int[] ss = table.getSelectedColumns();        
	           //Obtener Solo los numeros
	           String num=(String) table.getValueAt(x,y);
	           String numero="";
	           for(int i=0; i <num.length() ; i++)
	           { if (Character.isDigit(num.charAt(i)) || num.charAt(i)=='.' ){
	        		   numero=numero+num.charAt(i);    	   
	           } 
	           } 
	           //-----------fin--------
	           
	           int val=Integer.parseInt(numero);
	             for(int i=0;i< s.length ;i++){
	                    for(int ii=0;ii< ss.length ;ii++){
	                        if(!(i==0&&ii==0)){
	                      v=x+i;
	                      w=y+ii;
	                      
	                      //Obtener Solo los numeros
	                      String num2=(String) table.getValueAt(v,w);
	                      String numero2="";
	                      for(int j=0; j <num2.length() ; j++)
	                      { if (Character.isDigit(num2.charAt(j)) || num2.charAt(j)=='.' ){
	                    	  numero2=numero2+num2.charAt(j);    	   
	                      } 
	                      } 
	                      //-----------fin--------
	                      
	                       val += Integer.parseInt(numero2);
	                       }
	                       
	                    }
	                 
	             }
	             
	            	 if((int)ss.length>1){
	                	 table.setValueAt(val, v, w+1);
	                 }else{
	                	 table.setValueAt(val, v+1, w);
	                 }	
	             }catch(Exception  e){}
		
	}
	//----------------------------------Multiplicar----------------------------------
	public void multiplicarsetSelected(){
		
		try{
			 int x=table.getSelectedRow();
	         int y=table.getSelectedColumn();
	         int v = 0,w = 0;
	           int[] s = table.getSelectedRows();
	           int[] ss = table.getSelectedColumns();        
	           //Obtener Solo los numeros
	           String num=(String) table.getValueAt(x,y);
	           String numero="";
	           for(int i=0; i <num.length() ; i++)
	           { if (Character.isDigit(num.charAt(i)) || num.charAt(i)=='.' ){
	        		   numero=numero+num.charAt(i);    	   
	           } 
	           } 
	           //-----------fin--------
	           
	           int val=Integer.parseInt(numero);
	             for(int i=0;i< s.length ;i++){
	                    for(int ii=0;ii< ss.length ;ii++){
	                        if(!(i==0&&ii==0)){
	                      v=x+i;
	                      w=y+ii;
	                      
	                      //Obtener Solo los numeros
	                      String num2=(String) table.getValueAt(v,w);
	                      String numero2="";
	                      for(int j=0; j <num2.length() ; j++)
	                      { if (Character.isDigit(num2.charAt(j)) || num2.charAt(j)=='.' ){
	                    	  numero2=numero2+num2.charAt(j);    	   
	                      } 
	                      } 
	                      //-----------fin--------
	                      
	                       val *= Integer.parseInt(numero2);
	                       }
	                       
	                    }
	                 
	             }
	             
	            	 if((int)ss.length>1){
	                	 table.setValueAt(val, v, w+1);
	                 }else{
	                	 table.setValueAt(val, v+1, w);
	                 }	
	             }catch(Exception  e){}
	}
	
	//---------------------------------------------------------DIVIDIR--------------------------------------------------
	public void dividirsetSelected(){
		try{
			 int x=table.getSelectedRow();
	         int y=table.getSelectedColumn();
	         int v = 0,w = 0;
	           int[] s = table.getSelectedRows();
	           int[] ss = table.getSelectedColumns();        
	           //Obtener Solo los numeros
	           String num=(String) table.getValueAt(x,y);
	           String numero="";
	           for(int i=0; i <num.length() ; i++)
	           { if (Character.isDigit(num.charAt(i)) || num.charAt(i)=='.' ){
	        		   numero=numero+num.charAt(i);    	   
	           } 
	           } 
	           //-----------fin--------
	           
	           double val=Double.parseDouble(numero);
	             for(int i=0;i< s.length ;i++){
	                    for(int ii=0;ii< ss.length ;ii++){
	                        if(!(i==0&&ii==0)){
	                      v=x+i;
	                      w=y+ii;
	                      
	                      //Obtener Solo los numeros
	                      String num2=(String) table.getValueAt(v,w);
	                      String numero2="";
	                      for(int j=0; j <num2.length() ; j++)
	                      { if (Character.isDigit(num2.charAt(j)) || num2.charAt(j)=='.' ){
	                    	  numero2=numero2+num2.charAt(j);    	   
	                      } 
	                      } 
	                      //-----------fin--------
	                       val /= Double.parseDouble(numero2);
	                       }
	                       
	                    }
	                 
	             }
	             
	            	 if((int)ss.length>1){
	                	 table.setValueAt(val, v, w+1);
	                 }else{
	                	 table.setValueAt(val, v+1, w);
	                 }	
	             }catch(Exception  e){}
	}
	
	//-------------------------------------------------------Negrita------------------------------------------------------
	public void Negrita(){
		try{
			 int x=table.getSelectedRow();
	         int y=table.getSelectedColumn();
	         int v = 0,w = 0;
	           int[] s = table.getSelectedRows();
	           int[] ss = table.getSelectedColumns();        
	             for(int i=0;i< s.length ;i++){
	                    for(int ii=0;ii< ss.length ;ii++){
	                        	v=x+i;
	                        	w=y+ii;
	                        	String cambio="<html><b>"+table.getValueAt(v,w)+"</b></html>";
	                        	 table.setValueAt(cambio,v,w);
	                    }
	             }
	             }catch(Exception  e){}
	}
	
	//-------------------------------------------------------Subrayado------------------------------------------------------
	public void Subrayado(){
		try{
			 int x=table.getSelectedRow();
	         int y=table.getSelectedColumn();
	         int v = 0,w = 0;
	           int[] s = table.getSelectedRows();
	           int[] ss = table.getSelectedColumns();        
	             for(int i=0;i< s.length ;i++){
	                    for(int ii=0;ii< ss.length ;ii++){
	                        	v=x+i;
	                        	w=y+ii;
	                        	String cambio="<html><u>"+table.getValueAt(v,w)+"</u></html>";
	                        	 table.setValueAt(cambio,v,w);
	                    }
	             }
	             }catch(Exception  e){}
	}
	
	//-------------------------------------------------------Cursiva------------------------------------------------------
	public void Cursiva(){
		try{
			 int x=table.getSelectedRow();
	         int y=table.getSelectedColumn();
	         int v = 0,w = 0;
	           int[] s = table.getSelectedRows();
	           int[] ss = table.getSelectedColumns();        
	             for(int i=0;i< s.length ;i++){
	                    for(int ii=0;ii< ss.length ;ii++){
	                        	v=x+i;
	                        	w=y+ii;
	                        	String cambio="<html><i>"+table.getValueAt(v,w)+"</i></html>";
	                        	 table.setValueAt(cambio,v,w);
	                    }
	             }
	             }catch(Exception  e){}
	}
	
	
	//-------------------------------------------------------Numero------------------------------------------------------
	public void Numero(){
		try{
			 int x=table.getSelectedRow();
	         int y=table.getSelectedColumn();
	         String num2=(String) table.getValueAt(x,y);
             String numero2="";
             for(int j=0; j <num2.length() ; j++)
             { if (Character.isDigit(num2.charAt(j)) || num2.charAt(j)=='.' ){
           	  numero2=numero2+num2.charAt(j);    	   
             } 
             } 
             table.setValueAt(numero2, x, y);
             //-----------fin--------
	       }catch(Exception  e){}
	}
	
	//-------------------------------------------------------Porcentaje------------------------------------------------------
	public void Porcentaje(){
		 int x=table.getSelectedRow();
         int y=table.getSelectedColumn();
		try{
	         String num2=(String) table.getValueAt(x,y);
	         num2=num2.replace("<html>","");
	         num2=num2.replace("<b>","");
	         num2=num2.replace("<u>","");
	         num2=num2.replace("<i>","");
	         num2=num2.replace("</html>","");
	         num2=num2.replace("</b>","");
	         num2=num2.replace("</u>","");
	         num2=num2.replace("</i>","");
	         double val=Double.parseDouble(num2);
             table.setValueAt((val/100), x, y);
             //-----------fin--------
	       }catch(Exception  e){
	    	   table.setValueAt("NA", x, y);
	       }
	}
	
	//-----------------------------------------------------Operaciones-----------
	public void clickTable(String tipo){
		String[] abecedarios={"Columna","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
	      String[] nume={"Fila","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26"};
		
	      JComboBox xField = new JComboBox(abecedarios);
	      JComboBox yField = new JComboBox(nume);
	      JComboBox fxField = new JComboBox(abecedarios);
	      JComboBox Fyield = new JComboBox(nume);
	      JComboBox rxField = new JComboBox(abecedarios);
	      JComboBox ryField = new JComboBox(nume);

	      JPanel myPanel = new JPanel();
	      
	      myPanel.add(new JLabel("Inicio Columna:"));
	      myPanel.add(xField);
	      myPanel.add(Box.createHorizontalStrut(15)); // a spacer
	      myPanel.add(new JLabel("Inicio Fila:"));
	      myPanel.add(yField);
	      
	      myPanel.add(new JLabel("Fin Columna:"));
	      myPanel.add(fxField);
	      myPanel.add(Box.createHorizontalStrut(15)); // a spacer
	      myPanel.add(new JLabel("Fin Fila:"));
	      myPanel.add(Fyield);
	      
	      myPanel.add(new JLabel("Resultado Columna:"));
	      myPanel.add(rxField);
	      myPanel.add(Box.createHorizontalStrut(15)); // a spacer
	      myPanel.add(new JLabel("Resultado Fila:"));
	      myPanel.add(ryField);

	      int result = JOptionPane.showConfirmDialog(null, myPanel, 
	               "Valores", JOptionPane.OK_CANCEL_OPTION);
	      if (result == JOptionPane.OK_OPTION) {
	    	  LetterNumbers conver= new LetterNumbers();
	         operar(conver.convertAB((String)xField.getSelectedItem()),Integer.parseInt((String)yField.getSelectedItem())-1,conver.convertAB((String)fxField.getSelectedItem()),Integer.parseInt((String)Fyield.getSelectedItem())-1,
	        		 conver.convertAB((String)rxField.getSelectedItem()),Integer.parseInt((String)ryField.getSelectedItem())-1,tipo);
	      }
		
	}
	
	//-----------------------------------------Operacion---------
	public void operar(int ix,int iy,int fx,int fy,int rx,int ry,String tipo){
		int total=0;
		int mayor;
		int cantidad=0;
		List<Integer> t= new ArrayList<Integer>();
		try{
			//---------------------Sumar Cnatidad de Numeros----------------------
			if(tipo.equals("Sumar Todo")){
				for(int i=iy;i<=fy;i++){
					for(int j=ix;j<=fx;j++){
						int valor=Integer.parseInt((String)table.getValueAt(i,j));
						total=total+valor;
					}
				}
				//--------------------------------------Promedio de Numeros----------------
			}else if(tipo.equals("Promedio")){
				for(int i=iy;i<=fy;i++){
					for(int j=ix;j<=fx;j++){
						int valor=Integer.parseInt((String)table.getValueAt(i,j));
						total=total+valor;
						cantidad++;
					}
				}
				total= (total/cantidad);
				//------------------------------------Contar Numeros------------------------
			}else if(tipo.equals("Contar")){
				for(int i=iy;i<=fy;i++){
					for(int j=ix;j<=fx;j++){
						try{
							double val=Double.parseDouble((String)table.getValueAt(i,j));
							cantidad++;
						}catch(Exception  e){}
						
					}
				}
				total=cantidad;
				//-----------------------------------------Valor Maximo---------------------------

			}else if(tipo.equals("Valor maximo")){
				for(int i=iy;i<=fy;i++){
					for(int j=ix;j<=fx;j++){
						try{
							double val=Double.parseDouble((String)table.getValueAt(i,j));
							t.add(Integer.parseInt((String)table.getValueAt(i,j)));
						}catch(Exception  e){}
						
					}
				}
				mayor=t.stream().mapToInt(i->i).max().getAsInt();
				total=mayor;
			//---------------------------------------------------------Valor Minimo----------------------	
			}else if(tipo.equals("Valor minimo")){
				for(int i=iy;i<=fy;i++){
					for(int j=ix;j<=fx;j++){
						try{
							double val=Double.parseDouble((String)table.getValueAt(i,j));
							t.add(Integer.parseInt((String)table.getValueAt(i,j)));
						}catch(Exception  e){}
						
					}
				}
				mayor=t.stream().mapToInt(i->i).min().getAsInt();
				total=mayor;
			}
			table.setValueAt(total, ry, rx);
		}catch(Exception  e){
			JOptionPane.showMessageDialog(null, "Verifique que ningun campo este vacio o sea un string");
		}
	
	}
	
	
	//-------------------------------------COPIAR------------------------------
	public void Copiar(){
		int ro=table.getSelectedRow();
		int co=table.getSelectedColumn();
		copyData copiar=new copyData();
		String data=(String)table.getValueAt(ro, co);
		copiar.setValue(data);
	}
	
	//-------------------------------------Pegar Especial------------------------------
	public void pegarEspecial(){
		int ro=table.getSelectedRow();
		int co=table.getSelectedColumn();
		copyData copiar=new copyData();
		String data=copiar.getValue();
		table.setValueAt(data, ro, co);
	}
	
	//-------------------------------------Pegar ------------------------------
	public void pegar(){
		int ro=table.getSelectedRow();
		int co=table.getSelectedColumn();
		copyData copiar=new copyData();
		String data=copiar.getValue();
		data=data.replace("<html>","");
		data=data.replace("<b>","");
		data=data.replace("<u>","");
		data=data.replace("<i>","");
		data=data.replace("</html>","");
		data=data.replace("</b>","");
		data=data.replace("</u>","");
		data=data.replace("</i>","");
		table.setValueAt(data, ro, co);
	}
	
	//------------------------------------------Guardar---------------------
	public void Guardar(String direccion) throws IOException{
		direccion=direccion+".csv";
		BufferedWriter out=null;
		for(int i=0;i<100;i++){
			for(int j=1;j<100;j++){
				try{
					out = new BufferedWriter(new FileWriter(direccion, true));
					if(table.getValueAt(i,j).equals("")){
					}else{
						out.write(i+","+j+","+table.getValueAt(i,j));
						out.newLine();
					}
				}catch(IOException e){}finally{
					if(out!=null){
						out.close();
					}
				}
			}
		}	
		
	}
	
	//------------------------------------------------------Abrir-----------------------------
	public void abrir(String direccion) throws IOException{
		copyData ccopy= new copyData();
		String cadena;
		FileReader f = new FileReader(direccion);
		BufferedReader b = new BufferedReader(f);
		while((cadena = b.readLine())!=null) {
			String[] arrayCadena=cadena.split(",");
			if(cadena!=null){
				ccopy.setEstado(false);
				Object[] data={Integer.parseInt(arrayCadena[0]), Integer.parseInt(arrayCadena[1]),""};
				lista.ingresarDato(data);
				lista.Mostrar();
				modelo.setValueAt(arrayCadena[2], Integer.parseInt(arrayCadena[0]), Integer.parseInt(arrayCadena[1]));
			}
        }
		ccopy.setEstado(true);

	}
	@Override
	public void keyPressed(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}
	@Override
	public void keyReleased(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}
	@Override
	public void keyTyped(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}
	
	
	//-----------------------------GRAFICA DE PIE--------------------------------------
	public void pie(String titulo,String ruta){
		String[][] datos= grafica();
		 DefaultPieDataset data = new DefaultPieDataset();
		 for(int i=0;i<datos.length;i++){
			 data.setValue(datos[i][0], Integer.parseInt(datos[i][1]));
		 }
		// Creando el gráfico
		 JFreeChart chart = ChartFactory.createPieChart(
		  titulo, // Título del gráfico
		  data, // DataSet
		  true, // Leyenda
		  true, // ToolTips
		  true);

		 // Mostrando el gráfico
		 ChartFrame frame = new ChartFrame("Grafico", chart);
		 frame.pack();
		 frame.setVisible(true);
		 
		 try {
			 Document doc = new Document();
			 PdfWriter.getInstance(doc, new FileOutputStream(ruta+".pdf"));
			 doc.open();
			 BufferedImage bufferedImage = chart.createBufferedImage(500, 300);
			 Image image = Image.getInstance(bufferedImage, null);
			//Font para el titulo
			 Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
			 Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
			// titulo
				Paragraph paragraph= new Paragraph();
				paragraph.add(new Phrase(titulo,Tituloprin));
				paragraph.setAlignment(Element.ALIGN_CENTER);
				doc.add(paragraph);
			 //Crear Tabla
			 PdfPTable pdftable = new PdfPTable(2);
			 for(int i=0;i<datos.length;i++){
				 pdftable.addCell(new Paragraph(datos[i][0],fonTitulos));
				 pdftable.addCell(datos[i][1]);
			 }
			 doc.add(pdftable);
			 doc.add(image);
			 doc.close();
			} catch (Exception e) {
			 e.printStackTrace();
			}
		
	}
	//-----------------------------FIN GRAFICA DE PIE----------------------------------

	//-----------------------------GRAFICA DE PIE--------------------------------------
		public void barras(String titulo,String ruta){
			String[][] datos= grafica();
	        DefaultCategoryDataset dataset = new DefaultCategoryDataset();
			 for(int i=0;i<datos.length;i++){
				 dataset.setValue(Integer.parseInt(datos[i][1]),datos[i][0],datos[i][0]);
			 }
			// Creando el gráfico
		        JFreeChart chart = ChartFactory.createBarChart3D
		                (titulo,"", "", 
		                dataset, PlotOrientation.VERTICAL, true,true, false);
		                chart.getTitle().setPaint(Color.black); 
		                CategoryPlot p = chart.getCategoryPlot(); 
		                p.setRangeGridlinePaint(Color.red);

			 // Mostrando el gráfico
			 ChartFrame frame = new ChartFrame("Grafico", chart);
			 frame.pack();
			 frame.setVisible(true);
			 
			 try {
				 Document doc = new Document();
				 PdfWriter.getInstance(doc, new FileOutputStream(ruta+".pdf"));
				 doc.open();
				 BufferedImage bufferedImage = chart.createBufferedImage(500, 300);
				 Image image = Image.getInstance(bufferedImage, null);
				//Font para el titulo
				 Font fonTitulos=FontFactory.getFont(FontFactory.HELVETICA_BOLD,12,Font.BOLD,BaseColor.BLACK);
				 Font Tituloprin=FontFactory.getFont(FontFactory.HELVETICA_BOLD,20,Font.BOLD,BaseColor.BLACK);
				// titulo
					Paragraph paragraph= new Paragraph();
					paragraph.add(new Phrase(titulo,Tituloprin));
					paragraph.setAlignment(Element.ALIGN_CENTER);
					doc.add(paragraph);
				 //Crear Tabla
				 PdfPTable pdftable = new PdfPTable(2);
				 for(int i=0;i<datos.length;i++){
					 pdftable.addCell(new Paragraph(datos[i][0],fonTitulos));
					 pdftable.addCell(datos[i][1]);
				 }
				 doc.add(pdftable);
				 doc.add(image);
				 doc.close();
				} catch (Exception e) {
				 e.printStackTrace();
				}
			
		}
		//-----------------------------FIN GRAFICA DE PIE----------------------------------
	
	
	
	
	//--------------------------------DATOS PARA CUALQUIER GRAFICA--------------------
	public String[][] grafica(){
		String[] datos= getDatos("Ingrese Datos");
		String[][] graphi=new String[datos.length][2];
		for(int y=0;y<datos.length;y++){
			datos[y]=datos[y].replace("<html>","");
			datos[y]=datos[y].replace("<b>","");
			datos[y]=datos[y].replace("<u>","");
			datos[y]=datos[y].replace("<i>","");
			datos[y]=datos[y].replace("</html>","");
			datos[y]=datos[y].replace("</b>","");
			datos[y]=datos[y].replace("</u>","");
			datos[y]=datos[y].replace("</i>","");
			graphi[y][0]=datos[y];
		}	
		String[] datos2= getDatos("Ingrese Valores");
		for(int y=0;y<datos2.length;y++){
			datos2[y]=datos2[y].replace("<html>","");
			datos2[y]=datos2[y].replace("<b>","");
			datos2[y]=datos2[y].replace("<u>","");
			datos2[y]=datos2[y].replace("<i>","");
			datos2[y]=datos2[y].replace("</html>","");
			datos2[y]=datos2[y].replace("</b>","");
			datos2[y]=datos2[y].replace("</u>","");
			datos2[y]=datos2[y].replace("</i>","");
			graphi[y][1]=datos2[y];
		}
		return graphi;
	}
	
	//-------------------------------FIN DATOS PARA CUALQUIER GRAFICA-------------------
	
	//---METODO QUE OBTIENE DATOS---------------------
	public String[] getDatos(String texto){
		String[] abecedarios={"Columna","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
	      String[] nume={"Fila","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26"};
		
	      JComboBox xField = new JComboBox(abecedarios);
	      JComboBox yField = new JComboBox(nume);
	      JComboBox fxField = new JComboBox(abecedarios);
	      JComboBox Fyield = new JComboBox(nume);
	     

	      JPanel myPanel = new JPanel();
	      
	      myPanel.add(new JLabel("Inicio Columna:"));
	      myPanel.add(xField);
	      myPanel.add(Box.createHorizontalStrut(15)); // a spacer
	      myPanel.add(new JLabel("Inicio Fila:"));
	      myPanel.add(yField);
	      
	      myPanel.add(new JLabel("Fin Columna:"));
	      myPanel.add(fxField);
	      myPanel.add(Box.createHorizontalStrut(15)); // a spacer
	      myPanel.add(new JLabel("Fin Fila:"));
	      myPanel.add(Fyield);


	      int result = JOptionPane.showConfirmDialog(null, myPanel, 
	               texto, JOptionPane.OK_CANCEL_OPTION);
	      if (result == JOptionPane.OK_OPTION) {
	    	  LetterNumbers conver= new LetterNumbers();
	    	  int cant=conver.convertAB((String)fxField.getSelectedItem())-conver.convertAB((String)xField.getSelectedItem());
	    	  cant++;
	    	  int contador=0;
	    	  int cant2=Integer.parseInt((String)Fyield.getSelectedItem())-Integer.parseInt((String)yField.getSelectedItem());
	    	  cant2++;
	    	  if(cant>1){
		    	mat=new String[cant];  
		    	contador=conver.convertAB((String)xField.getSelectedItem());
		    	for(int i=0;i<mat.length;i++){
		    		mat[i]=(String) table.getValueAt(Integer.parseInt((String)yField.getSelectedItem())-1, contador);
		    		contador++;		
		    	}
	    	  }else if(cant2>1){
	    		  mat=new String[cant2];
	    		  contador=Integer.parseInt((String)yField.getSelectedItem())-1;
			    	for(int i=0;i<mat.length;i++){
			    		mat[i]=(String) table.getValueAt(contador, conver.convertAB((String)xField.getSelectedItem()));
			    		contador++;		
			    	}
	    	  }
	      }
		return mat;
	}
	
	
}
