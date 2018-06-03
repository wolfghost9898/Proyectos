#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QUrl>
#include <QMainWindow>
#include <QtWebSockets/QWebSocket>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_actionAutobuses_triggered();

    void on_pushButton_clicked();

    void on_actionPilotos_triggered();

    void on_actionUbicacion_triggered();

    void on_actionParqueos_triggered();

    void on_actionUsuarios_triggered();

    void on_actionRutas_triggered();

    void on_actionCrear_Bloque_triggered();

    void on_actionPor_Bloque_triggered();

    void on_actionUn_solo_AutoBus_triggered();

    void on_actionGeneral_triggered();

    void on_actionColision_triggered();

    void on_actionIndividual_triggered();

    void on_actionGeneral_2_triggered();

    void on_actionColision_2_triggered();

    void on_actionAutobus_triggered();

    void on_actionPiloto_triggered();

    void on_actionGeneral_3_triggered();

    void on_actionIndividual_2_triggered();

    void on_actionEstacion_triggered();

    void on_actionRutas_General_triggered();

    void on_actionVer_Ruta_triggered();

    void on_actionRuta_triggered();

    void on_actionParqueo_triggered();

    void on_actionGeneral_4_triggered();

    void on_actionParqueo_Individual_triggered();

    void on_actionParqueo_2_triggered();

    void on_actionGeneral_5_triggered();

    void on_actionIndividual_3_triggered();

    void on_actionUsuario_triggered();

    void on_actionCargar_Bitacora_triggered();

    void on_actionGeneral_6_triggered();

    void on_actionAvl_de_Rutas_de_un_Bloque_triggered();

    void on_actionRutas_de_un_Bloque_triggered();

    void on_actionid_triggered();

    void on_actionvuelta_triggered();

    void on_actionReporte_por_Bloque_triggered();

    void on_actionIndividual_4_triggered();

    void on_actionGeneral_7_triggered();

    void on_actionPor_Ruta_triggered();

    void on_actionGeneral_8_triggered();

    void on_actionReportes_triggered();

private:
    Ui::MainWindow *ui;
    QWebSocket *webSocket;
    void mostrarImagenes(QString );
public slots:
    void onConnect();
    void onTextMessageReceived(QString message);
signals:
    void closed();
};

#endif // MAINWINDOW_H
