/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Listas;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author HP
 */
public class Datos {

    public void guardar(lista ing, String dir) {
       
    try {
            //guardar en archivo binariolfdofdof 
            System.out.println("casi g");
            FileOutputStream fileOut = new FileOutputStream(dir);
            ObjectOutputStream salida = new ObjectOutputStream(fileOut);
            salida.writeObject("Lista Enlazada Guardada");
            salida.writeObject(ing);
            salida.close();
            System.out.println("guardo");
        } catch (IOException ex) {
         
        }
    }

    public lista abrir(File Tipo) {
    //  leer archivo binario
           lista l2= new lista();
           l2.setnull();
          try{
            FileInputStream fileIn = new FileInputStream(Tipo);
            ObjectInputStream entrada = new ObjectInputStream(fileIn);
            String str = (String)entrada.readObject();
             l2 = (lista)entrada.readObject();
            System.out.println("Leyendo de archivo tabla.dat");
            
            System.out.println("Mensaje: " + str);
            entrada.close();
        } catch( IOException | ClassNotFoundException ex){         
        }
          return l2;
    }
    
}
