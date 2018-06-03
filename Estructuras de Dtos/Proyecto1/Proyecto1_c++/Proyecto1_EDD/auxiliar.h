#ifndef AUXILIAR_H

#define AUXILIAR_H
#include "frontend.h"
#include "puntajes.h"
#include <QString>

//----------------------------------------------------Lista de Niveles--------------------------------------------------------
struct _nivel{
    int id;
    int estado;
    int tamano;

    struct  _cabeceracoluma *primerocolumna;
    struct _cabeceracoluma *ultimocolumna;

    struct  _cabecerafila *primerofila;
    struct _cabecerafila *ultimofila;

    struct _nivel *siguiente,*anterior;

};
extern   _nivel *primeronivel;
extern    _nivel *ultimonivel;
void generarGraficaNiveles();
void agregarNiveles(int cantidad,int tamano);

//------------------------------------------------Matriz rtogonal--------------------------------------------------------------
struct _cabeceracoluma{
    int numero;
    struct _cabeceracoluma *siguiente;
    struct _matriz *primeromatriz;
    struct _matriz *ultimomatriz;
};

struct _cabecerafila{
    int numero;
    struct _cabecerafila *siguiente;
    struct _matriz *primeromatriz;
    struct _matriz *ultimomatriz;
};

struct _matriz{
    int x;
    int y;
    struct _matriz *siguiente;
    struct _matriz *anterior;
    struct _matriz *abajo;
    struct _matriz *arriba;
    struct _pilaEnemigos *primerenemigo;
    struct _pilaEnemigos *ultimoenemigo;
};

struct _pilaEnemigos{
    int id;
    int tipo;
    int vida;
    struct _pilaEnemigos *siguiente;
    struct _pilaEnemigos *anterior;
};

 void existeX(int x);
void existeY(int y);
void recorrerCabecera();
void guardarEnemigo(int numero,int numero2);
void graficarMatriz();
void agregarPilaEnemigo(struct _matriz *nodo,int tipo);

void existeX2(int x);
void existeY2(int y);
void guardarEnemigo2(int numero,int numero2);
void graficarMatriz2();
void agregarPilaEnemigo2(struct _matriz *nodo,int tipo);



//------------------------------------------------ Numeros Aleatorios
int numeroAleatorio(int limite_superior,int limite_inferior);
int numeroAleatorio2(int limite_superior,int limite_inferior);
//-----------------------guardar en consola----------------------------
void guardarConsola(int tipo,int id,int x,int y);
void guardarConsola2(int tipo,int id,int x,int y,int mover);
//------------------------------------------------------Mover Enemigos-------------------------------------------
void moverEnemigos();
extern FrontEnd *front;
extern Puntajes *points;
extern int num_nivel;

//------------------------------Lista de Usuarios-------------------------------------------------------
struct _users{
    int id;
  struct _users *siguiente;
  struct _deleteememigos *cabecera_enemigo0;
  struct _deleteememigos *cabecera_enemigo0u;
  struct _deleteememigos *cabecera_enemigo1;
  struct _deleteememigos *cabecera_enemigo1u;
  struct _deleteememigos *cabecera_enemigo2;
  struct _deleteememigos *cabecera_enemigo2u;
  struct _users *anterior;
};

void agregarDeleteEnemigo(int id,int usuario,int tipo);
//----------------------------Lista de Enemigos Eliminados----------------------------------------------
struct _deleteememigos{
    int id;
    int usuario;
    struct _deleteememigos *sig;
};
extern _users *primerouser;
extern _users *ultimouser;
extern int num_usuario;

//-------------------------------Lista de Puntajes-----------------------------------------------------
struct _listapunta{
    int usuario;
    int puntaje;
    int id;
    struct _listapunta *siguiente;
};

extern struct _listapunta *primerolista;
extern struct _listapunta *ultimolista;





#endif // AUXILIAR_H


