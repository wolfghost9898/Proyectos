#ifndef AUXILIAR_H
#define AUXILIAR_H


struct matriz{
 struct cabecera *primColumna;
 struct cabecera *ultColumna;
 struct cabecera *primFila;
 struct cabecera *ultFila;

};

struct matriz *inicio;

struct cabecera{
    struct cabecera *siguiente;
    struct nodo *primero;
    struct nodo *ultimo;
    int pos;
};

struct nodo{

    int x;
    int y;
    struct arbol *abb;
    nodo *siguiente;
    nodo *anterior;
    nodo *arriba;
    nodo *abajo;

};


struct arbol{

    struct arbol *izquierda;
    struct arbol *derecho;
    int dato;

};

void movernodo(int,int,int);
void insertarValor(int valor,arbol *abb,arbol *raiz);

void crearMatriz(int tam);
void mostrarMatriz();
void inorden( struct arbol *hoja );
struct arbol *insertar( struct arbol *raiz, struct arbol *hoja, int num );
struct arbol *raiz;
#endif // AUXILIAR_H
