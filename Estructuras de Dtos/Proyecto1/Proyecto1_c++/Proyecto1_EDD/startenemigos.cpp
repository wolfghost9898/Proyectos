#include "startenemigos.h"
#include "QObject"
#include "QMessageBox"
startEnemigos::startEnemigos()
{
    thread=new QThread();
    worker= new generarEnemigos();
    worker->moveToThread(thread);
    QObject::connect(worker,SIGNAL(workRequest()),thread,SLOT(start()));
    QObject::connect(thread,SIGNAL(started()),worker,SLOT(doWork()));
    QObject::connect(worker,SIGNAL(finished()),thread,SLOT(quit()),Qt::DirectConnection);
    //--------------------------------------Timer--------------------------------------------------
    threadtimer=new QThread();
    workertimer=new timerGame();
    workertimer->moveToThread(threadtimer);
    QObject::connect(workertimer,SIGNAL(workRequest()),threadtimer,SLOT(start()));
    QObject::connect(threadtimer,SIGNAL(started()),workertimer,SLOT(doWork()));
    QObject::connect(workertimer,SIGNAL(finished()),threadtimer,SLOT(quit()),Qt::DirectConnection);
    //--------------------------------------Enemigos--------------------------------------------------
    threadmover=new QThread();
    workerenemigos=new moveEnemigos();
    workerenemigos->moveToThread(threadmover);
    QObject::connect(workerenemigos,SIGNAL(workRequest()),threadmover,SLOT(start()));
    QObject::connect(threadmover,SIGNAL(started()),workerenemigos,SLOT(doWork()));
    QObject::connect(workerenemigos,SIGNAL(finished()),threadmover,SLOT(quit()),Qt::DirectConnection);


}


