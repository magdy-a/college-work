
package Main;

import java.awt.DisplayMode;
import java.awt.Graphics;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.Point;
import java.util.Random;

public class Snake {

    private Snake next;

    private static Snake first,last;

    private int num;
    private static int length = 0;
    
    private Point center;

    public static int radius = 10;

    static GraphicsEnvironment GE = GraphicsEnvironment.getLocalGraphicsEnvironment();
    static GraphicsDevice GD = GE.getDefaultScreenDevice();
    static DisplayMode DM = GD.getDisplayMode();

    public Snake(){

        this.next = null;

        this.num = ++Snake.length;

        if(this.num == 1){
            Snake.first = this;
        }
        Snake.last = this;
    }

    public boolean setData(Point center){

        if(availableWithCoordiantes(center) && availableWithOtherParts(center)){
            this.center = center;
            return true;
        }else{
            return false;
        }
    }

    public static void setRadius(int radius){
        Snake.radius = radius;
    }

    public static Graphics draw(Graphics g){
        Snake tmp = Snake.first;
        do{
            g.drawOval((int)(tmp.getCenter().getX()-Snake.radius), (int)(tmp.getCenter().getY()-Snake.radius), Snake.radius, Snake.radius);
            tmp = tmp.next;
        }while(tmp != null);
        return g;
    }

    public static void rndmSnk(){
        do{
            
        }while( ! Snake.first.setData(new Point(new Random().nextInt(Snake.DM.getWidth()),new Random().nextInt(Snake.DM.getHeight()))));
    }

    public boolean availableWithCoordiantes(Point center){
        if(     ((center.getX() - Snake.radius) < 0) ||
                ((center.getY() - Snake.radius) < 0) ||
                (Snake.DM.getWidth()  < (center.getX() + Snake.radius)) ||
                (Snake.DM.getHeight() < (center.getY() + Snake.radius))
          ){
            return false;
        }
        else{
            return true;
        }
    }
    public boolean availableWithOtherParts(Point center){//the problem here >>> if i used a Snake as a parameter >>> then used a tmpSnake to Check >>> the static Length will change and never gonna back >>> unless i decreases the length at the end of the funcion ??? !!!

        Snake tmp = Snake.first;

        do{
            if(this.num != tmp.getNum()){// to aviod claculations on same object
                if(this.cCDistance(tmp) < radius*2){
                    return false;
                }
            }
            tmp = tmp.next;
        }while(tmp != null);
        return true;
    }
    private double cCDistance(Snake other){
        double diffXSquare = Math.pow(Math.abs((this.getCenter().getX() - other.getCenter().getX()) * 1.0), 2.0);
        double diffYSquare = Math.pow(Math.abs((this.getCenter().getY() - other.getCenter().getY()) * 1.0), 2.0);
        double result = Math.sqrt(diffXSquare + diffYSquare);
        return result;
    }

    public Point getCenter(){
        return center;
    }
    public int getNum(){
        return this.num;
    }
}
