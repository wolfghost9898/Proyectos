package Auxiliares;

import javax.swing.table.DefaultTableModel;

public class MyModel extends DefaultTableModel{
	public boolean isCellEditable(int row,int column)
	{
		if(column==9){
			return true;
		}else{
			return false;
		}
	}
}
