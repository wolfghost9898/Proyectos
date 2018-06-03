#include "puntajes.h"
#include "ui_puntajes.h"
#include "auxiliar.h"
#include "QMessageBox"
#include "QString"
#include "QTextStream"
#include "QFile"

 _users *primerouser;
 _users *ultimouser;

Puntajes::Puntajes(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Puntajes)
{
    ui->setupUi(this);
}

Puntajes::~Puntajes()
{
    delete ui;
}

void Puntajes::on_pushButton_clicked()
{
    struct _listapunta *temp=primerolista;
    QFile file("Puntaje.txt");
    file.open(QIODevice::ReadWrite | QIODevice::Truncate);
    QTextStream text(&file);
    while(temp!=NULL){
        text<<"Usuario "<<temp->usuario<<","<<"Nivel "<<temp->id<<","<<"Puntaje: "<<temp->puntaje<<endl;
        temp=temp->siguiente;
    }
    file.close();
    file.open(QIODevice::ReadOnly);
        QTextStream in(&file);
        ui->consola->setText(in.readAll());
        file.close();
}

void Puntajes::agregarUsuario(){
    struct _users *nuevo=(struct _users*)malloc(sizeof(struct _users));
    nuevo->cabecera_enemigo0=NULL;
    nuevo->cabecera_enemigo1=NULL;
    nuevo->cabecera_enemigo2=NULL;
    nuevo->cabecera_enemigo0u=NULL;
    nuevo->cabecera_enemigo1u=NULL;
    nuevo->cabecera_enemigo2u=NULL;
    if(primerouser==NULL){
        nuevo->id=0;
        nuevo->siguiente=NULL;
        primerouser=nuevo;
        ultimouser=nuevo;
    }else{
        nuevo->id=ultimouser->id+1;
        ultimouser->siguiente=nuevo;
        nuevo->anterior=ultimouser;
        nuevo->siguiente=NULL;
        ultimouser=nuevo;

    }

}

