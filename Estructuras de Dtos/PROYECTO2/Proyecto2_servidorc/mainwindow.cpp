#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "auxiliar.h"
#include <QMessageBox>
#include <QFile>
#include <QFileDialog>
#include <QTextStream>
#include <QDebug>
#include <math.h>
#include <QDate>
#include <QInputDialog>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    llenarPrimos();

    this->close();
}

MainWindow::~MainWindow()
{
    delete ui;
}


//-----------------------------------------------Guarda Autobuses en una tabla Hash----------------------------------------------
void MainWindow::on_actionAutobuses_triggered()
{
    QStringList filenames = QFileDialog::getOpenFileNames(this,tr("csv files"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );
    generalAutoBus(filenames);

    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Truncate);
    QTextStream text(&file);
    QString direcciones=filenames.join(",");
    direcciones="Autobus:"+direcciones;
    QByteArray ba=direcciones.toLatin1();
    QString obtenido=encriptacion(ba.data(),10);
    text<<obtenido<<endl;
    file.close();
}

void generalAutoBus(QStringList filenames){
    hashAuto=new autobuses[tam_autobuses];
    if( !filenames.isEmpty() )
    {
        QMessageBox msgBox;
        for (int i =0;i<filenames.length();i++){
            QFile inputFile(filenames[i]);
            inputFile.open(QIODevice::ReadOnly);
                QTextStream in(&inputFile);
                int fila=0;
                while(!in.atEnd()){
                    QString line=in.readLine();
                    QStringList datos=line.split(",");
                    if(fila!=0){
                     QString placa=datos.at(0);
                     QString modelo=datos.at(1);
                     QString estado=datos.at(2);
                         QByteArray ba=placa.toLatin1();
                         QByteArray ba2=modelo.toLatin1();
                         QByteArray ba3=estado.toLatin1();
                         int valor=funcionHash(ba.data(),tam_autobuses);
                         if(hashAuto[valor].flag==false) hashAuto[valor].flag=true;
                                 struct colision_autobuses *nodo=(struct colision_autobuses*)malloc(sizeof(struct colision_autobuses));
                                 nodo->estado=(char*)malloc(strlen(ba3.data())+1);
                                 nodo->placa=(char*)malloc(strlen(ba.data())+1);
                                 nodo->modelo=(char*)malloc(strlen(ba2.data())+1);
                                 nodo->siguiente=NULL;

                                 strcpy(nodo->estado,ba3.data());
                                 strcpy( nodo->placa,ba.data());
                                 strcpy( nodo->modelo,ba2.data());

                                 if(hashAuto[valor].primero==NULL){
                                     hashAuto[valor].primero=hashAuto[valor].ultimo=nodo;
                                 }else{
                                     hashAuto[valor].ultimo->siguiente=nodo;
                                     hashAuto[valor].ultimo=nodo;
                                 }

                        }
                     fila++;
                }
        }


    }

}
//-------------------------------------------------------------ARBOL AVL---------------------------------------------------------
int insertar(struct arbol **un_arbol, int edad,char *nombre,char *dpi,char *genero){

    int dato=cantidadNombre(nombre);

    if(*un_arbol == NULL){
        *un_arbol = (struct arbol *)malloc(sizeof(struct arbol));
        if(*un_arbol == NULL){
            return 0;
        }
        (*un_arbol)->dato = dato;
        (*un_arbol)->edad=edad;
        (*un_arbol)->nombre=(char*)malloc(strlen(nombre)+1);
        strcpy((*un_arbol)->nombre,nombre);
        (*un_arbol)->dpi=(char*)malloc(strlen(dpi)+1);
        strcpy((*un_arbol)->dpi,dpi);
        (*un_arbol)->genero=(char*)malloc(strlen(genero)+1);
        strcpy((*un_arbol)->genero,genero);
        (*un_arbol)->izquierdo = NULL;
        (*un_arbol)->derecho = NULL;
    }
    else{
        if((*un_arbol)->dato < dato){
            insertar(&((*un_arbol)->derecho), edad,nombre,dpi,genero);
        }
        else{
            insertar(&((*un_arbol)->izquierdo), edad,nombre,dpi,genero);
        }
    }

    balancear_arbolavl(un_arbol);

    return 1;
}


arbol* buscar(struct arbol *un_arbol, int dato){
    if(un_arbol == NULL){
        return NULL;
    }
    if(un_arbol->dato == dato){
        return un_arbol;
    }

    if(un_arbol->dato < dato){
        return buscar(un_arbol->derecho, dato);
    }
    else{
        return buscar(un_arbol->izquierdo, dato);
    }
}


int eliminar(struct arbol **un_arbol, int dato){
    struct  arbol ** aux = NULL;
    if(un_arbol == NULL){
        return 0;
    }

    if((*un_arbol)->dato == dato){
        if((*un_arbol)->derecho == NULL){
            (*un_arbol) = (*un_arbol)->izquierdo;
            balancear_arbolavl(un_arbol);
        }
        else if((*un_arbol)->izquierdo == NULL){
            (*un_arbol) = (*un_arbol)->derecho;
            balancear_arbolavl(un_arbol);
        }
        else{
            aux = un_arbol;
            reordenar(&((*un_arbol)->izquierdo), aux);
            balancear_arbolavl(&((*un_arbol)->izquierdo));
        }
    }
    else if((*un_arbol)->dato < dato){
        if((*un_arbol)->derecho == NULL){
            return 0;
        }
        return eliminar(&((*un_arbol)->derecho), dato);
    }
    else{
        if((*un_arbol)->izquierdo == NULL){
            return 0;
        }
        return eliminar(&((*un_arbol)->izquierdo), dato);
    }

    return 1;
}

//--------------------------------------------------------RECORRIDOS-----------------------------------------
//-------------------------------------------------------PRE ORDEN-----------------------------------------
void mostrar(struct arbol *un_arbol) {
    if(un_arbol == NULL){
        return;
    }
    QString carnet=QString::number(un_arbol->dato);
    if(un_arbol==auxx) textos=carnet;
    else textos=textos+","+carnet;
    mostrar(un_arbol->izquierdo);
    mostrar(un_arbol->derecho);
}
//----------------------------------------------POST ORDE-----------------------------------------------------
void postOrden(struct arbol *un_arbol) {
    if(un_arbol == NULL){
        return;
    }
    QString carnet=QString::number(un_arbol->dato);
    postOrden(un_arbol->izquierdo);
    postOrden(un_arbol->derecho);
    if(un_arbol==auxx) textos=carnet;
    else textos=textos+","+carnet;
}

//----------------------------------------------IN ORDEN----------------------------------------------------
void inOrden(arbol *un_arbol){
    if(un_arbol == NULL){
        return;
    }
    QString carnet=QString::number(un_arbol->dato);
    inOrden(un_arbol->izquierdo);
    if(un_arbol==auxx) textos=carnet;
    else textos=textos+","+carnet;
    inOrden(un_arbol->derecho);
}



//-----------------------------------------------------OPERACIONES-------------------------------------------
int altura_arbolavl(struct arbol *un_arbol){
    int alturaizq = 0;
    int alturader = 0;
    if(un_arbol == NULL){
        return 0;
    }
    alturaizq = altura_arbolavl(un_arbol->izquierdo);
    alturader = altura_arbolavl(un_arbol->derecho);
    if (alturader > alturaizq){
        return alturader + 1;
    }
    else{
        return alturaizq + 1;
    }
}

void balancear_arbolavl(struct arbol ** un_arbol) {
    int aux_balance = 0;
    if(un_arbol == NULL){
        return;
    }
    aux_balance = balanceo(*un_arbol);
    if(aux_balance > 1){
        if(balanceo((*un_arbol)->derecho) >= 1){
            rotar_izq(un_arbol);
        }
        else{
            rotar_derecha(&((*un_arbol)->derecho));
            rotar_izq(un_arbol);
        }
    }
    else if(aux_balance < -1){
        if(balanceo((*un_arbol)->izquierdo) <= -1){
            rotar_derecha(un_arbol);
        }
        else{
            rotar_izq(&((*un_arbol)->izquierdo));
            rotar_derecha(un_arbol);
        }
    }
}

int balanceo(struct arbol * un_arbol){
    int altura = 0;
    if(un_arbol == NULL){
        return 0;
    }

    altura = altura_arbolavl(un_arbol->derecho) - altura_arbolavl(un_arbol->izquierdo);
    return altura;
}

int rotar_derecha(struct arbol ** un_arbol){
    struct arbol *auxiliar = NULL;
    struct arbol *raiz = NULL;
    struct arbol *raiz_nueva = NULL;


    if(un_arbol == NULL){
        return 0;
    }
    raiz = (*un_arbol);
    raiz_nueva = (*un_arbol) -> izquierdo;
    auxiliar = (*un_arbol) -> izquierdo -> derecho;

    (*un_arbol) = raiz_nueva;
    raiz_nueva -> derecho = raiz;
    raiz -> izquierdo = auxiliar;
    return 1;
}

int rotar_izq(struct arbol ** un_arbol){
    struct arbol *auxiliar = NULL;
    struct arbol *raiz = NULL;
    struct arbol *raiz_nueva = NULL;

    if(un_arbol == NULL){
        return 0;
    }

    raiz = *un_arbol;
    raiz_nueva = (*un_arbol) -> derecho;
    auxiliar = (*un_arbol) -> derecho -> izquierdo;

    *un_arbol = raiz_nueva;
    (*un_arbol) -> izquierdo = raiz;
    raiz -> derecho = auxiliar;

    return 1;
}

int reordenar(struct arbol **un_arbol, struct arbol **aux_arbol) {
    if ((*un_arbol)->derecho == NULL){
        (*aux_arbol)->dato = (*un_arbol)->dato;
        (*aux_arbol)->nombre=(*un_arbol)->nombre;
        (*aux_arbol)->dpi=(*un_arbol)->dpi;
        (*aux_arbol)->edad=(*un_arbol)->edad;
        (*aux_arbol)->genero=(*un_arbol)->genero;
        *un_arbol = (*un_arbol)->izquierdo;
    }else
        reordenar(&(*un_arbol)->derecho, aux_arbol);
    return 1;
}








//------------------------------------------------------Funcion Hash-----------------------------------------
int funcionHash(char *palabra, int modulo){
    int valor;
    unsigned char *c;
    for(c=reinterpret_cast<unsigned char*>(palabra),valor=0;*c;c++){
        valor+=(int)(*c);
    }
    return (valor%modulo);
}

//--------------------------------------------------Devuelve ascci sobre nombre-------------------------------------
int cantidadNombre(char *palabra){
    int valor;
    unsigned char *c;
    for(c=reinterpret_cast<unsigned char*>(palabra),valor=0;*c;c++){
        valor+=(int)(*c);
    }
    return (valor);
}

void MainWindow::on_pushButton_clicked()
{
    struct rutas *ruta=cabecera_ruta;
         if(cabecera_ruta!=NULL){
             do{
                qDebug()<<ruta->archivo;
                qDebug()<<"Ruta de Ida:";
                struct viaje *aux=ruta->idaI;
                while(aux!=NULL){
                    qDebug()<<aux->nombre<<"->";
                    aux=aux->siguiente;
                }
                qDebug()<<"Ruta de Regreso:";
                aux=ruta->vueltaI;
                while(aux!=NULL){
                    qDebug()<<aux->nombre<<"->";
                    aux=aux->siguiente;
                }
                 ruta=ruta->siguiente;
             }while(ruta!=cabecera_ruta);
         }
}


void MainWindow::onConnect(){
    webSocket->sendTextMessage("Conectado desde cliente bitch");
}

void MainWindow::onTextMessageReceived(QString message){
    qDebug()<<"Mensaje recibido "<<message;
}


//-------------------------------------------Graficar un arbol--------------------------------------------------
void graficarArbol(arbol *un_arbol){
    if(un_arbol == NULL){
           return;
       }
       *textarbol<<un_arbol->dato<<";"<<endl;
       if(un_arbol->izquierdo!=NULL) *textarbol<<un_arbol->dato<<"->"<<un_arbol->izquierdo->dato<<";"<<endl;
       if(un_arbol->derecho!=NULL) *textarbol<<un_arbol->dato<<"->"<<un_arbol->derecho->dato<<";"<<endl;
       struct arbol *aux2=un_arbol;

       *textarbol<<un_arbol->dato<<"[label=\"Nombre : "<<un_arbol->nombre<<"\\n Dato:"<<un_arbol->dato<<"\\n Genero:"<<un_arbol->genero<<"\\n Dpi:"<<un_arbol->dpi<<" \"];"<<endl;
       graficarArbol(un_arbol->izquierdo);
       graficarArbol(un_arbol->derecho);
}

//-------------------------------------------------------------Agregar Pilotos---------------------------------------
void MainWindow::on_actionPilotos_triggered()
{
    QStringList filenames = QFileDialog::getOpenFileNames(this,tr("csv files"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );
    generalPiloto(filenames);



    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones=filenames.join(",");
    direcciones="Piloto:"+direcciones;
    QByteArray ba=direcciones.toLatin1();
    QString obtenido=encriptacion(ba.data(),10);
    text<<obtenido<<endl;
    file.close();
}

void generalPiloto(QStringList filenames){
    hashPilotos=new pilotos[tam_autobuses];
    if( !filenames.isEmpty() )
    {
        for (int i =0;i<filenames.length();i++){
            QFile inputFile(filenames[i]);
            inputFile.open(QIODevice::ReadOnly);
                QTextStream in(&inputFile);
                int fila=0;
                while(!in.atEnd()){
                    QString line=in.readLine();
                    QStringList datos=line.split(",");
                    if(fila!=0){
                     QString dpi=datos.at(0);
                     QString nombre=datos.at(1);
                     QString edd=datos.at(2);
                     int edad=edd.toInt();
                     QString genero=datos.at(3);
                         QByteArray ba=dpi.toLatin1();
                         QByteArray ba2=nombre.toLatin1();
                         QByteArray ba3=genero.toLatin1();
                         int valor=funcionHash(ba.data(),tam_autobuses);
                         if(hashPilotos[valor].estado==false)
                               hashPilotos[valor].estado=true;

                                 un_arbol=hashPilotos[valor].arbolavl;
                                 insertar(&un_arbol,edad,ba2.data(),ba.data(),ba3.data());
                                 hashPilotos[valor].arbolavl=un_arbol;
                                 un_arbol=NULL;


                  }
                 fila++;
                }
        }


    }

}
//----------------------------------------------------Abrir Ubicaciones----------------------------------------------
void MainWindow::on_actionUbicacion_triggered()
{

    QStringList filenames = QFileDialog::getOpenFileNames(this,tr("csv files"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );
    generalEstaciones(filenames);

    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones=filenames.join(",");
    direcciones="Estacion:"+direcciones;
    QByteArray ba=direcciones.toLatin1();
    QString obtenido=encriptacion(ba.data(),10);
    text<<obtenido<<endl;
    file.close();
}

void generalEstaciones(QStringList filenames){
    if( !filenames.isEmpty() )
    {
        QMessageBox msgBox;
        for (int i =0;i<filenames.length();i++){
            int fila=0;
            QFile inputFile(filenames[i]);
            inputFile.open(QIODevice::ReadOnly);
                QTextStream in(&inputFile);
                while(!in.atEnd()){
                    QString line=in.readLine();
                    QStringList datos=line.split(",");
                    if(fila!=0){
                         QString codigo=datos.at(0);
                         QString nombre=datos.at(1);
                         QString ubicacion=datos.at(2);
                         QByteArray ba=codigo.toLatin1();
                         QByteArray ba2=nombre.toLatin1();
                         QByteArray ba3=ubicacion.toLatin1();

                         struct estaciones *nodo=(struct estaciones*)malloc(sizeof(struct estaciones));
                         nodo->codigo=(char*)malloc(strlen(ba.data())+1);
                         nodo->nombre=(char*)malloc(strlen(ba2.data())+1);
                         nodo->ubicacion=(char*)malloc(strlen(ba3.data())+1);



                         strcpy(nodo->codigo,ba.data());
                         strcpy(nodo->nombre,ba2.data());
                         strcpy( nodo->ubicacion,ba3.data());
                         nodo->siguiente=NULL;
                         insertarUbicacion(nodo);
                       }
                    fila++;
                }
        }


    }

}

void insertarUbicacion(estaciones *nodo){
    if(primeroesta==NULL){
        primeroesta=ultimoesta=nodo;
    }else{
        ultimoesta->siguiente=nodo;
        ultimoesta=nodo;
    }
}

estaciones* buscarEstacion(QString codigo){
    struct estaciones *aux=primeroesta;
    while(aux!=NULL){
        QString recibido=QString::fromUtf8(aux->codigo);
        if(recibido==codigo) return aux;
        aux=aux->siguiente;
    }
    return NULL;
}

//------------------------------------------------------------PARQUEOS------------------------------------------------------
void MainWindow::on_actionParqueos_triggered()
{
    cabecera_parqueo=NULL;
    QStringList filenames = QFileDialog::getOpenFileNames(this,tr("csv files"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );
    generalMatriz(filenames);
    QFile file("Bitacora.201612118-log");
        file.open(QFile::WriteOnly|QFile::Append);
        QTextStream text(&file);
        QString direcciones=filenames.join(",");
        direcciones="Parqueo:"+direcciones;
        QByteArray ba=direcciones.toLatin1();
        QString obtenido=encriptacion(ba.data(),10);
        text<<obtenido<<endl;
        file.close();

}

void insertarParqueo(parqueo *nodo){
    if(cabecera_parqueo==NULL){
        cabecera_parqueo=nodo;
        cabecera_parqueo->anterior=nodo;
        cabecera_parqueo->siguiente=nodo;
        nodo->siguiente=cabecera_parqueo;
        nodo->anterior=cabecera_parqueo;
    }else{
        struct parqueo *temporal=cabecera_parqueo;
        do{
           temporal=temporal->siguiente;
        }while(temporal->siguiente!=cabecera_parqueo);
        temporal->siguiente=nodo;
        nodo->anterior=temporal;
        nodo->siguiente=cabecera_parqueo;
        cabecera_parqueo->anterior=nodo;
    }
}

void generalMatriz(QStringList filenames){
    if( !filenames.isEmpty() )
    {
        QMessageBox msgBox;
        for (int i =0;i<filenames.length();i++){
            int fila=0;
            QFile inputFile(filenames[i]);
            inputFile.open(QIODevice::ReadOnly);
                QTextStream in(&inputFile);
                QString name=QFileInfo(filenames[i]).fileName();
                QString namewithout=name.section(".", 0,0);
                QByteArray na=namewithout.toLatin1();
                struct parqueo *nodo=(struct parqueo*)malloc(sizeof(struct parqueo));
                nodo->archivo=(char*)malloc(strlen(na.data()+1));
                strcpy(nodo->archivo,na.data());

                nodo->columnafirst=NULL;
                nodo->filafirst=NULL;
                nodo->filalast=NULL;
                nodo->columnalast=NULL;

                nodo->siguiente=NULL;
                nodo->anterior=NULL;
                insertarParqueo(nodo);
                //--------------------------------------------Insertar Matriz Disperasa-----------------
                while(!in.atEnd()){
                    QString line=in.readLine();
                    QStringList datos=line.split(",");
                    if(fila!=0){
                        for(int j=0;j<datos.length();j++){
                            existeX(j,nodo);
                            existeY(fila,nodo);
                            QString placa=datos[j];
                            QByteArray ba=placa.toLatin1();
                            guardarEnemigo(j,fila,nodo,ba.data());
                        }
                    }

                    fila++;
                 }

        }


    }

}
//-------------------------------------Busca la cabecera horizontal---------------------------------------------------
void existeX(int x,parqueo *nuev){

    bool estado=true;
    bool encontrado=false;
    struct _matriz *temp=nuev->columnafirst;
    struct _matriz *aux;
    //----------------------------------Si esta vacia la cabecera--------------------------------------
    if(nuev->columnafirst==NULL){
        struct _matriz *nuevo=(struct _matriz*)malloc(sizeof(struct _matriz));
        nuevo->numero=x;
        nuevo->primero=NULL;
        nuevo->siguiente=NULL;
        nuev->columnafirst=nuevo;
        nuev->columnalast=nuevo;
    }else{
        while(estado==true){
            if(temp!=NULL){
                if(temp->numero==x){
                    estado=false;
                    encontrado=true;
                }else{
                    temp=temp->siguiente;
                }
            }else{
                estado=false;
                encontrado=false;
            }
        }

        if(encontrado==false){
            struct _matriz *nuevo=(struct _matriz*)malloc(sizeof(struct _matriz));
            nuevo->numero=x;
            nuevo->primero=NULL;

            if(x<nuev->columnafirst->numero){
                nuevo->siguiente=nuev->columnafirst;
                nuev->columnafirst=nuevo;
            }else if(x>nuev->columnalast->numero){
                nuev->columnalast->siguiente=nuevo;
                nuevo->siguiente=NULL;
                nuev->columnalast=nuevo;
            }else{
                temp=nuev->columnafirst;
                estado=true;
                while(estado){
                    if(temp->siguiente!=NULL){
                        if(x<temp->siguiente->numero){
                          estado=false;
                        }else{
                            temp=temp->siguiente;
                        }
                    }else{
                        estado=false;
                    }
                }
                aux=temp->siguiente;
                temp->siguiente=nuevo;
                nuevo->siguiente=aux;
            }


        }else{

        }
    }
}


//-------------------------------------Busca la cabecera vertical---------------------------------------------------
void existeY(int y,parqueo *nuev){
    bool estado=true;
    bool encontrado=false;
    struct _matriz *temp=nuev->filafirst;
    struct _matriz *aux;
    //----------------------------------Si esta vacia la cabecera--------------------------------------
    if(nuev->filafirst==NULL){
        struct _matriz *nuevo=(struct _matriz*)malloc(sizeof(struct _matriz));
        nuevo->numero=y;
        nuevo->primero=NULL;
        nuevo->siguiente=NULL;
        nuev->filafirst=nuevo;
        nuev->filalast=nuevo;
    }else{
        while(estado==true){
            if(temp!=NULL){
                if(temp->numero==y){
                    estado=false;
                    encontrado=true;
                }else{
                    temp=temp->siguiente;
                }
            }else{
                estado=false;
                encontrado=false;
            }
        }

        if(encontrado==false){
            struct _matriz *nuevo=(struct _matriz*)malloc(sizeof(struct _matriz));
            nuevo->numero=y;
            nuevo->primero=NULL;

            if(y<nuev->filafirst->numero){
                nuevo->siguiente=nuev->filafirst;
                nuev->filafirst=nuevo;
            }else if(y>nuev->filalast->numero){
                nuev->filalast->siguiente=nuevo;
                nuevo->siguiente=NULL;
                nuev->filalast=nuevo;
            }else{
                temp=nuev->filafirst;
                estado=true;
                while(estado){
                    if(temp->siguiente!=NULL){
                        if(y<temp->siguiente->numero){
                          estado=false;
                        }else{
                            temp=temp->siguiente;
                        }
                    }else{
                        estado=false;
                    }
                }
                aux=temp->siguiente;
                temp->siguiente=nuevo;
                nuevo->siguiente=aux;
            }


        }else{

        }
    }
}

//------------------------------------Guardar Nodo Enemigo-------------------------------------------------------------
void guardarEnemigo(int numero, int numero2,parqueo *nuev,char *placa){
       struct _matriz *auxma=nuev->columnafirst;
       struct _matriz *aux2=nuev->filafirst;
       bool estado;
       bool encontrado=false;
       if(auxma!=NULL){


       while(auxma->numero!=numero){
           auxma=auxma->siguiente;
       }

       while(aux2->numero!=numero2){
           aux2=aux2->siguiente;
       }
   //---------------------------------------------Guardar Enemigo-------------------------------------
       struct _nodoMatriz *nodoma2=aux2->primero;
       struct _nodoMatriz *nuevoenemigo=(struct _nodoMatriz*)malloc(sizeof(struct _nodoMatriz));
       struct _nodoMatriz *temp;
       struct _nodoMatriz *temp2;
       nuevoenemigo->x=numero;
       nuevoenemigo->y=numero2;
       nuevoenemigo->placa=(char*)malloc(strlen(placa)+1);
       strcpy(nuevoenemigo->placa,placa);
       //-----------------------------------posicion en X-------------------------------------------
       if(auxma->primero==NULL){
           nuevoenemigo->siguiente=NULL;
           auxma->primero=nuevoenemigo;
           auxma->ultimo=nuevoenemigo;
       }else{
           struct _nodoMatriz *nodoma=auxma->primero;
           estado=true;
           while(estado==true){
               if(nodoma!=NULL){
                   if(nodoma->y==numero2){
                       estado=false;
                       encontrado=true;
                   }else{
                       nodoma=nodoma->siguiente;
                   }
               }else{
                   estado=false;
                   encontrado=false;
               }
           }
          //------------------------------------if de encontrado-----------------------------
           if(encontrado==false){
               if(numero2<auxma->primero->y){
                   nuevoenemigo->anterior=NULL;
                   nuevoenemigo->siguiente=auxma->primero;
                   auxma->primero->anterior=nuevoenemigo;
                   auxma->primero=nuevoenemigo;
               }else if(numero2>auxma->ultimo->y){
                   nuevoenemigo->siguiente=NULL;
                   nuevoenemigo->anterior=auxma->ultimo;
                   auxma->ultimo->siguiente=nuevoenemigo;
                   auxma->ultimo=nuevoenemigo;
               }else{
                   struct _nodoMatriz *nodoauxiliar;
                   temp=auxma->primero;
                   estado=true;
                   while(estado){
                       if(temp->siguiente!=NULL){
                           if(numero2<temp->siguiente->y){
                             estado=false;
                           }else{
                               temp=temp->siguiente;
                           }
                       }else{
                           estado=false;
                       }
                   }
                   nodoauxiliar=temp->siguiente;
                   temp->siguiente=nuevoenemigo;
                   nuevoenemigo->siguiente=nodoauxiliar;
               }
           }else{
               //-------------------------else de encontrado---------------------------------
           }



       }



       //-----------------------------------posicion en Y-------------------------------------------
           if(aux2->primero==NULL){
              nuevoenemigo->arriba=NULL;
              aux2->primero=nuevoenemigo;
              aux2->ultimo=nuevoenemigo;
           }else{
               struct _nodoMatriz *nodoma=aux2->primero;
               estado=true;
               encontrado=false;
               while(estado==true){
                   if(nodoma!=NULL){
                       if(nodoma->x==numero){
                           estado=false;
                           encontrado=true;
                       }else{
                           nodoma=nodoma->arriba;
                       }
                   }else{
                       estado=false;
                       encontrado=false;
                   }
               }
               //------------------------------------if de encontrado-----------------------------
                if(encontrado==false){
                    if(numero<aux2->primero->x){
                        nuevoenemigo->abajo=NULL;
                        nuevoenemigo->arriba=aux2->primero;
                        aux2->primero->abajo=nuevoenemigo;
                        aux2->primero=nuevoenemigo;
                    }else if(numero>aux2->ultimo->x){
                        nuevoenemigo->arriba=NULL;
                        nuevoenemigo->abajo=aux2->ultimo;
                        aux2->ultimo->arriba=nuevoenemigo;
                        aux2->ultimo=nuevoenemigo;
                    }else{
                        struct _nodoMatriz *nodoauxiliar;
                        temp=aux2->primero;
                        estado=true;
                        while(estado){
                            if(temp->arriba!=NULL){
                                if(numero<temp->arriba->x){
                                  estado=false;
                                }else{
                                    temp=temp->arriba;
                                }
                            }else{
                                estado=false;
                            }
                        }
                        nodoauxiliar=temp->arriba;
                        temp->arriba=nuevoenemigo;
                        nuevoenemigo->arriba=nodoauxiliar;
                    }

                }else{
                    //-------------------------else de encontrado---------------------------------
                }


           }

    }

}

//-------------------------------------Graficar Matriz Dispersa---------------------
void graficarMatriz(int pos){
    struct parqueo *nuev=cabecera_parqueo;
       for(int i=0;i<pos;i++){
           nuev=nuev->siguiente;
       }


       QFile file("Matriz.dot");
       file.open(QIODevice::WriteOnly | QIODevice::Truncate);
       QTextStream text(&file);
       struct _matriz *auxiliar=nuev->columnafirst;
       struct _matriz *auxiliar2=nuev->filafirst;
       text<<"digraph G{"<<endl;
       //------------------------------------------FILAS Y COLUMNAS-----------------------------------------
       text<<"subgraph cluster_area{"<<endl;
       text<<"{rank=same raiz ";
       while(auxiliar!=NULL){
           long int point = reinterpret_cast<long int>(auxiliar);
           text<<point;
           text<<"  ";
           auxiliar=auxiliar->siguiente;
       }
       text<<"}"<<endl;
       text<<"}"<<endl;
       auxiliar=nuev->columnafirst;
       if(auxiliar!=NULL){
           //--------------------------------------------COLUMNA-----------------------------------------------
           text<<"subgraph cluster_lista_columna{"<<endl;
           text<<"raiz[shape=box,label=\"*\"];"<<endl;
           long int point = reinterpret_cast<long int>(auxiliar);
           text<<"raiz->"<<point<<";"<<endl;
           while(auxiliar!=NULL){
               long int point = reinterpret_cast<long int>(auxiliar);
               if(auxiliar->siguiente!=NULL){
                           long int point2 = reinterpret_cast<long int>(auxiliar->siguiente);
                           text<<point<<"[shape=box,label=\""<<auxiliar->numero<<"\"];"<<endl;
                           text<<point2<<"[shape=box,label=\""<<auxiliar->siguiente->numero<<"\"];"<<endl;
                           text<<point<<"->"<<point2<<";"<<endl;
               }else if(auxiliar==nuev->columnafirst){
                           text<<point<<"[shape=box,label=\""<<auxiliar->numero<<"\"];"<<endl;
               }
               struct _nodoMatriz *temp=auxiliar->primero;
               if(temp!=NULL){
                   point=reinterpret_cast<long int>(auxiliar);
                   long int point2=reinterpret_cast<long int>(temp);
                   text<<point<<"->"<<point2<<";"<<endl;
                   while(temp!=NULL){
                       if(temp!=auxiliar->ultimo){
                            long int point = reinterpret_cast<long int>(temp);
                            long int point2 = reinterpret_cast<long int>(temp->siguiente);
                            text<<point<<"->"<<point2<<";"<<endl;
                            QString placa=QString::fromUtf8(temp->placa);
                            if(placa!="0")text<<point<<"[label=\""<<temp->x<<","<<temp->y<<"\n Ocupado por:"<<temp->placa<<"\"]"<<endl;
                            else text<<point<<"[label=\""<<temp->x<<","<<temp->y<<"\nLibre\"]"<<endl;
                            text<<point2<<"->"<<point<<";"<<endl;
                            }else if(temp==auxiliar->primero || temp==auxiliar->ultimo){
                               long int point = reinterpret_cast<long int>(temp);
                               QString placa=QString::fromUtf8(temp->placa);
                               if(placa!="0")text<<point<<"[label=\""<<temp->x<<","<<temp->y<<"\n Ocupado por:"<<temp->placa<<"\"]"<<endl;
                               else text<<point<<"[label=\""<<temp->x<<","<<temp->y<<"\nLibre\"]"<<endl;                            }
                       temp=temp->siguiente;
                   }
               }

               auxiliar=auxiliar->siguiente;
           }
           //--------------------------------- FILA----------------------------------------------
           point=reinterpret_cast<long int>(auxiliar2);
           if(auxiliar2!=NULL){
               text<<"raiz->"<<point<<";"<<endl;
               int contador=0;
               while(auxiliar2!=NULL){
                  long int point = reinterpret_cast<long int>(auxiliar2);
                  if(auxiliar2->siguiente!=NULL){
                               long int point2 = reinterpret_cast<long int>(auxiliar2->siguiente);
                               text<<point<<"[shape=box,label=\""<<auxiliar2->numero<<"\"];"<<endl;
                               text<<point2<<"[shape=box,label=\""<<auxiliar2->siguiente->numero<<"\"];"<<endl;
                               text<<point<<"->"<<point2<<";"<<endl;
                  }else if(auxiliar2==nuev->filafirst){
                     text<<point<<"[shape=box,label=\""<<auxiliar2->numero<<"\"];"<<endl;
                  }
                  struct _nodoMatriz *temp=auxiliar2->primero;
                  //---------------------------------------horizontal la mtriz ortogonal-----------------------------------
                    point = reinterpret_cast<long int>(auxiliar2);
                  text<<"{rank=same "<<point<<" ";
                  while(temp!=NULL){
                      long int point = reinterpret_cast<long int>(temp);
                      text<<point;
                      text<<"  ";
                      temp=temp->arriba;
                  }
                  text<<"}"<<endl;
                  //--------------------------------------Matriz Ortogonal--------------------------------------------------
                  temp=auxiliar2->primero;
                  if(temp!=NULL){
                      point=reinterpret_cast<long int>(auxiliar2);
                      long int point2=reinterpret_cast<long int>(temp);
                      text<<point<<"->"<<point2<<";"<<endl;
                      while(temp!=NULL){
                          if(temp!=auxiliar2->ultimo){
                               long int point = reinterpret_cast<long int>(temp);
                               long int point2 = reinterpret_cast<long int>(temp->arriba);
                               text<<point<<"->"<<point2<<";"<<endl;
                               text<<point2<<"->"<<point<<";"<<endl;
                               }else if(temp==auxiliar2->primero || temp==auxiliar2->ultimo){
                                  long int point = reinterpret_cast<long int>(temp);
                               }
                          temp=temp->arriba;
                      }
                  }

                   auxiliar2=auxiliar2->siguiente;
                   contador+=1;
               }

           }
           text<<"}"<<endl;
       }

       text<<"}"<<endl;
       file.close();
       system("dot -Tpng Matriz.dot -o Matriz.png");
}
//--------------------------------------------Agregar Usuarios-----------------------------------------------
void MainWindow::on_actionUsuarios_triggered()
{
    QStringList filenames = QFileDialog::getOpenFileNames(this,tr("csv files"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );
     generalUsuario(filenames);


    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones=filenames.join(",");
    direcciones="Usuario:"+direcciones;
    QByteArray ba=direcciones.toLatin1();
    QString obtenido=encriptacion(ba.data(),10);
    text<<obtenido<<endl;
    file.close();
}

void generalUsuario(QStringList filenames){
    inicializarUsuarios(tamUsuarios);
    if( !filenames.isEmpty() )
    {
        QMessageBox msgBox;
        for (int i =0;i<filenames.length();i++){
            int fil=0;
            QFile inputFile(filenames[i]);
            inputFile.open(QIODevice::ReadOnly);
                QTextStream in(&inputFile);
                while(!in.atEnd()){
                    QString line=in.readLine();
                    QStringList datos=line.split(",");
                    if(fil!=0){
                     QString dpi=datos.at(0);
                     QString tarjeta=datos.at(1);
                     QString nombre=datos.at(2);
                     QString ed=datos.at(3);
                     int edad=ed.toInt();
                         QByteArray ba=dpi.toLatin1();
                         QByteArray ba2=tarjeta.toLatin1();
                         QByteArray ba3=nombre.toLatin1();
                         insertarUsuario(ba.data(),ba3.data(),ba2.data(),edad,funcionHash(ba.data(),tamUsuarios));
                         reHash();
                       }
                     fil++;
                }
        }


    }

}


void inicializarUsuarios(int cantidad){
    for(int i=0;i<tamUsuarios;i++){
        struct usuarios *nodo=(struct usuarios*)malloc(sizeof(struct usuarios));
        nodo->flag=false;
        nodo->siguiente=NULL;
        if(primerUsuario==NULL){
            primerUsuario=ultimoUsuario=nodo;
        }else{
            ultimoUsuario->siguiente=nodo;
            ultimoUsuario=nodo;
        }
    }
}

void insertarUsuario(char* dpi,char* nombre,char *tarjeta,int edad,int pos){
    struct usuarios *aux=primerUsuario;
    for(int i=0;i<pos;i++){
        aux=aux->siguiente;
    }
    while(aux->flag!=false){
        if(aux==ultimoUsuario) aux=primerUsuario;
        aux=aux->siguiente;
    }

    aux->dpi=(char*)malloc(strlen(dpi+1));
    aux->nombre=(char*)malloc(strlen(nombre+1));
    aux->tarjeta=(char*)malloc(strlen(tarjeta+1));

    aux->flag=true;
    strcpy(aux->dpi,dpi);
    strcpy(aux->nombre,nombre);
    strcpy(aux->tarjeta,tarjeta);
    aux->edad=edad;

}

void reHash(){
 int total=0;
 struct usuarios *aux=primerUsuario;
 while(aux!=NULL){
     if(aux->flag==true) total++;
     aux=aux->siguiente;
 }
 int tamactual=(int)rint(tamUsuarios*0.8);
 int nuevo=(int)rint(tamUsuarios*1.15);
 int diferencia=0;
 if(total>=tamactual){
     int temp=0;
     for(int i=0;i<NumerosPrimos.length();i++){
         int deff=nuevo-NumerosPrimos[i];
         if(deff>=0){
         }else{
             temp=NumerosPrimos[i];
             break;
         }
     }
     if(temp-tamUsuarios>0){
         QMessageBox ms;
         ms.setText("Re Hash, Tamaño Anterior: "+QString::number(tamUsuarios)+" \n Nuevo tamaño: "+QString::number(temp));
         ms.exec();
     }
     inicializarUsuarios(temp-tamUsuarios);
     tamUsuarios=temp;
 }
}


void llenarPrimos(){
    int primo=1;
    int contador=2;
    for(int i=0;i<5000;i++){
        primo=1;
        contador=2;
        while(contador<=i/2&&primo){
            if(i%contador==0) primo=0;
            contador++;
        }

        if(primo) NumerosPrimos.append(i);
    }

}
//------------------------------------------------CARGAR RUTAS-----------------------------------------------------
void MainWindow::on_actionRutas_triggered()
{
    QStringList filenames = QFileDialog::getOpenFileNames(this,tr("csv files"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );
    generalRutas(filenames);
    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones=filenames.join(",");
    direcciones="Ruta:"+direcciones;
    QByteArray ba=direcciones.toLatin1();
    QString obtenido=encriptacion(ba.data(),10);
    text<<obtenido<<endl;
    file.close();

}

void generalRutas(QStringList filenames){
    cabecera_ruta=NULL;
    if( !filenames.isEmpty() )
    {
        QMessageBox msgBox;
        for (int i =0;i<filenames.length();i++){
            int fila=0;
            QFile inputFile(filenames[i]);
            inputFile.open(QIODevice::ReadOnly);
                QTextStream in(&inputFile);
                QString name=QFileInfo(filenames[i]).fileName();
                QString namewithout=name.section(".", 0,0);

                QByteArray na=namewithout.toLatin1();

                struct rutas *nodo=(struct rutas*)malloc(sizeof(struct rutas));
                nodo->archivo=(char*)malloc(strlen(na.data()+1));
                strcpy(nodo->archivo,na.data());
                nodo->idaI=NULL;
                nodo->vueltaI=NULL;
                nodo->siguiente=NULL;
                nodo->anterior=NULL;

                while(!in.atEnd()){
                    QString line=in.readLine();
                    QStringList datos=line.split(",");
                    if(fila==0){

                    }else if(fila==1){
                        //--------------------------------Insertar la Ida---------------------------------
                        for(int j=0;j<datos.length();j++){
                            QString nombre=datos[j];
                            QByteArray ba=nombre.toLatin1();
                             struct viaje *esta=(struct viaje*)malloc(sizeof(struct viaje));
                             esta->siguiente=NULL;
                             esta->nombre=(char*)malloc(strlen(ba.data()+1));

                             struct estaciones *ge=buscarEstacion(nombre);
                             esta->esta=ge;
                             strcpy(esta->nombre,ba.data());
                             insertarIda(esta,nodo);

                        }
                    }else if(fila==2){
                         //-------------------------------Insertar uelta--------------------------------------
                        for(int j=0;j<datos.length();j++){
                            QString nombre=datos[j];
                            QByteArray ba=nombre.toLatin1();
                            nombre=nombre.replace(QString("\""),QString(""));
                             struct viaje *esta=(struct viaje*)malloc(sizeof(struct viaje));
                             esta->siguiente=NULL;
                             esta->nombre=(char*)malloc(strlen(ba.data()+1));
                             struct estaciones *ge=buscarEstacion(nombre);
                             esta->esta=ge;
                             strcpy(esta->nombre,ba.data());
                             insertarVuelta(esta,nodo);

                        }
                    }

                    fila++;
                 }

                insertarRuta(nodo);

        }


    }

}

//--------------------------------------------------Inserta el viaje de Ida------------------------------------------------------
void insertarIda(viaje *viaj, rutas *nodo){
    if(nodo->idaI==NULL){
        nodo->idaI=viaj;
        nodo->idaF=viaj;
    }else{
        nodo->idaF->siguiente=viaj;
        nodo->idaF=viaj;
    }
}

//-------------------------------------------------Insertar el viaje de vuelta----------------------------------------------------
void insertarVuelta(viaje *viaj, rutas *nodo){
    if(nodo->vueltaI==NULL){
        nodo->vueltaI=viaj;
        nodo->vueltaF=viaj;
    }else{
        nodo->vueltaF->siguiente=viaj;
        nodo->vueltaF=viaj;
    }
}

//---------------------------------------------------Guardar la Ruta---------------------------------------------------------------
void insertarRuta(rutas *nodo){
    if(cabecera_ruta==NULL){
        cabecera_ruta=nodo;
        cabecera_ruta->anterior=nodo;
        cabecera_ruta->siguiente=nodo;
        nodo->siguiente=cabecera_ruta;
        nodo->anterior=cabecera_ruta;
    }else{
        struct rutas *temporal=cabecera_ruta;
        do{
           temporal=temporal->siguiente;
        }while(temporal->siguiente!=cabecera_ruta);
        temporal->siguiente=nodo;
        nodo->anterior=temporal;
        nodo->siguiente=cabecera_ruta;
        cabecera_ruta->anterior=nodo;
    }
}



//---------------------------------------------------------------Crear Bloque---------------------------------------------------


void MainWindow::on_actionCrear_Bloque_triggered()
{
    //-------------------------------------------Busca un piloto-----------------------------
    QString salida="Bloque:";
    QDate cd=QDate::currentDate();
    QString fecha=cd.toString();
    QByteArray baba=fecha.toLatin1();

    struct bloque *nuevoBloque=(struct bloque*)malloc(sizeof(struct bloque));
    nuevoBloque->siguiente=NULL;
    nuevoBloque->primera=NULL;

    nuevoBloque->fecha=(char*)malloc(strlen(baba.data())+1);
    strcpy(nuevoBloque->fecha,baba.data());

    bool ok;
    QString nomb = QInputDialog::getText(this, tr("Ingrese el Nombre del Piloto"),tr("Nombre:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
       QString text = QInputDialog::getText(this, tr("Ingrese el DPI del Piloto"),tr("DPI:"), QLineEdit::Normal,QDir::home().dirName(), &ok);

       salida+=nomb+":"+text;

       QByteArray ba=text.toLatin1();
       QByteArray sbaba=nomb.toLatin1();
       struct arbol *aux=buscarPiloto(ba.data(),sbaba.data());
       if(aux!=NULL){
           nuevoBloque->piloto=aux;
           //--------------------------------------Busca Un Bus----------------------------------
            text = QInputDialog::getText(this, tr("Ingrese la Placa del Autobus"),tr("Placa:"), QLineEdit::Normal,QDir::home().dirName(), &ok);

            salida+=":"+text+":"+fecha;

            ba=text.toLatin1();
            struct colision_autobuses *aux2=buscarAutobus(ba.data());
            //-------------------------------------Buscar Ruta-------------------------------------
            if(aux2!=NULL){
                nuevoBloque->bus=aux2;
                for(int i=0;i<3;i++){
                    text = QInputDialog::getText(this, tr("Ingrese el nombre de la Ruta"),tr("Ruta:"), QLineEdit::Normal,QDir::home().dirName(), &ok);


                    ba=text.toLatin1();
                    struct rutas* busca=cabecera_ruta;
                    struct rutas* aux3=buscarRuta(ba.data(),busca);
                    if(aux3!=NULL){
                        struct list_rutas *nuevo=(struct list_rutas*)malloc(sizeof(struct list_rutas));
                        nuevo->ruta=aux3;
                        nuevo->siguiente=NULL;
                        QStringList filenames = QFileDialog::getOpenFileNames(this,tr("Archivo de Rutas"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );

                        if(i==2) salida+="|"+text+","+filenames[0];
                        else if(i==0) salida+=":"+text+","+filenames[0];
                        else salida+="|"+text+","+filenames[0];

                        asignarArbolAvl(filenames,nuevo);


                        //---------------------------Guardar en Lista de Rutas-------------------------------------------
                        if(nuevoBloque->primera==NULL){

                            nuevoBloque->primera=nuevoBloque->ultima=nuevo;
                        }else{
                            nuevoBloque->ultima->siguiente=nuevo;
                            nuevoBloque->ultima=nuevo;
                        }

                    }else{

                    }
                }
                bool esta=true;
                int contador=0;
                while(esta){
                    if(contador==2)esta=false;
                    else{
                        QMessageBox::StandardButton reply;
                          reply = QMessageBox::question(this, "Desea Agregar otra ruta", "Agregar?",
                                                        QMessageBox::Yes|QMessageBox::No);
                          if (reply == QMessageBox::Yes) {
                              text = QInputDialog::getText(this, tr("Ingrese el nombre de la Ruta"),tr("Ruta:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
                              ba=text.toLatin1();
                              struct rutas* busca=cabecera_ruta;
                              struct rutas* aux3=buscarRuta(ba.data(),busca);
                              if(aux3!=NULL){
                                  struct list_rutas *nuevo=(struct list_rutas*)malloc(sizeof(struct list_rutas));
                                  nuevo->ruta=aux3;
                                  nuevo->siguiente=NULL;
                                  QStringList filenames = QFileDialog::getOpenFileNames(this,tr("Archivo de Rutas"),QDir::currentPath(),tr("CSV files (*.csv);;All files (*.*)") );

                                  salida+="|"+text+","+filenames[0];

                                  asignarArbolAvl(filenames,nuevo);


                                  //---------------------------Guardar en Lista de Rutas-------------------------------------------
                                  if(nuevoBloque->primera==NULL){

                                      nuevoBloque->primera=nuevoBloque->ultima=nuevo;
                                  }else{
                                      nuevoBloque->ultima->siguiente=nuevo;
                                      nuevoBloque->ultima=nuevo;
                                  }

                              }else{

                              }

                          } else {
                            esta=false;
                          }
                    }
                    contador++;
                }
                bool ok;
                   QString nombre = QInputDialog::getText(this, tr("Ingrese el Nombre del Bloque"),tr("Nombre:"), QLineEdit::Normal,QDir::home().dirName(), &ok);

                   salida+=":"+nombre;


                   QFile file("Bitacora.201612118-log");
                   file.open(QFile::WriteOnly|QFile::Append);
                   QTextStream text(&file);
                   QByteArray ba=salida.toLatin1();
                   QString obtenido=encriptacion(ba.data(),10);
                   text<<obtenido<<endl;
                   file.close();


                   insertarBloque(nuevoBloque,nombre);
            }else{

            }


       }

}



void bitacoraBloque(QString nombrePi, QString dpiPi, QString placaBu, QString fechaBi, QStringList rutas, QString nombreBloque){
    //-------------------------------------------Busca un piloto-----------------------------
    QByteArray baba=fechaBi.toLatin1();

    struct bloque *nuevoBloque=(struct bloque*)malloc(sizeof(struct bloque));
    nuevoBloque->siguiente=NULL;
    nuevoBloque->primera=NULL;

    nuevoBloque->fecha=(char*)malloc(strlen(baba.data())+1);
    strcpy(nuevoBloque->fecha,baba.data());

    bool ok;
       QByteArray ba=dpiPi.toLatin1();
       QByteArray sbaba=nombrePi.toLatin1();
       struct arbol *aux=buscarPiloto(ba.data(),sbaba.data());
       if(aux!=NULL){
           nuevoBloque->piloto=aux;
           //--------------------------------------Busca Un Bus----------------------------------
            ba=placaBu.toLatin1();
            struct colision_autobuses *aux2=buscarAutobus(ba.data());
            //-------------------------------------Buscar Ruta-------------------------------------
            if(aux2!=NULL){
                nuevoBloque->bus=aux2;
                for(int i=0;i<rutas.length();i++){
                    QString subruta=rutas[i];
                    QStringList rrutas=subruta.split(",");
                    QString nomru=rrutas[0];
                    QString filerut=rrutas[1];

                    ba=nomru.toLatin1();
                    struct rutas* busca=cabecera_ruta;
                    struct rutas* aux3=buscarRuta(ba.data(),busca);
                    if(aux3!=NULL){
                        struct list_rutas *nuevo=(struct list_rutas*)malloc(sizeof(struct list_rutas));
                        nuevo->ruta=aux3;
                        nuevo->siguiente=NULL;
                        QStringList filenames=filerut.split(",");

                        asignarArbolAvl(filenames,nuevo);
                        //---------------------------Guardar en Lista de Rutas-------------------------------------------
                        if(nuevoBloque->primera==NULL){

                            nuevoBloque->primera=nuevoBloque->ultima=nuevo;
                        }else{
                            nuevoBloque->ultima->siguiente=nuevo;
                            nuevoBloque->ultima=nuevo;
                        }

                    }else{

                    }
                }

                   insertarBloque(nuevoBloque,nombreBloque);
            }else{

            }


       }
}
//--------------------------------------------Buscar Pilotos------------------------------------------------
arbol* buscarPiloto(char *dpi,char* nombre){
    int index=funcionHash(dpi,37);
    struct pilotos *aux=&hashPilotos[index];
    int da=cantidadNombre(nombre);
    struct arbol *avl=buscar(aux->arbolavl,da);
    return avl;
}

//----------------------------------------------Buscar Buses-------------------------------------------------
colision_autobuses* buscarAutobus(char *placa){
 int index=funcionHash(placa,37);
 struct autobuses *aux=&hashAuto[index];
 QString enviado=QString::fromUtf8(placa);

    struct colision_autobuses* send=aux->primero;
    struct colision_autobuses *ge=buscarAuto(placa,send);
    return ge;

}

colision_autobuses* buscarAuto(char *placa,colision_autobuses* cabeza){
    QString enviado=QString::fromUtf8(placa);
    while(cabeza!=NULL){
        QString recibido=QString::fromUtf8(cabeza->placa);
        if(enviado==recibido) return cabeza;
        cabeza=cabeza->siguiente;
    }
    return NULL;
}


//----------------------------------------------Buscar Rutas--------------------------------------------------
rutas* buscarRuta(char *nombre,rutas* nodo){
    QString enviado=QString::fromUtf8(nombre);
    if(nodo!=NULL){
         do{
            QString recibido=QString::fromUtf8(nodo->archivo);
            if(enviado==recibido) return nodo;
             nodo=nodo->siguiente;
         }while(nodo!=cabecera_ruta);
    }
    return NULL;
}

//----------------------------------------------Insertar BLoque----------------------------------------------
void insertarBloque(bloque *nodo,QString nombre){
    QByteArray ba=nombre.toLatin1();

    nodo->nombre=(char*)malloc(strlen(ba.data())+1);
    strcpy(nodo->nombre,ba.data());

    if(primeroBloque==NULL){
        primeroBloque=nodo;
        ultimoBloque=nodo;
    }else{
        ultimoBloque->siguiente=nodo;
        ultimoBloque=nodo;
    }
}

//----------------------------------------OPERACIONES PARA EL ARBOL AVL 2------------------------------------

int insertar2(struct arbolRuta **un_arbol, int dato,struct usuarios* nodo){


    if(*un_arbol == NULL){
        *un_arbol = (struct arbolRuta *)malloc(sizeof(struct arbolRuta));
        if(*un_arbol == NULL){
            return 0;
        }
        (*un_arbol)->dato = dato;
        (*un_arbol)->usuario=nodo;
        (*un_arbol)->izquierdo = NULL;
        (*un_arbol)->derecho = NULL;
    }
    else{
        if((*un_arbol)->dato < dato){
            insertar2(&((*un_arbol)->derecho), dato,nodo);
        }
        else{
            insertar2(&((*un_arbol)->izquierdo), dato,nodo);
        }
    }

    balancear_arbolavl2(un_arbol);

    return 1;
}


void balancear_arbolavl2(struct arbolRuta ** un_arbol) {
        int aux_balance = 0;
        if(un_arbol == NULL){
            return;
        }
        aux_balance = balanceo2(*un_arbol);
        if(aux_balance > 1){
            if(balanceo2((*un_arbol)->derecho) >= 1){
                rotar_izq2(un_arbol);
            }
            else{
                rotar_derecha2(&((*un_arbol)->derecho));
                rotar_izq2(un_arbol);
            }
        }
        else if(aux_balance < -1){
            if(balanceo2((*un_arbol)->izquierdo) <= -1){
                rotar_derecha2(un_arbol);
            }
            else{
                rotar_izq2(&((*un_arbol)->izquierdo));
                rotar_derecha2(un_arbol);
            }
        }
    }

int balanceo2(struct arbolRuta * un_arbol){
    int altura = 0;
    if(un_arbol == NULL){
        return 0;
    }

    altura = altura_arbolavl2(un_arbol->derecho) - altura_arbolavl2(un_arbol->izquierdo);
    return altura;
}


int rotar_derecha2(struct arbolRuta ** un_arbol){
    struct arbolRuta *auxiliar = NULL;
    struct arbolRuta *raiz = NULL;
    struct arbolRuta *raiz_nueva = NULL;


    if(un_arbol == NULL){
        return 0;
    }
    raiz = (*un_arbol);
    raiz_nueva = (*un_arbol) -> izquierdo;
    auxiliar = (*un_arbol) -> izquierdo -> derecho;

    (*un_arbol) = raiz_nueva;
    raiz_nueva -> derecho = raiz;
    raiz -> izquierdo = auxiliar;
    return 1;
}

int rotar_izq2(struct arbolRuta ** un_arbol){
    struct arbolRuta *auxiliar = NULL;
    struct arbolRuta *raiz = NULL;
    struct arbolRuta *raiz_nueva = NULL;

    if(un_arbol == NULL){
        return 0;
    }

    raiz = *un_arbol;
    raiz_nueva = (*un_arbol) -> derecho;
    auxiliar = (*un_arbol) -> derecho -> izquierdo;

    *un_arbol = raiz_nueva;
    (*un_arbol) -> izquierdo = raiz;
    raiz -> derecho = auxiliar;

    return 1;
}

int reordenar2(struct arbolRuta **un_arbol, struct arbolRuta **aux_arbol) {
    if ((*un_arbol)->derecho == NULL){
        (*aux_arbol)->dato = (*un_arbol)->dato;
        (*aux_arbol)->usuario=(*un_arbol)->usuario;
        *un_arbol = (*un_arbol)->izquierdo;
    }else
        reordenar2(&(*un_arbol)->derecho, aux_arbol);
    return 1;
}

int altura_arbolavl2(struct arbolRuta *un_arbol){
    int alturaizq = 0;
    int alturader = 0;
    if(un_arbol == NULL){
        return 0;
    }
    alturaizq = altura_arbolavl2(un_arbol->izquierdo);
    alturader = altura_arbolavl2(un_arbol->derecho);
    if (alturader > alturaizq){
        return alturader + 1;
    }
    else{
        return alturaizq + 1;
    }
}


//-------------------------------------------------Metodo para Asignar un Arbol Avl A los grafos-------------------------

void asignarArbolAvl(QStringList filenames, list_rutas *destino){
    if( !filenames.isEmpty() )
    {
        QMessageBox msgBox;
        for (int i =0;i<filenames.length();i++){
            QFile inputFile(filenames[i]);
            inputFile.open(QIODevice::ReadOnly);
                QTextStream in(&inputFile);
                QString name=QFileInfo(filenames[i]).fileName();
                QString namewithout=name.section(".", 0,0);
                QByteArray na=namewithout.toLatin1();

                destino->archivo=(char*)malloc(strlen(na.data()+1));
                strcpy(destino->archivo,na.data());

                struct rutas* aux=destino->ruta;
                struct viaje *grafo=aux->idaI;
                struct viaje *grafo2=aux->vueltaI;

                int fila=0;
                //--------------------------------------------Insertar Matriz Disperasa-----------------
               while(!in.atEnd()){
                   QString line=in.readLine();
                   QStringList datos=line.split(",");
                        if(grafo!=NULL){
                            grafo->raiz=NULL;
                            for(int j=0;j<datos.length();j++){
                                QString datooo=datos[j];
                                int dpi=datooo.toInt();
                                struct usuarios *user=buscarUsuario(datooo);
                                if(user!=NULL){
                                     rutArbol=grafo->raiz;
                                     if(buscar2(rutArbol,dpi)==NULL){
                                         rutArbol=grafo->raiz;
                                         insertar2(&rutArbol,dpi,user);
                                         grafo->raiz=rutArbol;
                                         rutArbol=NULL;
                                     }
                                }

                            }
                           grafo=grafo->siguiente;
                        }else if(grafo2!=NULL){

                            grafo2->raiz=NULL;
                            for(int j=0;j<datos.length();j++){
                                QString dato=datos[j];
                                int dpi=dato.toInt();
                                struct usuarios *user=buscarUsuario(dato);
                                if(user!=NULL){
                                        rutArbol=grafo2->raiz;
                                        insertar2(&rutArbol,dpi,user);
                                        grafo2->raiz=rutArbol;
                                        rutArbol=NULL;
                                }

                            }
                           grafo2=grafo2->siguiente;
                        }


                    fila++;
                 }

        }

    }
}

//--------------------------------------Buscar el Usuario en el arbol avl------------------------------------------
arbolRuta* buscar2(struct arbolRuta *un_arbol, int dato){
    if(un_arbol == NULL){
        return NULL;
    }
    if(un_arbol->dato == dato){
        return un_arbol;
    }

    if(un_arbol->dato < dato){
        return buscar2(un_arbol->derecho, dato);
    }
    else{
        return buscar2(un_arbol->izquierdo, dato);
    }
}


//---------------------------------------BUSCA UN USUARIO------------------------------------------------------------
usuarios* buscarUsuario(QString dpi){
    struct usuarios *aux=primerUsuario;
    while(aux!=NULL){
        if(aux->flag==true){
            QString dat=QString::fromUtf8(aux->dpi);
            if(dpi==dat) return aux;
        }
        aux=aux->siguiente;
    }
    return NULL;
}


void inOrden2(arbolRuta *un_arbol){
    if(un_arbol == NULL){
            return;
        }
        inOrden2(un_arbol->izquierdo);
        QString da=QString::number(un_arbol->dato);
        QByteArray ba=da.toLatin1();
        QString obtenido=encriptacion(ba.data(),10);
        if(textarbol!=NULL)*textarbol<<obtenido<<",";
        insercionB(un_arbol->dato);
        inOrden2(un_arbol->derecho);
}


/*----------------------------------------------------ARBOL B---------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------*/
btreeNode * crearNodoB(int val, btreeNode *child) {
    btreeNode *newNode = new btreeNode;
    newNode->val[1] = val;
    newNode->count = 1;
    newNode->link[0] = root;
    newNode->link[1] = child;
    return newNode;
}

void agregarValorNodo(int val, int pos, btreeNode *node, btreeNode *child) {
    int j = node->count;
    while (j > pos) {
        node->val[j + 1] = node->val[j];
        node->link[j + 1] = node->link[j];
        j--;
    }
    node->val[j + 1] = val;
    node->link[j + 1] = child;
    node->count++;
}

void dividirNodo(int val, int *pval, int pos, btreeNode *node,btreeNode *child, btreeNode **newNode) {
    int median, j;

    if (pos > MIN)
        median = MIN + 1;
    else
        median = MIN;

    *newNode = new btreeNode;
    j = median + 1;
    while (j <= MAX) {
        (*newNode)->val[j - median] = node->val[j];
        (*newNode)->link[j - median] = node->link[j];
        j++;
    }
    node->count = median;
    (*newNode)->count = MAX - median;

    if (pos <= MIN) {
        agregarValorNodo(val, pos, node, child);
    }
    else {
        agregarValorNodo(val, pos - median, *newNode, child);
    }
    *pval = node->val[node->count];
    (*newNode)->link[0] = node->link[node->count];
    node->count--;
}

int setValorNodo(int val, int *pval,btreeNode *node, btreeNode **child) {

    int pos;
    if (!node) {
        *pval = val;
        *child = NULL;
        return 1;
    }

    if (val < node->val[1]) {
        pos = 0;
    }
    else {
        for (pos = node->count;
            (val < node->val[pos] && pos > 1); pos--);
        if (val == node->val[pos]) {
            qDebug()<<"No se Guardan los Duplicados\n";
            return 0;
        }
    }
    if (setValorNodo(val, pval, node->link[pos], child)) {
        if (node->count < MAX) {
            agregarValorNodo(*pval, pos, node, *child);
        }
        else {
            dividirNodo(*pval, pval, pos, node, *child, child);
            return 1;
        }
    }
    return 0;
}

void insercionB(int val) {
    int flag, i;
    btreeNode *child;

    flag = setValorNodo(val, &i, root, &child);
    if (flag)
        root = crearNodoB(i, child);
}

void copiarSucesor(btreeNode *myNode, int pos) {
    btreeNode *dummy;
    dummy = myNode->link[pos];

    for (; dummy->link[0] != NULL;)
        dummy = dummy->link[0];
    myNode->val[pos] = dummy->val[1];

}

void removerValor(btreeNode *myNode, int pos) {
    int i = pos + 1;
    while (i <= myNode->count) {
        myNode->val[i - 1] = myNode->val[i];
        myNode->link[i - 1] = myNode->link[i];
        i++;
    }
    myNode->count--;
}

void equilibrarDerecha(btreeNode *myNode, int pos) {
    btreeNode *x = myNode->link[pos];
    int j = x->count;

    while (j > 0) {
        x->val[j + 1] = x->val[j];
        x->link[j + 1] = x->link[j];
    }
    x->val[1] = myNode->val[pos];
    x->link[1] = x->link[0];
    x->count++;

    x = myNode->link[pos - 1];
    myNode->val[pos] = x->val[x->count];
    myNode->link[pos] = x->link[x->count];
    x->count--;
    return;
}

void equilibrarIzquierda(btreeNode *myNode, int pos) {
    int j = 1;
    btreeNode *x = myNode->link[pos - 1];

    x->count++;
    x->val[x->count] = myNode->val[pos];
    x->link[x->count] = myNode->link[pos]->link[0];

    x = myNode->link[pos];
    myNode->val[pos] = x->val[1];
    x->link[0] = x->link[1];
    x->count--;

    while (j <= x->count) {
        x->val[j] = x->val[j + 1];
        x->link[j] = x->link[j + 1];
        j++;
    }
    return;
}

void fusionarNodos(btreeNode *myNode, int pos) {
    int j = 1;
    btreeNode *x1 = myNode->link[pos], *x2 = myNode->link[pos - 1];

    x2->count++;
    x2->val[x2->count] = myNode->val[pos];
    x2->link[x2->count] = myNode->link[0];

    while (j <= x1->count) {
        x2->count++;
        x2->val[x2->count] = x1->val[j];
        x2->link[x2->count] = x1->link[j];
        j++;
    }

    j = pos;
    while (j < myNode->count) {
        myNode->val[j] = myNode->val[j + 1];
        myNode->link[j] = myNode->link[j + 1];
        j++;
    }
    myNode->count--;
    free(x1);
}

void ajustarNodo(btreeNode *myNode, int pos) {
    if (!pos) {
        if (myNode->link[1]->count > MIN) {
            equilibrarIzquierda(myNode, 1);
        }
        else {
            fusionarNodos(myNode, 1);
        }
    }
    else {
        if (myNode->count != pos) {
            if (myNode->link[pos - 1]->count > MIN) {
                equilibrarDerecha(myNode, pos);
            }
            else {
                if (myNode->link[pos + 1]->count > MIN) {
                    equilibrarIzquierda(myNode, pos + 1);
                }
                else {
                    fusionarNodos(myNode, pos);
                }
            }
        }
        else {
            if (myNode->link[pos - 1]->count > MIN)
                equilibrarDerecha(myNode, pos);
            else
                fusionarNodos(myNode, pos);
        }
    }
}

int eliminarValorNodo(int val,btreeNode *myNode) {
    int pos, flag = 0;
    if (myNode) {
        if (val < myNode->val[1]) {
            pos = 0;
            flag = 0;
        }
        else {
            for (pos = myNode->count;
                (val < myNode->val[pos] && pos > 1); pos--);
            if (val == myNode->val[pos]) {
                flag = 1;
            }
            else {
                flag = 0;
            }
        }
        if (flag) {
            if (myNode->link[pos - 1]) {
                copiarSucesor(myNode, pos);
                flag = eliminarValorNodo(myNode->val[pos], myNode->link[pos]);
                if (flag == 0) {
                    qDebug()<<"Given data is not present in B-Tree\n";
                }
            }
            else {
                removerValor(myNode, pos);
            }
        }
        else {
            flag = eliminarValorNodo(val, myNode->link[pos]);
        }
        if (myNode->link[pos]) {
            if (myNode->link[pos]->count < MIN)
                ajustarNodo(myNode, pos);
        }
    }
    return flag;
}

void eliminarB(int val,btreeNode *myNode) {
    btreeNode *tmp;
    if (!eliminarValorNodo(val, myNode)) {
        qDebug()<<"Given value is not present in B-Tree\n";
        return;
    }
    else {
        if (myNode->count == 0) {
            tmp = myNode;
            myNode = myNode->link[0];
            free(tmp);
        }
    }
    root = myNode;
    return;
}

usuarios* buscarB(int val, int *pos,btreeNode *myNode) {
    if (!myNode) {
        return NULL;
    }

    if (val < myNode->val[1]) {
        *pos = 0;
    }
    else {
        for (*pos = myNode->count;
            (val < myNode->val[*pos] && *pos > 1); (*pos)--);
        if (val == myNode->val[*pos]) {
            QString dpi=QString::number(val);
            return buscarUsuario(dpi);
        }
    }
    buscarB(val, pos, myNode->link[*pos]);
}

void inOrdenArbolB(btreeNode *myNode) {
    int i;
    QString f="";
    if (myNode) {
        long int point = reinterpret_cast<long int>(myNode);
        for (i = 0; i < myNode->count; i++) {
            long int point2 = reinterpret_cast<long int>(myNode->link[i]);
            if(point2!=0) *textarbol<<point<<"->"<<point2<<endl;
            inOrdenArbolB(myNode->link[i]);
             f+="<TD>"+QString::number(myNode->val[i + 1])+"</TD>";
        }
        long int point2 = reinterpret_cast<long int>(myNode->link[i]);
        if(point2!=0) *textarbol<<point<<"->"<<point2<<endl;
        inOrdenArbolB(myNode->link[i]);
        *textarbol<<point<<"[label=<<TABLE><TR>"<<f<<"</TR></TABLE>>,shape=\"none\"];"<<endl;
    }
}
/*-----------------------------------------------------FIN ARBOL B-------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------*/

//--------------------------------------------------------CREAR REPORTE POR BLOQUE-----------------------------------------------------
void MainWindow::on_actionPor_Bloque_triggered()
{
    bool ok;
    QString nomb = QInputDialog::getText(this, tr("Ingrese el Nombre del Bloque"),tr("Nombre:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
        QFile file("Bitacora.201612118-log");
        file.open(QFile::WriteOnly|QFile::Append);
        textarbol=new QTextStream();
        textarbol->setDevice(&file);
        QString direcciones="Reporte:Bloque:"+nomb+":";
        QByteArray ba=direcciones.toLatin1();
        QString obtenido=encriptacion(ba.data(),10);
        *textarbol<<obtenido;
        reportePorBloque(nomb);
        *textarbol<<"fin\n"<<endl;
        file.close();
        textarbol=NULL;

}

void reportePorBloque(QString nombre){
    //------------------------------------------BUSCAR EL BLOQUE---------------------------------------------------
    reporteBloque=NULL;
    root=reporteBloque;
    struct bloque *aux=buscarBloque(nombre);
    if(aux!=NULL){
        //-----------------------------------------BUSCAR LA LISTA DE RUTAS----------------------------------------
        struct list_rutas *lista=aux->primera;
            //-------------------------------------BUSCAR LA RUTA-------------------------------------------------
            while(lista!=NULL){
                struct rutas *rut=lista->ruta;
                //-------------------------------------BUSCAR LOS GRAFOS-----------------------------------------
                struct viaje *ida=rut->idaI;
                struct viaje *vuelta=rut->vueltaI;

                //------------------------GRAFO DE IDA-------------------------------------------

                while(ida!=NULL){
                    qDebug()<<ida->nombre;
                    un_arbol2=ida->raiz;
                    inOrden2(un_arbol2);
                    un_arbol2=NULL;
                    ida=ida->siguiente;
                }

                //------------------------GRAFO DE VUELTA------------------------------------------------
                while(vuelta!=NULL){
                    un_arbol2=vuelta->raiz;
                    inOrden2(un_arbol2);
                    un_arbol2=NULL;
                    vuelta=vuelta->siguiente;
                }


            lista=lista->siguiente;
        }
    reporteBloque=root;
    root=NULL;
    }
}

//----------------------------------------------------Ver  un AutoBus -----------------------------------------------------
void MainWindow::on_actionUn_solo_AutoBus_triggered()
{
    QFile file("Hash.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    QTextStream text(&file);
    text<<"digraph G{"<<endl;
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese la Placa del Autobus"),tr("Placa:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    QByteArray  ba=texts.toLatin1();
    struct colision_autobuses *aux=buscarAutobus(ba.data());
    if(aux!=NULL){
        long int point = reinterpret_cast<long int>(aux);
        text<<point<<"[shape=\"none\",label= <<TABLE><TR><TD>No: ";
        text<<"</TD><TD>Placa: "<<aux->placa<<"</TD><TD>Modelo: "<<aux->modelo<<"</TD><TD> Estado: "<<aux->estado<<"</TD></TR></TABLE>>]"<<endl;
    }
    text<<"}"<<endl;
    file.close();
    system("dot -Tpng Hash.dot -o Hash.png");
    mostrarImagenes("Hash.png");
}
//---------------------------------------------------VER LISTA DE AUTOBUSES GENERALES....................................
void MainWindow::on_actionGeneral_triggered()
{

    QFile file("Hash.dot");
            file.open(QIODevice::WriteOnly | QIODevice::Truncate);
            QTextStream text(&file);
                text<<"digraph G{"<<endl;
             for(int i=0;i<37;i++){
                struct colision_autobuses *aux=hashAuto[i].primero;
                long int point = reinterpret_cast<long int>(&hashAuto[i]);
                long int point2 = reinterpret_cast<long int>(aux);
                if(i!=36){
                    long int point22 = reinterpret_cast<long int>(&hashAuto[i+1]);
                    text<<point<<"->"<<point22<<endl;
                }
                    if(hashAuto[i].flag==true){
                        text<<point<<"[label=\" "<<i<<". Ocupado \"];"<<endl;
                    }else{
                        text<<point<<"[label=\" "<<i<<". No ocupado \"];"<<endl;
                    }


            }
            text<<"}"<<endl;
            file.close();
            system("dot -Tpng Hash.dot -o Hash.png");

 mostrarImagenes("Hash.png");
}

//---AutoBus-------------------------Por Colision------------------------------------------------

void MainWindow::on_actionColision_triggered()
{
    QFile file("Hash.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    QTextStream text(&file);
    text<<"digraph G{"<<endl;
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese la Placa del Autobus"),tr("Placa:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    int valor=texts.toInt();
    struct colision_autobuses *aux=hashAuto[valor].primero;
    if(hashAuto[valor].flag!=false){
        if(aux!=NULL){
            while(aux!=NULL){
                if(aux!=hashAuto[valor].ultimo){
                                             long int point3 = reinterpret_cast<long int>(aux);
                                             long int point4 = reinterpret_cast<long int>(aux->siguiente);

                                             text<<point3<<"[shape=\"none\",label= <<TABLE><TR><TD>No: ";
                                             text<<"</TD><TD>Placa: "<<aux->placa<<"</TD><TD>Modelo: "<<aux->modelo<<"</TD><TD> Estado: "<<aux->estado<<"</TD></TR></TABLE>>]"<<endl;
                                             text<<point3<<"->"<<point4<<";"<<endl;
                                        }else if(aux==hashAuto[valor].primero || aux==hashAuto[valor].ultimo){
                                              long int point3 = reinterpret_cast<long int>(aux);
                                              text<<point3<<"[shape=\"none\",label= <<TABLE><TR><TD>No: ";
                                              text<<"</TD><TD>Placa: "<<aux->placa<<"</TD><TD>Modelo: "<<aux->modelo<<"</TD><TD> Estado: "<<aux->estado<<"</TD></TR></TABLE>>]"<<endl;
                                        }
                aux=aux->siguiente;
            }
        }

    }
    text<<"}"<<endl;
    file.close();
    system("dot -Tpng Hash.dot -o Hash.png");
     mostrarImagenes("Hash.png");

}


//------------------------------------------------Graficar todas las imagenes-------------------------------------------------
void MainWindow::mostrarImagenes(QString ruta){
    QPixmap  pix(ruta);
                 ui->imagen->setParent(this);
                 ui->imagen->setPixmap(pix);
                 ui->scrollArea->setWidget(ui->imagen);
                 ui->imagen->setParent(ui->scrollArea);
                 ui->imagen->show();
}
//--------------------------------------------------PILOTO INDIVIDUAL-------------------------------
void MainWindow::on_actionIndividual_triggered()
{
    QFile file("Hash.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    textarbol=new QTextStream();
    textarbol->setDevice(&file);
    *textarbol<<"digraph G{\n"<<endl;
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el DPI DE PILOTO"),tr("DPI:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    QString nomb = QInputDialog::getText(this, tr("Ingrese el Nombre DE PILOTO"),tr("Nombre:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    QByteArray  ba=texts.toLatin1();
    QByteArray baba=nomb.toLatin1();
    struct arbol *aux=buscarPiloto(ba.data(),baba.data());
    if(aux!=NULL){
        long int point = reinterpret_cast<long int>(aux);
        *textarbol<<point<<"[shape=\"none\",label= <<TABLE><TR> ";
        *textarbol<<"<TD>DPI: "<<aux->dpi<<"</TD><TD>Nombre: "<<aux->nombre<<"</TD><TD>Edad: "<<aux->edad<<"</TD><TD>"<<aux->genero<<"</TD></TR></TABLE>>]"<<endl;
    }
    *textarbol<<"}"<<endl;
    file.close();
    system("dot -Tpng Hash.dot -o Hash.png");
    mostrarImagenes("Hash.png");
}
//---------------------------------------------------------PILOTO GENERAL----------------------------------------------------
void MainWindow::on_actionGeneral_2_triggered()
{
    QFile file("Hash.dot");
            file.open(QIODevice::WriteOnly | QIODevice::Truncate);
            textarbol=new QTextStream();
            textarbol->setDevice(&file);
            *textarbol<<"digraph G{\n rankdir=LR;\n"<<endl;
            for(int i=0;i<tam_autobuses;i++){
                long int point = reinterpret_cast<long int>(&(hashPilotos[i]));
                if(hashPilotos[i].estado!=false){
                    *textarbol<<point<<"[shape=\"none\",label= <<TABLE><TR><TD>No: ";
                    *textarbol<<i<<"</TD><TD> ESTA OCUPADO</TD></TR></TABLE>>]"<<endl;
                }else{
                    *textarbol<<point<<"[shape=\"none\",label= <<TABLE><TR><TD>No: ";
                    *textarbol<<i<<"</TD><TD>NO ESTA OCUPADO</TD></TR></TABLE>>]"<<endl;

                }

            }
            *textarbol<<"}"<<endl;
            file.close();
            system("dot -Tpng Hash.dot -o Hash.png");
            mostrarImagenes("Hash.png");
}

//-------------------------------------------------------PILITO COLISION------------------------------------------------------
void MainWindow::on_actionColision_2_triggered()
{
    QFile file("Hash.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    textarbol=new QTextStream();
    textarbol->setDevice(&file);
    *textarbol<<"digraph G{\n"<<endl;
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el DPI DE PILOTO"),tr("DPI:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    int valor=texts.toInt();
    if(hashPilotos[valor].estado!=false){
        struct arbol *aux=hashPilotos[valor].arbolavl;
        un_arbol=aux;
        if(un_arbol!=NULL){
            graficarArbol(un_arbol);
        }
    }
    un_arbol=NULL;
    *textarbol<<"}"<<endl;
    file.close();
    system("dot -Tpng Hash.dot -o Hash.png");
    mostrarImagenes("Hash.png");
}

//----------------------------------Eliminar AutoBus--------------------------------------------------------------------
void MainWindow::on_actionAutobus_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese la Placa del Autobus"),tr("Placa:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    QByteArray  ba=texts.toLatin1();
    eliminarBus(ba.data());

    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones="Eliminar:Autobus:"+texts;
    QByteArray bas=direcciones.toLatin1();
    QString obtenido=encriptacion(bas.data(),10);
    text<<obtenido<<endl;
    file.close();
}

void eliminarBus(char *placa){
    int index=funcionHash(placa,37);
    struct autobuses *aux=&hashAuto[index];
    QString enviado=QString::fromUtf8(placa);
       struct colision_autobuses* send=aux->primero;
       QString recibido=QString::fromUtf8(send->placa);
       if(recibido==enviado){
           struct colision_autobuses* aux2=send->siguiente;
           free(send);
           aux->primero=aux2;
       }else if(QString::fromUtf8(aux->ultimo->placa)==enviado){
           struct colision_autobuses* aux2=send;
           while(aux2!=aux->ultimo){
               aux2=aux2->siguiente;
           }
           free(aux->ultimo);
           aux2->siguiente=NULL;
           aux->ultimo=aux2;

       }else{
           struct colision_autobuses *aux2;
           while(QString::fromUtf8(send->siguiente->placa)!=enviado){
                   send=send->siguiente;
           }
           aux2=send->siguiente;
           send->siguiente=aux2->siguiente;
           free(aux2);
       }

       QFile file("Bitacora.201612118-log");
       file.open(QFile::WriteOnly|QFile::Append);
       QTextStream text(&file);
       QString direcciones=QString::fromUtf8(placa);
       text<<"Eliminar:"<<"Autobus:"<<direcciones<<endl;
       file.close();

}

//---------------------------------------Eliminar Piloto-------------------------------------------------------------

void MainWindow::on_actionPiloto_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el DPI DE PILOTO"),tr("DPI:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    QString nomb = QInputDialog::getText(this, tr("Ingrese el Nombre DE PILOTO"),tr("Nombre:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    QByteArray  ba=texts.toLatin1();
    QByteArray baba=nomb.toLatin1();
    int dat=cantidadNombre(baba.data());
    int valor=funcionHash(ba.data(),37);
    struct arbol *aux=hashPilotos[valor].arbolavl;
    eliminar(&aux,dat);

    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones="Eliminar:Piloto:"+texts+":"+nomb;
    QByteArray bas=direcciones.toLatin1();
    QString obtenido=encriptacion(bas.data(),10);
    text<<obtenido<<endl;
    file.close();
}

//---------------------------------------VER GENERAL LISTA DE ESTACIONES---------------------------------------------
void MainWindow::on_actionGeneral_3_triggered()
{
    QFile file("Estaciones.dot");
          file.open(QIODevice::WriteOnly | QIODevice::Truncate);
          QTextStream text(&file);
              text<<"digraph G{\n rankdir=LR;\n"<<endl;
          struct estaciones *aux=primeroesta;
          while(aux!=NULL){
              if(aux!=ultimoesta){
                  long int point = reinterpret_cast<long int>(aux);
                  long int point2 = reinterpret_cast<long int>(aux->siguiente);
                   text<<point<<"->"<<point2<<";"<<endl;
                   text<<point<<"[label=\"Codigo: "<<aux->codigo<<" \\nNombre: "<<aux->nombre<<" \\n Direccion: "<<aux->ubicacion<<"\"];"<<endl;
              }else if(aux==primeroesta || aux==ultimoesta){
                  long int point = reinterpret_cast<long int>(aux);
                  text<<point<<"[label=\"Codigo: "<<aux->codigo<<" \\nNombre: "<<aux->nombre<<" \\n Direccion: "<<aux->ubicacion<<"\"];"<<endl;

              }
              aux=aux->siguiente;
          }

          text<<"}"<<endl;
          file.close();
          system("dot -Tpng Estaciones.dot -o Estaciones.png");
              mostrarImagenes("Estaciones.png");

}

//-----------------------------------------INDIVIDUAL ESTACION--------------------------------------------------------
void MainWindow::on_actionIndividual_2_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el codigo de la estacion"),tr("codigo:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    struct estaciones *aux=buscarEstacion(texts);
    if(aux!=NULL){
        QFile file("Estaciones.dot");
              file.open(QIODevice::WriteOnly | QIODevice::Truncate);
              QTextStream text(&file);
              text<<"digraph G{\n rankdir=LR;\n"<<endl;
              long int point = reinterpret_cast<long int>(aux);
              text<<point<<"[label=\"Codigo: "<<aux->codigo<<" \\nNombre: "<<aux->nombre<<" \\n Direccion: "<<aux->ubicacion<<"\"];"<<endl;
              text<<"}"<<endl;
              file.close();
              system("dot -Tpng Estaciones.dot -o Estaciones.png");
                  mostrarImagenes("Estaciones.png");
    }
}


//--------------------------------------Eliminar Estacion---------------------------------------------------
void MainWindow::on_actionEstacion_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el codigo de la estacion"),tr("Estacion:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    eliminarEstacion(texts);

    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones="Eliminar:Estacion:"+texts;
    QByteArray bas=direcciones.toLatin1();
    QString obtenido=encriptacion(bas.data(),10);
    text<<obtenido<<endl;
    file.close();


}

void eliminarEstacion(QString codigo){
    struct estaciones *aux=primeroesta;
    QString recibido=QString::fromUtf8(aux->codigo);
    if(recibido==codigo){
        primeroesta=aux->siguiente;
        free(aux);
    }else if((QString::fromUtf8(ultimoesta->codigo))==codigo){
        while(aux!=ultimoesta){
            aux=aux->siguiente;
        }
        free(ultimoesta);
        aux->siguiente=NULL;
        ultimoesta=aux;
    }else{
        struct estaciones *aux2;
        while(QString::fromUtf8(aux->siguiente->codigo)!=codigo){
                aux=aux->siguiente;
        }
        aux2=aux->siguiente;
        aux->siguiente=aux2->siguiente;
        free(aux2);
    }
}

//------------------------------------------------Ver Rutas---------------------------------------------------------
void MainWindow::on_actionRutas_General_triggered()
{
        QFile file("Ruta.dot");
          file.open(QIODevice::WriteOnly | QIODevice::Truncate);
          QTextStream text(&file);
          text<<"digraph G{"<<endl;
          if(cabecera_ruta!=NULL){
              struct rutas *ruta=cabecera_ruta;
              while(ruta->siguiente!=cabecera_ruta){
                           long int point = reinterpret_cast<long int>(ruta);
                           long int point2 = reinterpret_cast<long int>(ruta->siguiente);
                           text<<point<<"[label=\"Ruta: "<<ruta->archivo<<"\"];"<<endl;
                           text<<point<<"->"<<point2<<";"<<endl;
                           text<<point2<<"->"<<point<<";"<<endl;
                           ruta=ruta->siguiente;
                      }
               if(ruta->siguiente==cabecera_ruta){
                          long int point = reinterpret_cast<long int>(cabecera_ruta);
                          long int point2 = reinterpret_cast<long int>(ruta);
                          text<<point2<<"[label=\"Ruta: "<<ruta->archivo<<"\"];"<<endl;
                          text<<point<<"->"<<point2<<";"<<endl;
                          text<<point2<<"->"<<point<<";"<<endl;
               }
          }
          text<<"}"<<endl;
                  file.close();
                  system("dot -Tpng Ruta.dot -o Ruta.png");

                  mostrarImagenes("Ruta.png");
}


//--------------------------------------ver el Grafo--------------------------------------------

void MainWindow::on_actionVer_Ruta_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre de la Ruta"),tr("Ruta:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    QByteArray a=texts.toLatin1();
    struct rutas *rut=buscarRuta(a.data(),cabecera_ruta);
    if(rut!=NULL){
        QFile file("Ruta.dot");
          file.open(QIODevice::WriteOnly | QIODevice::Truncate);
          QTextStream text(&file);
          text<<"digraph G{"<<endl;

          struct viaje *ida=rut->idaI;
          struct viaje *vuelta=rut->vueltaI;

          while(ida!=NULL){
              if(ida!=rut->idaF){
                  if(ida->esta!=NULL){
                      text<<"ruta"<<ida->nombre<<"->ruta"<<ida->siguiente->nombre<<endl;
                      text<<"ruta"<<ida->nombre<<"[label=\"Nombre: "<<ida->esta->nombre<<"\"];"<<endl;
                  }

              }else if(ida==rut->idaI || ida==rut->idaF){
                  long int point = reinterpret_cast<long int>(ida);
                  text<<"ruta"<<ida->nombre<<"[label=\"Nombre: "<<ida->esta->nombre<<"\"];"<<endl;
              }
              ida=ida->siguiente;
          }

          while(vuelta!=NULL){
              if(vuelta!=rut->vueltaF){
                  if(vuelta->esta!=NULL){
                      text<<"ruta"<<vuelta->nombre<<"->ruta"<<vuelta->siguiente->nombre<<endl;
                       text<<"ruta"<<vuelta->nombre<<"[label=\"Nombre: "<<vuelta->esta->nombre<<"\"];"<<endl;
                  }

              }else if(vuelta==rut->vueltaI || vuelta==rut->vueltaF){
                  if(vuelta->esta!=NULL){
                       text<<"ruta"<<vuelta->nombre<<"[label=\"Nombre: "<<vuelta->esta->nombre<<"\"];"<<endl;
                  }              }
              vuelta=vuelta->siguiente;
          }


          text<<"}"<<endl;
          file.close();
          system("dot -Tpng Ruta.dot -o Ruta.png");
          mostrarImagenes("Ruta.png");
    }

}

//-----------------------------------------------ELIMINAR RUTA------------------------------------------------
void MainWindow::on_actionRuta_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre de la Ruta"),tr("Ruta:"), QLineEdit::Normal,QDir::home().dirName(), &ok);

    eliminarRuta(texts);

    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones="Eliminar:Ruta:"+texts;
    QByteArray bas=direcciones.toLatin1();
    QString obtenido=encriptacion(bas.data(),10);
    text<<obtenido<<endl;
    file.close();

}

void eliminarRuta(QString nombre){
    struct rutas *aux=cabecera_ruta;
    struct rutas *nodo;
    int contador=0;
    while(aux->siguiente!=cabecera_ruta){
        contador++;
        aux=aux->siguiente;
    }


    if(contador==0){
        if(cabecera_ruta!=NULL){
            QString recibido=QString::fromUtf8(cabecera_ruta->archivo);
            if(recibido==nombre){
                free(cabecera_ruta);
                cabecera_ruta=NULL;
            }
        }
    }else if(contador==1){
        aux=cabecera_ruta;
        do{
            QString recibido=QString::fromUtf8(aux->archivo);
            if(recibido==nombre){
                if(aux==cabecera_ruta){
                    nodo=aux->siguiente;
                    cabecera_ruta=nodo;
                    cabecera_ruta->siguiente=cabecera_ruta;
                    cabecera_ruta->anterior=cabecera_ruta;
                    free(aux);

                }else{
                    qDebug()<<"Rutab";
                    free(aux);
                    cabecera_ruta->siguiente=cabecera_ruta;
                    cabecera_ruta->anterior=cabecera_ruta;
                }
                break;
            }
            aux=aux->siguiente;
        }while(aux!=cabecera_ruta);


    }else{

        aux=cabecera_ruta;
        do{
            QString recibido=QString::fromUtf8(aux->archivo);
            if(recibido==nombre){
                if(aux==cabecera_ruta){
                    nodo=aux->anterior;
                    cabecera_ruta=aux->siguiente;
                    cabecera_ruta->anterior=nodo;
                    nodo->siguiente=cabecera_ruta;
                    free(aux);

                }else{
                    nodo=aux->anterior;
                    nodo->siguiente=aux->siguiente;
                    aux->siguiente->anterior=nodo;
                    free(aux);
                }
                break;
            }
            aux=aux->siguiente;
        }while(aux!=cabecera_ruta);
    }

}

//--------------------------------ver Parqueo-------------------------------------
void MainWindow::on_actionParqueo_triggered()
{
}

//-----------------------General Parqueo--------------------------------
void MainWindow::on_actionGeneral_4_triggered()
{
    QFile file("Parqueo.dot");
      file.open(QIODevice::WriteOnly | QIODevice::Truncate);
      QTextStream text(&file);
      text<<"digraph G{"<<endl;
      if(cabecera_parqueo!=NULL){
          struct parqueo *ruta=cabecera_parqueo;
          while(ruta->siguiente!=cabecera_parqueo){
                       long int point = reinterpret_cast<long int>(ruta);
                       long int point2 = reinterpret_cast<long int>(ruta->siguiente);
                       text<<point<<"[label=\"Parqueo: "<<ruta->archivo<<"\"];"<<endl;
                       text<<point<<"->"<<point2<<";"<<endl;
                       text<<point2<<"->"<<point<<";"<<endl;
                       ruta=ruta->siguiente;
                  }
           if(ruta->siguiente==cabecera_parqueo){
                      long int point = reinterpret_cast<long int>(cabecera_parqueo);
                      long int point2 = reinterpret_cast<long int>(ruta);
                      text<<point2<<"[label=\"Parqueo: "<<ruta->archivo<<"\"];"<<endl;
                      text<<point<<"->"<<point2<<";"<<endl;
                      text<<point2<<"->"<<point<<";"<<endl;
           }
      }
      text<<"}"<<endl;
              file.close();
              system("dot -Tpng Parqueo.dot -o Parqueo.png");

              mostrarImagenes("Parqueo.png");
}
//-----------------------------Parqueo Individual-----------------------------------
void MainWindow::on_actionParqueo_Individual_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre del Parqueo"),tr("Parqueo:"), QLineEdit::Normal,QDir::home().dirName(), &ok);

    bool estado=false;
    int pos=0;
    struct parqueo *aux=cabecera_parqueo;
    do{
        QString recibido=QString::fromUtf8(aux->archivo);
        if(texts==recibido){
            estado=true;
        }
        if(estado==false) pos++;
        aux=aux->siguiente;
    }while(aux!=cabecera_parqueo);

    if(estado==true){
        graficarMatriz(pos);
        mostrarImagenes("Matriz.png");
    }else{
        QMessageBox ms;
        ms.setText("No se encontro el Parqueo");
        ms.exec();
    }
}

//-----------------------------------------------------Eliminar Parqueo-------------------------------------------------------
void MainWindow::on_actionParqueo_2_triggered()
{

    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre del Parqueo"),tr("Parqueo:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    eliminarParqueo(texts);

    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones="Eliminar:Parqueo:"+texts;
    QByteArray bas=direcciones.toLatin1();
    QString obtenido=encriptacion(bas.data(),10);
    text<<obtenido<<endl;
    file.close();

}

void eliminarParqueo(QString nombre){
    struct parqueo *aux=cabecera_parqueo;
    struct parqueo *nodo;
    int contador=0;
    while(aux->siguiente!=cabecera_parqueo){
        contador++;
        aux=aux->siguiente;
    }


    if(contador==0){
        if(cabecera_parqueo!=NULL){
            QString recibido=QString::fromUtf8(cabecera_parqueo->archivo);
            if(recibido==nombre){
                free(cabecera_parqueo);
                cabecera_parqueo=NULL;
            }
        }
    }else if(contador==1){
        aux=cabecera_parqueo;
        do{
            QString recibido=QString::fromUtf8(aux->archivo);
            if(recibido==nombre){
                if(aux==cabecera_parqueo){
                    nodo=aux->siguiente;
                    cabecera_parqueo=nodo;
                    cabecera_parqueo->siguiente=cabecera_parqueo;
                    cabecera_parqueo->anterior=cabecera_parqueo;
                    free(aux);

                }else{
                    qDebug()<<"Rutab";
                    free(aux);
                    cabecera_parqueo->siguiente=cabecera_parqueo;
                    cabecera_parqueo->anterior=cabecera_parqueo;
                }
                break;
            }
            aux=aux->siguiente;
        }while(aux!=cabecera_parqueo);


    }else{

        aux=cabecera_parqueo;
        do{
            QString recibido=QString::fromUtf8(aux->archivo);
            if(recibido==nombre){
                if(aux==cabecera_parqueo){
                    nodo=aux->anterior;
                    cabecera_parqueo=aux->siguiente;
                    cabecera_parqueo->anterior=nodo;
                    nodo->siguiente=cabecera_parqueo;
                    free(aux);

                }else{
                    nodo=aux->anterior;
                    nodo->siguiente=aux->siguiente;
                    aux->siguiente->anterior=nodo;
                    free(aux);
                }
                break;
            }
            aux=aux->siguiente;
        }while(aux!=cabecera_parqueo);
    }
}

//-----------------------------------------------------------Graficar Usuarios General----------------------------------------------------
void MainWindow::on_actionGeneral_5_triggered()
{
    struct usuarios *aux=primerUsuario;
            QFile file("Lista.dot");
            file.open(QIODevice::WriteOnly | QIODevice::Truncate);
            QTextStream text(&file);
            text<<"digraph G{"<<endl;
            int i=0;
            while(aux!=NULL){
                if(aux!=ultimoUsuario){
                 long int point = reinterpret_cast<long int>(aux);
                 long int point2 = reinterpret_cast<long int>(aux->siguiente);
                 text<<point<<"->"<<point2<<";"<<endl;
                 if(aux->flag!=false) text<<point<<"[label= \" "<<i<<". Usuario "<<aux->nombre<<" \n DPI: "<<aux->dpi<<"\"];"<<endl;
                 else text<<point<<"[label= \" "<<i<<". Vacio\"];"<<endl;
                 text<<point2<<"->"<<point<<";"<<endl;
                 }else if(aux==primerUsuario || aux==ultimoUsuario){
                 long int point = reinterpret_cast<long int>(aux);
                 if(aux->flag!=false) text<<point<<"[label= \" "<<i<<". Usuario "<<aux->nombre<<" \n DPI: "<<aux->dpi<<"\"];"<<endl;
                 else text<<point<<"[label= \" "<<i<<". Vacio\"];"<<endl;               }
              aux=aux->siguiente;
              i++;
            }
            text<<"}"<<endl;
            file.close();
            system("dot -Tpng Lista.dot -o Lista.png");

            mostrarImagenes("Lista.png");
}

//--------------------------------------------------Individual usuarios Graficar----------------------------------------------
void MainWindow::on_actionIndividual_3_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el DPI del usuario"),tr("Usuario:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    struct usuarios *aux=buscarUsuario(texts);
    if(aux!=NULL){
        QFile file("Lista.dot");
        file.open(QIODevice::WriteOnly | QIODevice::Truncate);
        QTextStream text(&file);
        text<<"digraph G{"<<endl;
        long int point = reinterpret_cast<long int>(aux);
         text<<point<<"[label= \" Usuario "<<aux->nombre<<"\n DPI:"<<aux->dpi<<"\n Edad: "<<aux->edad<< "\"];"<<endl;
        text<<"}"<<endl;
        file.close();
        system("dot -Tpng Lista.dot -o Lista.png");
        mostrarImagenes("Lista.png");
    }
}

//-------------------------------------------------Eliminar Usuario-------------------------------------------------------------
void MainWindow::on_actionUsuario_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el DPI del usuario"),tr("Usuario:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    eliminarUsuario(texts);


    QFile file("Bitacora.201612118-log");
    file.open(QFile::WriteOnly|QFile::Append);
    QTextStream text(&file);
    QString direcciones="Eliminar:Usuario:"+texts;
    QByteArray bas=direcciones.toLatin1();
    QString obtenido=encriptacion(bas.data(),10);
    text<<obtenido<<endl;
    file.close();
}

void eliminarUsuario(QString nombre){
    struct usuarios *aux=primerUsuario;
    while(aux!=NULL){
        if(aux->flag!=false){
            QString recibido=QString::fromUtf8(aux->dpi);
            if(nombre==recibido) aux->flag=false;
        }
        aux=aux->siguiente;
    }
}

//---------------------------------------Cargar Bitacora------------------------------------------------------

void MainWindow::on_actionCargar_Bitacora_triggered()
{
    QFile inputFile("Bitacora.201612118-log");
    inputFile.open(QIODevice::ReadOnly);
        QTextStream in(&inputFile);
        while(!in.atEnd()){
            QString line=in.readLine();
            QByteArray ba=line.toLatin1();
            QString obtenido=desencriptacion(ba.data(),10);
            QStringList datos=obtenido.split(":");

            if(datos[0]=="Autobus"){
                QString ls=datos[1];
                QStringList archivos=ls.split(",");
                generalAutoBus(archivos);
            }else if(datos[0]=="Piloto"){
                QString ls=datos[1];
                QStringList archivos=ls.split(",");
                generalPiloto(archivos);
            }else if(datos[0]=="Estacion"){
                QString ls=datos[1];
                QStringList archivos=ls.split(",");
                generalEstaciones(archivos);
            }else if(datos[0]=="Parqueo"){
                QString ls=datos[1];
                QStringList archivos=ls.split(",");
                generalMatriz(archivos);
            }else if(datos[0]=="Usuario"){
                QString ls=datos[1];
                QStringList archivos=ls.split(",");
                generalUsuario(archivos);
            }else if(datos[0]=="Ruta"){
                QString ls=datos[1];
                QStringList archivos=ls.split(",");
                generalRutas(archivos);
            }else if(datos[0]=="Eliminar"){
                if(datos[1]=="Autobus"){
                    QString v=datos[2];
                    QByteArray ba=v.toLatin1();
                    eliminarBus(ba.data());
                }else if(datos[1]=="Piloto"){
                    QString texts=datos[2];
                    QString nomb=datos[3];
                    QByteArray  ba=texts.toLatin1();
                    QByteArray baba=nomb.toLatin1();
                    int dat=cantidadNombre(baba.data());
                    int valor=funcionHash(ba.data(),37);
                    struct arbol *aux=hashPilotos[valor].arbolavl;
                    eliminar(&aux,dat);
                }else  if(datos[1]=="Estacion"){
                    eliminarEstacion(datos[2]);
                }else  if(datos[1]=="Parqueo"){
                    eliminarParqueo(datos[2]);
                }else  if(datos[1]=="Usuario"){
                    eliminarUsuario(datos[2]);
                }else  if(datos[1]=="Ruta"){
                    eliminarRuta(datos[2]);
                }
            }else if(datos[0]=="Bloque"){
                QString ls=datos[5];
                QStringList rut=ls.split("|");
                bitacoraBloque(datos[1],datos[2],datos[3],datos[4],rut,datos[6]);
            }else if(datos[0]=="Reporte"){
                if(datos[1]=="Bloque"){
                    reportePorBloque(datos[2]);
                }else if(datos[1]=="Ruta"){
                    reportePorRuta(datos[2]);
                }
            }

        }
}



/*----------------------------------------------------ENCRIPTACION Y DESENCRIPTACION--------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------*/

char* encriptacion(char *frase, int n){
    int i,j;
        for(i=0;i<strlen(frase);i++){
            for(j=0;j<n;j++){
                if((frase[i]>=65 && frase[i]<90) || (frase[i]>=97 && frase[i]<122)){
                    frase[i]++;
                }
                else if(frase[i]==90)
                    frase[i]=65;
                else if(frase[i]==122)
                    frase[i]=97;
            }
        }
        return frase;
}

char* desencriptacion(char *frase, int n){
    int i,j;

        for(i=0;i<strlen(frase);i++){
            for(j=0;j<n;j++){
                if((frase[i]>65 && frase[i]<=90) || (frase[i]>97 && frase[i]<=122)){
                    frase[i]--;
                }
                else if(frase[i]==65)
                    frase[i]=90;
                else if(frase[i]==97)
                    frase[i]=122;
            }
        }
        return frase;
}


//----------------------------------------------------------Ver Bloque en General-------------------------------------------------
void MainWindow::on_actionGeneral_6_triggered()
{
    struct bloque *aux=primeroBloque;
    QFile file("Lista.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    QTextStream text(&file);
    text<<"digraph G{"<<endl;
    int i=0;
    while(aux!=NULL){
        if(aux!=ultimoBloque){
         long int point = reinterpret_cast<long int>(aux);
         long int point2 = reinterpret_cast<long int>(aux->siguiente);
         text<<point<<"->"<<point2<<";"<<endl;
          text<<point<<"[label= \" "<<"Nombre "<<aux->nombre<<" \n Piloto: "<<aux->piloto->nombre<<"\n Bus: "<<aux->bus->placa<<" \n Fecha: "<<aux->fecha<<"\"];"<<endl;
         }else if(aux==primeroBloque || aux==ultimoBloque){
         long int point = reinterpret_cast<long int>(aux);
         text<<point<<"[label= \" "<<"Nombre "<<aux->nombre<<" \n Piloto: "<<aux->piloto->nombre<<"\n Bus: "<<aux->bus->placa<<" \n Fecha: "<<aux->fecha<<"\"];"<<endl;
        }
         aux=aux->siguiente;
    }
    text<<"}"<<endl;
    file.close();
    system("dot -Tpng Lista.dot -o Lista.png");

    mostrarImagenes("Lista.png");
}


//---------------------------------------------Mostrar el grafo de las ruta y bloques---------------------------------------------
void MainWindow::on_actionAvl_de_Rutas_de_un_Bloque_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre del Bloque"),tr("Bloque:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    struct bloque *aux=buscarBloque(texts);
    if(aux!=NULL){
        texts = QInputDialog::getText(this, tr("Ingrese el nombre de la Ruta"),tr("ruta:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
        struct list_rutas *aux2=buscarRutta(texts,aux);
        if(aux2!=NULL){
            struct rutas* rut=aux2->ruta;
            if(rut!=NULL){
                QFile file("Ruta.dot");
                  file.open(QIODevice::WriteOnly | QIODevice::Truncate);
                  QTextStream text(&file);
                  text<<"digraph G{"<<endl;

                  struct viaje *ida=rut->idaI;
                  struct viaje *vuelta=rut->vueltaI;

                  while(ida!=NULL){
                      if(ida!=rut->idaF){
                          if(ida->esta!=NULL){
                              text<<"ruta"<<ida->nombre<<"->ruta"<<ida->siguiente->nombre<<endl;
                              text<<"ruta"<<ida->nombre<<"[label=\"Nombre: "<<ida->esta->nombre<<"\"];"<<endl;
                          }

                      }else if(ida==rut->idaI || ida==rut->idaF){
                          long int point = reinterpret_cast<long int>(ida);
                          text<<"ruta"<<ida->nombre<<"[label=\"Nombre: "<<ida->esta->nombre<<"\"];"<<endl;
                      }
                      ida=ida->siguiente;
                  }

                  while(vuelta!=NULL){
                      if(vuelta!=rut->vueltaF){
                          if(vuelta->esta!=NULL){
                              text<<"ruta"<<vuelta->nombre<<"->ruta"<<vuelta->siguiente->nombre<<endl;
                               text<<"ruta"<<vuelta->nombre<<"[label=\"Nombre: "<<vuelta->esta->nombre<<"\"];"<<endl;
                          }

                      }else if(vuelta==rut->vueltaI || vuelta==rut->vueltaF){
                          if(vuelta->esta!=NULL){
                               text<<"ruta"<<vuelta->nombre<<"[label=\"Nombre: "<<vuelta->esta->nombre<<"\"];"<<endl;
                          }              }
                      vuelta=vuelta->siguiente;
                  }


                  text<<"}"<<endl;
                  file.close();
                  system("dot -Tpng Ruta.dot -o Ruta.png");
                  mostrarImagenes("Ruta.png");
            }
        }
    }
}

bloque* buscarBloque(QString nombre){
    struct bloque *aux=primeroBloque;
    while(aux!=NULL){
        QString recibido=QString::fromUtf8(aux->nombre);
        if(recibido==nombre)return aux;
        aux=aux->siguiente;
    }
    return NULL;
}
//-------------------------------------------------MOSTRAR LAS RUTAS DE LOS BLOQUES------------------------------------------
void MainWindow::on_actionRutas_de_un_Bloque_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre del Bloque"),tr("Bloque:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    struct bloque *aux=buscarBloque(texts);
    if(aux!=NULL){
        QFile file("Ruta.dot");
          file.open(QIODevice::WriteOnly | QIODevice::Truncate);
          QTextStream text(&file);
          text<<"digraph G{"<<endl;
              struct list_rutas *ruta=aux->primera;
              while(ruta!=NULL){
                  if(ruta!=aux->ultima){
                      long int point = reinterpret_cast<long int>(ruta);
                      long int point2 = reinterpret_cast<long int>(ruta->siguiente);
                      text<<point<<"[label=\"Ruta: "<<ruta->ruta->archivo<<"\"];"<<endl;
                      text<<point<<"->"<<point2<<";"<<endl;
                  }else if(ruta==aux->primera || ruta==aux->ultima){
                      long int point = reinterpret_cast<long int>(ruta);
                      text<<point<<"[label=\"Ruta: "<<ruta->ruta->archivo<<"\"];"<<endl;
                  }
                  ruta=ruta->siguiente;
              }
                text<<"}"<<endl;
                  file.close();
                  system("dot -Tpng Ruta.dot -o Ruta.png");

                  mostrarImagenes("Ruta.png");
    }
}

list_rutas* buscarRutta(QString nombre,bloque* nodo){
    struct list_rutas *ruta=nodo->primera;
    while(ruta!=NULL){
        QString recibido=QString::fromUtf8(ruta->ruta->archivo);
        if(recibido==nombre) return ruta;
        ruta=ruta->siguiente;
    }
    return NULL;
}

//------------------------------------------MOSTRAR AVL DE IDA---------------------------------------
void MainWindow::on_actionid_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre del Bloque"),tr("Bloque:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    struct bloque *aux=buscarBloque(texts);
    if(aux!=NULL){
        texts = QInputDialog::getText(this, tr("Ingrese el nombre de la Ruta"),tr("ruta:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
        struct list_rutas *aux2=buscarRutta(texts,aux);
        if(aux2!=NULL){
            struct rutas* rut=aux2->ruta;
            if(rut!=NULL){
                texts = QInputDialog::getText(this, tr("Ingrese el nombrel Grafo"),tr("Grafo:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
               struct viaje *aux3=buscarGrafo(texts,rut->idaI);
               if(aux3!=NULL){
                   QFile file("Hash.dot");
                       file.open(QIODevice::WriteOnly | QIODevice::Truncate);
                       textarbol=new QTextStream();
                       textarbol->setDevice(&file);
                       *textarbol<<"digraph G{\n"<<endl;
                       if(aux3->raiz!=NULL){
                        graficarArbol2(aux3->raiz);
                       }
                        *textarbol<<"}"<<endl;
                       file.close();
                       system("dot -Tpng Hash.dot -o Hash.png");
                       mostrarImagenes("Hash.png");
                }
            }
        }
    }
}

viaje* buscarGrafo(QString nombre, viaje *aux){
    struct viaje *nodo=aux;
    while(nodo!=NULL){
        QString recibido=QString::fromUtf8(nodo->esta->nombre);
        if(recibido==nombre)return nodo;
        nodo=nodo->siguiente;
    }
    return NULL;
}

void graficarArbol2(arbolRuta *un_arbol){
    if(un_arbol == NULL){
           return;
       }
       *textarbol<<un_arbol->dato<<";"<<endl;
       if(un_arbol->izquierdo!=NULL) *textarbol<<un_arbol->dato<<"->"<<un_arbol->izquierdo->dato<<";"<<endl;
       if(un_arbol->derecho!=NULL) *textarbol<<un_arbol->dato<<"->"<<un_arbol->derecho->dato<<";"<<endl;
       struct arbolRuta *aux2=un_arbol;

       *textarbol<<un_arbol->dato<<"[label=\"Nombre : "<<un_arbol->usuario->nombre<<"\\n DPI:"<<un_arbol->usuario->dpi<<"\\n Edad:"<<un_arbol->usuario->edad<<" \"];"<<endl;
       graficarArbol2(un_arbol->izquierdo);
       graficarArbol2(un_arbol->derecho);
}

//-----------------------------------GRAFICAR VUELTA------------------------------
void MainWindow::on_actionvuelta_triggered()
{
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el nombre del Bloque"),tr("Bloque:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    struct bloque *aux=buscarBloque(texts);
    if(aux!=NULL){
        texts = QInputDialog::getText(this, tr("Ingrese el nombre de la Ruta"),tr("ruta:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
        struct list_rutas *aux2=buscarRutta(texts,aux);
        if(aux2!=NULL){
            struct rutas* rut=aux2->ruta;
            if(rut!=NULL){
                texts = QInputDialog::getText(this, tr("Ingrese el nombrel Grafo"),tr("Grafo:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
               struct viaje *aux3=buscarGrafo(texts,rut->vueltaI);
               if(aux3!=NULL){
                   QFile file("Hash.dot");
                       file.open(QIODevice::WriteOnly | QIODevice::Truncate);
                       textarbol=new QTextStream();
                       textarbol->setDevice(&file);
                       *textarbol<<"digraph G{\n"<<endl;
                       if(aux3->raiz!=NULL){
                        graficarArbol2(aux3->raiz);
                       }
                        *textarbol<<"}"<<endl;
                       file.close();
                       system("dot -Tpng Hash.dot -o Hash.png");
                       mostrarImagenes("Hash.png");
                }
            }
        }
    }
}

void MainWindow::on_actionReporte_por_Bloque_triggered()
{

}

//--------------------------------------Graficar Reporte por BLoque indivual
void MainWindow::on_actionIndividual_4_triggered()
{
    int pos;
    bool ok;
    QString texts = QInputDialog::getText(this, tr("Ingrese el dpi del Usuario"),tr("DPI:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
    root=reporteBloque;
    struct  usuarios *aux=buscarB(texts.toInt(),&pos,root);
    if(aux!=NULL){
        QFile file("ArbolB.dot");
        file.open(QIODevice::WriteOnly | QIODevice::Truncate);
        QTextStream text(&file);
        text<<"digraph G{"<<endl;
        long int point = reinterpret_cast<long int>(aux);
         text<<point<<"[label= \" Usuario "<<aux->nombre<<"\n DPI:"<<aux->dpi<<"\n Edad: "<<aux->edad<< "\"];"<<endl;
        text<<"}"<<endl;
        file.close();
        system("dot -Tpng ArbolB.dot -o ArbolB.png");
        mostrarImagenes("ArbolB.png");
    }else{
        QMessageBox ex;
        ex.setText("Usuario NO encontrado");
        ex.exec();
    }
}

//------------------------------------------MOSTRAR GRAFICA GENERAL DE REPROTE BLOQUE
void MainWindow::on_actionGeneral_7_triggered()
{
    QFile file("ArbolB.dot");
        file.open(QIODevice::WriteOnly | QIODevice::Truncate);
        textarbol=new QTextStream();
        textarbol->setDevice(&file);
        *textarbol<<"digraph G{\n"<<endl;
        if(reporteBloque!=NULL){
            root=reporteBloque;
            inOrdenArbolB(root);
            root=NULL;
        }
         *textarbol<<"}"<<endl;
        file.close();
        system("dot -Tpng ArbolB.dot -o ArbolB.png");
        mostrarImagenes("ArbolB.png");
}

//-------------------------------------------CREAR REPORTE POR RUTA-------------------------------------------
void MainWindow::on_actionPor_Ruta_triggered()
{
    bool ok;
    QString nomb = QInputDialog::getText(this, tr("Ingrese el Nombre de la Ruta"),tr("Nombre:"), QLineEdit::Normal,QDir::home().dirName(), &ok);
        QFile file("Bitacora.201612118-log");
        file.open(QFile::WriteOnly|QFile::Append);
        textarbol=new QTextStream();
        textarbol->setDevice(&file);
        QString direcciones="Reporte:Ruta:"+nomb+":";
        QByteArray ba=direcciones.toLatin1();
        QString obtenido=encriptacion(ba.data(),10);
        *textarbol<<obtenido;
        reportePorRuta(nomb);
        *textarbol<<"fin\n"<<endl;
        file.close();
        textarbol=NULL;
}

void reportePorRuta(QString nombre){
    //------------------------------------------BUSCAR EL BLOQUE---------------------------------------------------
    reporteRuta=NULL;
    root=reporteRuta;
    struct bloque *aux=primeroBloque;
    while(aux!=NULL){
        //-----------------------------------------BUSCAR LA LISTA DE RUTAS----------------------------------------
        struct list_rutas *lista=aux->primera;
            //-------------------------------------BUSCAR LA RUTA-------------------------------------------------
            while(lista!=NULL){
                struct rutas *rut=lista->ruta;
                QString recibido=QString::fromUtf8(rut->archivo);
                qDebug()<<recibido;
                if(recibido==nombre){
                    //-------------------------------------BUSCAR LOS GRAFOS-----------------------------------------
                    struct viaje *ida=rut->idaI;
                    struct viaje *vuelta=rut->vueltaI;

                    //------------------------GRAFO DE IDA-------------------------------------------

                    while(ida!=NULL){
                        un_arbol2=ida->raiz;
                        inOrden2(un_arbol2);
                        un_arbol2=NULL;
                        ida=ida->siguiente;
                    }

                    //------------------------GRAFO DE VUELTA------------------------------------------------
                    while(vuelta!=NULL){
                        un_arbol2=vuelta->raiz;
                        inOrden2(un_arbol2);
                        un_arbol2=NULL;
                        vuelta=vuelta->siguiente;
                    }

                }
            lista=lista->siguiente;
        }
    aux=aux->siguiente;
    }
    reporteRuta=root;
    root=NULL;
}

//-------------------------------------------------GRAFICAR GENERAL DEL REPORTE RUTA-----------------------
void MainWindow::on_actionGeneral_8_triggered()
{
    QFile file("ArbolB.dot");
        file.open(QIODevice::WriteOnly | QIODevice::Truncate);
        textarbol=new QTextStream();
        textarbol->setDevice(&file);
        *textarbol<<"digraph G{\n"<<endl;
        if(reporteRuta!=NULL){
            root=reporteRuta;
            inOrdenArbolB(root);
            root=NULL;
        }
         *textarbol<<"}"<<endl;
        file.close();
        system("dot -Tpng ArbolB.dot -o ArbolB.png");
        mostrarImagenes("ArbolB.png");
}

//------------------------------EN CARGADO DE GENERAR REPORTE TXT DE LOS REPORTES-----------------------------------
void MainWindow::on_actionReportes_triggered()
{

    QFile file("Bitacora.txt");
    file.open(QFile::WriteOnly|QFile::Truncate);
    QTextStream text(&file);


    QFile inputFile("Bitacora.201612118-log");
    inputFile.open(QIODevice::ReadOnly);
        QTextStream in(&inputFile);
        while(!in.atEnd()){
            QString line=in.readLine();
            QByteArray ba=line.toLatin1();
            QString obtenido=desencriptacion(ba.data(),10);
            QStringList datos=obtenido.split(":");
            if(datos[0]=="Reporte"){
                text<<obtenido<<endl;
            }
        }

        file.close();

}
