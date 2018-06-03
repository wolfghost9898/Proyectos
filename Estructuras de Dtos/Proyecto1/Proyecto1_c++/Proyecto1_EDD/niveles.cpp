#include "niveles.h"
#include "ui_niveles.h"
#include <QFile>
#include "auxiliar.h"
#include <QTextStream>
#include <QMessageBox>
#include "frontend.h"

_nivel *primeronivel;
_nivel *ultimonivel;

FrontEnd *front;
niveles::niveles(QWidget *parent) :

    QMainWindow(parent),
    ui(new Ui::niveles)
{
    ui->setupUi(this);
    thread=new QThread();
    worker= new generarEnemigos();
    worker->moveToThread(thread);
    QObject::connect(worker,SIGNAL(workRequest()),thread,SLOT(start()));
    QObject::connect(thread,SIGNAL(started()),worker,SLOT(doWork()));
    QObject::connect(worker,SIGNAL(finished()),thread,SLOT(quit()),Qt::DirectConnection);


    generacionNiveles();
    generarGraficaNiveles();
    mostrarGraficaNiveles();
}

niveles::~niveles()
{

    delete ui;

}
//--------------------------------------------------Ocultar o Mostrar Ui-------------------------------
void niveles::generacionNiveles(){
    if(primeronivel==NULL){
        ui->guardar_nivel->setVisible(true);
        ui->cant_nivel->setVisible(true);
        ui->tamano_nivel->setVisible(true);
        ui->cuerpo_imagen_2->setVisible(false);
    }else{
        ui->guardar_nivel->setVisible(false);
        ui->cant_nivel->setVisible(false);
        ui->tamano_nivel->setVisible(false);
        ui->cuerpo_imagen_2->setVisible(true);
    }
}
//--------------------------------------------------Guardar Niveles------------------------------------
void niveles::on_guardar_nivel_clicked()
{
    int cantidad=ui->cant_nivel->text().toInt();
    int tamano=ui->tamano_nivel->text().toInt();
    agregarNiveles(cantidad,tamano);
}
void agregarNiveles(int cantidad,int tamano){
    for(int i=0;i<cantidad;i++){
        struct _nivel *nuevo=(struct _nivel*)malloc(sizeof(struct _nivel));
        nuevo->id=i;
        nuevo->primerocolumna=NULL;
        nuevo->primerofila=NULL;
        nuevo->ultimocolumna=NULL;
        nuevo->ultimofila=NULL;
        if(primeronivel==NULL){
            nuevo->tamano=tamano;
            nuevo->siguiente=NULL;
            nuevo->anterior=NULL;
            nuevo->estado=1;
            primeronivel=ultimonivel=nuevo;
        }else{
            nuevo->estado=0;
            ultimonivel->siguiente=nuevo;
            nuevo->siguiente=NULL;
            ultimonivel=nuevo;
        }
    }
}
//----------------------------------------------------Genera Grafica de Niveles-------------------------
void generarGraficaNiveles(){
    struct _nivel *auxiliar=primeronivel;
    QFile file("Nivel.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    QTextStream text(&file);
    text<<"digraph G{"<<endl;
    text<<"subgraph cluster{"<<endl;
    text<<"label =\" Niveles \";"<<endl;
    //---------------------------------------NIveles-----------------------------
    while(auxiliar!=NULL){
        if(auxiliar!=ultimonivel){
                   long int point = reinterpret_cast<long int>(auxiliar);
                   long int point2 = reinterpret_cast<long int>(auxiliar->siguiente);
                  text<<point<<"->"<<point2<<";"<<endl;
                  if(auxiliar->estado==1){
                      text<<point<<"[label= <<TABLE><TR><TD><IMG SRC=\"checked.png\"/></TD><TD>";
                  }else{
                      text<<point<<"[label= <<TABLE><TR><TD><IMG SRC=\"lock.png\"/></TD><TD>";
                  }
                   text<<auxiliar->id<<"</TD></TR></TABLE>>]"<<endl;
                   text<<point2<<"->"<<point<<";"<<endl;
               }else if(auxiliar==primeronivel || auxiliar==ultimonivel){
                   long int point = reinterpret_cast<long int>(auxiliar);
                   if(auxiliar->estado==1){
                       text<<point<<"[label= <<TABLE><TR><TD><IMG SRC=\"checked.png\"/></TD><TD>";
                   }else{
                       text<<point<<"[label= <<TABLE><TR><TD><IMG SRC=\"lock.png\"/></TD><TD>";
                   }
                   text<<auxiliar->id<<"</TD></TR></TABLE>>]"<<endl;
               }
        auxiliar=auxiliar->siguiente;
    }
    text<<"}"<<endl;
    text<<"}"<<endl;
    file.close();
    system("dot -Tpng Nivel.dot -o Nivel.png");
}
//---------------------------------------------------Genera la Grafica de Niveles-------------------------------
void niveles::mostrarGraficaNiveles(){
    QPixmap  pix("Nivel.png");
          ui->imagen->setParent(this);
          ui->imagen->setPixmap(pix);
          ui->scrollArea->setWidget(ui->imagen);
          ui->imagen->setParent(ui->scrollArea);
          ui->imagen->show();
}

void niveles::on_pushButton_3_clicked()
{


}

void niveles::on_pushButton_2_clicked()
{

}

void niveles::on_pushButton_4_clicked()
{
    worker->abort();
    thread->wait();
    worker->requestWork();
}



//--------------------------------------Boton de Ingresar Nivel---------------------------------------------------
void niveles::on_pushButton_clicked()
{
    struct _nivel *temp=primeronivel;
    int ni=ui->nivel_ingresar->text().toInt();
    while(ni!=temp->id){
        temp=temp->siguiente;
    }
    if(temp->estado==1){
        FrontEnd *frontend=new FrontEnd();
        frontend->show();
        front=frontend;
        QString nivel=ui->nivel_ingresar->text();
        QString tamanio=QString::number(primeronivel->tamano);
        connect(this,SIGNAL(sendData(QString,QString)),frontend,SLOT(obtenerDatos(QString,QString)));
        emit sendData(nivel,tamanio);
        QFile file("Consola.txt");
        file.open(QFile::WriteOnly|QFile::Truncate);
        this->close();
    }else{
            QMessageBox Msgbox;
            Msgbox.setText("Nivel Bloqueado");
            Msgbox.exec();
    }


}
