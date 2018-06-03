#ifndef AUXILIAR_H
#define AUXILIAR_H

#endif // AUXILIAR_H


struct matriz{
 struct cabecera *primColumna;
 struct cabecera *ultColumna;
 struct cabecera *primFila;
 struct cabecera *ultFila;
 struct arbol *arbolbb=nullptr;

};

struct matriz *inicio;

struct cabecera{
    struct cabecera *siguiente;
    struct cabecera *anterior;
    int pos;
};

struct arbol{

    struct arbol *izquierda;
    struct arbol *derecho;
    int dato;

};

void principal();
