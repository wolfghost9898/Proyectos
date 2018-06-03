#include "timergame.h"
#include <QEventLoop>
#include <QTimer>

timerGame::timerGame(QObject *parent):
    QObject(parent){
    _working=false;
    _abort=false;
}

void timerGame::requestWork(){
    mutex.lock();
    _working=true;
    _abort=false;
    mutex.unlock();
    emit workRequest();
}
void timerGame::abort(){
    mutex.lock();
    if(_working){
        _abort=true;
        _working=false;
    }
    mutex.unlock();
}

void timerGame::doWork(){
    bool working=_working;
    while(working){
        bool abort=_abort;
//----------------------------------------------Generar Enemigos------------------------------------
        if(abort==true){
            break;
            working=false;
        }

        QObject::connect(this,SIGNAL(updateTimer()),front,SLOT(updateTimer()));
        QObject::connect(this,SIGNAL(cambiarTiempo()),front,SLOT(cambiarTiempo()));
        emit cambiarTiempo();
        emit updateTimer();
        QEventLoop loop;
        QTimer::singleShot(1000,&loop,SLOT(quit()));
        loop.exec();
    }
   mutex.lock();
    _working=false;
    mutex.unlock();
   emit finished();
}

