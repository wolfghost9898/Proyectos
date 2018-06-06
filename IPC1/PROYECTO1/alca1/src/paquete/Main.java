/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package paquete;
import Clases.Ventana1;
import UpperEssential.UpperEssentialLookAndFeel;
import javax.swing.UIManager;
/**
 *
 * @author HP
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
       
     Ventana1 ven= new Ventana1();
     ven.setVisible(true);
     ven.setBounds(200,10,900,700);
    
     try{
   UIManager.setLookAndFeel(new UpperEssentialLookAndFeel());
}catch(Exception e){
  e.printStackTrace();
} 
    }
    
}
