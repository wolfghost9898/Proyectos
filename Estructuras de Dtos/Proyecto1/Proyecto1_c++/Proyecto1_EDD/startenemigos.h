#ifndef STARTENEMIGOS_H
#define STARTENEMIGOS_H
#include "generarenemigos.h"
#include "timergame.h"
#include "moveenemigos.h"

#include <QThread>

class startEnemigos
{
public:
    startEnemigos();
    QThread *thread;
    generarEnemigos *worker;

    QThread *threadtimer;
    timerGame *workertimer;

    QThread *threadmover;
    moveEnemigos *workerenemigos;

};

#endif // STARTENEMIGOS_H
