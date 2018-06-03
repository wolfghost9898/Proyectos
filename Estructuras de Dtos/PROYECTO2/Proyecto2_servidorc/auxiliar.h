#ifndef AUXILIAR_H
#define AUXILIAR_H
#include <QString>
#include <QTextStream>
#include <QList>
#define MAX 4
#define MIN 2
/*----------------------------------TABLA HASH PARA AUTOBUSES-----------------------------------------------
----------------------------------------------------------------------------------------------------------*/
struct autobuses{
    bool flag=false;
    struct colision_autobuses *primero=NULL;
    struct colision_autobuses *ultimo;
};

struct colision_autobuses{
    char *placa;
    char *modelo;
    char *estado;
    struct colision_autobuses *siguiente;
};

struct autobuses *hashAuto;

int tam_autobuses=37;

colision_autobuses* buscarAutobus(char*);

colision_autobuses* buscarAuto(char*,colision_autobuses*);

/*------------------------------------------FIN TABLA HASH PARA AUTOBUSES---------------------------------
------------------------------------------------------------------------------------------------------------*/

/*----------------------------------------------------TABLA HASH PARA  PILOTOS---------------------------------
-------------------------------------------------------------------------------------------------------------*/

struct pilotos{
  bool estado=false;
  struct arbol *arbolavl=NULL;
};

struct arbol{
   int dato;
   int edad;
   char *dpi;
   char *nombre;
   char *genero;
   struct arbol *izquierdo;
   struct arbol *derecho;
};

struct arbol *un_arbol = NULL;
struct arbol *auxx=NULL;
struct pilotos *hashPilotos;

arbol* buscar(struct arbol *un_arbol, int dato);
int insertar(struct arbol ** , int,char*,char*,char*);

void mostrar(struct arbol *);

int altura_arbolavl(struct arbol *);


int balanceo(struct arbol *);
void balancear_arbolavl(struct arbol **);
int rotar_derecha(struct arbol **);
int rotar_izq(struct arbol **);

int reordenar(struct arbol **, struct arbol **);

void graficarArbol(struct arbol*);

int cantidadNombre(char*);
void graficarArbol(arbol*);


arbol* buscarPiloto(char* dpi,char* nombre);
/*------------------------------------------FIN TABLA HASH PARA PILOTOS---------------------------------
------------------------------------------------------------------------------------------------------------*/


/*----------------------------------------------LISTA DE ESTACIONES-------------------------------------------
-------------------------------------------------------------------------------------------------------------*/
struct estaciones{
  char* codigo;
  char* nombre;
  char* ubicacion;
  struct estaciones *siguiente;
};

struct estaciones *primeroesta;
struct estaciones *ultimoesta;

void insertarUbicacion(struct estaciones*);
estaciones* buscarEstacion(QString);
void eliminarEstacion(QString);
/*------------------------------------------FIN LISTA PARA ESTACIONES---------------------------------
------------------------------------------------------------------------------------------------------------*/


/*------------------------------------------------PARQUEO-------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------*/
struct parqueo{
    char *archivo;
    struct parqueo *siguiente;
    struct parqueo *anterior;

    struct _matriz *columnafirst;
    struct _matriz *columnalast;
    struct _matriz *filafirst;
    struct _matriz *filalast;
};

struct parqueo *cabecera_parqueo;

struct _matriz{
    int numero;
    struct _matriz *siguiente;
    struct _nodoMatriz *primero;
    struct _nodoMatriz *ultimo;
};

struct _nodoMatriz{
 int x;
 int y;
 char* placa;
 struct _nodoMatriz *siguiente;
 struct _nodoMatriz *anterior;
 struct _nodoMatriz *abajo;
 struct _nodoMatriz *arriba;
};



void existeX(int x,parqueo *nuev);
void existeY(int y,parqueo *nuev);
void recorrerCabecera();
void guardarEnemigo(int numero,int numero2,parqueo *nuev,char*);
void graficarMatriz(int);
void insertarParqueo(struct parqueo*);
void eliminarParqueo(QString nombre);
/*------------------------------------------FIN PARQUEO---------------------------------
------------------------------------------------------------------------------------------------------------*/

/*----------------------------------------------------LISTA DOBLE DE RUTAS---------------------------------
-------------------------------------------------------------------------------------------------------------*/
struct rutas{
    char *archivo;
    struct rutas *siguiente;
    struct rutas *anterior;

    struct viaje *idaI=NULL;
    struct viaje *idaF;
    struct viaje *vueltaI=NULL;
    struct viaje *vueltaF;
};

struct viaje{
    char *nombre;
    struct estaciones *esta;
    struct arbolRuta *raiz=NULL;
    struct viaje *siguiente;
};

void insertarIda(struct viaje*,struct rutas*);
void insertarVuelta(struct viaje*,struct rutas*);
void insertarRuta(struct rutas*);
void eliminarRuta(QString nombre);

struct rutas *cabecera_ruta;
/*----------------------------------------------------FIN LISTA DOBLE RUTAS---------------------------------
-------------------------------------------------------------------------------------------------------------*/

/*------------------------------------------Usuarios---------------------------------
------------------------------------------------------------------------------------------------------------*/

struct usuarios{
  bool flag=false;
  char* dpi;
  char* tarjeta;
  char* nombre;
  int edad;
  struct usuarios* siguiente;
};

struct usuarios* primerUsuario;
struct usuarios* ultimoUsuario;

void inicializarUsuarios(int);

void insertarUsuario(char* dpi,char* nombre,char *tarjeta,int edad,int);

void reHash();

void eliminarUsuario(QString nombre);

usuarios* buscarUsuario(QString dpi);

char* encriptacion(char*,int);
char* desencriptacion(char*,int);

/*------------------------------------------FIN USUARIOS---------------------------------
------------------------------------------------------------------------------------------------------------*/

/*------------------------------------------BLOQUEEE---------------------------------
------------------------------------------------------------------------------------------------------------*/

struct bloque{
    char* nombre;
    int id;
    char* fecha;

    struct colision_autobuses *bus;
    struct arbol *piloto;

    struct bloque *siguiente;

    struct list_rutas *primera;
    struct list_rutas *ultima;
};


struct list_rutas{
    struct rutas* ruta;
    char *archivo;
    struct list_rutas *siguiente;
};

struct arbolRuta{
   int dato;
   struct usuarios *usuario;
   struct arbolRuta *izquierdo;
   struct arbolRuta *derecho;
};

int insertar2(struct arbolRuta ** , int,struct usuarios*);

void mostrar2(struct arbolRuta *);

int altura_arbolavl2(struct arbolRuta *);


int balanceo2(struct arbolRuta *);
void balancear_arbolavl2(struct arbolRuta **);
int rotar_derecha2(struct arbolRuta **);
int rotar_izq2(struct arbolRuta **);

int reordenar2(struct arbolRuta **, struct arbolRuta **);

void asignarArbolAvl(QStringList,struct list_rutas*);

arbolRuta* buscar2(struct arbolRuta*,int);

void inOrden2(struct arbolRuta*);

rutas* buscarRuta(char*,rutas*);
void insertarBloque(struct bloque*,QString);

void bitacoraBloque(QString nombrePi,QString dpiPi,QString placaBu,QString fechaBi,QStringList rutas,QString nombreBloque);
bloque* buscarBloque(QString nombre);

list_rutas* buscarRutta(QString nombre,bloque* nodo);

viaje* buscarGrafo(QString nombre,viaje* nodo);

void graficarArbol2(arbolRuta*);

struct bloque* primeroBloque;
struct bloque* ultimoBloque;
arbolRuta *un_arbol2=NULL;
/*------------------------------------------FIN BLOQUE---------------------------------
------------------------------------------------------------------------------------------------------------*/

int funcionHash(char *palabra,int modulo);

void llenarPrimos();

QString textos="";
QTextStream *textarbol;
int tamUsuarios=37;
QList<int> NumerosPrimos;
struct arbolRuta *rutArbol = NULL;


/*------------------------------------------ARBOL B---------------------------------
------------------------------------------------------------------------------------------------------------*/


struct btreeNode {
    int val[MAX + 1], count;
    btreeNode *link[MAX + 1];
};

btreeNode *root;
btreeNode *reporteBloque;
btreeNode *reporteRuta;

btreeNode * crearNodoB(int val, btreeNode *child);
void agregarValorNodo(int val, int pos, btreeNode *node, btreeNode *child);
void dividirNodo(int val, int *pval, int pos, btreeNode *node,btreeNode *child, btreeNode **newNode);
int setValorNodo(int val, int *pval,btreeNode *node, btreeNode **child);
void insercionB(int val);
void copiarSucesor(btreeNode *myNode, int pos);
void removerValor(btreeNode *myNode, int pos);
void equilibrarDerecha(btreeNode *myNode, int pos);
void equilibrarIzquierda(btreeNode *myNode, int pos);
void fusionarNodos(btreeNode *myNode, int pos);
void ajustarNodo(btreeNode *myNode, int pos);
int eliminarValorNodo(int val,btreeNode *myNode);
void eliminarB(int val,btreeNode *myNode) ;
usuarios* buscarB(int val, int *pos,btreeNode *myNode);
void inOrdenArbolB(btreeNode *myNode);

void reportePorBloque(QString nombre);
void reportePorRuta(QString nombre);
/*------------------------------------------FIN ARBOL B---------------------------------
------------------------------------------------------------------------------------------------------------*/

//-----------------------------------------------METODOS GENERALES-----------------------------------------------------
void generalAutoBus(QStringList filenames);
void generalPiloto(QStringList filenames);
void generalMatriz(QStringList filenames);
void generalUsuario(QStringList filenames);
void generalEstaciones(QStringList filenames);
void generalRutas(QStringList filenames);

//--------------------------------------------METODOS DE ELIMINACION----------------------------------------------------
void eliminarBus(char*);
#endif // AUXILIAR_H
