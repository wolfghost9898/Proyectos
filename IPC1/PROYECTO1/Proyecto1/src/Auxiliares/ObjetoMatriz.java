package Auxiliares;

import java.util.Vector;

public interface ObjetoMatriz {
	//Stock
	String[][] getMatriz();
	void setMatriz(String[][] matriz);
	
	//Descuentos
	Vector getDescuentos();
	void setDescuentos(Vector vector);
	
	//Registro de Ventas
	Vector getRegistro();
	void setRegistro(Vector registro);
	
	//Registro de Compras
	Vector getCompras();
	void setCompras(Vector compras);
	
	//Registro Servicios
	Vector getServicios();
	void setServicios(Vector servicios);
}
