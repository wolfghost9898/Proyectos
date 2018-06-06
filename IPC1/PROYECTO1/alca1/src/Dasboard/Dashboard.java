package Dasboard;

import Listas.Cnodo;
import Listas.Datos;
import Listas.circular;
import Listas.lista;
import Listas.nodo;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import javax.sound.midi.Soundbank;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JTable;
import javax.swing.border.Border;
import javax.swing.event.TableModelEvent;
import javax.swing.event.TableModelListener;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.text.Document;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartMouseEvent;
import org.jfree.chart.ChartMouseListener;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.entity.CategoryItemEntity;
import org.jfree.chart.entity.ChartEntity;
import org.jfree.chart.entity.XYItemEntity;
import org.jfree.chart.plot.CategoryPlot;
import org.jfree.chart.plot.PiePlot;
import org.jfree.chart.renderer.category.BarRenderer;
import org.jfree.chart.renderer.category.StandardBarPainter;
import org.jfree.data.general.DefaultPieDataset;

public class Dashboard extends JFrame implements ActionListener,TableModelListener{

     private final JPanel panel1, panel2,panel3,panel4,panel6,p1,p2;
    private final JMenuBar menu;
    private final JMenu inicio,cambiar;
    private final JMenuItem inicioo,x,y;
    private JButton b;
    private final JFileChooser file;
    boolean estado = true;
    lista d1 = new lista();
    GenerarGraficas g = new GenerarGraficas();
    ChartPanel pp;
    @Override
    public void setLocation(int x, int y) {
        super.setLocation(x, y); //To change body of generated methods, choose Tools | Templates.
    }
    public Dashboard(){
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
    inicio.add(cambiar);
    cambiar.add(x);
    cambiar.add(y);
    this.setLayout(new BorderLayout());
    panel1.setLayout(new GridLayout(1,1,1,1));
    panel2.setLayout(new GridLayout(1,2,100,100));
    p1.setLayout(new GridLayout(1,1,100,100));
    p2.setLayout(new GridLayout(1,1,100,100));
    
    panel4.setLayout(new GridLayout(2,2,1,1));
    Border blackline, etched, raisedbevel, loweredbevel, empty;
    blackline = BorderFactory.createLineBorder(Color.black);
    etched = BorderFactory.createRaisedSoftBevelBorder();
     p1.setBorder(blackline);
     panel3.setBorder(etched);
     panel2.setBorder(etched);
    this.add(panel1,BorderLayout.NORTH);
    this.add(panel4,BorderLayout.CENTER);
    panel4.add(panel2,BorderLayout.NORTH);
    panel4.add(panel3,BorderLayout.CENTER);
     
    p1.setPreferredSize(new java.awt.Dimension(650,330));
 
  panel3.add(panel6);


       
   

       this.inicioo.addActionListener(this);
       this.inicio.addActionListener(this);
       this.cambiar.addActionListener(this);
       this.x.addActionListener(this);
       this.y.addActionListener(this);    }

    @Override
    public void actionPerformed(ActionEvent e) {
      
        if(e.getSource().equals(x)){estado=true;
           }
        if(e.getSource().equals(y)){estado=false;}
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

   public void datos(lista g1, final circular b1,final circular b2) {
      
    d1 = g1;


     ChartPanel bar1 = setn(b1,b2);
     
       final ChartPanel []panes= g.gra(d1);
     final ChartPanel []panes1= g.gra1(d1);
//                               panel3.removeAll();
//                               panel3.add(panes[0]);
//                                panel4.repaint();
         bar1.addChartMouseListener(new ChartMouseListener() {
                    
    
            public void chartMouseClicked(ChartMouseEvent cme) {
                for(int i=0;i<6;i++){
         panes[i].setVisible(false);
         panes1[i].setVisible(false);
         
         }panel4.repaint();
                    ChartEntity entity = cme.getEntity();

                           System.out.println(entity);
                           if (estado==true){
                    if(entity.toString().equals("PieSection: 0, 0(San Francisco)")){
                         panel4.repaint();
                        panes[0].setVisible(true);
                        panel3.setVisible(true);
                         panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 1(Milpitas)")){
                        panes[1].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 2(Fremont)")){
                    panes[2].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 3(Cupertino)")){
                    panes[3].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 4(Berkeley)")){
                    panes[4].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 5(Atherton)")){
                    panes[5].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}

                           }else if(estado==false){
                               if(entity.toString().equals("PieSection: 0, 0(San Francisco)")){
                        panes1[0].setVisible(true);
                        panel3.setVisible(true);
                         panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 1(Milpitas)")){
                        panes1[1].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 2(Fremont)")){
                    panes1[2].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 3(Cupertino)")){
                    panes1[3].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 4(Berkeley)")){
                    panes1[4].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    else if(entity.toString().equals("PieSection: 0, 5(Atherton)")){
                    panes1[5].setVisible(true);
                        panel3.setVisible(true);
                        panel4.repaint();}
                    }
            }

            @Override
            public void chartMouseMoved(ChartMouseEvent cme) {
           }

      
        });

         for(int i=0;i<6;i++){
         panes[i].setPreferredSize(new java.awt.Dimension(650,330));
         panes1[i].setPreferredSize(new java.awt.Dimension(650,330));
         panel3.add(panes[i]);
         panel3.add(panes1[i]);
         panes[i].setVisible(false);
         panes1[i].setVisible(false);
         }
              
       panel3.setVisible(false);
       panel2.add(bar1);
       panel2.repaint();

       

   }

    private ChartPanel setn(circular b1, circular b2) {
        ChartPanel bar1;
        Cnodo valot =b1.getcabeza();
    DefaultPieDataset data = new DefaultPieDataset();
    Cnodo temp = b1.getcabeza();
    Cnodo temp1 = b2.getcabeza();
    JFreeChart chart;
    while(temp1!=null){
     String cad = temp1.getInfo().toString();
         String sp []; 
         sp = cad.split("\\$");
         double val=0;
         try{
          val = Double.parseDouble(sp[1]);
         }catch(NumberFormatException ex){
             System.out.println("error casteo");
         }
         data.setValue(temp.getInfo().toString(), val);
        temp1 = temp1.getSig();
        temp = temp.getSig();
    }
    valot = getnodog(6,b1); 
    chart = ChartFactory.createPieChart(valot.getInfo().toString(), data, true, true, true);

    

     //  chart.setBackgroundPaint(Color.WHITE);   
      //BarRenderer.setDefaultBarPainter(new StandardBarPainter());
     

     bar1 = new ChartPanel(chart);
    return bar1;
    }
     private Cnodo getnodog(int n,circular d1) {
        Cnodo nor = d1.getcabeza();
 
       
     for(int i=0;i<n;i++){
         if(nor!=null){
         nor= nor.getSig();
         
         }
     }
     System.out.println(nor.getInfo());
     
    return nor;
    }
}
