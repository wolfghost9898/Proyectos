package Text;

public class copyData implements Copy {
	private static String valor;
	private static Object[] data;
	private static boolean estado=true;
	@Override
	public void setValue(String valor) {
		this.valor=valor;
	}
	
	@Override
	public String getValue() {
		return valor;
	}

	@Override
	public Object[] getChange() {
		// TODO Auto-generated method stub
		return data;
	}

	@Override
	public void setChange(Object[] data) {
		this.data=data;
	}

	@Override
	public boolean estado() {
		// TODO Auto-generated method stub
		return estado;
	}

	@Override
	public void setEstado(boolean estado) {
		this.estado=estado;
		
	}



}
