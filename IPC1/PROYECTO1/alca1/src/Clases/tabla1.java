/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Clases;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author HP
 */

public class tabla1 extends AbstractTableModel {
    public Object [][] data ;
    public String [] columnNames;
   
   
    tabla1(Object[][] data, String[] columnNames) {
        this.data = data;
         this.columnNames = columnNames;
    }
         
    @Override
    public int getRowCount() {
    return columnNames.length;
    }

    @Override
    public int getColumnCount() {
    return data.length;
    }

    @Override
    public String getColumnName(int column1) {
    return columnNames[column1];
    }
    

    @Override
    public Object getValueAt(int row1, int column2) {
     return data[row1][column2];
    }

    @Override
    public void setValueAt(Object Value, int row2, int column3) {
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

    @Override
    public Class getColumnClass(int colum) {
        return getValueAt(0,colum).getClass(); 
    }

    
   
    
   
}
