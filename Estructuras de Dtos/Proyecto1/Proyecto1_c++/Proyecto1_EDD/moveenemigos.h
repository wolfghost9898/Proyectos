#ifndef MOVEENEMIGOS_H
#define MOVEENEMIGOS_H
#include "auxiliar.h"
#include <QObject>
#include <QMutex>

class moveEnemigos:public QObject
{
    Q_OBJECT
public:
    explicit moveEnemigos(QObject *parent=0);
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

#endif // MOVEENEMIGOS_H
