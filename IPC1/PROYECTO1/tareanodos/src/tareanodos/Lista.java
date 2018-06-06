package tareanodos;

import javax.swing.DefaultListModel;
import javax.swing.JList;

public class Lista {
	
	private Nodo inicio;
	private int cantidad;
	private int tama�o;
	private int igual;
	public void Lista(){
		inicio=null;
		tama�o=0;
	}
	
	
	//Obtener tama�o
	public int getTama�o(){
		return tama�o;
	}
	
	
	//Agregar Nodo
	public void AgregarNodo(int valor){
		Nodo nodo= new Nodo();//Instancear clase nodo
		nodo.setCantidad(valor);// guardamos valor en el nodo
		igual=0;
		if(getTama�o()==0){//Verificar si el tama�o de la lista es nulo
			nodo.setSiguiente(inicio);
			inicio=nodo;
		}else{//Si el nodo ya esta vacio
			Nodo aux= inicio;
            Nodo aux2=aux;//Nodo auxiliar para moverlo libremente
            while(aux.getSiguiente()!=null){//Repetir hasta el nodo final
            	aux2=aux2.getSiguiente();//Obtenemos el valor siguiente al nodo aux
              	if((aux.getCantidad()==valor) || (aux2.getCantidad()==valor)){//Comparacion de nodo anterior con valor y nodo siguiente
            		igual=1;
            		break;//Rompemos en caso de que el valor este en medio
            		
            	}
            	if((aux.getCantidad()<valor) && (aux2.getCantidad()>valor)){//Comparacion de nodo anterior con valor y nodo siguiente
            		igual=0;
            		break;//Rompemos en caso de que el valor este en medio
            		
            	}
            	
            	aux = aux.getSiguiente();	//Se sigue recorriendo la lista

            }
            if(igual==1){
            	
            }else{
                Nodo editar=aux.getSiguiente();//guardar el nodo siguiente a la posicion
                aux.setSiguiente(nodo);//se inserta el nodo en la posicion indicada
                nodo.setSiguiente(editar);//unir el dato con la demas lista
            }


		}
		tama�o++;
	}
	
	//Obtener el datos del Nodo
	public void getDatos(DefaultListModel modelo,JList list){
		if(getTama�o()>0){
			modelo.clear();
			list.setModel(modelo);
			Nodo aux= inicio;
			int i=0;
			while(aux != null){      
                // Avanza al siguiente nodo.
				if(aux.getCantidad()<0){
					
				}else{
					//Agrega datos a JList
					modelo.addElement(aux.getCantidad());
	        		list.setModel(modelo);
	                
				}
				aux = aux.getSiguiente();

            }
		}
	}
	
	

}