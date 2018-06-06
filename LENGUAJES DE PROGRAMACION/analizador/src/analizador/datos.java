package analizador;

import java.util.ArrayList;

public interface datos {
	ArrayList<Integer> getCantidad();
	void setCantidad(ArrayList<Integer> cantidad);
	
	int getCant_letras();
	void setCant_letras(int cant_letras);
	
	String getCorrecion();
	void setCorrecion(String correcion);
	
	int getCant_errores();
	void setCant_errores(int cant_errores);
}
