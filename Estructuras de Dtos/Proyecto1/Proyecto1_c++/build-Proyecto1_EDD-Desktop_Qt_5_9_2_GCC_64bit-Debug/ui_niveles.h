/********************************************************************************
** Form generated from reading UI file 'niveles.ui'
**
** Created by: Qt User Interface Compiler version 5.9.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_NIVELES_H
#define UI_NIVELES_H

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
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_niveles
{
public:
    QWidget *centralwidget;
    QPushButton *guardar_nivel;
    QLineEdit *cant_nivel;
    QLineEdit *tamano_nivel;
    QWidget *cuerpo_imagen_2;
    QScrollArea *scrollArea;
    QWidget *scrollAreaWidgetContents;
    QLabel *imagen;
    QLineEdit *nivel_ingresar;
    QPushButton *pushButton;
    QLineEdit *lineEdit_2;
    QPushButton *pushButton_2;
    QLineEdit *lineEdit_3;
    QPushButton *pushButton_3;
    QPushButton *pushButton_4;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *niveles)
    {
        if (niveles->objectName().isEmpty())
            niveles->setObjectName(QStringLiteral("niveles"));
        niveles->resize(683, 396);
        centralwidget = new QWidget(niveles);
        centralwidget->setObjectName(QStringLiteral("centralwidget"));
        guardar_nivel = new QPushButton(centralwidget);
        guardar_nivel->setObjectName(QStringLiteral("guardar_nivel"));
        guardar_nivel->setGeometry(QRect(350, 10, 80, 23));
        cant_nivel = new QLineEdit(centralwidget);
        cant_nivel->setObjectName(QStringLiteral("cant_nivel"));
        cant_nivel->setGeometry(QRect(30, 10, 151, 23));
        cant_nivel->setText(QStringLiteral(""));
        tamano_nivel = new QLineEdit(centralwidget);
        tamano_nivel->setObjectName(QStringLiteral("tamano_nivel"));
        tamano_nivel->setGeometry(QRect(190, 10, 151, 23));
        cuerpo_imagen_2 = new QWidget(centralwidget);
        cuerpo_imagen_2->setObjectName(QStringLiteral("cuerpo_imagen_2"));
        cuerpo_imagen_2->setGeometry(QRect(10, 40, 631, 311));
        scrollArea = new QScrollArea(cuerpo_imagen_2);
        scrollArea->setObjectName(QStringLiteral("scrollArea"));
        scrollArea->setGeometry(QRect(9, 9, 471, 300));
        scrollArea->setMinimumSize(QSize(0, 300));
        scrollArea->setMaximumSize(QSize(16777215, 16777215));
        scrollArea->setWidgetResizable(true);
        scrollAreaWidgetContents = new QWidget();
        scrollAreaWidgetContents->setObjectName(QStringLiteral("scrollAreaWidgetContents"));
        scrollAreaWidgetContents->setGeometry(QRect(0, 0, 469, 298));
        imagen = new QLabel(scrollAreaWidgetContents);
        imagen->setObjectName(QStringLiteral("imagen"));
        imagen->setGeometry(QRect(140, 20, 151, 31));
        scrollArea->setWidget(scrollAreaWidgetContents);
        nivel_ingresar = new QLineEdit(cuerpo_imagen_2);
        nivel_ingresar->setObjectName(QStringLiteral("nivel_ingresar"));
        nivel_ingresar->setGeometry(QRect(490, 10, 125, 23));
        nivel_ingresar->setMinimumSize(QSize(10, 0));
        nivel_ingresar->setMaximumSize(QSize(150, 16777215));
        pushButton = new QPushButton(cuerpo_imagen_2);
        pushButton->setObjectName(QStringLiteral("pushButton"));
        pushButton->setGeometry(QRect(510, 40, 80, 23));
        pushButton->setMaximumSize(QSize(100, 16777215));
        lineEdit_2 = new QLineEdit(cuerpo_imagen_2);
        lineEdit_2->setObjectName(QStringLiteral("lineEdit_2"));
        lineEdit_2->setGeometry(QRect(500, 80, 113, 23));
        pushButton_2 = new QPushButton(cuerpo_imagen_2);
        pushButton_2->setObjectName(QStringLiteral("pushButton_2"));
        pushButton_2->setGeometry(QRect(520, 110, 80, 23));
        lineEdit_3 = new QLineEdit(cuerpo_imagen_2);
        lineEdit_3->setObjectName(QStringLiteral("lineEdit_3"));
        lineEdit_3->setGeometry(QRect(500, 150, 121, 23));
        pushButton_3 = new QPushButton(cuerpo_imagen_2);
        pushButton_3->setObjectName(QStringLiteral("pushButton_3"));
        pushButton_3->setGeometry(QRect(520, 180, 80, 23));
        pushButton_4 = new QPushButton(cuerpo_imagen_2);
        pushButton_4->setObjectName(QStringLiteral("pushButton_4"));
        pushButton_4->setGeometry(QRect(540, 240, 80, 23));
        niveles->setCentralWidget(centralwidget);
        menubar = new QMenuBar(niveles);
        menubar->setObjectName(QStringLiteral("menubar"));
        menubar->setGeometry(QRect(0, 0, 683, 20));
        niveles->setMenuBar(menubar);
        statusbar = new QStatusBar(niveles);
        statusbar->setObjectName(QStringLiteral("statusbar"));
        niveles->setStatusBar(statusbar);

        retranslateUi(niveles);

        QMetaObject::connectSlotsByName(niveles);
    } // setupUi

    void retranslateUi(QMainWindow *niveles)
    {
        niveles->setWindowTitle(QApplication::translate("niveles", "Niveles", Q_NULLPTR));
        guardar_nivel->setText(QApplication::translate("niveles", "Guardar", Q_NULLPTR));
        cant_nivel->setPlaceholderText(QApplication::translate("niveles", "Cantidad de Niveles", Q_NULLPTR));
        tamano_nivel->setPlaceholderText(QApplication::translate("niveles", "Tama\303\261o de niveles", Q_NULLPTR));
        imagen->setText(QApplication::translate("niveles", "TextLabel", Q_NULLPTR));
        nivel_ingresar->setPlaceholderText(QApplication::translate("niveles", "Nivel a Ingresar", Q_NULLPTR));
        pushButton->setText(QApplication::translate("niveles", "Ingresar", Q_NULLPTR));
        lineEdit_2->setPlaceholderText(QApplication::translate("niveles", "Reducir Tama\303\261o", Q_NULLPTR));
        pushButton_2->setText(QApplication::translate("niveles", "Reducir", Q_NULLPTR));
        lineEdit_3->setPlaceholderText(QApplication::translate("niveles", "Aumentar Tama\303\261o", Q_NULLPTR));
        pushButton_3->setText(QApplication::translate("niveles", "Aumentar", Q_NULLPTR));
        pushButton_4->setText(QApplication::translate("niveles", "PushButton", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class niveles: public Ui_niveles {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_NIVELES_H
