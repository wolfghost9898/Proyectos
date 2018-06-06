/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Clases;
import Dasboard.Dashboard;
import Listas.Datos;
import Listas.ListaCircularSE;
import Listas.Pila;
import Listas.circular;
import Listas.lista;
import Listas.lista_de_listas;
import Listas.nodo;
import javax.swing.*;
import java.awt.BorderLayout;//bordes
import java.awt.Color;
import java.awt.Desktop;
import java.awt.Dimension;
import java.awt.GridLayout;//tabla
import java.awt.FlowLayout;//fluido
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.border.Border;
import javax.swing.event.TableModelEvent;
import javax.swing.event.TableModelListener;
import javax.swing.filechooser.FileNameExtensionFilter;

/**
 *
 * @author HP
 */
public class Ventana1 extends JFrame implements ActionListener,TableModelListener{
    private final JPanel panel1;
    private final JPanel panel2,panel3,panel4;
    private final JMenuBar menu;
    private final JMenu inicio,edicion,formato,formulas,op,reportes,r1,carga,graficos;
    private final JFileChooser file,file2;
    private final JMenuItem negrita, sub,cursiva,general,numero,porcentaje, texto;
    private final JMenuItem sentencias,suma,prome1,contar, obm,obn,prome2;
    private final JMenuItem sumar,resta,multi,div,r2,r3,r4,r11,r12,abrir,guardar,grafico1,grafico2,grafico3;
    private final JButton copiar,pegar,b,i,u;
    public static Object [][] data = new Object[100][100];
    public static Object [][] datam = new Object[100][100];
    public static String[] columnNames = new String[100];
     public static String data1 ;
    public static int n,x,y,n1,n2,n3,xx,xy;
    JTable table = new JTable();
    Object [][]o ;
    ArrayList ord = new ArrayList(); 
    ArrayList ord1 = new ArrayList(); 
    String[][] ordr2 ;
    String [] orde1;
    String [] orde2;
    int columna,estad=1;
    boolean estado;
    int q, r ;
    public  boolean[][] BotonNegrita = new boolean[100][100];
    public boolean[][] BotonCursiva= new boolean[100][100];
    public   boolean[][] BotonSubrayar= new boolean[100][100];
    public   static boolean cam= true, cam1=true;
    
    lista ing = new lista();
    
    public Ventana1(){
        n=1;
    file = new JFileChooser();
    file2 = new JFileChooser();
    panel1= new JPanel();
    panel2= new JPanel();
    panel3= new JPanel();
    panel4= new JPanel();
    menu = new JMenuBar();
    inicio= new JMenu();
    edicion= new JMenu();
    formato= new JMenu();
    formulas = new JMenu();
    carga= new JMenu("Cargar Datos");
    graficos= new JMenu("Graficos");
    op = new JMenu();
    copiar = new JButton();
    pegar= new JButton();
    b= new JButton();
    i= new JButton();
    u= new JButton();
    reportes= new JMenu("Reportes");
    r1 = new JMenu("Reporte 1");

    negrita= new JMenuItem();
    sub= new JMenuItem();
    cursiva= new JMenuItem();
    general= new JMenuItem();
    numero= new JMenuItem();
    porcentaje= new JMenuItem();
    texto= new JMenuItem();
    abrir= new JMenuItem("Abrir");
    guardar= new JMenuItem("Guardar");
    grafico1= new JMenuItem("Grafico #1");
    grafico2= new JMenuItem("Grafico #2");
    grafico3= new JMenuItem("Grafico #3");
    r11= new JMenuItem("Ordenamiento Burbuja");
    r12= new JMenuItem("Ordenamiento Quicksort");
    r3= new JMenuItem("Reporte 3");
    r4= new JMenuItem("Reporte 4");
    r2= new JMenuItem("Reporte 2");
    
    
    
   
    sentencias= new JMenuItem();
    suma= new JMenuItem();
    prome1= new JMenuItem();
    contar= new JMenuItem();
    obm= new JMenuItem();
    obn= new JMenuItem();
    prome2= new JMenuItem();
    
    sumar= new JMenuItem();
    resta= new JMenuItem();
    multi= new JMenuItem();
    div= new JMenuItem();
    
    inicio.setText("Inicio");
    edicion.setText("Edición");
    formato.setText("Formato de Texto");
    negrita.setText("Negrita");
    sub.setText("Subrayado");
    cursiva.setText("Cursiva");
    general.setText("General");
    numero.setText("Número");
    porcentaje.setText("Porcentaje");
    texto.setText("Texto");
    
    formulas.setText("Fórmulas");
    sentencias.setText("Sentencia de Control");
    suma.setText("Suma");
    prome1.setText("Promedio");
    contar.setText("Contar Celdas"); 
    obm.setText("Obtener valor máximo de un rango de celdas");
    obn.setText("Obtener valor mínimo de un rango de celdas");
    //prome2.setText("Promedio2");
    
    op.setText("Operaciones Aritméticas");
    sumar.setText("Suma");
    resta.setText("Resta");
    multi.setText("Multiplicación");
    div.setText("División");
    
    panel1.add(menu);
    menu.add(inicio);
    inicio.add(edicion);
    edicion.add(negrita);
    edicion.add(sub);
    edicion.add(cursiva);
    inicio.add(formato);
    formato.add(general);
    formato.add(numero);
    formato.add(porcentaje);
    formato.add(texto);
    
    menu.add(formulas);
    formulas.add(sentencias);
    formulas.add(suma);
    formulas.add(prome1);
    formulas.add(contar);
    formulas.add(obm);
    formulas.add(obn);
    
    menu.add(op);
    op.add(sumar);
    op.add(resta);
    op.add(multi);
    op.add(div);
    menu.add(reportes);
    reportes.add(r1);
    reportes.add(r2);
    reportes.add(r3);
    reportes.add(r4);
    r1.add(r11);
    r1.add(r12);
    
    carga.add(abrir);
    carga.add(guardar);
   
    
    menu.add(carga);
    menu.add(graficos);
    graficos.add(grafico1);
    graficos.add(grafico2);
    graficos.add(grafico3);
ImageIcon f1 = new ImageIcon(getClass().getResource("/Recursos/co.png"));
ImageIcon f2 = new ImageIcon(getClass().getResource("/Recursos/pe.png"));
ImageIcon f3 = new ImageIcon(getClass().getResource("/Recursos/b.png"));
ImageIcon f4 = new ImageIcon(getClass().getResource("/Recursos/i.png"));
ImageIcon f5 = new ImageIcon(getClass().getResource("/Recursos/u.png"));
copiar.setIcon(f1);
copiar.setPreferredSize(new java.awt.Dimension(35,35));
pegar.setIcon(f2);
pegar.setPreferredSize(new java.awt.Dimension(35,35));
b.setIcon(f3);
b.setPreferredSize(new java.awt.Dimension(35,35));
i.setIcon(f4);
i.setPreferredSize(new java.awt.Dimension(35,35));
u.setIcon(f5);
u.setPreferredSize(new java.awt.Dimension(35,35));

    panel2.add(copiar);
    panel2.add(pegar);
    panel2.add(b);
    panel2.add(i);
    panel2.add(u);

    this.setLayout(new BorderLayout());
    panel1.setLayout(new GridLayout(1,1,1,1));
    panel2.setLayout(new FlowLayout(FlowLayout.LEFT,10,0));
    panel3.setLayout(new GridLayout(1,1,1,1));
    panel4.setLayout(new BorderLayout());
    Border blackline, etched, raisedbevel, loweredbevel, empty;
    blackline = BorderFactory.createLineBorder(Color.black);
    panel2.setBorder(blackline);
     panel3.setBorder(blackline);
      panel4.setBorder(blackline);
    this.add(panel1,BorderLayout.NORTH);
    this.add(panel4,BorderLayout.CENTER);
    panel4.add(panel2,BorderLayout.NORTH);
    panel4.add(panel3,BorderLayout.CENTER);


    this.setDefaultCloseOperation(Ventana1.EXIT_ON_CLOSE);
       
   


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
        columnNames[0]="";

        for(int l=1;l<27;l++){
          letra=(char)(64+l);
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
        //DefaultTableModel modelo = new DefaultTableModel(data, columnNames); 
         
         tabla1 modelo = new tabla1(data,columnNames);
        table = new JTable(modelo);
        table.setCellSelectionEnabled(true);
      
        //table.setDefaultRenderer(Object.class, new Render());

      table.setPreferredScrollableViewportSize(new Dimension(865, 500));
      table.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
      

        JScrollPane scroll = new JScrollPane(table);
        scroll.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS);
        scroll.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_ALWAYS);
        panel3.add(scroll, BorderLayout.CENTER);

            
      
      //cambio en la tabla
       table.getModel().addTableModelListener(this);
    table.getSelectionModel().addListSelectionListener(table);
    
    this.negrita.addActionListener(this);
    this.sub.addActionListener(this);
    this.cursiva.addActionListener(this);
    this.general.addActionListener(this);
    this.numero.addActionListener(this);
    this.porcentaje.addActionListener(this);
    this.texto.addActionListener(this);
    this.sentencias.addActionListener(this);
    this.suma.addActionListener(this);
    this.prome1.addActionListener(this);
    this.contar.addActionListener(this);
    this.obm.addActionListener(this);
    this.obn.addActionListener(this);
    this.prome2.addActionListener(this);
    this.sumar.addActionListener(this);
    this.resta.addActionListener(this);
    this.multi.addActionListener(this);
    this.div.addActionListener(this);
    this.copiar.addActionListener(this);
    this.pegar.addActionListener(this);
    this.r11.addActionListener(this);
    this.r12.addActionListener(this);
    this.r2.addActionListener(this);
    this.r3.addActionListener(this);
    this.r4.addActionListener(this);
    this.carga.addActionListener(this);
    this.abrir.addActionListener(this);
    this.guardar.addActionListener(this);
    this.graficos.addActionListener(this);
    this.grafico1.addActionListener(this);
    this.grafico2.addActionListener(this);
    this.grafico3.addActionListener(this);

table.getColumnModel().getColumn(0);
table.getColumnModel().getColumn(0).setCellRenderer(table.getTableHeader().getDefaultRenderer());
for(int i=0;i< 100 ;i++){
                     for(int ii=1;ii< 100 ;ii++){
                         
                         table.setValueAt("", i, ii);
                     }}


     Image icon = new ImageIcon(getClass().getResource("/Recursos/e.png")).getImage();
     this.setIconImage(icon);
     this.setTitle("Excel Lite");
     

  
        
       
    }

    @Override
//                                                      EVENTOS 
//------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------
    public void actionPerformed(ActionEvent e) {
        //GRAFICOS
        //Grafico2
          if(e.getSource().equals(grafico3)){
              ListaCircularSE c1 = new ListaCircularSE();
              ListaCircularSE c2 = new ListaCircularSE();
            lista l1 = new lista();
            lista l2 = new lista();
            lista l3 = new lista();
            lista l4 = new lista();
            lista l5 = new lista();
            lista l6 = new lista();
            Pila pl1 = new Pila();
            Pila pl2 = new Pila();
            for(int i =3;i<10;i++){
            pl1.push(table.getValueAt(i, 5));
            pl2.push(table.getValueAt(i, 6));
            c1.insertar(table.getValueAt(i, 1));
            c2.insertar(table.getValueAt(i, 2));
            l1.enlistar(table.getValueAt(i, 1));
            l2.enlistar(table.getValueAt(i, 2));
            l3.enlistar(table.getValueAt(i, 3));
            l4.enlistar(table.getValueAt(i, 4));
            l5.enlistar(table.getValueAt(i, 5));
            l6.enlistar(table.getValueAt(i, 6));
            }
            lista m1 = new lista();
            lista m2 = new lista();
            lista m3 = new lista();
            lista m4 = new lista();
            lista m5 = new lista();
            lista m6 = new lista();
            lista m7 = new lista();
            for(int i =1;i<7;i++){
            
            m1.enlistar(table.getValueAt(3, i));
            m2.enlistar(table.getValueAt(4, i));
            m3.enlistar(table.getValueAt(5, i));
            m4.enlistar(table.getValueAt(6, i));
            m5.enlistar(table.getValueAt(7, i));
            m6.enlistar(table.getValueAt(8, i));
            m7.enlistar(table.getValueAt(9, i));
            }
            lista_de_listas lli =new lista_de_listas();
            lli.enlistar(m7);
            lli.enlistar(m6);
            lli.enlistar(m5);
            lli.enlistar(m4);
            lli.enlistar(m3);
            lli.enlistar(m2);
            lli.enlistar(m1);
            
            
        DashboardGriafica3 ven= new DashboardGriafica3();
         ven.datos(l1,l2,l3,l4,l5,l6,m1,m2,m3,m4,m5,m6,m7,lli,c1,c2,pl1,pl2); 
         ven.setVisible(true);
         ven.setBounds(200,0,900,740);
           
          }
        //GRAFICO1
        if(e.getSource().equals(grafico1)){
       lista g1 = new lista();
       g1.datos();
       for(int yy=3;yy<10;yy++){
        for(int uu=1;uu<15;uu++){
            g1.enlistar(table.getValueAt(yy, uu)); 
        }}
        circular b1 = new circular();
        circular b2 = new circular();
        for(int uu=3;uu<10;uu++){
            b1.enlistar(table.getValueAt(uu, 1)); 
        }
        for(int uu=4;uu<10;uu++){
            b2.enlistar(table.getValueAt(uu, 14)); 
        }
  
         Dashboard ven= new Dashboard();
         ven.datos(g1, b1,b2); 
         ven.setVisible(true);
         ven.setBounds(200,0,900,740);
        
        }
        //-----------------------------------------------------------------------------------------
        //GUARDAR
       if(e.getSource().equals(guardar)){
          

           ing.setnull(); 
           
       for(int i=0;i<60;i++){
        for(int j=1;j<60;j++){ 
            
           ing.enlistar(table.getValueAt(i, j));
           
        }   
       }
        file2.addChoosableFileFilter(new FileNameExtensionFilter("todos los archivos *.dat", "dat","dat"));
            int seleccion = file2.showSaveDialog(null);
   
                if (seleccion == JFileChooser.APPROVE_OPTION){
                    File JFC = file2.getSelectedFile();
                    String dir = JFC.getAbsolutePath();
                    Datos d = new Datos();
                    d.guardar(ing,dir);
                }
       
        }
       //file abrir
        
        //abrir
        if(e.getSource().equals(abrir)){
            Datos dd= new Datos();
           lista a = new lista();
           
              int abri = file.showDialog(null, "Abrir");
        if (abri == JFileChooser.APPROVE_OPTION) {
            System.out.println("abrite");
             File  tipo = file.getSelectedFile();
             a = dd.abrir(tipo);
         nodo temp= a.getcabeza();
         while(!(temp==null)){
        for(int i=23;i>=0;i--){
        for(int w=23;w>=1;w--){
    if(temp!=null){
      
          table.setValueAt(temp.getInfo(), i, w);
      temp = temp.getSig();
    }    
    }    }
     }
        }
        }
        
//-------------------------------------------------------------------------------------




       
        if(e.getSource().equals(sumar)){

          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v = 0,w = 0;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
            
          
            String val= " ";
          
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                        val = val+" "+ String.valueOf(table.getValueAt(v,w));
                        
                     }
                  
              }

          table.setValueAt(val,v+1, w);
         } 
        
          if(e.getSource().equals(resta)){

          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v = 0,w = 0;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
            Object[]c= new Object[ss.length];
          
            double val=Double.parseDouble( (String) table.getValueAt(x,y));

              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                         if(!(i==0&&ii==0)){
                       v=x+i;
                       w=y+ii;
                        val -= Double.parseDouble( (String) table.getValueAt(v,w));
                        }
                        
                     }
                  
              }

          table.setValueAt(val,v+1, w);
         } 
          
          
          if(e.getSource().equals(multi)){

          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v = 0,w = 0;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
        
          
            double val;
              val= Double.parseDouble( (String) table.getValueAt(x,y));
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       if(!(i==0&&ii==0)){
                       v=x+i;
                       w=y+ii;
                        val *= Double.parseDouble( (String) table.getValueAt(v,w));
                        }
                        
                     }
                  
              }

          table.setValueAt(val,v+1, w);
         } 
          
            if(e.getSource().equals(div)){

          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v = 0,w = 0;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
           double val= Double.parseDouble( (String) table.getValueAt(x,y));
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                      if(!(i==0&&ii==0)){
                       v=x+i;
                       w=y+ii;
                        val /= Double.parseDouble( (String) table.getValueAt(v,w));
                        }
                        
                     }
                  
              }

          table.setValueAt(val,v+1, w);
         } 
             if(e.getSource().equals(suma)){

          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v = 0,w = 0;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
            
          
            double val=0;

              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                        val += Double.parseDouble( (String) table.getValueAt(v,w));
                        
                     }    
              }
             table.setValueAt(val,v+1, w);}
             
             if(e.getSource().equals(copiar)){

          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v,w;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
             o = new Object[s.length][ss.length];
          
            double val=0;
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                      o[i][ii]=table.getValueAt(v,w);
                         
                        
                     }    
              } 
             datos me = new datos(o,s.length,ss.length);
            q = me.getX();
            r = me.getY();
             }
             if(e.getSource().equals(pegar)){

          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          
              for(int i=0;i< q ;i++){
                     for(int ii=0;ii< r;ii++){
                    table.setValueAt(o[i][ii] ,x+i, y+ii);
                        
                     }    
              } }
             if(e.getSource().equals(prome1)){
             x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v = 0,w = 0;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
            
          
            double val=0;
              int con=0;
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                        val += Double.parseDouble( (String) table.getValueAt(v,w));
                        con++;
                     }
                  
              }
            double tot = val/(con);
          table.setValueAt(tot,v+1, w);
           } 
             
             if(e.getSource().equals(contar)){
             x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v = 0,w = 0;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
              int con=0;
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                        con++;
                     }
                  
              }
          table.setValueAt(con,v+1, w);
           }
         
             if(e.getSource().equals(obm)){
                 x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v,w;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
             o = new Object[s.length][ss.length];
          
            double val=0;
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                      o[i][ii]=table.getValueAt(v,w);
                         
                        
                     }    
              } 
             datos max = new datos(o,s.length,ss.length);;
             val = max.Max(o,max.getX(),max.getY());
             
              table.setValueAt(val,x+s.length, y+ss.length-1);
         
           }
             if(e.getSource().equals(obn)){
                 x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v,w;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
             o = new Object[s.length][ss.length];
          
            double val=0;
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                      o[i][ii]=table.getValueAt(v,w);
                         
                        
                     }    
              } 
             datos min = new datos(o,s.length,ss.length);;
             val = min.Min(o,min.getX(),min.getY());
             
              table.setValueAt(val,x+s.length, y+ss.length-1);
         
           }
             //Sentencia de Control
             if(e.getSource().equals(sentencias)){
                 Ventana2 ven= new Ventana2();
                
                      
            ven.setVisible(true);
            ven.setBounds(500,300,500,200);
             
             
             }
             
             //Estado
             if(e.getSource().equals(negrita)){
                 System.out.println("Negrita");
                   if (BotonNegrita[table.getSelectedRow()][table.getSelectedColumn()]==false) {
                BotonNegrita[table.getSelectedRow()][table.getSelectedColumn()]=true;
                System.out.println(BotonNegrita[table.getSelectedRow()][table.getSelectedColumn()]);
            }
            else if(BotonNegrita[table.getSelectedRow()][table.getSelectedColumn()]==true){
                BotonNegrita[table.getSelectedRow()][table.getSelectedColumn()]=false;
                System.out.println(BotonNegrita[table.getSelectedRow()][table.getSelectedColumn()]);
                
            }
                  
             }
             if(e.getSource().equals(sub)){
                 System.out.println("sub");
                   if (BotonCursiva[table.getSelectedRow()][table.getSelectedColumn()]==false) {
                BotonCursiva[table.getSelectedRow()][table.getSelectedColumn()]=true;
                
            } 
            else if(BotonCursiva[table.getSelectedRow()][table.getSelectedColumn()]==true){
                BotonCursiva[table.getSelectedRow()][table.getSelectedColumn()]=false;
            }
             }
              if(e.getSource().equals(cursiva)){
                  System.out.println("cur");
                   if (BotonSubrayar[table.getSelectedRow()][table.getSelectedColumn()]==false) {
                BotonSubrayar[table.getSelectedRow()][table.getSelectedColumn()]=true;
            } 
            else if(BotonSubrayar[table.getSelectedRow()][table.getSelectedColumn()]==true){
                BotonSubrayar[table.getSelectedRow()][table.getSelectedColumn()]=false;
            }
             }
              

           //Reportes
              if(e.getSource().equals(r11)){
                 ord.clear();
          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v,w;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
             o = new Object[s.length][ss.length];
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                      o[i][ii]=table.getValueAt(v,w);    
                     }    
              } 
             datos me = new datos(o,s.length,ss.length);
            q = me.getX();
            r = me.getY();
            
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                     ord.add(o[i][ii]);
                       }
                   }
           
           ordenar();
            
                
                css();
            try {
                abrir("C:\\Users\\HP\\Documents\\NetBeansProjects\\\\alca1\\index1.html");
            } catch (IOException ex) {
                Logger.getLogger(Ventana1.class.getName()).log(Level.SEVERE, null, ex);
            }
             }
               // Reportes 1.2
               if(e.getSource().equals(r12)){
                 
          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v,w;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
             o = new Object[s.length][ss.length];
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                      o[i][ii]=table.getValueAt(v,w);    
                     }    
              } 
             datos me = new datos(o,s.length,ss.length);
            q = me.getX();
            r = me.getY();
            ord1.clear();
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                     ord1.add(o[i][ii]);
                       }
                   }
           int izq=0;
           int der=ord1.size()-1;
            orde2= new String[ord1.size()];
        for(int i1=0;i1<ord1.size();i1++){
              orde2[i1]=(String) ord1.get(i1);
        }
         metodo_quicksort(orde2,izq,der);
         imprimir1(orde2);
         css();
         
             imprimir1(orde2);
             try {
                abrir("C:\\Users\\HP\\Documents\\NetBeansProjects\\\\alca1\\index1.html");
            } catch (IOException ex) {
                Logger.getLogger(Ventana1.class.getName()).log(Level.SEVERE, null, ex);
            }
             }
               // Reporte 2
               if(e.getSource().equals(r2)){
                 
          x=table.getSelectedRow();
          y=table.getSelectedColumn();
          int v,w;
            int[] s = table.getSelectedRows();
            int[] ss = table.getSelectedColumns();
             o = new Object[s.length][ss.length];
            int co=0;
              for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                       v=x+i;
                       w=y+ii;
                      o[i][ii]=table.getValueAt(v,w);    
                      co++;
                     }    
              } 
              //obtener
              
             ArrayList f=new ArrayList();
             f.clear();
             int l;
               for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                         l=s[i]+1;
                     f.add((char)(64+ss[ii])+""+l);
                     }    
              } 
                
              ordr2 = new String[co][3];
             
             for(int ip=0;ip<co ;ip++){
                         ordr2[ip][0]=(String) f.get(ip);
                     }
             ArrayList m = new ArrayList();
             m.clear(); 
             ArrayList mn = new ArrayList();
             mn.clear(); 
             int fg,ty,tt;
             for(int i=0;i< s.length ;i++){
                     for(int ii=0;ii< ss.length ;ii++){
                        m.add( (String) o[i][ii]); 
                        fg =s[i];
                        ty=ss[ii];
                        tt =(int) datam[fg][ty];
                        if(tt==1){
                           
                        mn.add("General");}else if(tt==2){
                           
                        mn.add("Numero");}else if (tt==3){
                            
                        mn.add("Porcentaje");}else if(tt==4){
                            
                        mn.add("Texto");} 
                     }    
              }
             
             
             for(int i =0 ; i<co;i++){
                 ordr2[i][1]=(String) m.get(i);
                 ordr2[i][2]=String.valueOf(mn.get(i)); 
             } 
         imprimir3(ordr2,co);
         css();
        
       
             try {
                abrir("C:\\Users\\HP\\Documents\\NetBeansProjects\\\\alca1\\index2.html");
            } catch (IOException ex) {
                Logger.getLogger(Ventana1.class.getName()).log(Level.SEVERE, null, ex);
            }
             }
                // Reporte 4
               if(e.getSource().equals(r4)){
                x=table.getSelectedRow();
                y=table.getSelectedColumn();
             o = new Object[21][14];
             
             o[0][0]="";
            for(int i=1;i<9;i++){
                    char letra = (char)(64+i);
               o[0][i]=String.valueOf(letra);;
            }
            
              for(int i=1;i< 11;i++){
                     for(int ii=0;ii< 9 ;ii++){
                      o[i][ii]=table.getValueAt(i-1,ii);    
                     }    
              } 
               imprimir5(o);
         css();
        
       
             try {
                abrir("C:\\Users\\HP\\Documents\\NetBeansProjects\\\\alca1\\index4.html");
            } catch (IOException ex) {
                Logger.getLogger(Ventana1.class.getName()).log(Level.SEVERE, null, ex);
            }
               
               
               }
              //Reporte 3
            if(e.getSource().equals(r3)){
              String pb=String.valueOf(JOptionPane.showInputDialog("Ingrese la palabra a buscar"));
              System.out.println("Encontrado");
              String vv;
              ArrayList ub1=new ArrayList();
              ArrayList ub2=new ArrayList();
              ub1.clear();
              ub2.clear();
              for(int i=0;i< 100 ;i++){
                     for(int ii=0;ii<100 ;ii++){
                         
                       vv = String.valueOf( table.getValueAt(i,ii));    
                      String arreglob[]=vv.split(" ");
                      
                      for(int iii=0;iii<arreglob.length ;iii++){
                      if(arreglob[iii].equalsIgnoreCase(pb)){
                      System.out.println("Encontrado");
                      ub1.add(i);
                      ub2.add(ii);
                     
                      }
                      }
                     }    
              } 
              int bb,mm;
              ArrayList ff=new ArrayList();
             ff.clear();
              for(int i=0;i< ub1.size() ;i++){
                         bb =(int) ub1.get(i);
                         mm= (int) ub2.get(i);
                         ff.add(table.getValueAt(bb,mm ));
                     }
              
               System.out.println(ff.size());
              ArrayList f=new ArrayList();
             f.clear();
             int l,ll;
               for(int i=0;i< ub1.size() ;i++){
                         l=((int) ub1.get(i))+1;
                         ll =64+((int) ub2.get(i));
                     f.add((char)(ll)+""+l);
                        
              }
               o = new Object[ff.size()][2];
               for(int i=0;i< ff.size() ;i++){
                    o[i][1]= ff.get(i);
               }
               for(int i=0;i< ff.size() ;i++){
                    o[i][0]= f.get(i);
               }
                imprimirf(o,pb,ff.size());       
         css();
        
       
             try {
                abrir("C:\\Users\\HP\\Documents\\NetBeansProjects\\\\alca1\\index3.html");
            } catch (IOException ex) {
                Logger.getLogger(Ventana1.class.getName()).log(Level.SEVERE, null, ex);
            }
              
              
              
              
              
              
            

               }
               
               
               //Estados
                 if(e.getSource().equals(general)){
                 estad=1;
                  x=table.getSelectedRow();
          y=table.getSelectedColumn();       
                 }
                 if(e.getSource().equals(numero)){ 
                  estad=2;
                  x=table.getSelectedRow();
                  y=table.getSelectedColumn();
                  System.out.println(estad);
      
             }  
                 
               if(e.getSource().equals(porcentaje)){   
                   estad=3;
                  x=table.getSelectedRow();
                  y=table.getSelectedColumn();
          
                     
             }  
               if(e.getSource().equals(texto)){
               estad=4;
                  x=table.getSelectedRow();
          y=table.getSelectedColumn();
             }  
    
    }
    @Override
          public void tableChanged(TableModelEvent e) {
    
     xx = e.getColumn();
     xy= e.getFirstRow();
     
     
     
    }

    private void ordenar() {
        
        columna = table.getSelectedColumn();
        orde1= new String[ord.size()];
        
        for(int i1=0;i1<ord.size();i1++){
              orde1[i1]=(String) ord.get(i1);
        }
        
        for(int j=0;j<orde1.length-1;j++) {
             for(int i=0;i<orde1.length-j-1;i++) {
                 if (orde1[i].compareTo(orde1[i+1])>0) {
                     String aux;
                     aux=orde1[i];
                     orde1[i]=orde1[i+1];
                     orde1[i+1]=aux;
                 }
             }
         }
          
          
          imprimir1(orde1);
    }


    private void metodo_quicksort(String[] orde2, int izq, int der) {
        columna = table.getSelectedColumn();
   int i=izq;
        int j=der;
        int pivote=(i+j)/2;
        do {
            while (orde2[i].compareToIgnoreCase(orde2[pivote])<0){
                i++;
            }
            while (orde2[j].compareToIgnoreCase(orde2[pivote])>0){
                j--;
            }
            if (i<=j){
                String aux=orde2[i];
                orde2[i]=orde2[j];
                orde2[j]=aux;
                i++;
                j--;
            }
        }while(i<=j);
        if (izq<j){
            metodo_quicksort(orde2, izq, j);
        }
        if (i<der){
            metodo_quicksort(orde2, i, der);
        }
  
    }

    private void imprimir1(String[] ordii) {    
 FileWriter filewriter = null;
 PrintWriter printw = null;
       
 try{
     filewriter = new FileWriter("index1.html");
     printw = new PrintWriter(filewriter);
     printw.println("<!DOCTYPE html>");
printw.println("<html lang=\"es\">");
	printw.println("<head>");
		printw.println("<title>Reportes</title>");
		printw.println("<meta charset=\"utf-8\">");
		printw.println("<link rel=\"stylesheet\" href=\"estilo.css\">");
	printw.println("</head>");
printw.println("<body>");
	printw.println("<div id=\"in\">");
	printw.println("<div id = \"p1\">");
	printw.println("<hgroup><h1><i>Reporte 1 </i></h1></hgroup>");
		printw.println("<header>");
			 printw.println("<nav>");

			 	printw.println("<ul>");
			 		printw.println("<li><a href=\"index1.html\">Reporte 1</a></li>");
			 		printw.println("<li><a href=\"index2.html\">Reporte 2</a></li>");
			 		printw.println("<li><a href=\"index3.html\">Reparte 3</a></li>");
			 		printw.println("<li><a href=\"index4.html\">Reporte 4</a></li>");
			 	printw.println("</ul>");
			 printw.println("</nav>");
		printw.println("</header>");
		printw.println("<section>");
                char letra=(char)(64+columna);
				printw.println("<article>");
					printw.println("<hgroup><h1><i>Columna "+letra+" Ordenada Descendentemente</i></h1></hgroup>");
					printw.println("<article>");			
				    printw.println("<table id=\"t1\" border=\"2px\">");
                                    printw.println("<tr>");
				    	printw.println("<th>Columna: "+letra+"</th>");
				    	 printw.println("</tr>");
                                    for(int i=0;i<ordii.length;i++){
                                    printw.println("<tr>");
				    	printw.println("<td>"+ordii[i]+"</td>");
				    	 printw.println("</tr>"); 
                                    }
				    	
				    		
				    printw.println("</table>");
				printw.println("</article>");
				     printw.println("<p><i></i></p>");
				printw.println("</article>");
			printw.println("</div>");
		printw.println("</section>");
	printw.println("</div>");	
	printw.println("<footer><section id=\"f1\">David Andres Alcazar Escobar 201504480 IP1</section></footer>");
	printw.println("</body>");
printw.println("</html>	");

     printw.close();
           
     
     
    }catch(Exception e){   System.out.println("Error"); }
    }

    

    private void abrir(String archivo) throws IOException {
     File objetofile = new File (archivo);
            Desktop.getDesktop().open(objetofile);
    }

    private void css() {
   
       
 FileWriter filewriter = null;
 PrintWriter printw = null;
       
 try{
     filewriter = new FileWriter("estilo.css");
     printw = new PrintWriter(filewriter);

    	printw.println("body ");
	printw.println("{");
		printw.println("background-image: url(\"i1.jpg\");");
    	printw.println("font-family: \"Palatino Linotype\", \"Book Antiqua\", Palatino, serif;");

	printw.println("}");
	printw.println("#in");
	printw.println("{");
		printw.println("width: 1000px;");
		printw.println("margin: 0 auto;");
		printw.println("text-align: left;");
	printw.println("}");
	printw.println("header");
	printw.println("{");
		
    	printw.println("color: #bbb7f0;");
    	printw.println("margin: 0 auto;");
    	printw.println("text-align: left;");
    	printw.println("border-color: black;");
    	printw.println("border-radius: 20px;");
        printw.println("box-shadow: 0px  0px 20px rgba(0,0,0,3)");
         
	printw.println("}");


	printw.println("h1");
	printw.println("{");

		printw.println("text-decoration: italic;");
		printw.println("color: black;");
		printw.println("text-align: left;");
	printw.println("}");

	printw.println("header hgroup h1");
	printw.println("{");
    	printw.println("border-bottom: solid;");
    	printw.println("padding-bottom: 10px;");
    	printw.println("border-width: 1px;");
    	printw.println("border-color: black ;");
    	printw.println("text-shadow: 0px 0px 30px rgba(0,0,0,0.5);");

	printw.println("}");


	printw.println("nav ul li ");
	printw.println("{");
		printw.println("display: inline-block;");
		printw.println("margin-right: 20px;");
		printw.println("color: green;");
		printw.println("cursor: pointer;");
		printw.println("padding: 5px;");
	
	printw.println("}");
    
    printw.println("#l1:hover");
   printw.println("{");
   		printw.println("background-color: white;");
   		printw.println("border-radius: 5px;");

   printw.println("}");
   printw.println("nav ul li a {");
   	printw.println("text-decoration: none;");
   	printw.println("color: #060344;");
   printw.println("}");
    printw.println("#p1");
    printw.println("{");
    	printw.println("background-color: #494242;");
        printw.println("height: 600px;");
    	printw.println("color: #bbb7f0;");
    	printw.println("margin: 0 auto;");
    	printw.println("text-align: center;");
    	printw.println("border-radius: 20px;");
    	printw.println("padding: 20px;");
        printw.println("box-shadow: 0px  0px 20px rgba(0,0,0,0.5)");
    printw.println("}");
    printw.println("#f1");
    printw.println("{");
    	printw.println("color:white;");
		printw.println("font-family: cambria;");
		printw.println("font-style: italic;");
		printw.println("Text-Align: center;");
		printw.println("font-size: 30px; ");
printw.println("}");

 printw.println("#t11");
    printw.println("{");
    	printw.println("height: 430px;");
    	printw.println("width:  900px;");
printw.println("}");
    


     printw.close();
           
     
     
    }catch(Exception e){   System.out.println("Error"); }
    }

    private void imprimir3(String[][] ordr2, int co) {
     FileWriter filewriter = null;
 PrintWriter printw = null;
       
 try{
     filewriter = new FileWriter("index2.html");
     printw = new PrintWriter(filewriter);
     printw.println("<!DOCTYPE html>");
printw.println("<html lang=\"es\">");
	printw.println("<head>");
		printw.println("<title>Reportes</title>");
		printw.println("<meta charset=\"utf-8\">");
		printw.println("<link rel=\"stylesheet\" href=\"estilo.css\">");
	printw.println("</head>");
printw.println("<body>");
	printw.println("<div id=\"in\">");
	printw.println("<div id = \"p1\">");
	printw.println("<hgroup><h1><i>Reporte 2 </i></h1></hgroup>");
		printw.println("<header>");
			 printw.println("<nav>");

			 	printw.println("<ul>");
			 		printw.println("<li><a href=\"index1.html\">Reporte 1</a></li>");
			 		printw.println("<li><a href=\"index2.html\">Reporte 2</a></li>");
			 		printw.println("<li><a href=\"index3.html\">Reparte 3</a></li>");
			 		printw.println("<li><a href=\"index4.html\">Reporte 4</a></li>");
			 	printw.println("</ul>");
			 printw.println("</nav>");
		printw.println("</header>");
		printw.println("<section>");
				printw.println("<article>");
					printw.println("<hgroup><h1><i>Reporte de Tipos de Contenidos por celda</i></h1></hgroup>");
					printw.println("<article>");			
				    printw.println("<table id=\"t1\" border=\"2px\" align=\"center\">");
                                    printw.println("<tr>");
				    	printw.println("<td>Celda</td>");
                                        printw.println("<td>Contenido</td>");
                                        printw.println("<td>Tipo de Contenido</td>");
				    	 printw.println("</tr>"); 
                                         for(int i=0;i< co ;i++){
                                            printw.println("<tr>");
                                            for(int ii=0;ii< 3;ii++){
				    	printw.println("<td>"+ordr2[i][ii]+"</td>");
                                            }
				    	 printw.println("</tr>");  
                                                   }
                                         
                                    printw.println("<tr>");
				    	//printw.println("<td>"+ordii[i]+"</td>");
				    	 printw.println("</tr>"); 
                                      
                                        
				    	
				    		
				    printw.println("</table>");
				printw.println("</article>");
				     printw.println("<p><i></i></p>");
				printw.println("</article>");
			printw.println("</div>");
		printw.println("</section>");
	printw.println("</div>");	
	printw.println("<footer><section id=\"f1\">David Andres Alcazar Escobar 201504480 IP1</section></footer>");
	printw.println("</body>");
printw.println("</html>	");

     printw.close();
           
     
     
    }catch(Exception e){   System.out.println("Error"); }
    
    }

    private void imprimir5(Object[][] o) {
    FileWriter filewriter = null;
 PrintWriter printw = null;
       
 try{
     filewriter = new FileWriter("index4.html");
     printw = new PrintWriter(filewriter);
     printw.println("<!DOCTYPE html>");
printw.println("<html lang=\"es\">");
	printw.println("<head>");
		printw.println("<title>Reportes</title>");
		printw.println("<meta charset=\"utf-8\">");
		printw.println("<link rel=\"stylesheet\" href=\"estilo.css\">");
	printw.println("</head>");
printw.println("<body>");
	printw.println("<div id=\"in\">");
	printw.println("<div id = \"p1\">");
	printw.println("<hgroup><h1><i>Reporte 4 </i></h1></hgroup>");
		printw.println("<header>");
			 printw.println("<nav>");

			 	printw.println("<ul>");
			 		printw.println("<li><a href=\"index1.html\">Reporte 1</a></li>");
			 		printw.println("<li><a href=\"index2.html\">Reporte 2</a></li>");
			 		printw.println("<li><a href=\"index3.html\">Reparte 3</a></li>");
			 		printw.println("<li><a href=\"index4.html\">Reporte 4</a></li>");
			 	printw.println("</ul>");
			 printw.println("</nav>");
		printw.println("</header>");
		printw.println("<section>");
				printw.println("<article>");
					printw.println("<hgroup><h1><i>Reporte de Datos</i></h1></hgroup>");
					printw.println("<article>");			
				    printw.println("<table id=\"t11\" border=\"2px\" align=\"center\">");
                                         for(int i=0;i< 11;i++){
                                            printw.println("<tr>");
                                            for(int ii=0;ii< 9;ii++){
				    	printw.println("<td>"+o[i][ii]+"</td>");
                                            }
				    	 printw.println("</tr>");  
                                                   }
		    		
				    printw.println("</table>");
				printw.println("</article>");
				     printw.println("<p><i></i></p>");
				printw.println("</article>");
			printw.println("</div>");
		printw.println("</section>");
	printw.println("</div>");	
	printw.println("<footer><section id=\"f1\">David Andres Alcazar Escobar 201504480 IP1</section></footer>");
	printw.println("</body>");
printw.println("</html>	");

     printw.close();
           
     
     
    }catch(Exception e){   System.out.println("Error"); }
    
    
    
    }

    private void imprimirf(Object[][] o, String pb,int tam) {
         FileWriter filewriter = null;
 PrintWriter printw = null;
       
 try{
     filewriter = new FileWriter("index3.html");
     printw = new PrintWriter(filewriter);
     printw.println("<!DOCTYPE html>");
printw.println("<html lang=\"es\">");
	printw.println("<head>");
		printw.println("<title>Reportes</title>");
		printw.println("<meta charset=\"utf-8\">");
		printw.println("<link rel=\"stylesheet\" href=\"estilo.css\">");
	printw.println("</head>");
printw.println("<body>");
	printw.println("<div id=\"in\">");
	printw.println("<div id = \"p1\">");
	printw.println("<hgroup><h1><i>Reporte 3 </i></h1></hgroup>");
		printw.println("<header>");
			 printw.println("<nav>");

			 	printw.println("<ul>");
			 		printw.println("<li><a href=\"index1.html\">Reporte 1</a></li>");
			 		printw.println("<li><a href=\"index2.html\">Reporte 2</a></li>");
			 		printw.println("<li><a href=\"index3.html\">Reparte 3</a></li>");
			 		printw.println("<li><a href=\"index4.html\">Reporte 4</a></li>");
			 	printw.println("</ul>");
			 printw.println("</nav>");
		printw.println("</header>");
		printw.println("<section>");
                char letra=(char)(64+columna);
				printw.println("<article>");
					printw.println("<hgroup><h1><i>Busqueda de Texto: \""+pb+"\"</i></h1></hgroup>");
					printw.println("<article>");			
				    printw.println("<table id=\"t1\" border=\"2px\">");
                                    printw.println("<tr>");
				    	printw.println("<th>Celda</th>");
                                        printw.println("<th>Contenido Encontrado</th>");
				    	 printw.println("</tr>");
                                         System.out.println(tam);
                                    for(int i=0;i<tam;i++){
                                    printw.println("<tr>");
                                    for(int ii=0;ii<2;ii++){
				    	printw.println("<td>"+o[i][ii]+"</td>");
                                    }
				    	 printw.println("</tr>"); 
                                    }
				    	
				    		
				    printw.println("</table>");
				printw.println("</article>");
				     printw.println("<p><i></i></p>");
				printw.println("</article>");
			printw.println("</div>");
		printw.println("</section>");
	printw.println("</div>");	
	printw.println("<footer><section id=\"f1\">David Andres Alcazar Escobar 201504480 IP1</section></footer>");
	printw.println("</body>");
printw.println("</html>	");

     printw.close();
           
     
     
    }catch(Exception e){   System.out.println("Error"); }
    
    }

   

    

   
}
