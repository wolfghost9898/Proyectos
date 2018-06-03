#include "moveenemigos.h"
#include <QEventLoop>
#include <QTimer>
#include <QFile>
#include <QTextStream>


moveEnemigos::moveEnemigos(QObject *parent):
    QObject(parent){
    _working=false;
    _abort=false;
}

void moveEnemigos::requestWork(){
    mutex.lock();
    _working=true;
    _abort=false;
    mutex.unlock();
    emit workRequest();
}
void moveEnemigos::abort(){
    mutex.lock();
    if(_working){
        _abort=true;
        _working=false;
    }
    mutex.unlock();
}

void moveEnemigos::doWork(){
    bool working=_working;
    while(working){
        bool abort=_abort;
        if(abort==true){
            break;
            working=false;
        }
//----------------------------------------------Mover Enemigos-----------------------------------
        moverEnemigos();

        QObject::connect(this,SIGNAL(updatePixmap()),front,SLOT(updatePixmap()));
        emit updatePixmap();


        QEventLoop loop;
        QTimer::singleShot(6000,&loop,SLOT(quit()));
        loop.exec();
    }
   mutex.lock();
    _working=false;
    mutex.unlock();
   emit finished();
}


void moverEnemigos(){
    struct _nivel *nuev=primeronivel;
    for(int i=0;i<num_nivel;i++){
        nuev=nuev->siguiente;
    }
    struct _cabeceracoluma *temp=nuev->primerocolumna;
    while(temp!=NULL){
        struct _matriz *nodo=temp->primeromatriz;
        while(nodo!=NULL && nodo->primerenemigo!=NULL){
                int posx=nodo->x;
                int posy=nodo->y;
                int mover=numeroAleatorio2(3,0);
                long int point = reinterpret_cast<long int>(nodo->primerenemigo);
                guardarConsola2(nodo->primerenemigo->tipo,point,posx,posy,mover);
            nodo=nodo->siguiente;
        }
        temp=temp->siguiente;
    }

}


//-------------------------------------------Agregar a Consola-----------------------------------------------------------
void guardarConsola2(int tipo, int id,int x,int y,int mover){

    QFile file("Consola.txt");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    text<<"Mensaje de 201612118: ";
    if(mover==0){
        text<<"arriba";
    }else if(mover==1){
        text<<"derecha";
    }else if(mover==2){
        text<<"abajo";
    }else{
        text<<"izquierda";
    }
    text<<" Se movio el enemigo  "<<id;
    text<<" de tipo "<<tipo<<" a las posiciones x"<<x<<" y"<<y<<endl;
    file.close();

}
//------------------------------------Numero Aleatorio---------------------------------------------------------------





//------------------------------------Numero Aleatorio---------------------------------------------------------------
 int numeroAleatorio2(int limite_superior, int limite_inferior){
   int numero=rand() %(limite_superior-limite_inferior+1)+ limite_inferior;
    return numero;
 }

