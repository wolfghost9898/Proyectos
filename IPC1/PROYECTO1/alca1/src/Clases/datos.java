/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Clases;

/**
 *
 * @author HP
 */
class datos {
Object o = new Object();
int x,y;
    datos(Object[][] o, int length, int length0) {
    this.o=o;
    this.x=length;
    this.y=length0;
    }

   

    public Object getO() {
        return o;
    }

    public void setO(Object o) {
        this.o = o;
    }

    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }
    double Max(Object[][] o, int v, int w) {
        double z=0,zz=0;
        for(int i=0;i< v ;i++){
                     for(int ii=0;ii< w;ii++){
                       z =  Double.parseDouble( (String) o[i][ii]);
                        zz=Math.max(z, zz);
                     }    
              }
    return zz;
    }
    double Min(Object[][] o, int v, int w) {
        double z;
        double zz=Double.parseDouble( (String) o[0][0]);
        for(int i=0;i< v ;i++){
                     for(int ii=0;ii< w;ii++){
                       z =  Double.parseDouble( (String) o[i][ii]);
                        zz=Math.min(z, zz);
                     }    
              }
    return zz;
    }
    
    
}
