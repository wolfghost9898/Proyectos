#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include "auxiliar.h"

//--------------------------------------------generar Numeros----------------------------------------
int generarNumeros(int lim_supe,int lim_infe){
	int numero=rand() %(lim_supe-lim_infe+1)+ lim_infe;
    return numero;
}
//-------------------------------------------pasar un carro al parqueo----------------------------------------------------
void accederParqueo(int id){
	int lim_supe=0;
	int lim_infe=0;
	bool estado=false;
	bool guardado=true;
	struct _parqueo *temporal;
	temporal=cabecera_parqueo;
	do{
		lim_supe=temporal->id;
		lim_infe=cabecera_parqueo->id;
		if(temporal->carro==-1){
			estado=true;
		}
		temporal=temporal->siguiente;
	}while(temporal->siguiente!=cabecera_parqueo);
	
	if(estado==true){
		getchar();
		while(guardado==true){
			int num=generarNumeros(lim_supe+1,lim_infe);
			printf("%s","Se genero el numero: " );
			printf("%d\n",num+1);
			temporal=cabecera_parqueo;
			for(int i=0;i<num;i++){
				temporal=temporal->siguiente;
			}
			if(temporal->carro==-1){
				temporal->carro=id;
				guardado=false;
				printf("%s","Se ha movido el carro al parqueo: " );
				printf("%d\n",temporal->id);
			}
		}
	}else{
		printf("%s","No hay espacios disponibles se agregara el carro ");
		printf("%d",id);
		printf("%s\n", " de nuevo a la carretera");
		getchar();
		nuevoCarro(1);
	}
}

//------------------------------------------Carretera------------------------------------------------------------------------------------
	void agregarCarro(int numero,int tipo){
		for(int i=0;i<=numero;i++){
			struct _carretera *nuevo;
			struct _carretera *temp;
			nuevo=(struct _carretera *)malloc(sizeof(struct _carretera));
			if(primero_carretera==NULL){
				if(tipo==0){
					nuevo->id=0;
					nuevo->numero=0;
					nuevo->tipo=0;
				}else{
					nuevo->id=0;
					nuevo->numero=0;
					nuevo->tipo=1;
				}
				primero_carretera=nuevo;
				primero_carretera->siguiente=NULL;
				ultimo_carretera=primero_carretera;
			}else{
				if(tipo==i){
					nuevo->id=primero_carretera->id;
					nuevo->numero=primero_carretera->numero;
					nuevo->tipo=0;
				}else{
					nuevo->id=primero_carretera->id+1;
					nuevo->numero=primero_carretera->numero+1;
					nuevo->tipo=1;
				}
				temp=primero_carretera;
				nuevo->siguiente=temp;
				primero_carretera=nuevo;
			}
		}
	}

	void nuevoCarro(int numero){
		for(int i=0;i<numero;i++){
			struct _carretera *nuevo;
			struct _carretera *temp;
			nuevo=(struct _carretera *)malloc(sizeof(struct _carretera));
			nuevo->id=primero_carretera->id+1;
			nuevo->numero=primero_carretera->id+1;
			nuevo->tipo=1;
			temp=primero_carretera;
			nuevo->siguiente=temp;
			primero_carretera=nuevo;
		}
	}

	void menuCarretera(){
		system("clear");
		int cantidad;
		if(primero_carretera==NULL){
			int posicion;
			printf("%s","Cuantos Carros hay en la carretera\n");
			scanf("%d",&cantidad);
			printf("%s","La posicion de la entrada\n");
			scanf("%d",&posicion);
			agregarCarro(cantidad,posicion);
			getchar();
		}else{
			printf("%s","Cuantos Carros desea Agregar\n");
			scanf("%d",&cantidad);
			nuevoCarro(cantidad);
			getchar();
		}	
		crearGrafica();
	}

	void moverVehiculo(){
		int id=0;
		system("clear");
		printf("%s\n","Ingrese el Id del carro a mover");
		scanf("%d",&id);
		struct _carretera *temporal;
		struct _carretera *auxilar;
		auxilar=primero_carretera;
		if(primero_carretera->id==id){
			primero_carretera=auxilar->siguiente;
			int carro=auxilar->id;
			free(auxilar);
			accederParqueo(carro);
		}else if(ultimo_carretera->id==id){
			while(auxilar->siguiente!=ultimo_carretera){
				auxilar=auxilar->siguiente;
			}
			auxilar->siguiente=NULL;
			int carro=ultimo_carretera->id;
			free(ultimo_carretera);
			ultimo_carretera=auxilar;
			accederParqueo(carro);
		}else{
			while(auxilar->siguiente->id!=id){
				auxilar=auxilar->siguiente;
			}
				
				if(auxilar->siguiente->tipo==0){
					auxilar=auxilar->siguiente;
				}
				temporal=auxilar->siguiente;
				auxilar->siguiente=temporal->siguiente;
				int carro=temporal->id;
				free(temporal);
				accederParqueo(carro);		
		}
		
	}

//-------------------------------------------parqueo----------------------------------------------------------------------------

	void guardarParqueo(){
		struct _parqueo *nuevo;
		nuevo=(struct _parqueo*)malloc(sizeof(struct _parqueo));
		if(cabecera_parqueo==NULL){
			nuevo->id=1;
			nuevo->carro=-1;
			cabecera_parqueo=nuevo;
			nuevo->siguiente=cabecera_parqueo;
			cabecera_parqueo->siguiente=nuevo;
		}else{
			struct _parqueo *temporal;
			temporal=cabecera_parqueo;
			do{
				temporal=temporal->siguiente;
			}while(temporal->siguiente!=cabecera_parqueo);
			nuevo->id=temporal->id+1;
			nuevo->carro=-1;
			temporal->siguiente=nuevo;
			nuevo->siguiente=cabecera_parqueo;
		}
	}

	void eliminarParqueo(){
		struct _parqueo *aux;
		struct _parqueo *nodo;
		int contador=0;
		aux=cabecera_parqueo;
		while(aux->siguiente!=cabecera_parqueo){
			aux=aux->siguiente;
			contador++;
		}
		
		if(contador==0){
			cabecera_parqueo=NULL;
			free(cabecera_parqueo);
		}else if(contador==1){
			nodo=cabecera_parqueo;
			cabecera_parqueo->siguiente=nodo;
			nodo->siguiente=cabecera_parqueo;
			free(aux);
		}else{
			nodo=cabecera_parqueo->siguiente;
			cabecera_parqueo->siguiente=nodo->siguiente;
			free(nodo);
		}

	}
	void agregarParqueo(int numero){
		for(int i=1;i<=numero;i++){
			guardarParqueo();
		}
	}

	void quitarParqueo(int numero){
		for(int i=1;i<=numero;i++){
			eliminarParqueo();
		}
	}


void menuParqueo(){
		system("clear");
		int cantidad;
		int opcion;
		if(cabecera_parqueo==NULL){
			printf("%s","Ingrese la cantidad de Espacios para el parqueo\n");
			scanf("%d",&cantidad);
			agregarParqueo(cantidad);
		}else{
			printf("%s","1. Aumentar Parqueo\n2. Reducir Parqueo\n");
			scanf("%d",&opcion);
			if(opcion==1){
				printf("%s","Ingrese la cantidad de Espacios a agregar\n");
				scanf("%d",&cantidad);
				agregarParqueo(cantidad);
			}else if(opcion==2){
				printf("%s","Ingrese la cantidad de Espacios a eliminar\n");
				scanf("%d",&cantidad);
				quitarParqueo(cantidad);
			}
		}
		crearGrafica();
	}


void mostrarParqueo(){
		struct _parqueo *temp;
		temp=cabecera_parqueo;
		do{
			printf("%d",temp->id);
			temp=temp->siguiente;
		}while(temp!=cabecera_parqueo);
	}

//------------------------------------Agregar Producto------------------------------------
void agregarProducto(struct _pasillo *nodo,int pasillo){
	system("clear");
	printf("%s","------------Pasillo-------------");
	printf("%d\n",pasillo);
	int id=0;
	int cantidad=0;
	printf("%s\n","Ingrese el Id del producto");
	scanf("%d",&id);
	printf("%s\n","Ingrese la cantidad del Producto");
	scanf("%d",&cantidad);
	struct _producto *temp=nodo->producto;
	for(int i=0;i<cantidad;i++){
		struct _producto *producto=(struct _producto*)malloc(sizeof(struct _producto));
		producto->id=id;
		if(nodo->producto==NULL){
			nodo->producto=producto;
			nodo->productofin=producto;
			nodo->productofin->siguiente=NULL;
		}else{
			nodo->productofin->siguiente=producto;
			nodo->productofin=producto;
			nodo->productofin->siguiente=NULL;
			}
	}
}	
//--------------------------------------Pasillo---------------------------------------------

void mostrarPasillos(){
	struct _pasillo *pasillo=cabecera_pasillo;
	struct _producto *producto;

	do{
		printf("%d\t",pasillo->id );
		producto=pasillo->producto;
		while(producto!=NULL){
			printf("%d",producto->id);
			producto=producto->siguiente;
		}
		printf("%s\n","-----------------------------");
		pasillo=pasillo->siguiente;
	}while(pasillo!=cabecera_pasillo);
	getchar();
}

void nuevoPasillo(){
	struct _pasillo *nodo=(struct _pasillo*)malloc(sizeof(struct _pasillo));
	if(cabecera_pasillo==NULL){
		nodo->id=1;
		nodo->producto=NULL;
		nodo->cliente=NULL;
		cabecera_pasillo=nodo;
		cabecera_pasillo->siguiente=cabecera_pasillo->anterior=cabecera_pasillo;
	}else{
		struct _pasillo *temporal;
		temporal=cabecera_pasillo;
		do{
			temporal=temporal->siguiente;
		}while(temporal->siguiente!=cabecera_pasillo);
		nodo->id=temporal->id+1;
		nodo->producto=NULL;
		nodo->cliente=NULL;
		cabecera_pasillo->anterior=nodo;
		nodo->siguiente=cabecera_pasillo;
		nodo->anterior=temporal;
		temporal->siguiente=nodo;
	}
}

void agregarPasillo(int cantidad){
	for(int i=1;i<=cantidad;i++){
		nuevoPasillo();
	}
}

void recorrerPasillo(){
	struct _pasillo *temp;
	temp=cabecera_pasillo;
	do{
		agregarProducto(temp,temp->id);
		temp=temp->siguiente;
	}while(temp!=cabecera_pasillo);
}

void menuPasillo(){
	system("clear");
	int cantidad;
	printf("%s\n","Ingrese la cantidad de Pasillos");
	scanf("%d",&cantidad);
	agregarPasillo(cantidad);
	recorrerPasillo();
	crearGrafica();
}	

//---------------------------------------------------Cajero-------------------------
void agregaCajeros(){
	struct _cajero *nuevo=(struct _cajero*)malloc(sizeof(struct _cajero));
	if(primero_cajero==NULL){
		nuevo->id=1;
		nuevo->numero=1;
		primero_cajero=ultimo_cajero=nuevo;
		ultimo_cajero->siguiente=NULL;
	}else{
		nuevo->id=ultimo_cajero->id+1;
		nuevo->numero=ultimo_cajero->numero+1;
		ultimo_cajero->siguiente=nuevo;
		nuevo->siguiente=NULL;
		ultimo_cajero=nuevo;
	}
}

void menuCajero(){
	system("clear");
	int cantidad;
	printf("%s\n","Ingrese el numero de cajeros");
	scanf("%d",&cantidad);
	for(int i=0;i<cantidad;i++){
		agregaCajeros();
	}
	crearGrafica();
}


void crearGrafica(){
	FILE *archivo;
	archivo=fopen("Grafo.dot","w");
	struct _carretera *carretera=primero_carretera;
	fputs("digraph G{\nsubgraph cluster{\nlabel=\"Carretera\";\n",archivo);
	//----------------------------------Carretera-----------------------------------------
	while(carretera!=NULL){
		if(carretera!=ultimo_carretera){
			char str[100];
			sprintf(str,"%d",carretera->id);
			char str2[100];
			sprintf(str2,"%d",carretera->siguiente->id);
			if(carretera->tipo==0){
				fputs("entrada->carro",archivo);
				fputs(str2,archivo);
				fputs(";\n",archivo);
			}else if(carretera->siguiente->tipo==0){
				fputs("carro",archivo);
				fputs(str,archivo);
				fputs("[label=\"Carro :",archivo);
				fputs(str,archivo);
				fputs("\"];",archivo);
				fputs("carro",archivo);
				fputs(str,archivo);
				fputs("->",archivo);
				fputs("entrada;\n",archivo);
			}else{
				fputs("carro",archivo);
				fputs(str,archivo);
				fputs("[label=\"Carro :",archivo);
				fputs(str,archivo);
				fputs("\"];",archivo);
				fputs("carro",archivo);
				fputs(str,archivo);
				fputs("->",archivo);
				fputs("carro",archivo);
				fputs(str2,archivo);
				fputs(";\n",archivo);
			}

		}else if(carretera==primero_carretera || carretera==ultimo_carretera){
			if(carretera->tipo==0){
				fputs("entrada;\n",archivo);
			}else{
				char str[100];
				sprintf(str,"%d",carretera->id);
				fputs("carro",archivo);
				fputs(str,archivo);
				fputs(";\n",archivo);
				fputs("carro",archivo);
				fputs(str,archivo);
				fputs("[label=\"Carro :",archivo);
				fputs(str,archivo);
				fputs("\"];",archivo);
			}
			
		}
		carretera=carretera->siguiente;		
	}
	fputs("\n}\n",archivo);
	//----------------------------------Parqueo----------------------------------------------
	struct _parqueo *parqueo=cabecera_parqueo;
	fputs("subgraph parqueo{\nlabel=\"Parqueo\";\n",archivo);
	if(cabecera_parqueo!=NULL){
		do{
			char str[100];
			sprintf(str,"%d",parqueo->id);
			char str2[100];
			sprintf(str2,"%d",parqueo->siguiente->id);
			fputs("parqueo",archivo);
			fputs(str,archivo);
			fputs("[label=\"parqueo :",archivo);
			fputs(str,archivo);
			if(parqueo->carro==-1){
				fputs("\n Estado: Disponible \"];",archivo);
			}else{
				char carrono[100];
				sprintf(carrono,"%d",parqueo->carro);
				fputs("\n Carro: ",archivo);
				fputs(carrono,archivo);
				fputs("\"];",archivo);
			}
			fputs("parqueo",archivo);
			fputs(str,archivo);
			fputs("->",archivo);
			fputs("parqueo",archivo);
			fputs(str2,archivo);
			fputs(";\n",archivo);
			parqueo=parqueo->siguiente;
		}while(parqueo!=cabecera_parqueo);
	}
	fputs("\n}\n",archivo);	
	fputs("subgraph pasillos{\nlabel=\"Pasillos\";\n",archivo);
	struct _pasillo *pasillo=cabecera_pasillo;
	if(cabecera_pasillo!=NULL){
		do{
			char str[100];
			sprintf(str,"%d",pasillo->id);
			char str2[100];
			sprintf(str2,"%d",pasillo->siguiente->id);
			fputs("pasillo",archivo);
			fputs(str,archivo);
			fputs("[label=\"pasillo :",archivo);
			fputs(str,archivo);
			fputs("\"];",archivo);
			fputs("pasillo",archivo);
			fputs(str,archivo);
			fputs("->",archivo);
			fputs("pasillo",archivo);
			fputs(str2,archivo);
			fputs(";\n",archivo);
			fputs("pasillo",archivo);
			fputs(str2,archivo);
			fputs("->",archivo);
			fputs("pasillo",archivo);
			fputs(str,archivo);
			fputs(";\n",archivo);
			pasillo=pasillo->siguiente;
		}while(pasillo!=cabecera_pasillo);
	}
	//---------------------------------Pilas de Productos---------------------------------------
	fputs("}\n",archivo);
	pasillo=cabecera_pasillo;
	if(cabecera_pasillo!=NULL){
		struct _producto *producto;
		do{
			int contador=1;
			char str[100];
			sprintf(str,"%d",pasillo->id);
			fputs("subgraph pila_producto",archivo);
			fputs(str,archivo);
			fputs("{\n",archivo);
			producto=pasillo->producto;
			if(producto!=NULL){
				fputs("pasillo",archivo);
				fputs(str,archivo);
				fputs("->",archivo);
				while(producto!=NULL){
					if(producto->siguiente!=NULL){
						char str2[100];
						sprintf(str2,"%d",pasillo->id+contador);;
						char str3[100];
						sprintf(str3,"%d",producto->id);
						char str4[100];
						sprintf(str4,"%d",pasillo->id+contador+1);

						fputs("producto",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs("->",archivo);

						fputs("producto",archivo);
						fputs(str4,archivo);
						fputs(str3,archivo);
						fputs(";\n",archivo);

						fputs("producto",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs("[shape=box,label=\"Producto :",archivo);
						fputs(str3,archivo);
						fputs("\"];",archivo);

					}else{
						char str2[100];
						sprintf(str2,"%d",pasillo->id+contador);;
						char str3[100];
						sprintf(str3,"%d",producto->id);

						fputs("producto",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs(";\n",archivo);
						
						fputs("producto",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs("[shape=box,label=\"Producto :",archivo);
						fputs(str3,archivo);
						fputs("\"];",archivo);
					}
					contador++;
				    producto=producto->siguiente;
				}
	
			}

									
			fputs("}\n",archivo);
			pasillo=pasillo->siguiente;
		}while(pasillo!=cabecera_pasillo);
	}
	//--------------------------------Pilas de CLientes-----------------------------------------
	pasillo=cabecera_pasillo;
		if(cabecera_pasillo!=NULL){
		struct _cliente *cliente;
		do{
			char str[100];
			sprintf(str,"%d",pasillo->id);
			fputs("subgraph pila_cliente",archivo);
			fputs(str,archivo);
			fputs("{\n",archivo);
			cliente=pasillo->cliente;
			if(cliente!=NULL){
				fputs("pasillo",archivo);
				fputs(str,archivo);
				fputs("->",archivo);
				while(cliente!=NULL){
					if(cliente->siguiente!=NULL){
						char str2[100];
						sprintf(str2,"%d",pasillo->id);;
						char str3[100];
						sprintf(str3,"%d",cliente->id);
						char str4[100];
						sprintf(str4,"%d",cliente->siguiente->id);

						fputs("cliente",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs("->",archivo);

						fputs("cliente",archivo);
						fputs(str2,archivo);
						fputs(str4,archivo);
						fputs(";\n",archivo);

						fputs("cliente",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs("[shape=box,label=\"cliente :",archivo);
						fputs(str3,archivo);
						fputs("\"];",archivo);

					}else{
						char str2[100];
						sprintf(str2,"%d",pasillo->id);;
						char str3[100];
						sprintf(str3,"%d",cliente->id);

						fputs("cliente",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs(";\n",archivo);
						
						fputs("cliente",archivo);
						fputs(str2,archivo);
						fputs(str3,archivo);
						fputs("[shape=box,label=\"cliente :",archivo);
						fputs(str3,archivo);
						fputs("\"];",archivo);
					}
				    cliente=cliente->siguiente;
				}
	
			}
									
			fputs("}\n",archivo);
			pasillo=pasillo->siguiente;
		}while(pasillo!=cabecera_pasillo);
	}




	fputs("\n}",archivo);
	fclose(archivo);
	system("dot -Tpng Grafo.dot -o Grafo.png");
	system("eog Grafo.png");
}
//------------------------------------------Ingresar a Pasillo--------------------------
void ingresarAPasillo(){
	int id=0;
	int lim_supe=0;
	int lim_infe=0;
	int numero=0;
	bool estado=false;
	struct _parqueo *temporal;
	struct _pasillo *auxilar;
	struct _cliente *auxiliar2;
	struct _cliente *nuevo=(struct _cliente*)malloc(sizeof(struct _cliente));

	printf("%s\n","Ingrese el id del cliente a mover");
	scanf("%d",&id);
	lim_infe=cabecera_pasillo->id;
	lim_supe=cabecera_pasillo->anterior->id;
	temporal=cabecera_parqueo;
	do{
		if(temporal->carro==id){
			estado=true;
		}
		temporal=temporal->siguiente;
	}while(temporal!=cabecera_parqueo);
	if(estado==true){
		numero=generarNumeros(lim_supe,lim_infe);
		printf("%s","El numero generado Aleatoriamente es: " );
		printf("%d\n",numero+1);
		auxilar=cabecera_pasillo;
		for(int i=0;i<numero;i++){
			auxilar=auxilar->siguiente;
		}
		nuevo->id=id;
		if(auxilar->cliente==NULL){
			auxilar->cliente=nuevo;
			auxilar->clientefin=nuevo;
			auxilar->clientefin->siguiente=NULL;
		}else{
			auxilar->clientefin->siguiente=nuevo;
			auxilar->clientefin=nuevo;
			auxilar->clientefin->siguiente=NULL;
			}
		printf("%s","El cliente: " );
		printf("%d",id);
		printf("%s"," Se ingreso al Pasillo" );
		printf("%d\n", auxilar->id );	

		getchar();
	}else{
		printf("%s\n","No se encontro el id");
		getchar();
	}
}
//---------------------------------------------Simular--------------------------------
void menuSimular(){
	system("clear");
	int opcion=0;
	printf("%s\n","Seleccione una opcion:");
	printf("%s\n","1. Mover Vehiculos");
	printf("%s\n","2. Ingresar Cliente a Pasillo");
	scanf("%d",&opcion);
	switch(opcion){

		case 1:
			moverVehiculo();
			crearGrafica();
		break;

		case 2:
			ingresarAPasillo();
			crearGrafica();
		break;

		case 3:
			crearGrafica();
		break;
		default:
		printf("%s\n","No se escogio ninguna opcion regresando al menu");
		getchar();
		break;
	}
}

int main(){
	int opcion;
	bool estado=true;
	while(estado){
		system("clear");
		printf("\n%s","Escoja una opcion");
		printf("\n%s","1. Carretera");
		printf("\n%s","2. Parqueo");
		printf("\n%s","3.Supermercado,Estanterias y Productos");
		printf("\n%s","4.Cajas");
		printf("\n%s","5.Ventas");
		printf("\n%s","6.Simular");
		printf("\n%s","7.Salir");
		printf("\n%s","");
		scanf("%d",&opcion);
		switch(opcion)
		{
			case 1:
				menuCarretera();
			break;

			case 2:
				menuParqueo();
			break;

			case 3:
				menuPasillo();
			break;

			case 4:
				menuCajero();
			break;

			case 5:
			break;

			case 6:
				menuSimular();
			break;
			
			case 7:
				
			break;

			default:
				printf("%s","No se escogio ninguna opcion se procedera a salir\n");
				estado=false;
			break;

		}
		getchar();	
		
	}
	


	return 0;
}