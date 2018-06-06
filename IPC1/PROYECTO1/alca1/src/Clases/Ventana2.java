/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Clases;

import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.BoxLayout;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.event.TableModelEvent;
import javax.swing.event.TableModelListener;

/**
 *
 * @author HP
 */
class Ventana2 extends JFrame implements ActionListener,TableModelListener{
int w;
private final JLabel l1;
private final JLabel l2;
private final JLabel l3;
private final JTextField t1;
private final JTextField t2;
private final JTextField t3;
private final JTextField t4;
private final JTextField t5;
private final JTextField t6;
private final JComboBox c1;
private final JComboBox c2;
private final JComboBox c3;
private final JPanel p1;
private final JPanel p2;
private final JPanel p3;
private final JPanel p4;


   
    public Ventana2(){
        l1= new JLabel();
        l2= new JLabel();
        l3= new JLabel();
        t1 = new JTextField();
        t2 = new JTextField();
        t3 = new JTextField();
        t4 = new JTextField();
        t5 = new JTextField();
        t6 = new JTextField();
        p1 = new JPanel();
        p2 = new JPanel();
        p3 = new JPanel();
        p4 = new JPanel();
        l2.setText("Verdadero");
        l1.setText("Condicion");
        l3.setText("falso");
        t1.setText("dato 1");
        t2.setText("dato2");
        t2.setText("dato 1");
        
       c1 = new JComboBox();
       c2 = new JComboBox();
       c3 = new JComboBox();
        c1.addItem("<");
        c1.addItem(">");
        c1.addItem("=");
        c2.addItem("Suma");
        c2.addItem("Resta ");
        c2.addItem("Multiplicacion");
        c2.addItem("Division");
        c3.addItem("Suma");
        c3.addItem("Resta ");
        c3.addItem("Multiplicacion");
        c3.addItem("Division");
	p1.setLayout(new FlowLayout(FlowLayout.LEFT,10,0));
        p2.setLayout(new FlowLayout(FlowLayout.LEFT,10,0));
        p3.setLayout(new FlowLayout(FlowLayout.LEFT,10,0));
        p4.setLayout(new FlowLayout(FlowLayout.LEFT,10,0));
        this.setLayout(new GridLayout(2,1,1,1));
	p1.add(l1);
        p2.add(t1);
        p2.add(c1);
        p2.add(t2);
           this.add(p1);
           this.add(p2);
        p3.add(l2);
        
		this.add(p1);
   }

    @Override
    public void actionPerformed(ActionEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void tableChanged(TableModelEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
     public int tabl() {
     int o =0;
     return o;
     }
    
    
}
