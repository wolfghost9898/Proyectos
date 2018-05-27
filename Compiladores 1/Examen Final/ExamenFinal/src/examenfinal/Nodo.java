/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package examenfinal;

/**
 *
 * @author Carlos
 */
import java.util.ArrayList;

public class Nodo {
    public String Etiqueta;
    public ArrayList<Nodo> hijos = new ArrayList<>();
    public String valor;
    public int idNod;

    public void AddHijos(Nodo hijo) {
        hijos.add(hijo);
    }

    public void setEtiqueta(String Etiqueta) {
        this.Etiqueta = Etiqueta;
    }

    public String getEtiqueta() {
        return Etiqueta;
    }

    public ArrayList<Nodo> getHijos() {
        return hijos;
    }

    public void setHijos(ArrayList<Nodo> hijos) {
        this.hijos = hijos;
    }

    public void setValor(String valor) {
        this.valor = valor;
    }

    public String getValor() {
        return valor;
    }

    public void setId(int id) {
        this.idNod = id;
    }

    public int getId() {
        return idNod;
    }
}