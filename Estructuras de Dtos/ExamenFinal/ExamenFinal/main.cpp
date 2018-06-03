#include "auxiliar.h"
#include <QCoreApplication>



int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    printf("----------------------MENU-------------------");
    printf("1. Ingresar tamaño de matriz");
    getch();
    return a.exec();
}


