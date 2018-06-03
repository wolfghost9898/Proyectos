/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.9.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QScrollArea>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QAction *actionAutobuses;
    QAction *actionPilotos;
    QAction *actionUbicacion;
    QAction *actionParqueos;
    QAction *actionUsuarios;
    QAction *actionRutas;
    QAction *actionCrear_Bloque;
    QAction *actionCargar_Bitacora;
    QAction *actionVer_Informacion;
    QAction *actionPor_Bloque;
    QAction *actionPor_Ruta;
    QAction *actionGeneral;
    QAction *actionUn_solo_AutoBus;
    QAction *actionColision;
    QAction *actionGeneral_2;
    QAction *actionColision_2;
    QAction *actionIndividual;
    QAction *actionAutobus;
    QAction *actionPiloto;
    QAction *actionGeneral_3;
    QAction *actionIndividual_2;
    QAction *actionEstacion;
    QAction *actionRutas_General;
    QAction *actionVer_Ruta;
    QAction *actionRuta;
    QAction *actionGeneral_4;
    QAction *actionParqueo_Individual;
    QAction *actionParqueo_2;
    QAction *actionGeneral_5;
    QAction *actionIndividual_3;
    QAction *actionUsuario;
    QAction *actionGeneral_6;
    QAction *actionRutas_de_un_Bloque;
    QAction *actionAvl_de_Rutas_de_un_Bloque;
    QAction *actionid;
    QAction *actionvuelta;
    QAction *actionIndividual_4;
    QAction *actionGeneral_7;
    QAction *actionGeneral_8;
    QAction *actionReportes;
    QWidget *centralWidget;
    QScrollArea *scrollArea;
    QWidget *scrollAreaWidgetContents;
    QLabel *imagen;
    QMenuBar *menuBar;
    QMenu *menuAbrir;
    QMenu *menuCrear;
    QMenu *menuBitacora;
    QMenu *menuVer;
    QMenu *menuAutobuses;
    QMenu *menuPilotos;
    QMenu *menuEstaciones;
    QMenu *menuRutas;
    QMenu *menuParqueo;
    QMenu *menuUsuarios;
    QMenu *menuBloque;
    QMenu *menumostrar_Avl;
    QMenu *menuReporte;
    QMenu *menuReporte_por_Bloque;
    QMenu *menuReporte_por_Ruta;
    QMenu *menuReportes;
    QMenu *menuEliminar;
    QMenu *menuGenerar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->resize(807, 539);
        actionAutobuses = new QAction(MainWindow);
        actionAutobuses->setObjectName(QStringLiteral("actionAutobuses"));
        actionPilotos = new QAction(MainWindow);
        actionPilotos->setObjectName(QStringLiteral("actionPilotos"));
        actionUbicacion = new QAction(MainWindow);
        actionUbicacion->setObjectName(QStringLiteral("actionUbicacion"));
        actionParqueos = new QAction(MainWindow);
        actionParqueos->setObjectName(QStringLiteral("actionParqueos"));
        actionUsuarios = new QAction(MainWindow);
        actionUsuarios->setObjectName(QStringLiteral("actionUsuarios"));
        actionRutas = new QAction(MainWindow);
        actionRutas->setObjectName(QStringLiteral("actionRutas"));
        actionCrear_Bloque = new QAction(MainWindow);
        actionCrear_Bloque->setObjectName(QStringLiteral("actionCrear_Bloque"));
        actionCargar_Bitacora = new QAction(MainWindow);
        actionCargar_Bitacora->setObjectName(QStringLiteral("actionCargar_Bitacora"));
        actionVer_Informacion = new QAction(MainWindow);
        actionVer_Informacion->setObjectName(QStringLiteral("actionVer_Informacion"));
        actionPor_Bloque = new QAction(MainWindow);
        actionPor_Bloque->setObjectName(QStringLiteral("actionPor_Bloque"));
        actionPor_Ruta = new QAction(MainWindow);
        actionPor_Ruta->setObjectName(QStringLiteral("actionPor_Ruta"));
        actionGeneral = new QAction(MainWindow);
        actionGeneral->setObjectName(QStringLiteral("actionGeneral"));
        actionUn_solo_AutoBus = new QAction(MainWindow);
        actionUn_solo_AutoBus->setObjectName(QStringLiteral("actionUn_solo_AutoBus"));
        actionColision = new QAction(MainWindow);
        actionColision->setObjectName(QStringLiteral("actionColision"));
        actionGeneral_2 = new QAction(MainWindow);
        actionGeneral_2->setObjectName(QStringLiteral("actionGeneral_2"));
        actionColision_2 = new QAction(MainWindow);
        actionColision_2->setObjectName(QStringLiteral("actionColision_2"));
        actionIndividual = new QAction(MainWindow);
        actionIndividual->setObjectName(QStringLiteral("actionIndividual"));
        actionAutobus = new QAction(MainWindow);
        actionAutobus->setObjectName(QStringLiteral("actionAutobus"));
        actionPiloto = new QAction(MainWindow);
        actionPiloto->setObjectName(QStringLiteral("actionPiloto"));
        actionGeneral_3 = new QAction(MainWindow);
        actionGeneral_3->setObjectName(QStringLiteral("actionGeneral_3"));
        actionIndividual_2 = new QAction(MainWindow);
        actionIndividual_2->setObjectName(QStringLiteral("actionIndividual_2"));
        actionEstacion = new QAction(MainWindow);
        actionEstacion->setObjectName(QStringLiteral("actionEstacion"));
        actionRutas_General = new QAction(MainWindow);
        actionRutas_General->setObjectName(QStringLiteral("actionRutas_General"));
        actionVer_Ruta = new QAction(MainWindow);
        actionVer_Ruta->setObjectName(QStringLiteral("actionVer_Ruta"));
        actionRuta = new QAction(MainWindow);
        actionRuta->setObjectName(QStringLiteral("actionRuta"));
        actionGeneral_4 = new QAction(MainWindow);
        actionGeneral_4->setObjectName(QStringLiteral("actionGeneral_4"));
        actionParqueo_Individual = new QAction(MainWindow);
        actionParqueo_Individual->setObjectName(QStringLiteral("actionParqueo_Individual"));
        actionParqueo_2 = new QAction(MainWindow);
        actionParqueo_2->setObjectName(QStringLiteral("actionParqueo_2"));
        actionGeneral_5 = new QAction(MainWindow);
        actionGeneral_5->setObjectName(QStringLiteral("actionGeneral_5"));
        actionIndividual_3 = new QAction(MainWindow);
        actionIndividual_3->setObjectName(QStringLiteral("actionIndividual_3"));
        actionUsuario = new QAction(MainWindow);
        actionUsuario->setObjectName(QStringLiteral("actionUsuario"));
        actionGeneral_6 = new QAction(MainWindow);
        actionGeneral_6->setObjectName(QStringLiteral("actionGeneral_6"));
        actionRutas_de_un_Bloque = new QAction(MainWindow);
        actionRutas_de_un_Bloque->setObjectName(QStringLiteral("actionRutas_de_un_Bloque"));
        actionAvl_de_Rutas_de_un_Bloque = new QAction(MainWindow);
        actionAvl_de_Rutas_de_un_Bloque->setObjectName(QStringLiteral("actionAvl_de_Rutas_de_un_Bloque"));
        actionid = new QAction(MainWindow);
        actionid->setObjectName(QStringLiteral("actionid"));
        actionvuelta = new QAction(MainWindow);
        actionvuelta->setObjectName(QStringLiteral("actionvuelta"));
        actionIndividual_4 = new QAction(MainWindow);
        actionIndividual_4->setObjectName(QStringLiteral("actionIndividual_4"));
        actionGeneral_7 = new QAction(MainWindow);
        actionGeneral_7->setObjectName(QStringLiteral("actionGeneral_7"));
        actionGeneral_8 = new QAction(MainWindow);
        actionGeneral_8->setObjectName(QStringLiteral("actionGeneral_8"));
        actionReportes = new QAction(MainWindow);
        actionReportes->setObjectName(QStringLiteral("actionReportes"));
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        scrollArea = new QScrollArea(centralWidget);
        scrollArea->setObjectName(QStringLiteral("scrollArea"));
        scrollArea->setGeometry(QRect(10, 20, 781, 431));
        scrollArea->setWidgetResizable(true);
        scrollAreaWidgetContents = new QWidget();
        scrollAreaWidgetContents->setObjectName(QStringLiteral("scrollAreaWidgetContents"));
        scrollAreaWidgetContents->setGeometry(QRect(0, 0, 779, 429));
        imagen = new QLabel(scrollAreaWidgetContents);
        imagen->setObjectName(QStringLiteral("imagen"));
        imagen->setGeometry(QRect(80, 80, 53, 25));
        scrollArea->setWidget(scrollAreaWidgetContents);
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 807, 30));
        menuAbrir = new QMenu(menuBar);
        menuAbrir->setObjectName(QStringLiteral("menuAbrir"));
        menuCrear = new QMenu(menuBar);
        menuCrear->setObjectName(QStringLiteral("menuCrear"));
        menuBitacora = new QMenu(menuBar);
        menuBitacora->setObjectName(QStringLiteral("menuBitacora"));
        menuVer = new QMenu(menuBar);
        menuVer->setObjectName(QStringLiteral("menuVer"));
        menuAutobuses = new QMenu(menuVer);
        menuAutobuses->setObjectName(QStringLiteral("menuAutobuses"));
        menuPilotos = new QMenu(menuVer);
        menuPilotos->setObjectName(QStringLiteral("menuPilotos"));
        menuEstaciones = new QMenu(menuVer);
        menuEstaciones->setObjectName(QStringLiteral("menuEstaciones"));
        menuRutas = new QMenu(menuVer);
        menuRutas->setObjectName(QStringLiteral("menuRutas"));
        menuParqueo = new QMenu(menuVer);
        menuParqueo->setObjectName(QStringLiteral("menuParqueo"));
        menuUsuarios = new QMenu(menuVer);
        menuUsuarios->setObjectName(QStringLiteral("menuUsuarios"));
        menuBloque = new QMenu(menuVer);
        menuBloque->setObjectName(QStringLiteral("menuBloque"));
        menumostrar_Avl = new QMenu(menuBloque);
        menumostrar_Avl->setObjectName(QStringLiteral("menumostrar_Avl"));
        menuReporte = new QMenu(menuVer);
        menuReporte->setObjectName(QStringLiteral("menuReporte"));
        menuReporte_por_Bloque = new QMenu(menuReporte);
        menuReporte_por_Bloque->setObjectName(QStringLiteral("menuReporte_por_Bloque"));
        menuReporte_por_Ruta = new QMenu(menuReporte);
        menuReporte_por_Ruta->setObjectName(QStringLiteral("menuReporte_por_Ruta"));
        menuReportes = new QMenu(menuBar);
        menuReportes->setObjectName(QStringLiteral("menuReportes"));
        menuEliminar = new QMenu(menuBar);
        menuEliminar->setObjectName(QStringLiteral("menuEliminar"));
        menuGenerar = new QMenu(menuBar);
        menuGenerar->setObjectName(QStringLiteral("menuGenerar"));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        MainWindow->setStatusBar(statusBar);

        menuBar->addAction(menuAbrir->menuAction());
        menuBar->addAction(menuCrear->menuAction());
        menuBar->addAction(menuBitacora->menuAction());
        menuBar->addAction(menuReportes->menuAction());
        menuBar->addAction(menuVer->menuAction());
        menuBar->addAction(menuEliminar->menuAction());
        menuBar->addAction(menuGenerar->menuAction());
        menuAbrir->addAction(actionAutobuses);
        menuAbrir->addAction(actionPilotos);
        menuAbrir->addAction(actionUbicacion);
        menuAbrir->addAction(actionParqueos);
        menuAbrir->addAction(actionUsuarios);
        menuAbrir->addAction(actionRutas);
        menuCrear->addAction(actionCrear_Bloque);
        menuBitacora->addSeparator();
        menuBitacora->addAction(actionCargar_Bitacora);
        menuVer->addAction(actionVer_Informacion);
        menuVer->addAction(menuAutobuses->menuAction());
        menuVer->addAction(menuPilotos->menuAction());
        menuVer->addAction(menuEstaciones->menuAction());
        menuVer->addAction(menuRutas->menuAction());
        menuVer->addAction(menuParqueo->menuAction());
        menuVer->addAction(menuUsuarios->menuAction());
        menuVer->addAction(menuBloque->menuAction());
        menuVer->addAction(menuReporte->menuAction());
        menuAutobuses->addAction(actionGeneral);
        menuAutobuses->addAction(actionUn_solo_AutoBus);
        menuAutobuses->addAction(actionColision);
        menuPilotos->addAction(actionGeneral_2);
        menuPilotos->addAction(actionColision_2);
        menuPilotos->addAction(actionIndividual);
        menuEstaciones->addAction(actionGeneral_3);
        menuEstaciones->addAction(actionIndividual_2);
        menuRutas->addAction(actionRutas_General);
        menuRutas->addAction(actionVer_Ruta);
        menuParqueo->addAction(actionGeneral_4);
        menuParqueo->addAction(actionParqueo_Individual);
        menuUsuarios->addAction(actionGeneral_5);
        menuUsuarios->addAction(actionIndividual_3);
        menuBloque->addAction(actionGeneral_6);
        menuBloque->addAction(actionRutas_de_un_Bloque);
        menuBloque->addAction(actionAvl_de_Rutas_de_un_Bloque);
        menuBloque->addAction(menumostrar_Avl->menuAction());
        menumostrar_Avl->addAction(actionid);
        menumostrar_Avl->addAction(actionvuelta);
        menuReporte->addAction(menuReporte_por_Bloque->menuAction());
        menuReporte->addAction(menuReporte_por_Ruta->menuAction());
        menuReporte_por_Bloque->addAction(actionIndividual_4);
        menuReporte_por_Bloque->addAction(actionGeneral_7);
        menuReporte_por_Ruta->addAction(actionGeneral_8);
        menuReportes->addAction(actionPor_Bloque);
        menuReportes->addAction(actionPor_Ruta);
        menuEliminar->addAction(actionAutobus);
        menuEliminar->addAction(actionPiloto);
        menuEliminar->addAction(actionEstacion);
        menuEliminar->addAction(actionRuta);
        menuEliminar->addAction(actionParqueo_2);
        menuEliminar->addAction(actionUsuario);
        menuGenerar->addAction(actionReportes);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "MainWindow", Q_NULLPTR));
        actionAutobuses->setText(QApplication::translate("MainWindow", "Autobuses", Q_NULLPTR));
        actionPilotos->setText(QApplication::translate("MainWindow", "Pilotos", Q_NULLPTR));
        actionUbicacion->setText(QApplication::translate("MainWindow", "Estaciones", Q_NULLPTR));
        actionParqueos->setText(QApplication::translate("MainWindow", "Parqueos", Q_NULLPTR));
        actionUsuarios->setText(QApplication::translate("MainWindow", "Usuarios", Q_NULLPTR));
        actionRutas->setText(QApplication::translate("MainWindow", "Rutas", Q_NULLPTR));
        actionCrear_Bloque->setText(QApplication::translate("MainWindow", "Crear Bloque", Q_NULLPTR));
        actionCargar_Bitacora->setText(QApplication::translate("MainWindow", "Cargar Bitacora", Q_NULLPTR));
        actionVer_Informacion->setText(QApplication::translate("MainWindow", "Ver Informacion", Q_NULLPTR));
        actionPor_Bloque->setText(QApplication::translate("MainWindow", "Por Bloque", Q_NULLPTR));
        actionPor_Ruta->setText(QApplication::translate("MainWindow", "Por Ruta", Q_NULLPTR));
        actionGeneral->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionUn_solo_AutoBus->setText(QApplication::translate("MainWindow", "Individual", Q_NULLPTR));
        actionColision->setText(QApplication::translate("MainWindow", "Colision", Q_NULLPTR));
        actionGeneral_2->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionColision_2->setText(QApplication::translate("MainWindow", "Colision", Q_NULLPTR));
        actionIndividual->setText(QApplication::translate("MainWindow", "Individual", Q_NULLPTR));
        actionAutobus->setText(QApplication::translate("MainWindow", "Autobus", Q_NULLPTR));
        actionPiloto->setText(QApplication::translate("MainWindow", "Piloto", Q_NULLPTR));
        actionGeneral_3->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionIndividual_2->setText(QApplication::translate("MainWindow", "Individual", Q_NULLPTR));
        actionEstacion->setText(QApplication::translate("MainWindow", "Estacion", Q_NULLPTR));
        actionRutas_General->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionVer_Ruta->setText(QApplication::translate("MainWindow", "Ver Ruta", Q_NULLPTR));
        actionRuta->setText(QApplication::translate("MainWindow", "Ruta", Q_NULLPTR));
        actionGeneral_4->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionParqueo_Individual->setText(QApplication::translate("MainWindow", "Parqueo Individual", Q_NULLPTR));
        actionParqueo_2->setText(QApplication::translate("MainWindow", "Parqueo", Q_NULLPTR));
        actionGeneral_5->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionIndividual_3->setText(QApplication::translate("MainWindow", "Individual", Q_NULLPTR));
        actionUsuario->setText(QApplication::translate("MainWindow", "Usuario", Q_NULLPTR));
        actionGeneral_6->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionRutas_de_un_Bloque->setText(QApplication::translate("MainWindow", "Rutas de un Bloque", Q_NULLPTR));
        actionAvl_de_Rutas_de_un_Bloque->setText(QApplication::translate("MainWindow", "ver Grafo de Ruta", Q_NULLPTR));
        actionid->setText(QApplication::translate("MainWindow", "ida", Q_NULLPTR));
        actionvuelta->setText(QApplication::translate("MainWindow", "vuelta", Q_NULLPTR));
        actionIndividual_4->setText(QApplication::translate("MainWindow", "Individual", Q_NULLPTR));
        actionGeneral_7->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionGeneral_8->setText(QApplication::translate("MainWindow", "General", Q_NULLPTR));
        actionReportes->setText(QApplication::translate("MainWindow", "Reportes", Q_NULLPTR));
        imagen->setText(QApplication::translate("MainWindow", "TextLabel", Q_NULLPTR));
        menuAbrir->setTitle(QApplication::translate("MainWindow", "Abrir", Q_NULLPTR));
        menuCrear->setTitle(QApplication::translate("MainWindow", "Crear", Q_NULLPTR));
        menuBitacora->setTitle(QApplication::translate("MainWindow", "Bitacora", Q_NULLPTR));
        menuVer->setTitle(QApplication::translate("MainWindow", "Ver", Q_NULLPTR));
        menuAutobuses->setTitle(QApplication::translate("MainWindow", "Autobuses", Q_NULLPTR));
        menuPilotos->setTitle(QApplication::translate("MainWindow", "Pilotos", Q_NULLPTR));
        menuEstaciones->setTitle(QApplication::translate("MainWindow", "Estaciones", Q_NULLPTR));
        menuRutas->setTitle(QApplication::translate("MainWindow", "Rutas", Q_NULLPTR));
        menuParqueo->setTitle(QApplication::translate("MainWindow", "Parqueo", Q_NULLPTR));
        menuUsuarios->setTitle(QApplication::translate("MainWindow", "Usuarios", Q_NULLPTR));
        menuBloque->setTitle(QApplication::translate("MainWindow", "Bloque", Q_NULLPTR));
        menumostrar_Avl->setTitle(QApplication::translate("MainWindow", "mostrar Avl", Q_NULLPTR));
        menuReporte->setTitle(QApplication::translate("MainWindow", "Reporte", Q_NULLPTR));
        menuReporte_por_Bloque->setTitle(QApplication::translate("MainWindow", "Reporte por Bloque", Q_NULLPTR));
        menuReporte_por_Ruta->setTitle(QApplication::translate("MainWindow", "Reporte por Ruta", Q_NULLPTR));
        menuReportes->setTitle(QApplication::translate("MainWindow", "Reportes", Q_NULLPTR));
        menuEliminar->setTitle(QApplication::translate("MainWindow", "Eliminar", Q_NULLPTR));
        menuGenerar->setTitle(QApplication::translate("MainWindow", "Generar", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
