namespace java proyecto1edd
namespace cpp proyecto1

service Proyecto1{
	bool accesoNivel(1:i32 num1);
	void generadorEnemigos();
	void pararGeneradorEnemigos();
	i32 obtenerTamanio();
	i32 moverJugador(1:i32 num1,2:i32 num2,3:i32 num3,4:i32 errores);
	i32 obtenerNivel();
	void guardarUsuario(1: string nombre);
	string regresarUsuario(1:i32 numero);
	void setUsuario(1:i32 numero);
	i32 obtenerUsuario();
	void desbloquearNivel(1:i32 numero);

	void graficarEnemigos(1:i32 usuario);

	void guardarPuntaje(1:i32 usuario,2:i32 nivel,3:i32 puntaje);

}