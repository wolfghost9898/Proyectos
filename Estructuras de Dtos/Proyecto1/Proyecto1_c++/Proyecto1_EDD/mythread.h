#ifndef MYTHREAD_H
#define MYTHREAD_H
#include <auxiliar.h>
#include <QThread>
#include <QObject>

class MyThread:public QThread
{
    Q_OBJECT
public:
    explicit MyThread(const QString &);
    void run();
    void stop();
private:
    QString myText;
    bool stopThread;
    _nivel *primeronivel;


public slots:

};

#endif // MYTHREAD_H
