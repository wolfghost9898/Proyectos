package Clases;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */



import java.awt.Color;
import java.awt.Component;
import java.awt.Font;
import java.awt.font.TextAttribute;
import java.util.Map;
import javax.swing.JTable;
import javax.swing.table.DefaultTableCellRenderer;

/**
 *
 * @author HP
 */
public class Render extends DefaultTableCellRenderer{
  Font normal = new Font( "Arial",Font.PLAIN,12 );
    Font negrilla = new Font( "Helvetica",Font.BOLD,12 );
    Font cursiva = new Font( "Times new roman",Font.ITALIC,12 );
    Ventana1 RENDER;
    String cadena;
    
    public Render() {
           this.RENDER=RENDER;
    }

    Render(int i) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    

    @Override 
    public Component getTableCellRendererComponent ( JTable table, Object value, boolean selected, boolean focused, int row, int column ) 
    {
        setEnabled(table == null || table.isEnabled()); 
        table.setFont(normal);//tipo de fuente
        setHorizontalAlignment(2);//derecha
        
        //BOOLEANO DE NEGRITA.
        if (this.RENDER.BotonNegrita[row][column]==true) {
               table.setFont(negrilla);
        }
        
        //BOOLEANO DE CURSIVA.
        if (this.RENDER.BotonCursiva[row][column]==true) {
               Font font = table.getFont();
               Map DatoConFuenteActual = font.getAttributes();
               DatoConFuenteActual.put(TextAttribute.POSTURE,TextAttribute.POSTURE_OBLIQUE);
               table.setFont(font.deriveFont(DatoConFuenteActual));
               table.setForeground(Color.black);
        }
        
        //BOOLEANO DE SUBRAYADO.
        if (this.RENDER.BotonSubrayar[row][column]==true) {
              Font font = table.getFont();
              Map DatoConFuenteActual = font.getAttributes();
              DatoConFuenteActual.put(TextAttribute.UNDERLINE,TextAttribute.UNDERLINE_ON);
              table.setFont(font.deriveFont(DatoConFuenteActual));
              table.setForeground(Color.black);  
        }
        
        if (this.RENDER.BotonSubrayar[row][column]==true) {
              Font font = table.getFont();
              Map DatoConFuenteActual = font.getAttributes();
              DatoConFuenteActual.put(TextAttribute.UNDERLINE,TextAttribute.UNDERLINE_ON);
              table.setFont(font.deriveFont(DatoConFuenteActual));
              table.setForeground(Color.black);  
        }        
        //

        super.getTableCellRendererComponent(table, value, selected, focused, row, column);         
        return this;
 }
    
 

}