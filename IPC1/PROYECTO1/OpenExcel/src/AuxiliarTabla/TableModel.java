package AuxiliarTabla;

import javax.swing.table.AbstractTableModel;

import Text.copyData;

public class TableModel  extends AbstractTableModel{
	  public Object [][] data;
	  public String [] columnNames;
	  TableModel(Object[][] data, String[] columnNames) {
		 this.data = data;
         this.columnNames = columnNames;
	}

	@Override
	public int getColumnCount() {
		// TODO Auto-generated method stub
		
		return data.length;
	}

	@Override
	public int getRowCount() {
		// TODO Auto-generated method stub
		return columnNames.length;
	}
	 @Override
	    public String getColumnName(int column1) {
	    return columnNames[column1];
	    }

	@Override
	public Object getValueAt(int row1, int column2) {
		// TODO Auto-generated method stub
		return data[row1][column2];
	}
	
	
	@Override
    public void setValueAt(Object Value, int row2, int column3) {
		
		copyData copy= new copyData();
		Object[] data2={row2,column3,getValueAt(row2,column3).toString()};
		copy.setChange(data2);
		Object[] caca=copy.getChange();
		
    data[row2][column3]=Value;
    fireTableCellUpdated(row2,column3);
    }

    @Override
    public boolean isCellEditable(int row, int column) {
    if(column==0){
    return false;
    }else{
        
        return true;
    }
    }

 

    

}
