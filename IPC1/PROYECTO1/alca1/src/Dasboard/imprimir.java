/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Dasboard;

import com.itextpdf.awt.PdfGraphics2D;
import com.itextpdf.text.Chunk;
import com.itextpdf.text.Document;
import com.itextpdf.text.Element;
import com.itextpdf.text.Image;
import com.itextpdf.text.PageSize;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.PdfContentByte;
import com.itextpdf.text.pdf.PdfTemplate;
import com.itextpdf.text.pdf.PdfWriter;
import java.awt.Graphics2D;
import java.io.FileOutputStream;
import javax.swing.JPanel;




/**
 *
 * @author HP
 */
public class imprimir  {

    public void imprimir(JPanel panel4, String dir) {
 Document document = new Document();
     JPanel g5 = new JPanel();

   try {
    PdfWriter writer = PdfWriter.getInstance(document, new FileOutputStream(dir));
    document.open();
    PdfContentByte contentByte = writer.getDirectContent();
    PdfTemplate template = contentByte.createTemplate(500, 500);
    Graphics2D g2 = template.createGraphics(500, 500);
    g2.scale(0.6, 0.6);
    panel4.print(g2);
    g2.dispose();
    contentByte.addTemplate(template, 30, 300);
} catch (Exception e) {
    e.printStackTrace();
}
finally{
    if(document.isOpen()){
        document.close();
    
    }}}}

//      FileOutputStream archivo = new FileOutputStream("hola1.pdf");
//      Document document = new Document();
//PdfWriter writer = PdfWriter.getInstance(document, archivo);
//      document.open();
//      //      documento.add(new Paragraph("Hola Mundo!"));
//      PdfContentByte cb = writer.getDirectContent();
//      cb.saveState();
//      Graphics2D g2 = cb.createGraphicsShapes(500, 500);
//      Shape oldClip = g2.getClip();
//      g2.clipRect(0, 0, 500, 500);
//     g5.setSize(100, 100);
//     g5.print(g2);
//      g2.setClip(oldClip);
//
//      g2.dispose();
//      cb.restoreState();
//      document.close();
//    } catch (Exception e) {
//      System.err.println(e.getMessage());
//    }
    

//      PdfWriter.getInstance(documento, archivo);
//      documento.open();
//      documento.add(new Paragraph("Hola Mundo!"));
//      //documento.add((Element) panel4);
//      documento.close();
       
    

//   public BufferedImage createImage(JPanel panel) {
//
//    int w = panel.getWidth();
//    int h = panel.getHeight();
//    BufferedImage bi = new BufferedImage(w, h, BufferedImage.TYPE_INT_RGB);
//    Graphics2D g = bi.createGraphics();
//    panel.paint(g);
//    return bi;
//}
    

   

   


