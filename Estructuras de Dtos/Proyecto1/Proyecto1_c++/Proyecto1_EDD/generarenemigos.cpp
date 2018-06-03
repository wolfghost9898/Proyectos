#include "generarenemigos.h"
#include <QtDebug>
#include <QThread>
#include <QMessageBox>
#include <QTimer>
#include <QFile>
#include <QEventLoop>
#include <stdlib.h>
#include <time.h>
#include<iostream>
#include<QFile>
#include<QTextStream>

generarEnemigos::generarEnemigos(QObject *parent):
    QObject(parent){
    _working=false;
    _abort=false;
}

void generarEnemigos::requestWork(){
    mutex.lock();
    _working=true;
    _abort=false;
    mutex.unlock();
    emit workRequest();
}
void generarEnemigos::abort(){
    mutex.lock();
    if(_working){
        _abort=true;
        _working=false;
    }
    mutex.unlock();
}

void generarEnemigos::doWork(){
    bool working=_working;
    while(working){
        bool abort=_abort;

        if(abort==true){
            working=false;
            break;
        }
//----------------------------------------------Generar Enemigos------------------------------------
        int numero=numeroAleatorio(primeronivel->tamano-1,0);
        existeX(numero);

        int numero2=numeroAleatorio(primeronivel->tamano-1,0);
        existeY(numero2);

        guardarEnemigo(numero,numero2);

        graficarMatriz();


        QObject::connect(this,SIGNAL(updatePixmap()),front,SLOT(updatePixmap()));
        emit updatePixmap();

        QEventLoop loop;
        QTimer::singleShot(10000,&loop,SLOT(quit()));
        loop.exec();
    }
   mutex.lock();
    _working=false;
    mutex.unlock();
   emit finished();
}


//-------------------------------------Busca la cabecera horizontal---------------------------------------------------
void existeX(int x){
    struct _nivel *nuev=primeronivel;
    for(int i=0;i<num_nivel;i++){
        nuev=nuev->siguiente;
    }

    bool estado=true;
    bool encontrado=false;
    struct _cabeceracoluma *temp=nuev->primerocolumna;
    struct _cabeceracoluma *aux;
    //----------------------------------Si esta vacia la cabecera--------------------------------------
    if(nuev->primerocolumna==NULL){
        struct _cabeceracoluma *nuevo=(struct _cabeceracoluma*)malloc(sizeof(struct _cabeceracoluma));
        nuevo->numero=x;
        nuevo->primeromatriz=NULL;
        nuevo->siguiente=NULL;
        nuev->primerocolumna=nuevo;
        nuev->ultimocolumna=nuevo;
    }else{
        while(estado==true){
            if(temp!=NULL){
                if(temp->numero==x){
                    estado=false;
                    encontrado=true;
                }else{
                    temp=temp->siguiente;
                }
            }else{
                estado=false;
                encontrado=false;
            }
        }

        if(encontrado==false){
            struct _cabeceracoluma *nuevo=(struct _cabeceracoluma*)malloc(sizeof(struct _cabeceracoluma));
            nuevo->numero=x;
            nuevo->primeromatriz=NULL;

            if(x<nuev->primerocolumna->numero){
                nuevo->siguiente=nuev->primerocolumna;
                nuev->primerocolumna=nuevo;
            }else if(x>nuev->ultimocolumna->numero){
                nuev->ultimocolumna->siguiente=nuevo;
                nuevo->siguiente=NULL;
                nuev->ultimocolumna=nuevo;
            }else{
                temp=nuev->primerocolumna;
                estado=true;
                while(estado){
                    if(temp->siguiente!=NULL){
                        if(x<temp->siguiente->numero){
                          estado=false;
                        }else{
                            temp=temp->siguiente;
                        }
                    }else{
                        estado=false;
                    }
                }
                aux=temp->siguiente;
                temp->siguiente=nuevo;
                nuevo->siguiente=aux;
            }


        }else{

        }
    }
}


//----------------------------------Busca la cabecera vertical------------------------------------------------------
void existeY(int y){
    struct _nivel *nuev=primeronivel;
    for(int i=0;i<num_nivel;i++){
        nuev=nuev->siguiente;
    }

    bool estado=true;
    bool encontrado=false;
    struct _cabecerafila *temp=nuev->primerofila;
    struct _cabecerafila *auy;
    //----------------------------------Si esta vacia la cabecera--------------------------------------
    if(nuev->primerofila==NULL){
        struct _cabecerafila *nuevo=(struct _cabecerafila*)malloc(sizeof(struct _cabecerafila));
        nuevo->primeromatriz=NULL;
        nuevo->numero=y;
        nuevo->siguiente=NULL;
        nuev->primerofila=nuevo;
        nuev->ultimofila=nuevo;
    }else{
        while(estado==true){
            if(temp!=NULL){
                if(temp->numero==y){
                    estado=false;
                    encontrado=true;
                }else{
                    temp=temp->siguiente;
                }
            }else{
                estado=false;
                encontrado=false;
            }
        }

        if(encontrado==false){
            struct _cabecerafila *nuevo=(struct _cabecerafila*)malloc(sizeof(struct _cabecerafila));
            nuevo->primeromatriz=NULL;
            nuevo->numero=y;

            if(y<nuev->primerofila->numero){
                nuevo->siguiente=nuev->primerofila;
                nuev->primerofila=nuevo;
            }else if(y>nuev->ultimofila->numero){
                nuev->ultimofila->siguiente=nuevo;
                nuevo->siguiente=NULL;
                nuev->ultimofila=nuevo;
            }else{
                temp=nuev->primerofila;
                estado=true;
                while(estado){
                    if(temp->siguiente!=NULL){
                        if(y<temp->siguiente->numero){
                          estado=false;
                        }else{
                            temp=temp->siguiente;
                        }
                    }else{
                        estado=false;
                    }
                }
                auy=temp->siguiente;
                temp->siguiente=nuevo;
                nuevo->siguiente=auy;
            }


        }else{

        }
    }
}

//------------------------------------Guardar Nodo Enemigo-------------------------------------------------------------
void guardarEnemigo(int numero, int numero2){
    struct _nivel *nuev=primeronivel;
    for(int i=0;i<num_nivel;i++){
        nuev=nuev->siguiente;
    }
    struct _cabeceracoluma *auxma=nuev->primerocolumna;
    struct _cabecerafila *aux2=nuev->primerofila;
    bool estado;
    bool encontrado=false;
    if(auxma!=NULL){


    while(auxma->numero!=numero){
        auxma=auxma->siguiente;
    }

    while(aux2->numero!=numero2){
        aux2=aux2->siguiente;
    }
//---------------------------------------------Guardar Enemigo-------------------------------------
    struct _matriz *nodoma2=aux2->primeromatriz;
    struct _matriz *nuevoenemigo=(struct _matriz*)malloc(sizeof(struct _matriz));
    struct _matriz *temp;
    struct _matriz *temp2;
    nuevoenemigo->x=numero;
    nuevoenemigo->y=numero2;
    //-----------------------------------posicion en X-------------------------------------------
    if(auxma->primeromatriz==NULL){
        nuevoenemigo->siguiente=NULL;
        auxma->primeromatriz=nuevoenemigo;
        auxma->ultimomatriz=nuevoenemigo;
        agregarPilaEnemigo(nuevoenemigo,0);
    }else{
        struct _matriz *nodoma=auxma->primeromatriz;
        estado=true;
        while(estado==true){
            if(nodoma!=NULL){
                if(nodoma->y==numero2){
                    estado=false;
                    encontrado=true;
                }else{
                    nodoma=nodoma->siguiente;
                }
            }else{
                estado=false;
                encontrado=false;
            }
        }
       //------------------------------------if de encontrado-----------------------------
        if(encontrado==false){
            if(numero2<auxma->primeromatriz->y){
                nuevoenemigo->anterior=NULL;
                nuevoenemigo->siguiente=auxma->primeromatriz;
                auxma->primeromatriz->anterior=nuevoenemigo;
                auxma->primeromatriz=nuevoenemigo;
            }else if(numero2>auxma->ultimomatriz->y){
                nuevoenemigo->siguiente=NULL;
                nuevoenemigo->anterior=auxma->ultimomatriz;
                auxma->ultimomatriz->siguiente=nuevoenemigo;
                auxma->ultimomatriz=nuevoenemigo;
            }else{            
                struct _matriz *nodoauxiliar;
                temp=auxma->primeromatriz;
                estado=true;
                while(estado){
                    if(temp->siguiente!=NULL){
                        if(numero2<temp->siguiente->y){
                          estado=false;
                        }else{
                            temp=temp->siguiente;
                        }
                    }else{
                        estado=false;
                    }
                }
                nodoauxiliar=temp->siguiente;
                temp->siguiente=nuevoenemigo;
                nuevoenemigo->siguiente=nodoauxiliar;
            }
            agregarPilaEnemigo(nuevoenemigo,0);
        }else{
            //-------------------------else de encontrado---------------------------------
            agregarPilaEnemigo(nodoma,0);
        }



    }


    //-----------------------------------posicion en Y-------------------------------------------
    if(aux2->primeromatriz==NULL){
       nuevoenemigo->arriba=NULL;
       aux2->primeromatriz=nuevoenemigo;
       aux2->ultimomatriz=nuevoenemigo;
    }else{
        struct _matriz *nodoma=aux2->primeromatriz;
        estado=true;
        encontrado=false;
        while(estado==true){
            if(nodoma!=NULL){
                if(nodoma->x==numero){
                    estado=false;
                    encontrado=true;
                }else{
                    nodoma=nodoma->arriba;
                }
            }else{
                estado=false;
                encontrado=false;
            }
        }
        //------------------------------------if de encontrado-----------------------------
         if(encontrado==false){
             if(numero<aux2->primeromatriz->x){
                 nuevoenemigo->abajo=NULL;
                 nuevoenemigo->arriba=aux2->primeromatriz;
                 aux2->primeromatriz->abajo=nuevoenemigo;
                 aux2->primeromatriz=nuevoenemigo;
             }else if(numero>aux2->ultimomatriz->x){
                 nuevoenemigo->arriba=NULL;
                 nuevoenemigo->abajo=aux2->ultimomatriz;
                 aux2->ultimomatriz->arriba=nuevoenemigo;
                 aux2->ultimomatriz=nuevoenemigo;
             }else{
                 struct _matriz *nodoauxiliar;
                 temp=aux2->primeromatriz;
                 estado=true;
                 while(estado){
                     if(temp->arriba!=NULL){
                         if(numero<temp->arriba->x){
                           estado=false;
                         }else{
                             temp=temp->arriba;
                         }
                     }else{
                         estado=false;
                     }
                 }
                 nodoauxiliar=temp->arriba;
                 temp->arriba=nuevoenemigo;
                 nuevoenemigo->arriba=nodoauxiliar;
             }

         }else{
             //-------------------------else de encontrado---------------------------------
         }


    }
    }
    }

//-------------------------------------Generar Grafica-------------------------------------------------------------------
void graficarMatriz(){
    struct _nivel *nuev=primeronivel;
    for(int i=0;i<num_nivel;i++){
        nuev=nuev->siguiente;
    }


    QFile file("Matriz.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    QTextStream text(&file);
    struct _cabeceracoluma *auxiliar=nuev->primerocolumna;
    struct _cabecerafila *auxiliar2=nuev->primerofila;
    text<<"digraph G{"<<endl;
    //------------------------------------------FILAS Y COLUMNAS-----------------------------------------
    text<<"subgraph cluster_area{"<<endl;
    text<<"{rank=same raiz ";
    while(auxiliar!=NULL){
        long int point = reinterpret_cast<long int>(auxiliar);
        text<<point;
        text<<"  ";
        auxiliar=auxiliar->siguiente;
    }
    text<<"}"<<endl;
    text<<"}"<<endl;
    auxiliar=nuev->primerocolumna;
    if(auxiliar!=NULL){
        //--------------------------------------------COLUMNA-----------------------------------------------
        text<<"subgraph cluster_lista_columna{"<<endl;
        text<<"raiz[shape=box,label=\"*\"];"<<endl;
        long int point = reinterpret_cast<long int>(auxiliar);
        text<<"raiz->"<<point<<";"<<endl;
        while(auxiliar!=NULL){
            long int point = reinterpret_cast<long int>(auxiliar);
            if(auxiliar->siguiente!=NULL){
                        long int point2 = reinterpret_cast<long int>(auxiliar->siguiente);
                        text<<point<<"[shape=box,label=\""<<auxiliar->numero<<"\"];"<<endl;
                        text<<point2<<"[shape=box,label=\""<<auxiliar->siguiente->numero<<"\"];"<<endl;
                        text<<point<<"->"<<point2<<";"<<endl;
            }else if(auxiliar==nuev->primerocolumna){
                        text<<point<<"[shape=box,label=\""<<auxiliar->numero<<"\"];"<<endl;
            }
            struct _matriz *temp=auxiliar->primeromatriz;
            if(temp!=NULL){
                point=reinterpret_cast<long int>(auxiliar);
                long int point2=reinterpret_cast<long int>(temp);
                text<<point<<"->"<<point2<<";"<<endl;
                while(temp!=NULL){
                    if(temp!=auxiliar->ultimomatriz){
                         long int point = reinterpret_cast<long int>(temp);
                         long int point2 = reinterpret_cast<long int>(temp->siguiente);
                         text<<point<<"->"<<point2<<";"<<endl;
                         text<<point<<"[label=\""<<temp->x<<","<<temp->y<<"\"]"<<endl;
                         text<<point2<<"->"<<point<<";"<<endl;
                         }else if(temp==auxiliar->primeromatriz || temp==auxiliar->ultimomatriz){
                            long int point = reinterpret_cast<long int>(temp);
                            text<<point<<"[label=\""<<temp->x<<","<<temp->y<<"\"]"<<endl;
                         }
                    temp=temp->siguiente;
                }
            }

            auxiliar=auxiliar->siguiente;
        }
        //--------------------------------- FILA----------------------------------------------
        point=reinterpret_cast<long int>(auxiliar2);
        if(auxiliar2!=NULL){
            text<<"raiz->"<<point<<";"<<endl;
            int contador=0;
            while(auxiliar2!=NULL){
               long int point = reinterpret_cast<long int>(auxiliar2);
               if(auxiliar2->siguiente!=NULL){
                            long int point2 = reinterpret_cast<long int>(auxiliar2->siguiente);
                            text<<point<<"[shape=box,label=\""<<auxiliar2->numero<<"\"];"<<endl;
                            text<<point2<<"[shape=box,label=\""<<auxiliar2->siguiente->numero<<"\"];"<<endl;
                            text<<point<<"->"<<point2<<";"<<endl;
               }else if(auxiliar2==nuev->primerofila){
                  text<<point<<"[shape=box,label=\""<<auxiliar2->numero<<"\"];"<<endl;
               }
               struct _matriz *temp=auxiliar2->primeromatriz;
               //---------------------------------------horizontal la mtriz ortogonal-----------------------------------
                 point = reinterpret_cast<long int>(auxiliar2);
               text<<"{rank=same "<<point<<" ";
               while(temp!=NULL){
                   long int point = reinterpret_cast<long int>(temp);
                   text<<point;
                   text<<"  ";
                   temp=temp->arriba;
               }
               text<<"}"<<endl;
               //--------------------------------------Matriz Ortogonal--------------------------------------------------
               temp=auxiliar2->primeromatriz;
               if(temp!=NULL){
                   point=reinterpret_cast<long int>(auxiliar2);
                   long int point2=reinterpret_cast<long int>(temp);
                   text<<point<<"->"<<point2<<";"<<endl;
                   while(temp!=NULL){
                       if(temp!=auxiliar2->ultimomatriz){
                            long int point = reinterpret_cast<long int>(temp);
                            long int point2 = reinterpret_cast<long int>(temp->arriba);
                            text<<point<<"->"<<point2<<";"<<endl;
                            text<<point2<<"->"<<point<<";"<<endl;
                            }else if(temp==auxiliar2->primeromatriz || temp==auxiliar2->ultimomatriz){
                               long int point = reinterpret_cast<long int>(temp);
                            }
                       temp=temp->arriba;
                   }
               }

                auxiliar2=auxiliar2->siguiente;
                contador+=1;
            }

        }
        text<<"}"<<endl;
    }

    text<<"}"<<endl;
    file.close();
    system("dot -Tpng Matriz.dot -o Matriz.png");
}

//--------------------------------------Guarda Enemigo en la Pila--------------------------------------------------
void agregarPilaEnemigo(_matriz *nodo, int tipo){
    struct _pilaEnemigos *nuevo=(struct _pilaEnemigos*)malloc(sizeof(struct _pilaEnemigos));
    long int point = reinterpret_cast<long int>(nuevo);
    nuevo->id=tipo;
    if(tipo==0){
        int vida=numeroAleatorio(2,0);
        nuevo->tipo=vida;
        if(vida==0){
            nuevo->vida=1;
        }else if(vida==1){
            nuevo->vida=3;
        }else{
            nuevo->vida=5;
        }
    }else{

    }
    if(nodo->primerenemigo==NULL){
        nuevo->siguiente=NULL;
        nodo->primerenemigo=nuevo;
        nodo->ultimoenemigo=nuevo;
    }else{
        nuevo->siguiente=nodo->primerenemigo;
        nodo->primerenemigo=nuevo;
    }
    guardarConsola(nuevo->tipo,point,nodo->x,nodo->y);
}

//-------------------------------------------Agregar a Consola-----------------------------------------------------------
void guardarConsola(int tipo, int id,int x,int y){
    QFile file("Consola.txt");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    text<<"Mensaje de 201612118: Se Creo un enemigo con id "<<id;
    text<<" de tipo "<<tipo<<" en las posiciones x"<<x<<" y"<<y<<endl;
    file.close();

}
//------------------------------------Numero Aleatorio---------------------------------------------------------------
 int numeroAleatorio(int limite_superior, int limite_inferior){
   int numero=rand() %(limite_superior-limite_inferior+1)+ limite_inferior;
    return numero;
 }
