/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Clases;

import Listas.Cnodo;
import Listas.lista;
import Listas.nodo;
import java.awt.Color;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.CategoryPlot;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.chart.renderer.category.BarRenderer;
import org.jfree.chart.renderer.category.StandardBarPainter;
import org.jfree.data.category.DefaultCategoryDataset;
import org.jfree.data.general.DefaultPieDataset;

/***
 * @author
  HP
 */
class Generar {
//   public ChartPanel[] grafica_barras(lista l1, lista l2, lista l3, lista l4, lista l5, lista l6) {
//   ChartPanel[] l;
//       
//       return  l;
//  
//    }

    public ChartPanel[] grafica_pastel(lista l1, lista l2, lista l3, lista l4, lista l5, lista l6) {
   ChartPanel[] ll = new ChartPanel[5];
   ll[0]= poi(l2);
   ll[1]= poi(l3);
   ll[2]= poi(l4);  
   ll[3]= poi(l5);
   ll[4]= poi(l6);
   return ll;
    
    }
    private ChartPanel poi(lista l2) {
        JFreeChart chart;
        ChartPanel panel; 
         DefaultPieDataset data = new DefaultPieDataset();
         nodo temp = l2.getcabeza();
         int n1=0;int p1=0;
         int w=0;
            while(temp!=null && w!=6){
                w++;
            if(Double.parseDouble(temp.getInfo().toString())>=61){
           n1++;
       }else{p1++;}
            temp=temp.getSig();
    }   
            data.setValue( "Ganaron",n1);
            data.setValue( "Perdieron",p1);
    chart = ChartFactory.createPieChart3D(temp.getInfo().toString(), data, true, true, true);
     panel = new ChartPanel(chart);
            return panel;
    }

    ChartPanel[] grafica_barras(lista m1, lista m2, lista m3, lista m4, lista m5, lista m6, lista m7) {
    
    ChartPanel[] ll = new ChartPanel[6];
   ll[0]= dmc(m1, m2);
   ll[1]= dmc(m1, m3);
   ll[2]= dmc(m1,m4);  
   ll[3]= dmc(m1,m5);
   ll[4]= dmc(m1,m6);
   ll[5]= dmc(m1,m7);
   return ll;
    
    }

    private ChartPanel dmc(lista m1, lista m2) {
    JFreeChart chart;
        ChartPanel panel;  
        int bn=0;
        nodo temp1 = m1.getcabeza();
        nodo temp2 = m2.getcabeza();
        DefaultCategoryDataset dataset = new DefaultCategoryDataset();
       dataset.clear();
        while(temp1!=null && bn!=5){
            bn++;
         dataset.setValue(Double.parseDouble(temp2.getInfo().toString()), "", ""+temp1.getInfo());
        temp1 = temp1.getSig();
        temp2 = temp2.getSig();
        }
    
    chart = ChartFactory.createBarChart3D(temp2.getInfo().toString()
             , "", "", dataset, PlotOrientation.VERTICAL,
             false, false, false);
       chart.setBackgroundPaint(Color.white);   
      BarRenderer.setDefaultBarPainter(new StandardBarPainter());
     
       CategoryPlot p = chart.getCategoryPlot();
     p.setBackgroundPaint(Color.WHITE);
     panel = new ChartPanel(chart);
          panel.setBounds(0, 0, 50, 50);
    return panel;
    
    
    }
        
    
}
