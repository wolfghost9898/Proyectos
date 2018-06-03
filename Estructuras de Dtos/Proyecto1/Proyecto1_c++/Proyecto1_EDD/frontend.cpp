#include "frontend.h"
#include "ui_frontend.h"
#include <QFile>
#include "auxiliar.h"
#include <QTextStream>
#include <QMessageBox>
#include <QScrollBar>
static int minutos;
static int segundos;


FrontEnd::FrontEnd(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::FrontEnd)
{
    ui->setupUi(this);
    setearTiempo();
}

void FrontEnd::updatePixmap(){
mostrarImagen();
}

void FrontEnd::updateTimer(){
    QFile file("Consola.txt");
    file.open(QIODevice::ReadOnly);
    QTextStream in(&file);
    ui->Consola->setText(in.readAll());
    file.close();
    QScrollBar *sb=ui->Consola->verticalScrollBar();
    sb->setValue(sb->maximum());
}

FrontEnd::~FrontEnd()
{
    delete ui;
}

void FrontEnd::obtenerDatos(QString nivel,QString tamanio){
ui->nivel->setText(nivel);
QString tam=tamanio+"x"+tamanio;
ui->tamanio->setText(tam);
}

void FrontEnd::mostrarImagen(){
    QPixmap  pix("Matriz.png");
          ui->imagen->setParent(this);
          ui->imagen->setPixmap(pix);
          ui->scrollArea->setWidget(ui->imagen);
          ui->imagen->setParent(ui->scrollArea);
          ui->imagen->show();
}



void FrontEnd::on_Ver_clicked()
{
    int x=ui->num_x->text().toInt();
    int y=ui->num_y->text().toInt();
    bool ciclo=true;

    struct _nivel *nivel=primeronivel;
    for(int i=0;i<num_nivel;i++){
        nivel=nivel->siguiente;
    }


    struct _cabeceracoluma *temp=nivel->primerocolumna;
    while(ciclo){
        if(temp!=NULL){
            if(temp->numero==x){
                struct _matriz *aux=temp->primeromatriz;
                while(ciclo){
                    if(aux!=NULL){
                        if(aux->y==y){
                            QFile file("PilaEnemigos.dot");
                            file.open(QIODevice::WriteOnly | QIODevice::Truncate);
                            QTextStream text(&file);
                            struct _pilaEnemigos *enemigo=aux->primerenemigo;
                            text<<"digraph G{"<<endl;
                            text<<"subgraph enemigo{"<<endl;
                            while(enemigo!=NULL){
                                 long int point = reinterpret_cast<long int>(enemigo);
                                if(enemigo->siguiente!=NULL){
                                    long int point2 = reinterpret_cast<long int>(enemigo->siguiente);
                                    text<<point<<"[shape=box,label=\"Enemigo\"];"<<endl;
                                    text<<point2<<"[shape=box,label=\"Enemigo\"];"<<endl;
                                    text<<point2<<"->"<<point<<";"<<endl;
                                }else if(enemigo==aux->primerenemigo){
                                    text<<point<<"[shape=box,label=\"Enemigo\"];"<<endl;
                                }
                                enemigo=enemigo->siguiente;
                            }
                            text<<"}"<<endl;
                            text<<"}"<<endl;
                            file.close();
                            system("dot -Tpng PilaEnemigos.dot -o PilaEnemigos.png");
                            ciclo=false;
                            mostrarEnemigo();

                        }else{
                            aux=aux->siguiente;
                        }
                    }else{
                        ciclo=false;
                    }
                }
            }else{
                temp=temp->siguiente;
            }
        }else{
            ciclo=false;
        }
    }
}

void FrontEnd::mostrarEnemigo(){
    QPixmap  pix("PilaEnemigos.png");
          ui->imagen2->setParent(this);
          ui->imagen2->setPixmap(pix);
          ui->scrollArea2->setWidget(ui->imagen2);
          ui->imagen2->setParent(ui->scrollArea2);
          ui->imagen2->show();
}

void FrontEnd::cambiarPuntaje(int numero){
    int numeros=ui->puntos->text().toInt();
    numeros=numero+numeros;
    QString punta=QString::number(numeros);
    ui->puntos->setText(punta);
}

void FrontEnd::setearTiempo(){
    int niv=ui->nivel->text().toInt();
    if(niv==0 || niv==1){
       ui->minutos->setText("1");
       ui->segundos->setText("00");
       minutos=1;
       segundos=0;
     }else if(niv==2 || niv==3){
        ui->minutos->setText("1");
        ui->segundos->setText("30");
        minutos=1;
        segundos=30;
     }else if(niv==4 || niv==5){
        ui->minutos->setText("2");
        ui->segundos->setText("00");
        minutos=2;
        segundos=0;
     }else{
        ui->minutos->setText("3");
        ui->segundos->setText("00");
        minutos=3;
        segundos=0;
     }
}

void FrontEnd::cambiarTiempo(){
    if(segundos==0){
       segundos=59;
       minutos-=1;
     }else{
        segundos-=1;
     }
    QString m=QString::number(minutos);
    QString s=QString::number(segundos);
     ui->segundos->setText(s);
     ui->minutos->setText(m);
}


