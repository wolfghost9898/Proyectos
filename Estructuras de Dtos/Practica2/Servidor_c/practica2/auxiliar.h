#ifndef AUXILIAR_H
#define AUXILIAR_H
#include "QString"
#include <string.h>
#include <QTextStream>


//-------------------------------------------Lista de Arboles AVL------------------------------------------------
struct lista{
    int id;
    char *nombre;
    struct arbol *arbolavl;
    char *hora;
    char *fecha;
    struct lista *siguiente;
    struct lista *anterior;
};

struct lista *primeroli;
struct lista *ultimoli;

void agregarLista(char *name,char* fecha,char *hora,QString direccion);

void recorrerArchivo(QString direccion);

arbol* buscarArbol(QString buscar);

//-----------------------------------------------Arbol AVL-----------------------------------------------------------

 struct arbol{
    int dato;

    char *nombre;
    char *nota;
    struct arbol *izquierdo;
    struct arbol *derecho;
};
 struct arbol *un_arbol = NULL;
 struct arbol *auxx=NULL;

 int insertar(struct arbol ** , int,char*,char*);
 arbol* buscar(struct arbol *, int);
 void editar( struct arbol*,int,char*,char*);

 int eliminar(struct arbol **, int);
 void mostrar(struct arbol *);

 int altura_arbolavl(struct arbol *);


 int balanceo(struct arbol *);
 void balancear_arbolavl(struct arbol **);
 int rotar_derecha(struct arbol **);
 int rotar_izq(struct arbol **);

 int reordenar(struct arbol **, struct arbol **);

 void graficarArbol(struct arbol*);

 //--------------------------------------------------SUb arbol--------------------------------------------
 void graficarSubArbol(struct arbol*);

 int esHoja(struct arbol*);

  int esPadre(struct arbol*);

  int esRama(struct arbol*);

  int nivel_Nodo(struct arbol*,int);

   void postOrden(struct arbol *);
   void inOrden(struct arbol *);

   void anchura(struct arbol*);

   QString llaveUnica(struct arbol*);

   void preOrdenJson(struct arbol*);

   void postOrdenJson(struct arbol*);

   void inOrdenJson(struct arbol*);
   //-------------------------------------------------Para hacer recorrido por nivel-------------------------------------
   struct nodoCola{
    arbol *ptr;
    struct nodoCola *sgte;
   };

   struct cola{
       struct nodoCola *delante;
       struct nodoCola *atras;
   };

   void inicializacionCola(struct cola &q);

   void encola(struct cola &q,arbol *n);

   arbol* desencola(struct cola &q);

QString textos;
QTextStream *textarbol;
int seleccionado=0;
int cantHojas=0;
int cantPadres=0;
int cantRamas=0;
int nodoNivel=0;
QTextStream *textsub;
QString Json;
struct arbol *bloque=NULL;

//.---------------------variables

QString llave="";
QString postO="";
QString inO="";
#endif // AUXILIAR_H
