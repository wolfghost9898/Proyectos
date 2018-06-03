#ifndef TIMERGAME_H
#define TIMERGAME_H
#include <auxiliar.h>
#include <QObject>
#include <QMutex>

class timerGame:public QObject
{
    Q_OBJECT
public:
    explicit timerGame(QObject *parent=0);
    void requestWork();
    void abort();
public:
    bool _abort;
    bool _working;
    QMutex mutex;
signals:
    void workRequest();
    void finished();
    void updateTimer();
    void cambiarTiempo();
public slots:
    void doWork();
};


#endif // TIMERGAME_H
