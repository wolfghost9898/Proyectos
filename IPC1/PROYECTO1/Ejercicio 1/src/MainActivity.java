import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JTextField;


public class MainActivity {
	static JFrame ventana;
	static JTextField ingresar;
	static JButton guardar,eliminar;
	
	static int elemento;
	static Lista lista;
	
	public static void main(String[] args){
		ventana= new JFrame();
		ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);  
		ventana.setLocationRelativeTo(null);      
		ventana.setLayout(null); 
		ventana.setSize(500,500);
		Ejecutar();
	}
	
	public static void Ejecutar(){
		lista= new Lista();
		
		ingresar= new JTextField();
		guardar= new JButton("Guardar");
		eliminar= new JButton("Eliminar");
		
		ingresar.setBounds(0, 0, 100, 30);
		guardar.setBounds(0,50,80,50);
		eliminar.setBounds(100,50,80,50);
		
		ventana.add(ingresar);
		ventana.add(eliminar);
		ventana.add(guardar);
		
		guardar.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				elemento=Integer.parseInt(ingresar.getText());			
				lista.Guardar(elemento);
				lista.mostrarDatosInicio();
			}
			
		});
		
		eliminar.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				elemento=Integer.parseInt(ingresar.getText());			
				lista.Borrar(elemento);
				lista.mostrarDatosInicio();
			}
			
		});
		
		
		ventana.setVisible(true);
	}
}
