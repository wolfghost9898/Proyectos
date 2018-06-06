
package Listas;



public class Pila {
    
    Object arr[];
    int top; 
    
    
    public Pila(/*int n*/ ){
       arr = new Object[10];
        top = 0;   
    }
    
    public boolean empty(){
        if(top==0){
            return true;}
        else{
            return false;
        }
    }
    
    public void push(Object str){
        if(top < arr.length){
        arr[top] = str;
        top++;
        }
        else{
            Object temporal[] = new Object[arr.length +2];
            for(int i=0; i<arr.length;i++){
                temporal[i] =arr[i];     
            }
            arr =temporal;
            arr[top]= str;
            top ++;
        }
    }
    
    public Object peek(){
        if(top >0)
        return arr[top-1];
        else
            return null;
    }
    
    public Object pop(){
        Object temp=null;
        if(top>0){
            temp = arr[top-1];
            arr[top-1] =null;
            top--;
        }
        return temp;
    }
    
}



