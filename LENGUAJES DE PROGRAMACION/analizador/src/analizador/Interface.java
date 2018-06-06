package analizador;

import java.util.ArrayList;

public class Interface implements datos {
	private static ArrayList<Integer> cantidad;
	private static int cant_letras;
	private static String correcion;
	private static int cant_errores;
	@Override
	public ArrayList<Integer> getCantidad() {
		// TODO Auto-generated method stub
		return cantidad;
	}
	@Override
	public void setCantidad(ArrayList<Integer> cantidad) {
		this.cantidad=cantidad;
	}
	@Override
	public int getCant_letras() {
		// TODO Auto-generated method stub
		return cant_letras;
	}
	@Override
	public void setCant_letras(int cant_letras) {
		this.cant_letras=cant_letras;
	}
	@Override
	public String getCorrecion() {
		// TODO Auto-generated method stub
		return correcion;
	}
	@Override
	public void setCorrecion(String correcion) {
		this.correcion=correcion;
	}
	@Override
	public int getCant_errores() {
		// TODO Auto-generated method stub
		return cant_errores;
	}
	@Override
	public void setCant_errores(int cant_errores) {
		this.cant_errores=cant_errores;
	}
	
	
}
