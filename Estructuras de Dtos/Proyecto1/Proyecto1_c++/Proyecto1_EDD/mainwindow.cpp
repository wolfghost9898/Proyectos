#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "niveles.h"
#include "puntajes.h"
#include "QMessageBox"
#include "QString"

Puntajes *points;

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

}

MainWindow::~MainWindow()
{


    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    niveles *nivel= new niveles();
    nivel->show();
}


void MainWindow::on_pushButton_3_clicked()
{
    Puntajes *puntajes= new Puntajes();
    points=puntajes;
    puntajes->show();

}

void MainWindow::on_acercade_clicked()
{
    QString s="Carlos Hernandez \n 201612118 \n EDD SECCION B ";
    QMessageBox m;
    m.setText(s);
    m.exec();
}
