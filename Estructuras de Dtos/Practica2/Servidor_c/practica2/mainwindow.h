#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QObject>
#include <QFile>
#include <QDebug>
#include <QTcpServer>
#include <QTcpSocket>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    void mostrarLista();
    void agregarSeleccionado();

public slots:
    void nuevaConexion();
    void on_disconnect();
    void readyRead();

private slots:
    void on_actionCargar_Archivos_triggered();

    void on_pushButton_clicked();

    void on_comboBox_2_currentIndexChanged(const QString &arg1);

    void on_actionPost_Orden_triggered();

    void on_actionPre_Orden_triggered();

    void on_actionIn_Orden_triggered();

    void on_actionAmplitud_triggered();

    void on_pushButton_4_clicked();

    void on_subarbolbutton_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_3_clicked();

    void on_actionCrear_Bloque_triggered();

    void on_actionManual_de_Usuario_triggered();

    void on_actionAcerca_de_triggered();

private:
    Ui::MainWindow *ui;
     QTcpSocket *socket;
     QTcpSocket *clie;
    QTcpServer *servidor;
    QVector<QTcpSocket *> mClients;
};

#endif // MAINWINDOW_H
