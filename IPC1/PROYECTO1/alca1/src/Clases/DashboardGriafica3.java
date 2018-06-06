/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Clases;

import Dasboard.GenerarGraficas;
import Dasboard.imprimir;
import Listas.Cnodo;
import Listas.ListaCircularSE;
import Listas.Pila;
import Listas.circular;
import Listas.lista;
import Listas.lista_de_listas;
import Listas.nodo;
import Listas.nodo_enlazada;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.border.Border;
import javax.swing.event.TableModelEvent;
import javax.swing.event.TableModelListener;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartMouseEvent;
import org.jfree.chart.ChartMouseListener;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.entity.ChartEntity;
import org.jfree.data.general.DefaultPieDataset;

/**
 *
 * @author HP
 */
class DashboardGriafica3 extends JFrame implements ActionListener,TableModelListener{

     private final JPanel panel1, panel2,panel3,panel4,panel6,p1,p2;
    private final JMenuBar menu;
    private final JMenu inicio,cambiar;
    private final JMenuItem inicioo,x,y;
    private JButton b;
    private final JFileChooser file;
    JComboBox combo1, combo2 ;
    boolean estado = true;
    lista d1 = new lista();
    Generar gg = new Generar();
    ChartPanel pp;
       ChartPanel []pan;
          ChartPanel []pan1;
    @Override
    public void setLocation(int x, int y) {
        super.setLocation(x, y); //To change body of generated methods, choose Tools | Templates.
    }
    public DashboardGriafica3(){
        combo1= new JComboBox();
        combo2 = new JComboBox();
        b = new JButton();
    file = new JFileChooser();
    panel1= new JPanel();
    panel6= new JPanel();
    p1= new JPanel();
    p2= new JPanel();
    panel2= new JPanel();
    panel3= new JPanel();
    panel4= new JPanel();
    menu = new JMenuBar();
    cambiar = new JMenu("Cambiar ejes");
    inicio= new JMenu("Opcion");
    inicioo= new JMenuItem("Imprimir");
    x= new JMenuItem("Establecer eje x ");
    y= new JMenuItem("Establecer eje y ");
    
    

    panel1.add(menu,BorderLayout.CENTER);
    menu.add(inicio,BorderLayout.CENTER);
    inicio.add(inicioo);
    this.setLayout(new BorderLayout());
    panel1.setLayout(new GridLayout(1,1,1,1));

    p1.setLayout(new GridLayout(1,1,100,100));
    p2.setLayout(new GridLayout(1,1,100,100));
    
     panel4.setLayout(new GridLayout(2,3,1,1));
    Border blackline, etched, raisedbevel, loweredbevel, empty;
    blackline = BorderFactory.createLineBorder(Color.black);
    etched = BorderFactory.createRaisedSoftBevelBorder();
     p1.setBorder(blackline);
     panel3.setBorder(etched);
     panel2.setBorder(etched);
    this.add(panel1,BorderLayout.NORTH);
    this.add(panel4,BorderLayout.CENTER);
    panel4.add(panel2,BorderLayout.WEST);
    panel4.add(panel3,BorderLayout.EAST);
     
    p1.setPreferredSize(new java.awt.Dimension(650,330));
    combo1.setPreferredSize(new java.awt.Dimension(650,20));
    combo2.setPreferredSize(new java.awt.Dimension(650,20));
    panel3.add(combo1,BorderLayout.NORTH);
    panel2.add(combo2,BorderLayout.NORTH);


       
   

       this.inicioo.addActionListener(this);
       this.inicio.addActionListener(this);
       this.combo1.addActionListener(this);
       this.combo2.addActionListener(this);
       this.cambiar.addActionListener(this);
  }

    @Override
    public void actionPerformed(ActionEvent e) {

      pan[5].setVisible(false);
        if(e.getSource().equals(combo1)){
              for(int i=0;i<5;i++){
         pan1[i].setVisible(false);
     }
              if(combo1.getSelectedIndex()==0){
                    
                   pan1[4].setVisible(true);
                     
              }else  if(combo1.getSelectedIndex()==1){
                     pan1[3].setVisible(true);
              }else  if(combo1.getSelectedIndex()==2){
                     pan1[2].setVisible(true);
              }else  if(combo1.getSelectedIndex()==3){
                     pan1[1].setVisible(true);
              }else  if(combo1.getSelectedIndex()==4){
                     pan1[0].setVisible(true);
              }
        }
        if(e.getSource().equals(combo2)){
             for(int i=0;i<5;i++){
         pan[i].setVisible(false);
     }
             
              if(combo2.getSelectedIndex()==0){
                    
                   pan[5].setVisible(true);
                     
              }else  if(combo2.getSelectedIndex()==1){
                     pan[4].setVisible(true);
              }else  if(combo2.getSelectedIndex()==2){
                     pan[3].setVisible(true);
              }else  if(combo2.getSelectedIndex()==3){
                     pan[2].setVisible(true);
              }else  if(combo2.getSelectedIndex()==4){
                     pan[1].setVisible(true);
              }else  if(combo2.getSelectedIndex()==5){
                     pan[0].setVisible(true);
              }
        }
       if(e.getSource().equals(inicioo)){

            int seleccion = file.showSaveDialog(null);
   
                if (seleccion == JFileChooser.APPROVE_OPTION){
                    File JFC = file.getSelectedFile();
                    String dir = JFC.getAbsolutePath();
                    imprimir imp = new imprimir();
                    imp.imprimir( panel4 ,dir);
                }
             
             //imp.imprimir();
      
   
       }
    }

    @Override
    public void tableChanged(TableModelEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

   public void datos(lista l1, lista l2, lista l3, lista l4, lista l5, lista l6, lista mm1,lista mm2,lista m3,lista m4,lista m5,lista m6, lista m7,lista_de_listas lli, ListaCircularSE c1, ListaCircularSE c2, Pila pl1,Pila pl2) {

       nodo_enlazada tel = lli.getcabeza();
       lista m1 = tel.getInfo();
       lista m2 = tel.getSig().getInfo();
       
       
       lista ll5 = new lista();
       lista ll6 = new lista();
       
       while(!(pl1.empty())){
           
          ll5.enlistar(pl1.peek());
          ll6.enlistar(pl2.peek());
          pl1.pop();
          pl2.pop();
       }
  pan1= gg.grafica_pastel(l1,l2,l3,l4,l5,l6);
pan= gg.grafica_barras(m1,m2,m3,m4,m5,m6,m7);
     m1.mostrar();
     m2.mostrar();
     m3.mostrar();
     m4.mostrar();
     m5.mostrar(); 
     m6.mostrar();
     m7.mostrar();
     for(int i=0;i<5;i++){
         pan[i].setPreferredSize(new java.awt.Dimension(650,290));
         pan1[i].setPreferredSize(new java.awt.Dimension(650,290));
         panel3.add(pan1[i]);
         panel2.add(pan[i]);
     }
     pan[5].setPreferredSize(new java.awt.Dimension(650,290));
      pan[5].setVisible(false);
      panel2.add(pan[5]);
       panel4.repaint();
       int c =0;
       nodo temp=m1.getcabeza();
     while(c!=5){
     c++;
     combo1.addItem(temp.getInfo().toString());
      temp=temp.getSig();}
     
     
     c=0;
     temp=l1.getcabeza();
     while(c!=6){
     c++;
     combo2.addItem(temp.getInfo().toString());
      temp=temp.getSig();}
   }

 

   


  

    
    
}
