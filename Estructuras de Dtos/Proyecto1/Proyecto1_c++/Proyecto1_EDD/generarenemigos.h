#ifndef GENERARENEMIGOS_H
#define GENERARENEMIGOS_H
#include <auxiliar.h>
#include <QObject>
#include <QMutex>

class generarEnemigos:public QObject
{
    Q_OBJECT
public:
    explicit generarEnemigos(QObject *parent=0);
    void requestWork();
    void abort();
public:
    bool _abort;
    bool _working;
    QMutex mutex;

signals:
    void workRequest();
    void finished();
    void updatePixmap();
public slots:
    void doWork();
};


#endif // GENERARENEMIGOS_H
