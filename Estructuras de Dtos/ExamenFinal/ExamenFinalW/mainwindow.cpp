#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "QDebug"
#include "QString"
#include "auxiliar.h"

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
    QString valor=ui->tamao->text();
    struct matriz *in=(struct matriz*)malloc(sizeof(struct matriz));
    in->primColumna=NULL;
    in->primFila=NULL;
    in->ultColumna=NULL;
    in->ultFila=NULL;
    inicio=in;
    int tam=valor.toInt();
    crearMatriz(tam);
    mostrarMatriz();

}

void crearMatriz(int tam){
    for(int i=0;i<tam;i++){
        struct cabecera *columna=(struct cabecera*)malloc(sizeof(struct cabecera));
        struct cabecera *fila=(struct cabecera*)malloc(sizeof(struct cabecera));

        columna->pos=i;
        columna->siguiente=NULL;
        columna->primero=NULL;
        columna->ultimo=NULL;
        fila->pos=i;
        fila->siguiente=NULL;
        fila->primero=NULL;
        if(inicio->primColumna==NULL){
            inicio->primColumna=columna;
            inicio->ultColumna=columna;
        }else{
            inicio->ultColumna->siguiente=columna;
            inicio->ultColumna=columna;
        }

        for(int j=0;j<tam;j++){
            struct nodo *nod=(struct nodo*)malloc(sizeof(struct nodo));
            nod->abb=NULL;
            nod->x=i;
            nod->y=j;
            nod->arriba=NULL;
            nod->abajo=NULL;
            nod->anterior=NULL;
            nod->siguiente=NULL;

            if(columna->primero==NULL){
                columna->primero=nod;
                columna->ultimo=nod;
            }else{
                columna->ultimo->siguiente=nod;
                columna->ultimo=nod;
            }
        }
    }
}


void mostrarMatriz(){
    struct cabecera *columna=inicio->primColumna;
    struct cabecera *fila=inicio->primFila;
    QString text="";
    QString tot="";
        while(columna!=NULL){
            text="";
            struct nodo *nod=columna->primero;
            while(nod!=NULL){
                if(nod->abb==NULL) text+="(0) ";
                else text+="  ("+QString::number(nod->y) +","+QString::number(nod->x)+")";
                nod=nod->siguiente;
            }
            qDebug()<<text;
            columna=columna->siguiente;
        }

}

void MainWindow::on_pushButton_2_clicked()
{
    int x=ui->posX->text().toInt();
    int y=ui->posY->text().toInt();
    int valor=ui->ValorGuardar->text().toInt();
    movernodo(x,y,valor);
}

void movernodo(int x, int y, int valor){

    struct cabecera *columna=inicio->primColumna;
    struct nodo *nod;
    for(int i=0;i<x;i++){
        columna=columna->siguiente;
    }
    nod=columna->primero;
    for(int i=0;i<y;i++){
        nod=nod->siguiente;
    }
    raiz=nod->abb;
    nod->abb=insertar(nod->abb,nod->abb,valor);
}



struct arbol *insertar( struct arbol *raiz, struct arbol *hoja, int num )
    {
    if( !hoja )
        {
        hoja= (struct arbol *) malloc( sizeof (struct arbol) );
        hoja->dato= num;
        hoja->izquierda= NULL;
        hoja->derecho= NULL;
        if( !raiz ) return hoja;
        else if( num<raiz->dato ) raiz->izquierda= hoja;
        else raiz->derecho= hoja;
        return hoja;
        }
    else if( num<hoja->dato )
        insertar( hoja, hoja->izquierda, num );
    else insertar( hoja, hoja->derecho, num );
    return raiz;
    }


void MainWindow::on_pushButton_3_clicked()
{
    mostrarMatriz();
}

void MainWindow::on_pushButton_4_clicked()
{
    int x=ui->posX->text().toInt();
    int y=ui->posY->text().toInt();
    struct cabecera *columna=inicio->primColumna;
    struct nodo *nod;
    for(int i=0;i<x;i++){
        columna=columna->siguiente;
    }
    nod=columna->primero;
    for(int i=0;i<y;i++){
        nod=nod->siguiente;
    }
    raiz=nod->abb;
    inorden(raiz);
}


void inorden( struct arbol *hoja )
    {
    if( !hoja ) return;

    inorden( hoja->izquierda );
    qDebug()<<hoja->dato;
    inorden( hoja->derecho );
    }
