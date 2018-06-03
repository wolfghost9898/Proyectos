#include "mythread.h"
#include "gen-cpp/Proyecto1.h"
#include "startenemigos.h"
#include "QObject"
#include "QFile"
#include "QTextStream"
#include "QMessageBox"

#include <thrift/protocol/TBinaryProtocol.h>
#include <thrift/server/TSimpleServer.h>
#include <thrift/transport/TServerSocket.h>
#include <thrift/transport/TBufferTransports.h>

using namespace ::apache::thrift;
using namespace ::apache::thrift::protocol;
using namespace ::apache::thrift::transport;
using namespace ::apache::thrift::server;

using boost::shared_ptr;
using namespace  ::proyecto1;

int num_nivel;
int num_usuario;

 struct _listapunta *primerolista;
 struct _listapunta *ultimolista;



class Proyecto1Handler : virtual public Proyecto1If {
 public:
  Proyecto1Handler() {
  }
  startEnemigos *nivel=new startEnemigos();
//---------------------------------------ver si se puede jugar en el nivel-----------------------------
  bool accesoNivel(const int32_t num1) {
      struct _nivel *auxiliar=primeronivel;
      for(int i=0;i<num1;i++){
          if(primeronivel!=NULL){
            auxiliar=auxiliar->siguiente;
          }
      }
      if(primeronivel!=NULL){
          if(auxiliar->estado==1){
            num_nivel=num1;
            return true;
          }else{

              return false;
          }
      }else{

          return false;
      }

  }
//--------------------------------------------------------hilo de generar enemigos--------------------------------
  void generadorEnemigos(){
    nivel->worker->abort();
    nivel->thread->wait();
    nivel->worker->requestWork();

    nivel->workertimer->abort();
    nivel->threadtimer->wait();
    nivel->workertimer->requestWork();

    nivel->workerenemigos->abort();
    nivel->threadmover->wait();
    nivel->workerenemigos->requestWork();
  }
//-----------------------------------------------------------parar todos los hilos-------------------------------------
  void pararGeneradorEnemigos() {
    nivel->worker->abort();
    nivel->thread->wait();

    nivel->workertimer->abort();
    nivel->threadtimer->wait();

    nivel->workerenemigos->abort();
    nivel->threadmover->wait();
  }

  //-----------------------------------------------Obtener el tamaño estatico de la matriz--------------------------------
  int32_t obtenerTamanio() {
    return primeronivel->tamano;
   }

  //-----------------------------------------------Mover Jugador por la matriz-------------------------------------------
   int32_t moverJugador(const int32_t num1, const int32_t num2, const int32_t num3, const int32_t errores) {
       struct _nivel *nivel=primeronivel;
       bool estado=false;
       bool ciclo=true;
       FrontEnd *frontend=front;
       for(int i=0;i<num_nivel;i++){
           nivel=nivel->siguiente;
       }

       struct _cabeceracoluma *temp=nivel->primerocolumna;
       struct _matriz *posx=NULL;
       //--------------------------------------------------movernos en x---------------------------------
       while(ciclo){
           if(temp!=NULL){
               if(temp->numero==num1){
                   posx=temp->primeromatriz;
                   while(ciclo){
                       if(posx!=NULL){
                               if(posx->y==num2){
                                   estado=true;
                                   ciclo=false;
                               }else{
                                   posx=posx->siguiente;
                               }
                       }else{
                           estado=false;
                           ciclo=false;
                       }


                   }
               }else{
                   temp=temp->siguiente;
               }
           }else{
               estado=false;
               ciclo=false;
           }
       }

       //-------------------------------------------------tipo de enemigo--------------------------------
       if(estado==true && posx->primerenemigo!=NULL){
           QFile file("Consola.txt");
           file.open(QFile::WriteOnly|QFile::Append);
           QTextStream text(&file);
           text<<"Mensaje de 201612118: Ataque";
           text<<" en las posiciones x"<<num1<<" y"<<num2<<endl;
           struct _pilaEnemigos *enemigo=posx->primerenemigo;
           if(enemigo->id==0){
               if(enemigo->vida-1==0){
                   if(enemigo->tipo==0){
                        text<<"Mensaje de 201612118: Puntos: +10"<<endl;
                        posx->primerenemigo=enemigo->siguiente;
                        free(enemigo);
                        frontend->cambiarPuntaje(10);
                        agregarDeleteEnemigo(0,num_usuario,0);
                        return 10;
                   }else if(enemigo->tipo==1){
                        text<<"Mensaje de 201612118: Puntos: +20"<<endl;
                        posx->primerenemigo=enemigo->siguiente;
                        free(enemigo);
                        frontend->cambiarPuntaje(20);
                        agregarDeleteEnemigo(1,num_usuario,1);
                        return 20;
                   }else{
                        text<<"Mensaje de 201612118: Puntos: +40"<<endl;
                        posx->primerenemigo=enemigo->siguiente;
                        free(enemigo);
                        frontend->cambiarPuntaje(40);
                        agregarDeleteEnemigo(2,num_usuario,2);
                        return 40;
                   }


               }else{
                    enemigo->vida=enemigo->vida-1;
                    text<<"Mensaje de 201612118: Le queda al enemigo "<<enemigo->vida<<" vidas"<<endl;
                    return 1;
               }
           }
           file.close();

       }else{
           QFile file("Consola.txt");
           file.open(QFile::WriteOnly|QFile::Append);
           QTextStream text(&file);
           text<<"Mensaje de 201612118: Ataque Fallido";
           text<<" en las posiciones x"<<num1<<" y"<<num2<<endl;
           file.close();
           if(errores==4){
               frontend->cambiarPuntaje(-100);
               text<<"Mensaje de 201612118: Puntos: -100"<<endl;
           }else{
           }
           return -100;
       }
   }

   //----------------------------------------------------obtener nivel en el que estamos------------------------------
   int32_t obtenerNivel() {
     return num_nivel;
   }
//-----------------------------------------------------Guarda el Usuario-------------------------
   void guardarUsuario(const std::string& nombre) {
    const char* name=nombre.c_str();
    points->agregarUsuario();
  }
//--------------------------------------Regresa un usuario------------------------------------------
   void regresarUsuario(std::string& _return, const int32_t numero) {
    struct _users *temp=primerouser;
    for(int i=0;i<numero;i++){
        if(temp->siguiente!=NULL){
            temp=temp->siguiente;
        }
    }
    std::string var=std::to_string(temp->id);
    _return =var;
   }


   void setUsuario(const int32_t numero) {
    num_usuario=numero;
   }

   int32_t obtenerUsuario() {
        return num_usuario;
   }

  //------------------------------------Desbloquear Nivel-------------------------------------------
   void desbloquearNivel(const int32_t numero) {
     struct _nivel *temp=primeronivel;
     for(int i=0;i<numero;i++){
         temp=temp->siguiente;
     }
     temp->siguiente->estado=1;
   }


  //------------------------------------void graficar lista enemigos---------------------------------
   void graficarEnemigos(const int32_t usuario) {
    struct _users *usua=primerouser;
    for(int i=0;i<usuario;i++){
        usua=usua->siguiente;
    }
    QFile file("Enemigos.dot");
    file.open(QIODevice::WriteOnly | QIODevice::Truncate);
    QTextStream text(&file);
    text<<"digraph G{"<<endl;
    struct _deleteememigos *enemi;
    struct _deleteememigos *aux;
        int cont_maletas=0;
        aux=usua->cabecera_enemigo0;
        text<<"subgraph cluster0"<<"{"<<endl;
        text<<"label =\" Tipo: 0"<<"\";"<<endl;
        if(usua->cabecera_enemigo0!=NULL){
            do{
                long int point = reinterpret_cast<long int>(aux);
                long int point2 = reinterpret_cast<long int>(aux->sig);
                text<<point<<"[label=\"Enemigo: "<<cont_maletas<<"\"];"<<endl;
                text<<point<<"->"<<point2<<";"<<endl;
                cont_maletas++;
                aux=aux->sig;
            }while(aux!=usua->cabecera_enemigo0);

        }
        text<<"}"<<endl;

        //--------------------------------------tipo 1-------------------------------------------------------------------
        cont_maletas=0;
        aux=usua->cabecera_enemigo1;
        text<<"subgraph cluster1"<<"{"<<endl;
        text<<"label =\" Tipo: 1"<<"\";"<<endl;
        if(usua->cabecera_enemigo1!=NULL){
            do{
                long int point = reinterpret_cast<long int>(aux);
                long int point2 = reinterpret_cast<long int>(aux->sig);
                text<<point<<"[label=\"Enemigo: "<<cont_maletas<<"\"];"<<endl;
                text<<point<<"->"<<point2<<";"<<endl;
                cont_maletas++;
                aux=aux->sig;
            }while(aux!=usua->cabecera_enemigo1);
        }
        text<<"}"<<endl;

        //------------------------------------------Tipo 2--------------------------------------------------------------------
        cont_maletas=0;
        aux=usua->cabecera_enemigo2;
        text<<"subgraph cluster2"<<"{"<<endl;
        text<<"label =\" Tipo: 2"<<"\";"<<endl;
        if(usua->cabecera_enemigo2!=NULL){
            do{
                long int point = reinterpret_cast<long int>(aux);
                long int point2 = reinterpret_cast<long int>(aux->sig);
                text<<point<<"[label=\"Enemigo: "<<cont_maletas<<"\"];"<<endl;
                text<<point<<"->"<<point2<<";"<<endl;
                cont_maletas++;
                aux=aux->sig;
            }while(aux!=usua->cabecera_enemigo2);
        }
        text<<"}"<<endl;


    text<<"}"<<endl;
    file.close();
   system("dot -Tpng Enemigos.dot -o Enemigos.png");
   }

   void agregarDeleteEnemigo(int id,int usuario,int tipo){
       struct _deleteememigos *nuevo=(struct _deleteememigos*)malloc(sizeof(struct _deleteememigos));
       struct _deleteememigos *aux;
       struct _users *usua=primerouser;
       for(int i=0;i<usuario;i++){
           usua=usua->siguiente;
       }

       nuevo->id=id;
       nuevo->usuario=usuario;

       if(tipo==0){
           if(usua->cabecera_enemigo0==NULL){
                usua->cabecera_enemigo0=nuevo;
                nuevo->sig=usua->cabecera_enemigo0;
                usua->cabecera_enemigo0u=nuevo;
           }else{
               usua->cabecera_enemigo0u->sig=nuevo;
               nuevo->sig=usua->cabecera_enemigo0;
               usua->cabecera_enemigo0u=nuevo;
           }
       }else if(tipo==1){
           if(usua->cabecera_enemigo1==NULL){
               nuevo->sig=usua->cabecera_enemigo1;
                usua->cabecera_enemigo1=nuevo;
                usua->cabecera_enemigo1u=nuevo;
           }else{
               nuevo->sig=usua->cabecera_enemigo1;
               usua->cabecera_enemigo1u->sig=nuevo;
               usua->cabecera_enemigo1u=nuevo;
          }
       }else{
          if(usua->cabecera_enemigo2==NULL){
               usua->cabecera_enemigo2=nuevo;
               nuevo->sig=usua->cabecera_enemigo2;
               usua->cabecera_enemigo2u=nuevo;
           }else{
              nuevo->sig=usua->cabecera_enemigo2;
              usua->cabecera_enemigo2u->sig=nuevo;
              usua->cabecera_enemigo2u=nuevo;
           }
       }


   }



   void guardarPuntaje(const int32_t usuario, const int32_t nivel, const int32_t puntaje) {
    struct _listapunta *nuevo=(struct _listapunta*)malloc(sizeof(struct _listapunta));
    nuevo->usuario=usuario;
    nuevo->id=nivel;
    nuevo->puntaje=puntaje;
    if(primerolista==NULL){
        primerolista=nuevo;
        nuevo->siguiente=NULL;
        ultimolista=nuevo;
    }else{
        ultimolista->siguiente=nuevo;
        nuevo->siguiente=NULL;
        ultimolista=nuevo;
    }

   }

};



MyThread::MyThread(const QString &text):QThread()
{
    myText = text;
    stopThread = false;
}


void MyThread::run(){
    while(!stopThread){
        int port = 9090;
        shared_ptr<Proyecto1Handler> handler(new Proyecto1Handler());
        shared_ptr<TProcessor> processor(new Proyecto1Processor(handler));
        shared_ptr<TServerTransport> serverTransport(new TServerSocket(port));
        shared_ptr<TTransportFactory> transportFactory(new TBufferedTransportFactory());
        shared_ptr<TProtocolFactory> protocolFactory(new TBinaryProtocolFactory());

        TSimpleServer server(processor, serverTransport, transportFactory, protocolFactory);
        server.serve();
    }
}

void MyThread::stop()
{
  stopThread = true;
}

