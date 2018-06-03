#ifndef PUNTAJES_H
#define PUNTAJES_H

#include <QMainWindow>

namespace Ui {
class Puntajes;
}

class Puntajes : public QMainWindow
{
    Q_OBJECT

public:
    explicit Puntajes(QWidget *parent = 0);
    ~Puntajes();
    void agregarUsuario();

private slots:
    void on_pushButton_clicked();

private:
    Ui::Puntajes *ui;
};

#endif // PUNTAJES_H
