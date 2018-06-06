import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.table.DefaultTableModel;

public class Control extends JFrame {
	private static JButton guardar,ordenarA,ordenarE;
	private static JLabel nombre,edad,altura;
	private static JTextField tnombre,tedad,taltura;
	private static JTable tabla;
	private static DefaultTableModel modelo;
	private static JScrollPane scroll;
	private String[][] registro;
	public Control(){
		super("Ventas");
		setSize(800,600);
		dispose();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Ejecutar();
	}
	public  void Ejecutar()
	{
		registro= new String[3][5];
		Container cp= getContentPane();
		JPanel panel=new JPanel();
		panel.setLayout(null);
		nombre= new JLabel();
		edad=new JLabel();
		altura= new JLabel();
		tnombre= new JTextField();
		tedad= new JTextField();
		taltura= new JTextField();
		guardar= new JButton("Guardar");
		ordenarA= new JButton("Ordenar por Altura");
		ordenarE= new JButton("Ordenar por Edad");
		//Tabla
		modelo= new DefaultTableModel();
		tabla= new JTable(modelo);
		scroll= new JScrollPane();
		tabla.setPreferredScrollableViewportSize(tabla.getPreferredSize());
		tabla.setFillsViewportHeight(true);
		
		//Agregar Columna
		modelo.addColumn("Nombre");
		modelo.addColumn("Edad");
		modelo.addColumn("Altura");
		
		//Otros
		nombre.setText("Nombre");
		edad.setText("Altura");
		altura.setText("Edad");

		//Posicion
		nombre.setBounds(80,10,150,20);
		edad.setBounds(80,50,150,20);
		altura.setBounds(80,90,150,20);
		tnombre.setBounds(150,10,150,20);
		taltura.setBounds(150, 50, 150, 20);
		tedad.setBounds(150,90,150,20);
		guardar.setBounds(100,110,100,20);
		ordenarA.setBounds(220,110,150,20);
		ordenarE.setBounds(400,110,150,20);
		scroll.setBounds(150,150,500,100);
		scroll.setViewportView(tabla);
		/*
		 * Click en los botones
		 */
		
		guardar.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				String INombre=tnombre.getText();
				String IAltura=taltura.getText();
				String IEdad=tedad.getText();
				boolean afirmacion=true;
				int i=0;
				while(afirmacion){
					if(registro[0][i]==null){
						registro[0][i]=INombre;
						registro[1][i]=IEdad;
						registro[2][i]=IAltura;
						HerenciaMatriz herencia= new HerenciaMatriz();
						herencia.setMatriz(registro);
						break;
					}
					i++;
				}
				tnombre.setText("");
				taltura.setText("");
				tedad.setText("");
				
			}
		});;
		
		//ORDENAR POR EDAD
		ordenarE.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				HerenciaMatriz herencia= new HerenciaMatriz();
				String[][] objeto= herencia.getMatriz();
				boolean recorrer=true;
				for(int i=0; i<5;i++){
					for(int j=0;j<5;j++){
						if((Integer.parseInt(objeto[1][i]))>(Integer.parseInt(objeto[1][j]))){
							int aux=Integer.parseInt(objeto[1][i]);
							String auxnom=objeto[0][i];
							String auxaltu=objeto[2][i];
							objeto[0][i]=objeto[0][j];
							objeto[2][i]=objeto[2][j];;
							objeto[1][i]=objeto[1][j];
							objeto[1][j]=String.valueOf(aux);
							objeto[0][j]=auxnom;
							objeto[2][j]=auxaltu;
						}
					}
				}
				AgregarATabla(objeto);
				
			}
		});;
		
		
		//Ordenar por Altura
		ordenarA.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				HerenciaMatriz herencia= new HerenciaMatriz();
				String[][] objeto= herencia.getMatriz();
				String[][] nuevamatriz= new String[3][2];
				nuevamatriz[0][0]=objeto[0][0];
				nuevamatriz[1][0]=objeto[1][0];
				nuevamatriz[2][0]=objeto[2][0];
				nuevamatriz[0][1]=objeto[0][4];
				nuevamatriz[1][1]=objeto[1][4];
				nuevamatriz[2][1]=objeto[2][4];
				AgregarATabla2(nuevamatriz);
				
			}
		});;
		
		
		//Agregar
		
		panel.add(scroll);
		panel.add(taltura);
		panel.add(nombre);
		panel.add(altura);
		panel.add(edad);
		panel.add(tedad);
		panel.add(tnombre);
		panel.add(ordenarA);
		panel.add(guardar);
		panel.add(ordenarE);
		cp.add(panel, BorderLayout.CENTER);
		
	}
	
	//Agregar A la Tabla
	public void AgregarATabla(String[][] objeto){
		Clear_Table1();
		for(int i=0;i<5;i++){
			Object [] newRow={objeto[0][i],objeto[1][i],objeto[2][i]};
			modelo.addRow(newRow);
		}
	}
	public void AgregarATabla2(String[][] objeto){
		Clear_Table1();
		for(int i=0;i<2;i++){
			Object [] newRow={objeto[0][i],objeto[1][i],objeto[2][i]};
			modelo.addRow(newRow);
		}
	}
	
	//LimpiarTabla
	private void Clear_Table1(){
	       for (int i = 0; i < tabla.getRowCount(); i++) {
	           modelo.removeRow(i);
	           i-=1;
	       }
	   }
	
}
