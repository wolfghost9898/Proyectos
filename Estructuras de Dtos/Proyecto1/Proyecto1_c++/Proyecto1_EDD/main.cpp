#include "mainwindow.h"
#include "mythread.h"
#include <QApplication>


int main(int argc, char **argv) {
    QApplication a(argc, argv);
    MainWindow w;
    w.show();
    MyThread thread1("Principal");
    thread1.start();
    return a.exec();
 }
