#include "mainwindow.h"
#include "auxiliar.h"
#include "ui_mainwindow.h"
#include <QFileDialog>
#include <QFileInfo>
#include <QTextStream>
#include <QDate>
#include <QTime>
#include <QDir>
#include <QMessageBox>
#include <QInputDialog>
#include <QJsonDocument>
#include <QJsonObject>

#define DERECHA 1
#define IZQUIERDA 0
#define TRUE 1
#define FALSE 0

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    servidor=new QTcpServer(this);
    connect(servidor,SIGNAL(newConnection()),this,SLOT(nuevaConexion()));
    if(!servidor->listen(QHostAddress::Any,1234)){
        qDebug()<<"Servidor no pudo iniciar";
    }else{
        qDebug()<<"Servidor empezo correctamente";
    }

}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::nuevaConexion(){
    socket=servidor->nextPendingConnection();
    connect(socket,SIGNAL(disconnected()),this,SLOT(on_disconnect()));
    connect(socket,SIGNAL(readyRead()),SLOT(readyRead()));
}

void MainWindow::on_disconnect(){
    disconnect(socket, SIGNAL(disconnected()));
    disconnect(socket, SIGNAL(readyRead()));
    socket->deleteLater();
}

//--------------------------------------------------Devuelve el arbol--------------------------------------------------------------
void MainWindow::readyRead(){
    QString message=socket->readAll();
    QJsonDocument jsonResponse=QJsonDocument::fromJson(message.toUtf8());
    QJsonObject jsonObject=jsonResponse.object();
    int opcion=jsonObject["tipo-operacion"].toInt();
    if(opcion==0){
        QMessageBox ex;
        ex.setText("Conectado....");
        ex.exec();
    }else if(opcion==2){
        QString names=jsonObject["nombre"].toString();
        QMessageBox:: StandardButton reply;
        reply=QMessageBox::question(this,"Seleccione una opcion","Desea devoler un arbol",QMessageBox::Yes|QMessageBox::No);
        message=message.simplified();
        message.replace(" ","");
        if(reply==QMessageBox::Yes){
            struct arbol *res=buscarArbol(names);
            struct arbol *auxs=res;
            textos="";
            Json="{\n\"tipo-operacion\":2,\n\"nombre\":\""+names+"\",\n\"llave-unica\":\"<";

            QString resllave=llaveUnica(auxs);
            resllave=resllave.remove(0,2);
            Json+=resllave;

            Json+=">\",\n\"pre-orden\":[\n";
            auxs=res;
            preOrdenJson(auxs);
            Json+="],";

            auxs=res;
            postO="";
            Json+="\n\"post-orden\":[\n";
            postOrdenJson(auxs);
            postO=postO.remove(0,2);
            Json+=postO;
            Json+="],";

            auxs=res;
            inO="";
            Json+="\n\"in-orden\":[\n";
            inOrdenJson(auxs);
            inO=inO.remove(0,2);
            Json+=inO;
            Json+="]\n}";
            ui->consola->setText(Json);
            socket->write(Json.toUtf8().constData());
            socket->close();
        }else{
            socket->write("Error");
            socket->close();
        }
    }

}


void MainWindow::on_actionCargar_Archivos_triggered()
{
    QStringList filenames = QFileDialog::getOpenFileNames(this,tr("EDD files"),QDir::currentPath(),tr("EDD files (*.edd-b);;All files (*.*)") );
    if( !filenames.isEmpty() )
    {
        QMessageBox msgBox;
        QDate cd=QDate::currentDate();
        QTime ct=QTime::currentTime();
        QString fecha=cd.toString();
        QString hora=ct.toString();

        for (int i =0;i<filenames.length();i++){
            QString name=QFileInfo(filenames[i]).fileName();
            QString namewithout=name.section(".", 0,0);

            QByteArray ba=namewithout.toLatin1();
            QByteArray array2=fecha.toLatin1();
            QByteArray array3=hora.toLatin1();

            agregarLista(ba.data(),array2.data(),array3.data(),filenames[i]);

        }
        agregarSeleccionado();
        mostrarLista();
    }

}

/*-------------------------------------------------------------lista doblemente enlazada
---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------*/

void agregarLista( char *nombre,char* fecha,char *hora,QString direccion){
    struct lista *nodo=(struct lista*)malloc(sizeof(struct lista));

    nodo->nombre=(char*)malloc(strlen(nombre)+1);
    nodo->fecha=(char*)malloc(strlen(fecha)+1);
    nodo->hora=(char*)malloc(strlen(hora)+1);

    strcpy(nodo->nombre,nombre);
   strcpy(nodo->fecha,fecha);
    strcpy(nodo->hora,hora);

    un_arbol=NULL;
    recorrerArchivo(direccion);
    nodo->arbolavl=un_arbol;
    if(primeroli==NULL){
        nodo->id=0;
        nodo->siguiente=NULL;
        nodo->anterior=NULL;
        primeroli=ultimoli=nodo;
    }else{
        nodo->id=ultimoli->id+1;
        ultimoli->siguiente=nodo;
        nodo->anterior=ultimoli;
        nodo->siguiente=NULL;
        ultimoli=nodo;
    }
}


void recorrerArchivo(QString direccion){
    QFile inputFile(direccion);
    inputFile.open(QIODevice::ReadOnly);
        QTextStream in(&inputFile);
        int cabecera=0;
        while(!in.atEnd()){
            if(cabecera!=0){
                QString line=in.readLine();
                QStringList datos=line.split(",");

                QString carnet_=datos.at(0);
                QString nomb=datos.at(1);
                QString nota=datos.at(2);

                 QByteArray ba=nomb.toLatin1();
                  QByteArray ba2=nota.toLatin1();

                int carnet=carnet_.toInt();
                if(carnet!=0) insertar(&un_arbol,carnet,ba.data(),ba2.data());
            }
            cabecera++;
        }

}


void MainWindow::mostrarLista(){
    struct lista *aux=primeroli;
    QFile file("Lista.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    QTextStream text(&file);
    text<<"digraph G{"<<endl;
    text<<"subgraph cluster{"<<endl;
    text<<"label =\" Arboles en memoria \";"<<endl;
    while(aux!=NULL){
        if(aux!=ultimoli){
                           long int point = reinterpret_cast<long int>(aux);
                           long int point2 = reinterpret_cast<long int>(aux->siguiente);
                          text<<point<<"->"<<point2<<";"<<endl;
                          if(aux->id==seleccionado){
                              text<<point<<"[label= <<TABLE><TR><TD><IMG SRC=\"checked.png\"/></TD><TD>";
                          }else{
                              text<<point<<"[label= <<TABLE><TR><TD>";
                          }
                           text<<"Id: "<<aux->id<<" <br/> Nombre: "<<aux->nombre<<" <br/>Fecha: "<<aux->fecha<<" <br/> Hora: "<<aux->hora<<"</TD></TR></TABLE>>]"<<endl;
                           text<<point2<<"->"<<point<<";"<<endl;
                       }else if(aux==primeroli || aux==ultimoli){
                           long int point = reinterpret_cast<long int>(aux);
                           if(aux->id==seleccionado){
                               text<<point<<"[label= <<TABLE><TR><TD><IMG SRC=\"checked.png\"/></TD><TD>";
                           }else{
                               text<<point<<"[label= <<TABLE><TR><TD>";
                           }
                           text<<"Id: "<<aux->id<<" <br/> Nombre: "<<aux->nombre<<" <br/>Fecha: "<<aux->fecha<<" <br/> Hora: "<<aux->hora<<"</TD></TR></TABLE>>]"<<endl;
                       }
                aux=aux->siguiente;
    }
    text<<"}"<<endl;
    text<<"}"<<endl;
    file.close();
    system("dot -Tpng Lista.dot -o Lista.png");
    QPixmap  pix("Lista.png");
              ui->listarboles->setParent(this);
              ui->listarboles->setPixmap(pix);
              ui->scrollArea->setWidget(ui->listarboles);
              ui->listarboles->setParent(ui->scrollArea);
              ui->listarboles->show();
}

void MainWindow::agregarSeleccionado(){
    lista *aux=primeroli;
    int contador=0;
    while(aux!=NULL){
        contador++;
        aux=aux->siguiente;
    }

    for(int i=0;i<contador;i++){
        ui->comboBox_2->addItem(QString::number(i));
    }
}


/*-------------------------------------------------------------ARBOL AVL
---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------*/
//-------------------------------------------------------------ARBOL AVL---------------------------------------------------------
int insertar(struct arbol **un_arbol, int dato,char *nombre,char *nota){
    if(*un_arbol == NULL){
        *un_arbol = (struct arbol *)malloc(sizeof(struct arbol));
        if(*un_arbol == NULL){
            return 0;
        }

        (*un_arbol)->dato = dato;
        (*un_arbol)->nombre=(char*)malloc(strlen(nombre)+1);
        strcpy((*un_arbol)->nombre,nombre);
        (*un_arbol)->nota=(char*)malloc(strlen(nota)+1);
        strcpy((*un_arbol)->nota,nota);
        (*un_arbol)->izquierdo = NULL;
        (*un_arbol)->derecho = NULL;
    }
    else{
        if((*un_arbol)->dato < dato){
            insertar(&((*un_arbol)->derecho), dato,nombre,nota);
        }
        else{
            insertar(&((*un_arbol)->izquierdo), dato,nombre,nota);
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

//------------------------------------------------POR AMPLITUD-----------------------------------------------
void inicializacionCola(cola &q){
    q.delante=NULL;
    q.atras=NULL;
}

void encola(cola &q, arbol *n){
    struct nodoCola *p=(struct nodoCola*)malloc(sizeof(struct nodoCola));
    p->ptr=n;
    p->sgte=NULL;
    if(q.delante==NULL) q.delante=p;
    else (q.atras)->sgte=p;
    q.atras=p;
}

arbol* desencola(cola &q){
    struct nodoCola *p;
    p=q.delante;
    arbol *n=p->ptr;
    q.delante=(q.delante)->sgte;
    delete(p);
    return n;
}

void anchura(arbol *un_arbol){
    struct cola q;
    inicializacionCola(q);
    if(un_arbol!=NULL){
        encola(q,un_arbol);
        while(q.delante!=NULL){
            un_arbol=desencola(q);
            QString carnet=QString::number(un_arbol->dato);
            textos=textos+","+carnet;
            if(un_arbol->izquierdo!=NULL) encola(q,un_arbol->izquierdo);
            if(un_arbol->derecho!=NULL) encola(q,un_arbol->derecho);
        }
    }

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
        (*aux_arbol)->nota=(*un_arbol)->nota;
        *un_arbol = (*un_arbol)->izquierdo;
    }else
        reordenar(&(*un_arbol)->derecho, aux_arbol);
    return 1;
}


//-------------------------------------------------GRAFICA EL ARBOL--------------------------------------------------------------
void MainWindow::on_comboBox_2_currentIndexChanged(const QString &arg1)
{
    seleccionado=arg1.toInt();
    lista *aux=primeroli;
    for(int i=0;i<seleccionado;i++){
        aux=aux->siguiente;
    }
    un_arbol=aux->arbolavl;
    mostrarLista();

    //-------------------------------------------------------Agregar Datos---------------------------------
    QString nom=QString::fromUtf8(aux->nombre);
    ui->nombrearbol->setText(nom);

    QString altu=QString::number(altura_arbolavl(un_arbol));
    ui->alturaarbol->setText(altu);

    un_arbol=aux->arbolavl;
    QString nivel=QString::number(altura_arbolavl(un_arbol)-1);
    ui->nivelarbol->setText(nivel);

    un_arbol=aux->arbolavl;
    QString hoja=QString::number(esHoja(un_arbol));
    ui->hojaarbol->setText(hoja);

    un_arbol=aux->arbolavl;
    QString padr=QString::number(esPadre(un_arbol));
    ui->padrearbol->setText(padr);

    un_arbol=aux->arbolavl;
    QString ram=QString::number(esRama(un_arbol));
    ui->ramasarbol->setText(ram);

    //-----------------------Graficar Arbol-----------------------------------------------------
    QFile file("Arbol.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    textarbol=new QTextStream();
    textarbol->setDevice(&file);
    *textarbol<<"digraph G{"<<endl;
    *textarbol<<"subgraph cluster{"<<endl;
    textos="";
    //mostrar(un_arbol);
    auxx=aux->arbolavl;
    un_arbol=aux->arbolavl;
    graficarArbol(un_arbol);
    *textarbol<<"}"<<endl;
    *textarbol<<"}"<<endl;
    file.close();
    system("dot -Tpng Arbol.dot -o Arbol.png");


    QPixmap  pix("Arbol.png");
              ui->arbolmostrar->setParent(this);
              ui->arbolmostrar->setPixmap(pix);
              ui->scrollArea2->setWidget(ui->arbolmostrar);
              ui->arbolmostrar->setParent(ui->scrollArea2);
              ui->arbolmostrar->show();
    //-----------------para un proximo analisis---------------
     cantHojas=0;
     cantPadres=0;
     cantRamas=0;
     nodoNivel=0;
}

void graficarArbol(arbol *un_arbol){
    if(un_arbol == NULL){
           return;
       }
       *textarbol<<un_arbol->dato<<";"<<endl;
       if(un_arbol->izquierdo!=NULL) *textarbol<<un_arbol->dato<<"->"<<un_arbol->izquierdo->dato<<";"<<endl;
       if(un_arbol->derecho!=NULL) *textarbol<<un_arbol->dato<<"->"<<un_arbol->derecho->dato<<";"<<endl;
       struct arbol *aux2=un_arbol;

       *textarbol<<un_arbol->dato<<"[label=\"Carnet : "<<un_arbol->dato<<"\\n FE:"<<balanceo(aux2)<<"\\n Nivel:"<<nivel_Nodo(auxx,aux2->dato)<<" \"];"<<endl;
       graficarArbol(un_arbol->izquierdo);
       graficarArbol(un_arbol->derecho);
}

int esHoja(arbol *un_arbol){
    if(un_arbol == NULL){
           return cantHojas;
       }
if(!un_arbol->derecho && !un_arbol->izquierdo) cantHojas++;
    esHoja(un_arbol->izquierdo);
    esHoja(un_arbol->derecho);
}


int esPadre(arbol *un_arbol){
    if(un_arbol == NULL){
           return cantPadres;
       }
if(un_arbol->derecho && un_arbol->izquierdo) cantPadres++;
    esPadre(un_arbol->izquierdo);
    esPadre(un_arbol->derecho);
}



int esRama(arbol *un_arbol){
    if(un_arbol == NULL){
           return cantRamas;
       }
if(un_arbol->derecho) cantRamas++;
if(un_arbol->izquierdo) cantRamas++;
    esRama(un_arbol->izquierdo);
    esRama(un_arbol->derecho);
}


int nivel_Nodo(arbol *arbol_, int carnet){
 int altura=0;
 arbol *aux3=arbol_;
 while(aux3!=NULL){
     if(carnet==aux3->dato){
         return altura;
     }else{
         altura++;
         if(carnet<aux3->dato) aux3=aux3->izquierdo;
         else if(carnet>aux3->dato) aux3=aux3->derecho;
     }
 }
 return -1;
}

void MainWindow::on_actionPost_Orden_triggered()
{
    textos="";
    postOrden(auxx);
    ui->consola->setText("Post Orden: "+textos);
}

void MainWindow::on_actionPre_Orden_triggered()
{
    textos="";
    mostrar(auxx);
    ui->consola->setText("Pre Orden: "+textos);
}

void MainWindow::on_actionIn_Orden_triggered()
{
    textos="";
    inOrden(auxx);
    ui->consola->setText("In Orden: "+textos);
}

void MainWindow::on_actionAmplitud_triggered()
{
    textos="";
    anchura(auxx);
    ui->consola->setText("Anchura: "+textos);
}


//----------------------------------------------------------BUSCAR EL NODO-------------------------------------------------
void MainWindow::on_pushButton_4_clicked()
{
    int carnet=ui->claveBuscar->text().toInt();
    un_arbol=auxx;
    struct arbol *regreso=buscar(un_arbol,carnet);
    if(regreso!=NULL){
        QString nom=QString::fromUtf8(regreso->nombre);
        ui->nombreeditar->setText(nom);

        ui->notaeditar->setText(regreso->nota);
    }else{
        QMessageBox error;
        error.setText("No se encontro el carnet");
        error.exec();
    }
}

//------------------------------------------------------------Generar Sub Arbol-------------------------------------------------
void MainWindow::on_pushButton_clicked()
{


}


void graficarSubArbol(arbol *un_arbol){
    if(un_arbol == NULL){
           return;
       }
       *textsub<<un_arbol->dato<<";"<<endl;
       if(un_arbol->izquierdo!=NULL) *textsub<<un_arbol->dato<<"->"<<un_arbol->izquierdo->dato<<";"<<endl;
       if(un_arbol->derecho!=NULL) *textsub<<un_arbol->dato<<"->"<<un_arbol->derecho->dato<<";"<<endl;
       struct arbol *aux2=un_arbol;

       *textsub<<un_arbol->dato<<"[label=\"Carnet : "<<un_arbol->dato<<"\\n FE:"<<balanceo(aux2)<<"\\n Nivel:"<<nivel_Nodo(auxx,aux2->dato)<<" \"];"<<endl;
       graficarSubArbol(un_arbol->izquierdo);
       graficarSubArbol(un_arbol->derecho);
}


void MainWindow::on_subarbolbutton_clicked()
{
    QFile file("SubArbol.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    textsub=new QTextStream();
    textsub->setDevice(&file);
    int carnet=ui->claveBuscar->text().toInt();
    un_arbol=auxx;
    struct arbol *regreso=buscar(un_arbol,carnet);
    *textsub<<"digraph G{"<<endl;
    *textsub<<"subgraph cluster{"<<endl;
    graficarSubArbol(regreso);
    *textsub<<"}"<<endl;
    *textsub<<"}"<<endl;
    file.close();
    system("dot -Tpng SubArbol.dot -o SubArbol.png");
    system("eog SubArbol.png");
}

//------------------------------------------------------EDITAR--------------------------------------
void MainWindow::on_pushButton_2_clicked()
{

    int carnet=ui->claveBuscar->text().toInt();
    QString nomb=ui->nombreeditar->text();
    QString nota=ui->notaeditar->text();

     QByteArray ba=nomb.toLatin1();
      QByteArray ba2=nota.toLatin1();
      un_arbol=auxx;
      editar(un_arbol,carnet,ba.data(),ba2.data());
}

void editar(struct arbol *un_arbol,int dato, char *nom, char *nota){
    if(un_arbol == NULL){
        return ;
    }
    if(un_arbol->dato == dato){
        un_arbol->nombre=(char*)malloc(strlen(nom)+1);
        strcpy(un_arbol->nombre,nom);
        un_arbol->nota=(char*)malloc(strlen(nota)+1);
        strcpy(un_arbol->nota,nota);
    }

    if(un_arbol->dato < dato){
        return editar(un_arbol->derecho, dato,nom,nota);
    }
    else{
        return editar(un_arbol->izquierdo, dato,nom,nota);
    }
}
//--------------------------------------------Eliminar------------------------------------------
void MainWindow::on_pushButton_3_clicked()
{
    int carnet=ui->claveBuscar->text().toInt();
    un_arbol=auxx;
    eliminar(&un_arbol,carnet);
    on_comboBox_2_currentIndexChanged(QString::number(seleccionado));
}


//--------------------------------------------Crear Bloque----------------------------------------
void MainWindow::on_actionCrear_Bloque_triggered()
{
     bool ok;
    QString text = QInputDialog::getText(this, tr("Ingrese el nombre del arbol"),
                                            tr("Arbol:"), QLineEdit::Normal,
                                            QDir::home().dirName(), &ok);

    struct arbol *res=buscarArbol(text);
    struct arbol *auxs=res;
    textos="";
    Json="{\n\"tipo-operacion\":1,\n\"nombre\":\""+text+"\",\n\"llave-unica\":\"<";

    QString resllave=llaveUnica(auxs);
    resllave=resllave.remove(0,2);
    Json+=resllave;

    Json+=">\",\n\"pre-orden\":[\n";
    auxs=res;
    preOrdenJson(auxs);
    Json+="],";

    auxs=res;
    postO="";
    Json+="\n\"post-orden\":[\n";
    postOrdenJson(auxs);
    postO=postO.remove(0,2);
    Json+=postO;
    Json+="],";

    auxs=res;
    inO="";
    Json+="\n\"in-orden\":[\n";
    inOrdenJson(auxs);
    inO=inO.remove(0,2);
    Json+=inO;
    Json+="]\n}";
    ui->consola->setText(Json);
    socket->write(Json.toUtf8().constData());
    socket->close();

    QMessageBox ex;
    ex.setText("Arbol enviado correctamente");
    ex.exec();




}

//-------------------------------------------------llave unica--------------------------------------------
QString llaveUnica(arbol *un_arbol){
    if(un_arbol == NULL){
        return "";
    }
    QString carnet=QString::number(un_arbol->dato);
    QString punteo=un_arbol->nota;
    QString nombre=QString::fromUtf8(un_arbol->nombre);
    llaveUnica(un_arbol->izquierdo);
    llave=llave+"&&"+carnet+","+nombre+","+punteo;
    llaveUnica(un_arbol->derecho);
    return llave;
}

void preOrdenJson(arbol *un_arbol){
    if(un_arbol == NULL){
        return;
    }
    QString carnet=QString::number(un_arbol->dato);
    QString punteo=un_arbol->nota;
    QString nombre=QString::fromUtf8(un_arbol->nombre);
    if(un_arbol==bloque) Json=Json+"{\"carnet\":"+carnet+",\"Nombre\":\""+nombre+"\",\"Nota\":"+punteo+"}";
    else Json=Json+",\n"+"{\"carnet\":"+carnet+",\"Nombre\":\""+nombre+"\",\"Nota\":"+punteo+"}";
    preOrdenJson(un_arbol->izquierdo);
    preOrdenJson(un_arbol->derecho);
}

void postOrdenJson(arbol *un_arbol){
    if(un_arbol == NULL){
        return;
    }
    QString carnet=QString::number(un_arbol->dato);
    QString punteo=un_arbol->nota;
    QString nombre=QString::fromUtf8(un_arbol->nombre);
    postOrdenJson(un_arbol->izquierdo);
    postOrdenJson(un_arbol->derecho);
    postO=postO+",\n"+"{\"carnet\":"+carnet+",\"Nombre\":\""+nombre+"\",\"Nota\":"+punteo+"}";
}

void inOrdenJson(arbol *un_arbol){
    if(un_arbol == NULL){
        return;
    }
    QString carnet=QString::number(un_arbol->dato);
    QString punteo=un_arbol->nota;
    QString nombre=QString::fromUtf8(un_arbol->nombre);
    inOrdenJson(un_arbol->izquierdo);
    inO=inO+",\n"+"{\"carnet\":"+carnet+",\"Nombre\":\""+nombre+"\",\"Nota\":"+punteo+"}";
    inOrdenJson(un_arbol->derecho);
}


//----------------------------------------------buscar arbol---------------------------------------------
arbol* buscarArbol(QString buscar){
    struct lista *aux=primeroli;
    bool encontrado=true;
    while(encontrado){
        if(aux!=NULL){
            QString nom=QString::fromUtf8(aux->nombre);
            if(nom==buscar) encontrado=false;
            else aux=aux->siguiente;
        }else{
            encontrado=false;
        }
    }
    bloque=aux->arbolavl;
    return aux->arbolavl;
}

void MainWindow::on_actionManual_de_Usuario_triggered()
{

}

void MainWindow::on_actionAcerca_de_triggered()
{
    QMessageBox ex;
    ex.setText("CARLOS HERNANDEZ \n 201612118 \n ESTRUCTURAS DE DATOS \n SECCION B");
    ex.exec();
}
