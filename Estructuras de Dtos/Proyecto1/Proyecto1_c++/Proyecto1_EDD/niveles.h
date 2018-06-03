#ifndef NIVELES_H
#define NIVELES_H
#include <QMainWindow>
#include "generarenemigos.h"
#include <QThread>

namespace Ui {
class niveles;
}

class niveles : public QMainWindow
{
    Q_OBJECT

public:
    explicit niveles(QWidget *parent = 0);
    ~niveles();
    void generacionNiveles();
    void mostrarGraficaNiveles();
    QThread *thread;
    generarEnemigos *worker;


private slots:
    void on_guardar_nivel_clicked();

    void on_pushButton_3_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_4_clicked();

    void on_pushButton_clicked();


private:
    Ui::niveles *ui;

signals:
   void sendData( QString nivel, QString tamanio);

};

#endif // NIVELES_H
