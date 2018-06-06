import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.DefaultListModel;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.border.EmptyBorder;
import javax.swing.JList;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.swing.JTextField;
import javax.swing.SwingUtilities;
import javax.swing.JButton;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class SALA extends JFrame implements Runnable {

	private JPanel contentPane;
	private JTextField textField;
	private JList list;
	private DefaultListModel modelo;
	private String ultimo,ultimo2,ruta;
	private JScrollPane scrollPane;
	private Thread hilo;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					SALA frame = new SALA(null,null);
					frame.setVisible(true);
					frame.setTitle("ChatRoom");
					frame.setLocationRelativeTo(null);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 * @throws IOException 
	 * @throws FileNotFoundException 
	 */
	public SALA(String ruta,String nickname) throws FileNotFoundException, IOException {
		setTitle("Chat");
		this.ruta=ruta;
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 590, 379);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(new BorderLayout(0, 0));
		
		scrollPane = new JScrollPane();
		contentPane.add(scrollPane);
		
		list = new JList();
		modelo= new DefaultListModel();
		
		
		scrollPane.setViewportView(list);
		
		llenarList(ruta);
		
		JPanel panel = new JPanel();
		contentPane.add(panel, BorderLayout.SOUTH);
		panel.setLayout(new BorderLayout(0, 0));
		
		textField = new JTextField();
		panel.add(textField, BorderLayout.CENTER);
		textField.setColumns(10);
		
		JButton btnNewButton = new JButton("Enviar");
		btnNewButton.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent arg0) {
				String mensaje=textField.getText();
				try {
					SendMessage(mensaje,nickname,ruta);
					textField.setText("");
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
			}
		});
		panel.add(btnNewButton, BorderLayout.EAST);

	}
	
	public void llenarList(String archivo)  throws FileNotFoundException, IOException {
		String cadena;
        FileReader f = new FileReader(archivo);
        BufferedReader b = new BufferedReader(f);
        while((cadena = b.readLine())!=null) {
        	modelo.addElement(cadena);
        	ultimo=cadena;
        }
        list.setModel(modelo);
        //Baja el Scroll hacia el ultimo Mensaje
        int lastIndex = list.getModel().getSize() - 1;
        if (lastIndex >= 0) {
        	list.ensureIndexIsVisible(lastIndex);
        }
        
        
        hilo= new Thread(this);
        hilo.start();
        b.close();
		
		
	}

	@Override
	public void run() {
		Thread ct=Thread.currentThread();
		if(ct==hilo){
			while(true){
				try{
					String cadena;
			        FileReader f = new FileReader(ruta);
			        BufferedReader b = new BufferedReader(f);
			        while((cadena = b.readLine())!=null) {
			        	ultimo2=cadena;
			        }
			        if(ultimo!=null){
				        if(!(ultimo.equals(ultimo2))){
				        	modelo.addElement(ultimo2);
				        	list.setModel(modelo);
				        	//Baja el scroll cada que entre nuevo mensaje
				        	SwingUtilities.invokeLater(new Runnable() { public void run() { 
				        		scrollPane.getVerticalScrollBar().setValue(scrollPane.getVerticalScrollBar().getMaximum());
				            }
				        }); 
				        	//Fin Scroll Bottom
				        	ultimo=ultimo2;		     
				        }
			        }else{
			        	ultimo="";
			        }

					Thread.sleep(1000);
				}catch(InterruptedException rr){} 
				catch (FileNotFoundException e) {}
				catch (IOException e) {}
			}
		}

	}
	
	public void SendMessage(String mensaje,String nickname,String ruta) throws IOException{
		BufferedWriter out = null;   
		try {   
		    out = new BufferedWriter(new FileWriter(ruta, true));   
		    Date date= new Date();
		    DateFormat hour=new SimpleDateFormat("dd/MM/yyyy-HH:mm:ss");
		    out.write("[ "+hour.format(date)+"] "+nickname+": "+mensaje);   
		    out.newLine();
		} catch (IOException e) {   
		    // error processing code   
		} finally {   
		    if (out != null) {   
		        out.close();   
		    }   
		}
	}
	
	
	
}
