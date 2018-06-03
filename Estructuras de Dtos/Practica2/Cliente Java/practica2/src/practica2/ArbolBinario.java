/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package practica2;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.JSONValue;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
/**
 *
 * @author wolfghost
 */
public class ArbolBinario {
    
    Node buildUtil(JSONArray in,JSONArray post,int inStrt,int inEnd,Index pIndex){
        if(inStrt>inEnd) return null;
        JSONObject inner=(JSONObject)post.get(pIndex.index);
        int carnet=(int)(long)inner.get("carnet");
        String nombre=String.valueOf(inner.get("Nombre"));
        String nota=String.valueOf(inner.get("Nota"));
        Node node=new Node(nombre,nota,carnet);
        (pIndex.index)--;
        
        int iIndex=search(in,inStrt,inEnd,node.carnet);
        node.derecha=buildUtil(in,post,iIndex+1,inEnd,pIndex);
        node.izquierda=buildUtil(in,post,inStrt,iIndex-1,pIndex);
        return node;
    }
    
    Node buildTree(JSONArray in,JSONArray post,int n){
        Index pIndex=new Index();
        pIndex.index=n-1;
        return buildUtil(in,post,0,n-1,pIndex);
    }
    
    int search(JSONArray arr,int strt,int end,int value){
        int i;
        for(i=strt;i<=end;i++){
            JSONObject inner=(JSONObject)arr.get(i);
            int carnet=(int)(long)inner.get("carnet");
            if(carnet==value) break;
        }
        return i;
    }
    
    void preOrden(Node node){
        if(node==null)
            return;
        System.out.println(node.carnet+" ");
        preOrden(node.izquierda);
        preOrden(node.derecha);
    }
}
