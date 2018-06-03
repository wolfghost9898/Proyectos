
//----------------------------------------Carretera----------------------------------------------
struct _carretera{
	int id;
	int numero;
	int tipo;

	struct _carretera *siguiente;
};

struct _carretera *primero_carretera,*ultimo_carretera;
void agregarCarro(int numero,int tipo);
void menuCarretera();
void nuevoCarro(int numero);
void movervehiculo();


//-----------------------------------------Parqueo------------------------------------------------
struct _parqueo{
	int id;
	int carro;
	struct _parqueo *siguiente;
};

struct _parqueo *cabecera_parqueo;
void agregarParqueo(int numero);
void guardarParqueo();
void menuParqueo();
void mostrarParqueo();
void quitarParqueo(int numero);
void eliminarParqueo();

void accederParqueo(int id);
//--------------------------------------Cliente---------------------------------------
struct _cliente{
	int id;
	char nombre;
	struct _cliente *siguiente;
};
struct _cliente *primero_cliente;
struct _cliente *ultimo_cliente;

void ingresarAPasillo();
//-----------------------------------Producto------------------------------------
struct _producto{
	int id;
	struct _producto *siguiente;
};
struct _producto *primero_producto;
struct _producto *ultimo_producto;


//--------------------------------------Pasillos----------------------------------
struct _pasillo{
	int id;
	struct _producto *producto,*productofin;
	struct _cliente *cliente,*clientefin;
	struct _pasillo *siguiente;
	struct _pasillo *anterior;
};
struct _pasillo *cabecera_pasillo;
void menuPasillo();
void agregarPasillo(int cantidad);
void nuevoPasillo();
void recorrerPasillo();

//-----------------------------Metodos Producto-------------------------------
void agregarProducto(struct _pasillo *nodo,int pasillo);

//--------------------------------------CAJEROS-------------------------------------------
struct _cajero{
 int id;
 int numero;
 struct _cliente *cliente_inicio,*cliente_final;
 struct _cajero *siguiente;
};
struct _cajero *primero_cajero;
struct _cajero *ultimo_cajero;
void menuCajero();
void agregarCajeros();



//---------------------------------------Archivo Graphviz-----------------------------
void crearGrafica();

//------------------------------------------simular----------------------------------
void menuSimular();

int generarNumeros(int lim_supe,int lim_infe);

void mostrarPasillos();