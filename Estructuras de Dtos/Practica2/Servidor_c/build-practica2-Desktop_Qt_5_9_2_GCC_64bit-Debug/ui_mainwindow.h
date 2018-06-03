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
#include <QtWidgets/QComboBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QScrollArea>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextBrowser>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QAction *actionPost_Orden;
    QAction *actionPre_Orden;
    QAction *actionIn_Orden;
    QAction *actionAmplitud;
    QAction *actionManual_de_Usuario;
    QAction *actionManual_Tecnico;
    QAction *actionAcerca_de;
    QAction *actionCargar_Archivos;
    QAction *actionCrear_Bloque;
    QWidget *centralWidget;
    QWidget *formWidget;
    QComboBox *comboBox_2;
    QScrollArea *scrollArea;
    QWidget *scrollAreaWidgetContents;
    QLabel *listarboles;
    QScrollArea *scrollArea2;
    QWidget *scrollAreaWidgetContents_2;
    QLabel *arbolmostrar;
    QLabel *label;
    QLabel *nombrearbol;
    QLabel *label_2;
    QLabel *alturaarbol;
    QLabel *label_3;
    QLabel *nivelarbol;
    QLabel *label_4;
    QLabel *ramasarbol;
    QLabel *label_5;
    QLabel *padrearbol;
    QLabel *label_6;
    QLabel *hojaarbol;
    QTextBrowser *consola;
    QLabel *label_7;
    QLineEdit *claveBuscar;
    QLabel *label_8;
    QLineEdit *nombreeditar;
    QLabel *label_9;
    QLineEdit *notaeditar;
    QPushButton *subarbolbutton;
    QPushButton *pushButton_2;
    QPushButton *pushButton_3;
    QPushButton *pushButton_4;
    QMenuBar *menuBar;
    QMenu *menuArchivo;
    QMenu *menuRecorridos;
    QMenu *menuBloque;
    QMenu *menuAyuda;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->resize(1300, 745);
        actionPost_Orden = new QAction(MainWindow);
        actionPost_Orden->setObjectName(QStringLiteral("actionPost_Orden"));
        actionPre_Orden = new QAction(MainWindow);
        actionPre_Orden->setObjectName(QStringLiteral("actionPre_Orden"));
        actionIn_Orden = new QAction(MainWindow);
        actionIn_Orden->setObjectName(QStringLiteral("actionIn_Orden"));
        actionAmplitud = new QAction(MainWindow);
        actionAmplitud->setObjectName(QStringLiteral("actionAmplitud"));
        actionManual_de_Usuario = new QAction(MainWindow);
        actionManual_de_Usuario->setObjectName(QStringLiteral("actionManual_de_Usuario"));
        actionManual_Tecnico = new QAction(MainWindow);
        actionManual_Tecnico->setObjectName(QStringLiteral("actionManual_Tecnico"));
        actionAcerca_de = new QAction(MainWindow);
        actionAcerca_de->setObjectName(QStringLiteral("actionAcerca_de"));
        actionCargar_Archivos = new QAction(MainWindow);
        actionCargar_Archivos->setObjectName(QStringLiteral("actionCargar_Archivos"));
        actionCrear_Bloque = new QAction(MainWindow);
        actionCrear_Bloque->setObjectName(QStringLiteral("actionCrear_Bloque"));
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        formWidget = new QWidget(centralWidget);
        formWidget->setObjectName(QStringLiteral("formWidget"));
        formWidget->setGeometry(QRect(849, 259, 431, 411));
        comboBox_2 = new QComboBox(formWidget);
        comboBox_2->setObjectName(QStringLiteral("comboBox_2"));
        comboBox_2->setGeometry(QRect(380, 10, 41, 33));
        scrollArea = new QScrollArea(formWidget);
        scrollArea->setObjectName(QStringLiteral("scrollArea"));
        scrollArea->setGeometry(QRect(60, 60, 371, 331));
        scrollArea->setWidgetResizable(true);
        scrollAreaWidgetContents = new QWidget();
        scrollAreaWidgetContents->setObjectName(QStringLiteral("scrollAreaWidgetContents"));
        scrollAreaWidgetContents->setGeometry(QRect(0, 0, 369, 329));
        listarboles = new QLabel(scrollAreaWidgetContents);
        listarboles->setObjectName(QStringLiteral("listarboles"));
        listarboles->setGeometry(QRect(40, 30, 53, 25));
        scrollArea->setWidget(scrollAreaWidgetContents);
        scrollArea2 = new QScrollArea(centralWidget);
        scrollArea2->setObjectName(QStringLiteral("scrollArea2"));
        scrollArea2->setGeometry(QRect(150, 20, 671, 571));
        scrollArea2->setWidgetResizable(true);
        scrollAreaWidgetContents_2 = new QWidget();
        scrollAreaWidgetContents_2->setObjectName(QStringLiteral("scrollAreaWidgetContents_2"));
        scrollAreaWidgetContents_2->setGeometry(QRect(0, 0, 669, 569));
        arbolmostrar = new QLabel(scrollAreaWidgetContents_2);
        arbolmostrar->setObjectName(QStringLiteral("arbolmostrar"));
        arbolmostrar->setGeometry(QRect(420, 150, 53, 25));
        scrollArea2->setWidget(scrollAreaWidgetContents_2);
        label = new QLabel(centralWidget);
        label->setObjectName(QStringLiteral("label"));
        label->setGeometry(QRect(10, 20, 53, 25));
        nombrearbol = new QLabel(centralWidget);
        nombrearbol->setObjectName(QStringLiteral("nombrearbol"));
        nombrearbol->setGeometry(QRect(70, 20, 53, 25));
        label_2 = new QLabel(centralWidget);
        label_2->setObjectName(QStringLiteral("label_2"));
        label_2->setGeometry(QRect(10, 80, 53, 25));
        alturaarbol = new QLabel(centralWidget);
        alturaarbol->setObjectName(QStringLiteral("alturaarbol"));
        alturaarbol->setGeometry(QRect(60, 80, 53, 25));
        label_3 = new QLabel(centralWidget);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(10, 130, 53, 25));
        nivelarbol = new QLabel(centralWidget);
        nivelarbol->setObjectName(QStringLiteral("nivelarbol"));
        nivelarbol->setGeometry(QRect(50, 130, 53, 25));
        label_4 = new QLabel(centralWidget);
        label_4->setObjectName(QStringLiteral("label_4"));
        label_4->setGeometry(QRect(10, 180, 53, 25));
        ramasarbol = new QLabel(centralWidget);
        ramasarbol->setObjectName(QStringLiteral("ramasarbol"));
        ramasarbol->setGeometry(QRect(70, 180, 53, 25));
        label_5 = new QLabel(centralWidget);
        label_5->setObjectName(QStringLiteral("label_5"));
        label_5->setGeometry(QRect(10, 240, 91, 41));
        padrearbol = new QLabel(centralWidget);
        padrearbol->setObjectName(QStringLiteral("padrearbol"));
        padrearbol->setGeometry(QRect(20, 270, 53, 25));
        label_6 = new QLabel(centralWidget);
        label_6->setObjectName(QStringLiteral("label_6"));
        label_6->setGeometry(QRect(10, 310, 91, 41));
        hojaarbol = new QLabel(centralWidget);
        hojaarbol->setObjectName(QStringLiteral("hojaarbol"));
        hojaarbol->setGeometry(QRect(20, 350, 53, 25));
        consola = new QTextBrowser(centralWidget);
        consola->setObjectName(QStringLiteral("consola"));
        consola->setGeometry(QRect(60, 610, 811, 51));
        label_7 = new QLabel(centralWidget);
        label_7->setObjectName(QStringLiteral("label_7"));
        label_7->setGeometry(QRect(860, 30, 53, 25));
        claveBuscar = new QLineEdit(centralWidget);
        claveBuscar->setObjectName(QStringLiteral("claveBuscar"));
        claveBuscar->setGeometry(QRect(900, 30, 113, 33));
        label_8 = new QLabel(centralWidget);
        label_8->setObjectName(QStringLiteral("label_8"));
        label_8->setGeometry(QRect(860, 80, 53, 25));
        nombreeditar = new QLineEdit(centralWidget);
        nombreeditar->setObjectName(QStringLiteral("nombreeditar"));
        nombreeditar->setGeometry(QRect(930, 80, 221, 33));
        label_9 = new QLabel(centralWidget);
        label_9->setObjectName(QStringLiteral("label_9"));
        label_9->setGeometry(QRect(860, 140, 53, 25));
        notaeditar = new QLineEdit(centralWidget);
        notaeditar->setObjectName(QStringLiteral("notaeditar"));
        notaeditar->setGeometry(QRect(900, 140, 71, 33));
        subarbolbutton = new QPushButton(centralWidget);
        subarbolbutton->setObjectName(QStringLiteral("subarbolbutton"));
        subarbolbutton->setGeometry(QRect(860, 200, 80, 33));
        pushButton_2 = new QPushButton(centralWidget);
        pushButton_2->setObjectName(QStringLiteral("pushButton_2"));
        pushButton_2->setGeometry(QRect(960, 200, 80, 33));
        pushButton_3 = new QPushButton(centralWidget);
        pushButton_3->setObjectName(QStringLiteral("pushButton_3"));
        pushButton_3->setGeometry(QRect(1060, 200, 80, 33));
        pushButton_4 = new QPushButton(centralWidget);
        pushButton_4->setObjectName(QStringLiteral("pushButton_4"));
        pushButton_4->setGeometry(QRect(1070, 30, 80, 33));
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 1300, 30));
        menuArchivo = new QMenu(menuBar);
        menuArchivo->setObjectName(QStringLiteral("menuArchivo"));
        menuRecorridos = new QMenu(menuBar);
        menuRecorridos->setObjectName(QStringLiteral("menuRecorridos"));
        menuBloque = new QMenu(menuBar);
        menuBloque->setObjectName(QStringLiteral("menuBloque"));
        menuAyuda = new QMenu(menuBar);
        menuAyuda->setObjectName(QStringLiteral("menuAyuda"));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        MainWindow->setStatusBar(statusBar);

        menuBar->addAction(menuArchivo->menuAction());
        menuBar->addAction(menuRecorridos->menuAction());
        menuBar->addAction(menuBloque->menuAction());
        menuBar->addAction(menuAyuda->menuAction());
        menuArchivo->addAction(actionCargar_Archivos);
        menuRecorridos->addAction(actionPost_Orden);
        menuRecorridos->addAction(actionPre_Orden);
        menuRecorridos->addAction(actionIn_Orden);
        menuRecorridos->addSeparator();
        menuRecorridos->addAction(actionAmplitud);
        menuBloque->addAction(actionCrear_Bloque);
        menuAyuda->addAction(actionManual_de_Usuario);
        menuAyuda->addAction(actionManual_Tecnico);
        menuAyuda->addSeparator();
        menuAyuda->addAction(actionAcerca_de);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "MainWindow", Q_NULLPTR));
        actionPost_Orden->setText(QApplication::translate("MainWindow", "Post-Orden", Q_NULLPTR));
        actionPre_Orden->setText(QApplication::translate("MainWindow", "Pre-Orden", Q_NULLPTR));
        actionIn_Orden->setText(QApplication::translate("MainWindow", "In-Orden", Q_NULLPTR));
        actionAmplitud->setText(QApplication::translate("MainWindow", "Amplitud", Q_NULLPTR));
        actionManual_de_Usuario->setText(QApplication::translate("MainWindow", "Manual de Usuario", Q_NULLPTR));
        actionManual_Tecnico->setText(QApplication::translate("MainWindow", "Manual Tecnico", Q_NULLPTR));
        actionAcerca_de->setText(QApplication::translate("MainWindow", "Acerca de", Q_NULLPTR));
        actionCargar_Archivos->setText(QApplication::translate("MainWindow", "Cargar Archivos", Q_NULLPTR));
        actionCrear_Bloque->setText(QApplication::translate("MainWindow", "Crear Bloque", Q_NULLPTR));
        listarboles->setText(QString());
        arbolmostrar->setText(QString());
        label->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Nombre:</span></p></body></html>", Q_NULLPTR));
        nombrearbol->setText(QString());
        label_2->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Altura:</span></p></body></html>", Q_NULLPTR));
        alturaarbol->setText(QString());
        label_3->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Nivel:</span></p></body></html>", Q_NULLPTR));
        nivelarbol->setText(QString());
        label_4->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Ramas:</span></p></body></html>", Q_NULLPTR));
        ramasarbol->setText(QString());
        label_5->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Nodos Padre:</span></p></body></html>", Q_NULLPTR));
        padrearbol->setText(QString());
        label_6->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Nodos Hoja:</span></p></body></html>", Q_NULLPTR));
        hojaarbol->setText(QString());
        label_7->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Clave:</span></p></body></html>", Q_NULLPTR));
        label_8->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Nombre:</span></p></body></html>", Q_NULLPTR));
        label_9->setText(QApplication::translate("MainWindow", "<html><head/><body><p><span style=\" font-size:10pt; font-weight:600;\">Nota:</span></p></body></html>", Q_NULLPTR));
        subarbolbutton->setText(QApplication::translate("MainWindow", "SubArbol", Q_NULLPTR));
        pushButton_2->setText(QApplication::translate("MainWindow", "Editar", Q_NULLPTR));
        pushButton_3->setText(QApplication::translate("MainWindow", "Eliminar", Q_NULLPTR));
        pushButton_4->setText(QApplication::translate("MainWindow", "Buscar", Q_NULLPTR));
        menuArchivo->setTitle(QApplication::translate("MainWindow", "Archivo", Q_NULLPTR));
        menuRecorridos->setTitle(QApplication::translate("MainWindow", "Recorridos", Q_NULLPTR));
        menuBloque->setTitle(QApplication::translate("MainWindow", "Bloque", Q_NULLPTR));
        menuAyuda->setTitle(QApplication::translate("MainWindow", "Ayuda", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
