package Auxiliares;

import java.util.Vector;

public class MatrizHere implements ObjetoMatriz {
private static String[][] matriz;
private static Vector v,registro,compras,servicios;
//Stock
@Override
public String[][] getMatriz() {
	// TODO Auto-generated method stub
	return matriz;
}

@Override
public void setMatriz(String[][] matriz) {
	this.matriz=matriz;
	
}

//Descuento
@Override
public Vector getDescuentos() {
	// TODO Auto-generated method stub
	return v;
}

@Override
public void setDescuentos(Vector v) {
	this.v=v;
	
}

@Override
public Vector getRegistro() {
	// TODO Auto-generated method stub
	return registro;
}

@Override
public void setRegistro(Vector registro) {
	this.registro=registro;
	
}

@Override
public Vector getCompras() {
	// TODO Auto-generated method stub
	return compras;
}

@Override
public void setCompras(Vector compras) {
	// TODO Auto-generated method stub
	this.compras=compras;
	
}

@Override
public Vector getServicios() {
	// TODO Auto-generated method stub
	return servicios;
}

@Override
public void setServicios(Vector servicios) {
	this.servicios=servicios;
	
}
	

}
