/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Dasboard;

import Listas.lista;
import Listas.nodo;
import Listas.simple;
import java.awt.Color;
import java.io.IOException;
import javax.sound.midi.Soundbank;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.CategoryPlot;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.chart.renderer.category.BarRenderer;
import org.jfree.chart.renderer.category.StandardBarPainter;
import org.jfree.data.category.DefaultCategoryDataset;
import org.jfree.data.general.DefaultPieDataset;

/**
 *
 * @author HP
 */
public class GenerarGraficas {
    
    
    public ChartPanel pie(lista l){
         ChartPanel pi = null;
         DefaultPieDataset dat = new DefaultPieDataset();
         dat.setValue("1", 23.5);
         
         return pi;
        
    }
 

    public ChartPanel[] gra(lista d1) {
         
        ChartPanel []ps =new ChartPanel[6];
        int h=1;

       nodo temp= d1.getcabeza().getSig();
       int n=15,c=1;
       nodo temp1 =getnodog(15,d1);
       nodo temp2 =getnodog(29,d1);
       nodo temp3 =getnodog(43,d1);
       nodo temp4 =getnodog(57,d1);
       nodo temp5 =getnodog(71,d1);
       nodo temp6 =getnodog(85,d1);
     simple l1 = new simple();
     simple l2 = new simple();
     simple l3 = new simple();
     simple l4 = new simple();
     simple l5 = new simple();
     simple l6 = new simple();
     simple l7 = new simple();
       
     while(temp!=null && h!=14){
         h++;
       l1.enlistar(temp.getInfo());
       l2.enlistar(temp1.getInfo());
       l3.enlistar(temp2.getInfo());
       l4.enlistar(temp3.getInfo());
       l5.enlistar(temp4.getInfo());
       l6.enlistar(temp5.getInfo());
       l7.enlistar(temp6.getInfo());
       
     temp=temp.getSig();
     temp1=temp1.getSig();
     temp2=temp2.getSig();
     temp3=temp3.getSig();
     temp4=temp4.getSig();
     temp5=temp5.getSig();
     temp6=temp6.getSig();
     }
     
     
     ps[0]=pa(l1,l7);
     ps[1]=pa(l2,l7);
     ps[2]=pa(l3,l7);
     ps[3]=pa(l4,l7);
     ps[4]=pa(l5,l7);
     ps[5]=pa(l6,l7);
 
     ps[0].setBounds(0, 0, 25,25);
        return ps;
       
    }

    private ChartPanel pa(simple l, simple mes) {
        JFreeChart chart;
        ChartPanel panel;  
        nodo temp1 = l.getcabeza().getSig();
        nodo temp2 = mes.getcabeza().getSig();
        DefaultCategoryDataset dataset = new DefaultCategoryDataset();
       dataset.clear();
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
         dataset.setValue(val, "", ""+temp2.getInfo());
        temp1 = temp1.getSig();
        temp2 = temp2.getSig();
        }
    
    chart = ChartFactory.createBarChart(l.getcabeza().getInfo().toString()
             , "", "", dataset, PlotOrientation.VERTICAL,
             false, false, false);
       chart.setBackgroundPaint(Color.WHITE);   
      BarRenderer.setDefaultBarPainter(new StandardBarPainter());
     
       CategoryPlot p = chart.getCategoryPlot();
     p.setBackgroundPaint(Color.WHITE);
     panel = new ChartPanel(chart);
     panel.setBounds(0, 0, 50, 50);
    return panel;
    }

    
    private nodo getnodog(int n,lista d1) {
        nodo nor = d1.getcabeza();
 
       
     for(int i=0;i<n;i++){
         if(nor!=null){
         nor= nor.getSig();
         
         }
     }
     System.out.println(nor.getInfo());

    return nor;
    }

    ChartPanel[] gra1(lista d1) {
     int j=0;
        ChartPanel []ps =new ChartPanel[6];
        int h=1;

       nodo temp= d1.getcabeza().getSig();
       int n=15,c=1;
       nodo temp1 =getnodog(15,d1);
       nodo temp2 =getnodog(29,d1);
       nodo temp3 =getnodog(43,d1);
       nodo temp4 =getnodog(57,d1);
       nodo temp5 =getnodog(71,d1);
       nodo temp6 =getnodog(85,d1);
     simple l1 = new simple();
     simple l2 = new simple();
     simple l3 = new simple();
     simple l4 = new simple();
     simple l5 = new simple();
     simple l6 = new simple();
     simple l7 = new simple();
        
     while(temp!=null && h!=14){
         h++;
       l1.enlistar(temp.getInfo());
       l2.enlistar(temp1.getInfo());
       l3.enlistar(temp2.getInfo());
       l4.enlistar(temp3.getInfo());
       l5.enlistar(temp4.getInfo());
       l6.enlistar(temp5.getInfo());
       l7.enlistar(temp6.getInfo());
       
     temp=temp.getSig();
     temp1=temp1.getSig();
     temp2=temp2.getSig();
     temp3=temp3.getSig();
     temp4=temp4.getSig();
     temp5=temp5.getSig();
     temp6=temp6.getSig();
     }
     
     
     ps[0]=pa1(l1,l7);
     ps[1]=pa1(l2,l7);
     ps[2]=pa1(l3,l7);
     ps[3]=pa1(l4,l7);
     ps[4]=pa1(l5,l7);
     ps[5]=pa1(l6,l7);
     ps[0].setBounds(0, 0, 25,25);

        return ps;
       
    }

    private ChartPanel pa1(simple l, simple mes) {
   JFreeChart chart;
        ChartPanel panel;  
        nodo temp1 = l.getcabeza().getSig();
        nodo temp2 = mes.getcabeza().getSig();
        DefaultCategoryDataset dataset = new DefaultCategoryDataset();
       dataset.clear();
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
         dataset.setValue(val, "", ""+temp2.getInfo());
        temp1 = temp1.getSig();
        temp2 = temp2.getSig();
        }
    
    chart = ChartFactory.createBarChart(l.getcabeza().getInfo().toString()
             , "", "", dataset, PlotOrientation.HORIZONTAL,
             false, false, false);
       chart.setBackgroundPaint(Color.WHITE);   
      BarRenderer.setDefaultBarPainter(new StandardBarPainter());
     
       CategoryPlot p = chart.getCategoryPlot();
     p.setBackgroundPaint(Color.WHITE);
     panel = new ChartPanel(chart);
          panel.setBounds(0, 0, 50, 50);
    return panel;
    }


    }
      
      
      
      























































     //dd
    

