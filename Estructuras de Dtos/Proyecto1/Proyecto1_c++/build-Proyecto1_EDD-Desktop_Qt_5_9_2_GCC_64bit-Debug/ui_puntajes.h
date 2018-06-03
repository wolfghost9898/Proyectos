/********************************************************************************
** Form generated from reading UI file 'puntajes.ui'
**
** Created by: Qt User Interface Compiler version 5.9.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_PUNTAJES_H
#define UI_PUNTAJES_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Puntajes
{
public:
    QWidget *centralwidget;
    QPushButton *pushButton;
    QTextEdit *consola;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *Puntajes)
    {
        if (Puntajes->objectName().isEmpty())
            Puntajes->setObjectName(QStringLiteral("Puntajes"));
        Puntajes->resize(800, 600);
        centralwidget = new QWidget(Puntajes);
        centralwidget->setObjectName(QStringLiteral("centralwidget"));
        pushButton = new QPushButton(centralwidget);
        pushButton->setObjectName(QStringLiteral("pushButton"));
        pushButton->setGeometry(QRect(20, 0, 171, 33));
        consola = new QTextEdit(centralwidget);
        consola->setObjectName(QStringLiteral("consola"));
        consola->setGeometry(QRect(20, 60, 721, 361));
        Puntajes->setCentralWidget(centralwidget);
        menubar = new QMenuBar(Puntajes);
        menubar->setObjectName(QStringLiteral("menubar"));
        menubar->setGeometry(QRect(0, 0, 800, 30));
        Puntajes->setMenuBar(menubar);
        statusbar = new QStatusBar(Puntajes);
        statusbar->setObjectName(QStringLiteral("statusbar"));
        Puntajes->setStatusBar(statusbar);

        retranslateUi(Puntajes);

        QMetaObject::connectSlotsByName(Puntajes);
    } // setupUi

    void retranslateUi(QMainWindow *Puntajes)
    {
        Puntajes->setWindowTitle(QApplication::translate("Puntajes", "MainWindow", Q_NULLPTR));
        pushButton->setText(QApplication::translate("Puntajes", "Mostrar Puntajes", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class Puntajes: public Ui_Puntajes {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_PUNTAJES_H
