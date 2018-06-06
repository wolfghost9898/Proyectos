package analizador;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import java.awt.Font;
import java.util.ArrayList;
import java.awt.Color;
import javax.swing.JSeparator;
import javax.swing.ScrollPaneConstants;
import javax.swing.SwingConstants;
import javax.swing.JEditorPane;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;

public class Resultados extends JFrame {

	private JPanel contentPane;
	private ArrayList <Integer>cant;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Resultados frame = new Resultados();
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
	public Resultados() {
		setResizable(false);
		setTitle("Resultados");
		this.dispose();
		setBounds(100, 100, 494, 357);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setLayout(null);
		setContentPane(contentPane);
		
		
		
		Interface inter= new Interface();
		cant= inter.getCantidad();
		
		
		JLabel lblNewLabel = new JLabel("RESULTADOS ");
		lblNewLabel.setForeground(Color.DARK_GRAY);
		lblNewLabel.setFont(new Font("MS Reference Sans Serif", Font.BOLD, 14));
		lblNewLabel.setBounds(0, 0, 134, 14);
		contentPane.add(lblNewLabel);
		
		JLabel lblDelAnalizador = new JLabel("del Analizador");
		lblDelAnalizador.setForeground(Color.DARK_GRAY);
		lblDelAnalizador.setFont(new Font("MS Reference Sans Serif", Font.PLAIN, 13));
		lblDelAnalizador.setBounds(116, 0, 109, 14);
		contentPane.add(lblDelAnalizador);
		
		JSeparator separator = new JSeparator();
		separator.setBounds(0, 15, 260, 2);
		contentPane.add(separator);
		
		JLabel lblNewLabel_1 = new JLabel("Palabras");
		lblNewLabel_1.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblNewLabel_1.setForeground(Color.GRAY);
		lblNewLabel_1.setBounds(33, 48, 63, 14);
		contentPane.add(lblNewLabel_1);
		
		JLabel lblNewLabel_2 = new JLabel("");
		lblNewLabel_2.setForeground(new Color(255, 255, 255));
		lblNewLabel_2.setBackground(new Color(30, 144, 255));
		lblNewLabel_2.setOpaque(true);
		lblNewLabel_2.setHorizontalAlignment(JLabel.CENTER);
	    lblNewLabel_2.setBounds(106, 44, 63, 25);
	    lblNewLabel_2.setText(String.valueOf(cant.get(0)));
		contentPane.add(lblNewLabel_2);
		
		JLabel lblOraciones = new JLabel("Oraciones");
		lblOraciones.setForeground(Color.GRAY);
		lblOraciones.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblOraciones.setBounds(22, 95, 74, 14);
		contentPane.add(lblOraciones);
		
		JLabel label = new JLabel("");
		label.setOpaque(true);
		label.setHorizontalAlignment(SwingConstants.CENTER);
		label.setForeground(Color.WHITE);
		label.setBackground(new Color(100, 149, 237));
		label.setBounds(106, 95, 63, 25);
		label.setText(String.valueOf(cant.get(1)));
		contentPane.add(label);
		
		JLabel lblParrafos = new JLabel("Parrafos");
		lblParrafos.setForeground(Color.GRAY);
		lblParrafos.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblParrafos.setBounds(33, 141, 63, 14);
		contentPane.add(lblParrafos);
		
		JLabel label_1 = new JLabel("");
		label_1.setOpaque(true);
		label_1.setHorizontalAlignment(SwingConstants.CENTER);
		label_1.setForeground(Color.WHITE);
		label_1.setBackground(new Color(51, 204, 153));
		label_1.setBounds(106, 141, 63, 25);
		label_1.setText(String.valueOf(cant.get(2)));
		contentPane.add(label_1);
		
		JLabel lblSignosDenPuntuacion = new JLabel("<html>Signos  de <BR>Puntuacion</html>");
		lblSignosDenPuntuacion.setForeground(Color.GRAY);
		lblSignosDenPuntuacion.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblSignosDenPuntuacion.setBounds(22, 177, 101, 48);
		contentPane.add(lblSignosDenPuntuacion);
		
		JLabel label_2 = new JLabel("");
		label_2.setOpaque(true);
		label_2.setHorizontalAlignment(SwingConstants.CENTER);
		label_2.setForeground(Color.WHITE);
		label_2.setBackground(new Color(255, 165, 0));
		label_2.setBounds(106, 189, 63, 25);
		label_2.setText(String.valueOf(cant.get(3)));
		contentPane.add(label_2);
		
		JLabel lblletrastildadas = new JLabel("<html>Letras<BR>Tildadas</html>");
		lblletrastildadas.setForeground(Color.GRAY);
		lblletrastildadas.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblletrastildadas.setBounds(22, 224, 101, 48);
		contentPane.add(lblletrastildadas);
		
		JLabel label_3 = new JLabel("");
		label_3.setOpaque(true);
		label_3.setHorizontalAlignment(SwingConstants.CENTER);
		label_3.setForeground(Color.WHITE);
		label_3.setBackground(new Color(154, 205, 50));
		label_3.setBounds(106, 236, 63, 25);
		label_3.setText(String.valueOf(cant.get(4)));

		contentPane.add(label_3);
		
		JLabel lblcaracteres = new JLabel("<html>Caracteres</html>");
		lblcaracteres.setForeground(Color.GRAY);
		lblcaracteres.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblcaracteres.setBounds(22, 269, 101, 48);
		contentPane.add(lblcaracteres);
		
		JLabel label_4 = new JLabel("");
		label_4.setOpaque(true);
		label_4.setHorizontalAlignment(SwingConstants.CENTER);
		label_4.setForeground(Color.WHITE);
		label_4.setBackground(new Color(0, 128, 0));
		label_4.setBounds(106, 283, 63, 25);
		label_4.setText(String.valueOf(cant.get(5)));
		contentPane.add(label_4);
		
		JLabel lbldiptongos = new JLabel("<html>Diptongos</html>");
		lbldiptongos.setForeground(Color.GRAY);
		lbldiptongos.setFont(new Font("Tahoma", Font.BOLD, 13));
		lbldiptongos.setBounds(221, 31, 101, 48);
		contentPane.add(lbldiptongos);
		
		JLabel label_5 = new JLabel("");
		label_5.setOpaque(true);
		label_5.setHorizontalAlignment(SwingConstants.CENTER);
		label_5.setForeground(Color.WHITE);
		label_5.setBackground(new Color(255, 99, 71));
		label_5.setBounds(299, 44, 63, 25);
		label_5.setText(String.valueOf(cant.get(6)));
		contentPane.add(label_5);
		
		JLabel lbltriptongos = new JLabel("<html>Triptongos</html>");
		lbltriptongos.setForeground(Color.GRAY);
		lbltriptongos.setFont(new Font("Tahoma", Font.BOLD, 13));
		lbltriptongos.setBounds(221, 80, 101, 48);
		contentPane.add(lbltriptongos);
		
		JLabel label_6 = new JLabel("");
		label_6.setOpaque(true);
		label_6.setHorizontalAlignment(SwingConstants.CENTER);
		label_6.setForeground(Color.WHITE);
		label_6.setBackground(new Color(255, 69, 0));
		label_6.setBounds(299, 96, 63, 25);
		label_6.setText(String.valueOf(cant.get(7)));

		contentPane.add(label_6);
		
		JLabel lblhiato = new JLabel("<html>Hiato</html>");
		lblhiato.setForeground(Color.GRAY);
		lblhiato.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblhiato.setBounds(249, 124, 101, 48);
		contentPane.add(lblhiato);
		
		JLabel label_7 = new JLabel("");
		label_7.setOpaque(true);
		label_7.setHorizontalAlignment(SwingConstants.CENTER);
		label_7.setForeground(Color.WHITE);
		label_7.setBackground(new Color(51, 51, 51));
		label_7.setBounds(299, 142, 63, 25);
		label_7.setText(String.valueOf(cant.get(8)));
		contentPane.add(label_7);
		
		JLabel lblmonosilaba = new JLabel("<html>Monosilaba</html>");
		lblmonosilaba.setForeground(Color.GRAY);
		lblmonosilaba.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblmonosilaba.setBounds(209, 177, 101, 48);
		contentPane.add(lblmonosilaba);
		
		JLabel label_8 = new JLabel("");
		label_8.setOpaque(true);
		label_8.setHorizontalAlignment(SwingConstants.CENTER);
		label_8.setForeground(Color.WHITE);
		label_8.setBackground(new Color(153, 102, 153));
		label_8.setBounds(299, 187, 63, 25);
		label_8.setText(String.valueOf(cant.get(9)));
		contentPane.add(label_8);
		
		JLabel lblerroresLexicos = new JLabel("<html>Errores <BR> Lexicos</html>");
		lblerroresLexicos.setForeground(Color.GRAY);
		lblerroresLexicos.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblerroresLexicos.setBounds(221, 277, 101, 48);
		contentPane.add(lblerroresLexicos);
		
		JLabel lblletrasPorPalabra = new JLabel("<html>Letras por <BR> Palabra</html>");
		lblletrasPorPalabra.setForeground(Color.GRAY);
		lblletrasPorPalabra.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblletrasPorPalabra.setBounds(209, 224, 101, 48);
		contentPane.add(lblletrasPorPalabra);
		
		double totals=(double)inter.getCant_letras()/(double)cant.get(0);
		JLabel label_10 = new JLabel("null");
		label_10.setOpaque(true);
		label_10.setForeground(Color.WHITE);
		label_10.setBackground(new Color(102, 153, 204));
		label_10.setBounds(299, 229, 166, 25);
		label_10.setText(String.valueOf(totals));
		contentPane.add(label_10);
		
		JEditorPane dtrpnHayDe = new JEditorPane();
		dtrpnHayDe.setEditable(false);
		dtrpnHayDe.setBorder(null);
		dtrpnHayDe.setFont(new Font("Tahoma", Font.PLAIN, 9));
		dtrpnHayDe.setForeground(new Color(255, 255, 255));
		dtrpnHayDe.setBackground(new Color(102, 51, 51));
		dtrpnHayDe.setBounds(299, 283, 166, 42);
		dtrpnHayDe.setText("Hay "+inter.getCant_errores()+" "+inter.getCorrecion());

		contentPane.add(dtrpnHayDe);
		
		JScrollPane scrollBar = new JScrollPane(dtrpnHayDe);
		scrollBar.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_NEVER);
		scrollBar.setBounds(299, 283, 166, 42);
		
		contentPane.add(scrollBar);
	}
}
