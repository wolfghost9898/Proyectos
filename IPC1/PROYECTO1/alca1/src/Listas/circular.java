/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Listas;

import java.io.Serializable;

/**
 *
 * @author HP
 */
public class circular implements Serializable{
    Cnodo cabeza, sig;
     int tam;
     public circular(){
     cabeza=null;
     sig=null;
     tam=0;
     
     }
     
     public void enlistar(Object info){
         Cnodo c= new Cnodo(); 
         Cnodo w;
         c.setInfo(info);
         if(cabeza==null){
             tam=0;
            c.setSig(cabeza); 
            w = cabeza;
            cabeza=c;
            tam++;
            }else {
            c.setSig(cabeza);
            cabeza=c;  
            tam++;
            }
             
          
     }
     public int tamaño(int tam){
     return tam;
     }
      public Cnodo getcabeza(){
     return cabeza;
     }
     public void mostrar(){
     Cnodo temp= cabeza;
     while(!(temp==null)){
     
     System.out.println(temp.getInfo()+" ");
     temp = temp.getSig();
     }
     }
      public void modificar(Cnodo temp, int n2) {
           Cnodo c = new Cnodo();
            c.setInfo(n2);
            
            c.setSig(temp.getSig().getSig());
           Cnodo tempp= cabeza;
     while(!(tempp==null)){
    
     System.out.print(tempp.getInfo()+" ");
     tempp = tempp.getSig();
     }
            
    }

    public void ordenar() {
        Cnodo temp = cabeza;
        Cnodo temp1;
        int n1,n2=200;
       
        
         while (temp!= null) {
            temp1 = temp.getSig();
             
            while (temp1 != null) {
                n1= Integer.parseInt((String) temp.getInfo());
                n2= Integer.parseInt((String) temp1.getInfo());
                System.out.print(temp.getInfo()+"\n");
             System.out.print(temp1.getInfo()+"\n");
             
                if (n2<n1) {
                    Object aux = temp.getInfo();
                    temp.info= n2;
                      temp1.info = n1;

                }
                temp1 = temp1.getSig();
            }
            temp = temp.getSig();
        }
         
    }


  

    public int [] datos() {
    Cnodo temp= cabeza;
    int[] list= new int [tam];
    int ns,i=0;
     while(!(temp==null)){
     ns=Integer.parseInt(temp.getInfo().toString());
     list[i]=ns;
     i++;
     temp = temp.getSig();
     }
        return list;
    
    }

    public void setnull() {
    cabeza=null;
    }
}
