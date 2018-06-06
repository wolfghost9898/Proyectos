import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JTextField;
import javax.swing.JLabel;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JComboBox;
import javax.swing.JFileChooser;

import java.awt.Choice;
import javax.swing.DefaultComboBoxModel;
import javax.swing.JButton;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class Chat extends JFrame {

	private JPanel contentPane;
	private JTextField textField;
	private JTextField textField_1;
	private String ruta="";
	private String rut;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Chat frame = new Chat();
					frame.setTitle("Chat");
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Chat() {
		setTitle("Room Chat");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setLayout(null);
		setContentPane(contentPane);
		
		textField_1 = new JTextField();
		textField_1.setBounds(99, 11, 135, 20);
		contentPane.add(textField_1);
		textField_1.setColumns(10);
		
		JLabel lblNickname = new JLabel("NickName: ");
		lblNickname.setFont(new Font("Tahoma", Font.BOLD, 12));
		lblNickname.setBounds(10, 14, 79, 14);
		contentPane.add(lblNickname);
		
		JLabel lblSalaDeChat = new JLabel("Sala de Chat");
		lblSalaDeChat.setFont(new Font("Tahoma", Font.BOLD, 12));
		lblSalaDeChat.setBounds(10, 42, 91, 14);
		contentPane.add(lblSalaDeChat);
		
		JComboBox comboBox = new JComboBox();
		comboBox.setModel(new DefaultComboBoxModel(new String[] {"Nueva Sala", "Sala Existente"}));
		comboBox.setBounds(99, 42, 135, 20);
		
		JPanel panel = new JPanel();
		panel.setLayout(null);
		panel.setBounds(36, 99, 345, 59);
		panel.setVisible(false);
		contentPane.add(panel);
		
		JLabel lblTipoDeChat = new JLabel("Tipo de Chat: ");
		lblTipoDeChat.setFont(new Font("Tahoma", Font.BOLD, 12));
		lblTipoDeChat.setBounds(10, 11, 96, 14);
		panel.add(lblTipoDeChat);
		
		JComboBox comboBox_1 = new JComboBox();
		comboBox_1.setModel(new DefaultComboBoxModel(new String[] {"Chat Normal", "Chat Encriptado", "Chat Privado"}));
		comboBox_1.setBounds(101, 9, 120, 20);
		panel.add(comboBox_1);
		
		comboBox.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				if(comboBox.getSelectedItem().equals("Nueva Sala")){
					JFileChooser guardar=new JFileChooser();
					try{
						if(guardar.showSaveDialog(null)==guardar.APPROVE_OPTION){
							ruta=guardar.getSelectedFile().getAbsolutePath();
							panel.setVisible(true);
						}
					}catch(Exception ex){
						ex.printStackTrace();
					}
				}else if(comboBox.getSelectedItem().equals("Sala Existente")){
					JFileChooser guardar=new JFileChooser();
					try{
						if(guardar.showOpenDialog(null)==guardar.APPROVE_OPTION){
							ruta=guardar.getSelectedFile().getAbsolutePath();
							panel.setVisible(false);
						}
					}catch(Exception ex){
						ex.printStackTrace();
					}
					
				}
			}
		});
		contentPane.add(comboBox);
		
		JButton btnEntrar = new JButton("Entrar");
		
		btnEntrar.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent arg0) {
				
				if(comboBox.getSelectedItem().equals("Nueva Sala")){
					if(comboBox_1.getSelectedItem().equals("Chat Normal")){
						rut=ruta+".txt";
						try {
							crearArchivo(rut);
							new SALA(rut,textField_1.getText()).setVisible(true);
							dispose();
						} catch (IOException e) {
							e.printStackTrace();
						}
						
					}else if(comboBox_1.getSelectedItem().equals("Chat Encriptado")){
						rut=ruta+".enc";
						
						try {
							crearArchivo(rut);
							new EncriptRoom(rut,textField_1.getText()).setVisible(true);
							dispose();
						} catch (IOException e) {
							e.printStackTrace();
						}
						
					}else if(comboBox_1.getSelectedItem().equals("Chat Privado")){
						rut=ruta+".gpg";
						try {
							crearArchivo(rut);
							new PrivateRoom(rut,textField_1.getText()).setVisible(true);
							dispose();
						} catch (IOException e) {
							e.printStackTrace();
						}
					}
					
				}else{
					int index = ruta.lastIndexOf('.');
					String ext=ruta.substring(index+1);
					if(ext.equals("txt")){
						try {
							new SALA(ruta,textField_1.getText()).setVisible(true);
							dispose();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
					}else if(ext.equals("enc")){
						try {
							new EncriptRoom(ruta,textField_1.getText()).setVisible(true);
							dispose();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
					}else if(ext.equals("gpg")){
						try {
							new PrivateRoom(ruta,textField_1.getText()).setVisible(true);
							dispose();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
					}

					
				}
			}
		});
		btnEntrar.setBounds(168, 193, 89, 23);
		contentPane.add(btnEntrar);
		
	}
	
	public void crearArchivo(String ruta) throws IOException{
		File archivo= new File(ruta);
		BufferedWriter bw;
		if(!(archivo.exists())){
			bw= new BufferedWriter(new FileWriter(archivo));
			bw.close();
		}
		
	}
}
