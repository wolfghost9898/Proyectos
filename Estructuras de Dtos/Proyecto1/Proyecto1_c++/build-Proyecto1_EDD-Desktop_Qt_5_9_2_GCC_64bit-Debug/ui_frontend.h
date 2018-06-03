/********************************************************************************
** Form generated from reading UI file 'frontend.ui'
**
** Created by: Qt User Interface Compiler version 5.9.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_FRONTEND_H
#define UI_FRONTEND_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QScrollArea>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextBrowser>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_FrontEnd
{
public:
    QWidget *centralwidget;
    QWidget *gridWidget;
    QLabel *label;
    QLabel *nivel;
    QLabel *tamanio;
    QLabel *label_2;
    QLabel *puntos;
    QLabel *label_3;
    QLabel *minutos;
    QLabel *segundos;
    QLabel *label_4;
    QScrollArea *scrollArea;
    QWidget *scrollAreaWidgetContents;
    QLabel *imagen;
    QScrollArea *scrollArea2;
    QWidget *scrollAreaWidgetContents_2;
    QLabel *imagen2;
    QLabel *label_6;
    QLineEdit *num_x;
    QLabel *label_7;
    QLineEdit *num_y;
    QPushButton *Ver;
    QTextBrowser *Consola;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *FrontEnd)
    {
        if (FrontEnd->objectName().isEmpty())
            FrontEnd->setObjectName(QStringLiteral("FrontEnd"));
        FrontEnd->resize(1192, 751);
        centralwidget = new QWidget(FrontEnd);
        centralwidget->setObjectName(QStringLiteral("centralwidget"));
        gridWidget = new QWidget(centralwidget);
        gridWidget->setObjectName(QStringLiteral("gridWidget"));
        gridWidget->setGeometry(QRect(0, 0, 821, 31));
        label = new QLabel(gridWidget);
        label->setObjectName(QStringLiteral("label"));
        label->setGeometry(QRect(0, 10, 59, 15));
        nivel = new QLabel(gridWidget);
        nivel->setObjectName(QStringLiteral("nivel"));
        nivel->setGeometry(QRect(40, 10, 59, 15));
        tamanio = new QLabel(gridWidget);
        tamanio->setObjectName(QStringLiteral("tamanio"));
        tamanio->setGeometry(QRect(110, 10, 59, 15));
        label_2 = new QLabel(gridWidget);
        label_2->setObjectName(QStringLiteral("label_2"));
        label_2->setGeometry(QRect(270, 10, 59, 15));
        puntos = new QLabel(gridWidget);
        puntos->setObjectName(QStringLiteral("puntos"));
        puntos->setGeometry(QRect(320, 10, 59, 15));
        label_3 = new QLabel(gridWidget);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(520, 10, 59, 15));
        minutos = new QLabel(gridWidget);
        minutos->setObjectName(QStringLiteral("minutos"));
        minutos->setGeometry(QRect(580, 10, 59, 15));
        segundos = new QLabel(gridWidget);
        segundos->setObjectName(QStringLiteral("segundos"));
        segundos->setGeometry(QRect(650, 10, 59, 15));
        label_4 = new QLabel(gridWidget);
        label_4->setObjectName(QStringLiteral("label_4"));
        label_4->setGeometry(QRect(640, 10, 16, 16));
        scrollArea = new QScrollArea(centralwidget);
        scrollArea->setObjectName(QStringLiteral("scrollArea"));
        scrollArea->setGeometry(QRect(10, 50, 841, 501));
        scrollArea->setWidgetResizable(true);
        scrollAreaWidgetContents = new QWidget();
        scrollAreaWidgetContents->setObjectName(QStringLiteral("scrollAreaWidgetContents"));
        scrollAreaWidgetContents->setGeometry(QRect(0, 0, 839, 499));
        imagen = new QLabel(scrollAreaWidgetContents);
        imagen->setObjectName(QStringLiteral("imagen"));
        imagen->setGeometry(QRect(10, 10, 59, 15));
        scrollArea->setWidget(scrollAreaWidgetContents);
        scrollArea2 = new QScrollArea(centralwidget);
        scrollArea2->setObjectName(QStringLiteral("scrollArea2"));
        scrollArea2->setGeometry(QRect(870, 50, 311, 501));
        scrollArea2->setWidgetResizable(true);
        scrollAreaWidgetContents_2 = new QWidget();
        scrollAreaWidgetContents_2->setObjectName(QStringLiteral("scrollAreaWidgetContents_2"));
        scrollAreaWidgetContents_2->setGeometry(QRect(0, 0, 309, 499));
        imagen2 = new QLabel(scrollAreaWidgetContents_2);
        imagen2->setObjectName(QStringLiteral("imagen2"));
        imagen2->setGeometry(QRect(40, 50, 59, 15));
        scrollArea2->setWidget(scrollAreaWidgetContents_2);
        label_6 = new QLabel(centralwidget);
        label_6->setObjectName(QStringLiteral("label_6"));
        label_6->setGeometry(QRect(0, 560, 21, 16));
        num_x = new QLineEdit(centralwidget);
        num_x->setObjectName(QStringLiteral("num_x"));
        num_x->setGeometry(QRect(20, 560, 31, 23));
        label_7 = new QLabel(centralwidget);
        label_7->setObjectName(QStringLiteral("label_7"));
        label_7->setGeometry(QRect(60, 560, 21, 16));
        num_y = new QLineEdit(centralwidget);
        num_y->setObjectName(QStringLiteral("num_y"));
        num_y->setGeometry(QRect(70, 560, 31, 23));
        Ver = new QPushButton(centralwidget);
        Ver->setObjectName(QStringLiteral("Ver"));
        Ver->setGeometry(QRect(110, 560, 80, 23));
        Consola = new QTextBrowser(centralwidget);
        Consola->setObjectName(QStringLiteral("Consola"));
        Consola->setGeometry(QRect(50, 590, 801, 91));
        FrontEnd->setCentralWidget(centralwidget);
        menubar = new QMenuBar(FrontEnd);
        menubar->setObjectName(QStringLiteral("menubar"));
        menubar->setGeometry(QRect(0, 0, 1192, 30));
        FrontEnd->setMenuBar(menubar);
        statusbar = new QStatusBar(FrontEnd);
        statusbar->setObjectName(QStringLiteral("statusbar"));
        FrontEnd->setStatusBar(statusbar);

        retranslateUi(FrontEnd);

        QMetaObject::connectSlotsByName(FrontEnd);
    } // setupUi

    void retranslateUi(QMainWindow *FrontEnd)
    {
        FrontEnd->setWindowTitle(QApplication::translate("FrontEnd", "MainWindow", Q_NULLPTR));
        label->setText(QApplication::translate("FrontEnd", "Nivel:", Q_NULLPTR));
        nivel->setText(QString());
        tamanio->setText(QString());
        label_2->setText(QApplication::translate("FrontEnd", "Puntos:", Q_NULLPTR));
        puntos->setText(QApplication::translate("FrontEnd", "0", Q_NULLPTR));
        label_3->setText(QApplication::translate("FrontEnd", "Tiempo:", Q_NULLPTR));
        minutos->setText(QString());
        segundos->setText(QString());
        label_4->setText(QApplication::translate("FrontEnd", ":", Q_NULLPTR));
        imagen->setText(QApplication::translate("FrontEnd", "TextLabel", Q_NULLPTR));
        imagen2->setText(QApplication::translate("FrontEnd", "TextLabel", Q_NULLPTR));
        label_6->setText(QApplication::translate("FrontEnd", "X:", Q_NULLPTR));
        label_7->setText(QApplication::translate("FrontEnd", "Y:", Q_NULLPTR));
        Ver->setText(QApplication::translate("FrontEnd", "Ver", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class FrontEnd: public Ui_FrontEnd {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_FRONTEND_H
