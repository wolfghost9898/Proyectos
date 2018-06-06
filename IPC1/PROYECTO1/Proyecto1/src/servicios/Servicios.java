package servicios;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.Vector;

import javax.swing.DefaultListModel;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.ListSelectionModel;

import Auxiliares.MatrizHere;

public class Servicios extends JFrame{
	private DefaultListModel modelo;
	private JScrollPane scrolllista;
	private JList servi;
	private int fila;
	public Servicios()
	{
	super("SERVICIOS");
	setSize(200,200);
	dispose();
	setResizable(false);
	services();
	}
	
	public void services()
	{
		Container cp= getContentPane();
		JPanel inter= new JPanel();
		inter.setLayout(null);
		
		servi= new JList();
		servi.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		
		//Modelo
		modelo= new DefaultListModel();
		
		//Scroll
		scrolllista= new JScrollPane();
		scrolllista.setViewportView(servi);
		
		
				Object categoria = JOptionPane.showInputDialog(null,"Seleccione Una Categoria",
				"Categorias", JOptionPane.QUESTION_MESSAGE, null,
				new Object[] { "Seleccione","Digital Music", "Electronics", "Gift Card","PC GAME" },"Seleccione");
				String seleccion=categoria.toString();
				
				if(seleccion.equals("Digital Music")){
					modelo.clear();
					modelo.addElement("Musica Online");
					servi.setModel(modelo);
				}else if(seleccion.equals("Electronics")){
					modelo.clear();
					modelo.addElement("Reparacion");
					servi.setModel(modelo);
				}else if(seleccion.equals("Gift Card")){
					modelo.clear();
					modelo.addElement("Enviar Tarjetas a Domicilio");
					servi.setModel(modelo);
				}else if(seleccion.equals("PC GAME")){
					modelo.clear();
					modelo.addElement("Cambio de Juego por Juego");
					servi.setModel(modelo);
				}else{
					JOptionPane.showMessageDialog(null,"Seleccione alguna opcion");
				}
				
		servi.addMouseListener(new MouseAdapter(){
			public void mouseClicked(MouseEvent evt){
				JList subproducto=(JList)evt.getSource();
				if(evt.getClickCount()==2){
					int index=subproducto.locationToIndex(evt.getPoint());
					Object o=subproducto.getModel().getElementAt(index);
					int dialogResult=JOptionPane.showConfirmDialog(null, "Desea Comprar este Servicio?");
					if(dialogResult==JOptionPane.YES_OPTION){
						MatrizHere herencia= new MatrizHere();
						fila=-1;
						Vector servicios= herencia.getServicios();
						if(servicios.size()>0){
							for(int i=0;i<servicios.size();i++){
								Object[] subpro= (Object[]) servicios.elementAt(i);
								if(subpro[0].toString()==(o.toString())){
									fila=i;
									break;
								}
							}
							if(fila>=0){
								Object[] subpro= (Object[]) servicios.elementAt(fila);
								int cant=(int)subpro[2]+1;
								Object[] buy={subpro[0],subpro[1],cant};
								servicios.setElementAt(buy, fila);;
							}else{
								Object[] buy={o.toString(),150,1};
								servicios.addElement(buy);
							}
						}else{
							Object[] buy={o.toString(),150,1};
							servicios.addElement(buy);
						}
						
						
						herencia.setServicios(servicios);
						JOptionPane.showMessageDialog(null,"Compra Realizada Exitosamente");

					}
				}
			}
		});
		scrolllista.setBounds(50,40,100,100);
		inter.add(scrolllista);
		cp.add(inter,BorderLayout.CENTER);

	}
}


