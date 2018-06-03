#ifndef FRONTEND_H
#define FRONTEND_H
#include <QMainWindow>

namespace Ui {
class FrontEnd;
}

class FrontEnd : public QMainWindow
{
    Q_OBJECT

public:
    void mostrarImagen();
    void mostrarEnemigo();
    explicit FrontEnd(QWidget *parent = 0);
    ~FrontEnd();
    void cambiarPuntaje(int numero);
    void setearTiempo();
private:
    Ui::FrontEnd *ui;
private slots:
    void obtenerDatos(QString nivel,QString tamanio);
    void updatePixmap();
    void updateTimer();
    void on_Ver_clicked();
    void cambiarTiempo();
};


#endif // FRONTEND_H
