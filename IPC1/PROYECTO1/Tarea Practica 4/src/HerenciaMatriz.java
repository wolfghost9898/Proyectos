
public class HerenciaMatriz implements Matriz{
	private static String[][] matriz;
	@Override
	public void setMatriz(String[][] matriz) {
		this.matriz=matriz;
		
	}

	@Override
	public String[][] getMatriz() {
		// TODO Auto-generated method stub
		return matriz;
	}

}
