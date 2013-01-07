
package Main;

import java.awt.DisplayMode;
import java.awt.Graphics;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.Point;
import java.util.Random;

public class Snake {

    //Important: DoNOT create a new Snake as a (tmp) EVER
    //this will change the static length
    //And Obviously change the num of Points & it will be an ERROR
    //Solution: do like this: Snake tmp = Snake.first; for example
    // or like: Snake tmp = getElement(4);

    private Snake next;

    private static Snake first,last;

    private int num;

    private static int length = 0;
    
    private Point center;

    private int dir;

    //dir is an int suposed to be from 0 to 7 ( 8 directions ) snake can move in,
    //starting from east and value 0 going to south east with value 1
    //going to south with value 2 and so on
    //finally reaching the end in north east with value 7

    private static int radius = 10;

    private static GraphicsEnvironment GE = GraphicsEnvironment.getLocalGraphicsEnvironment();
    private static GraphicsDevice GD = GE.getDefaultScreenDevice();
    private static DisplayMode DM = GD.getDisplayMode();

    public Snake(){

        this.next = null;

        this.num = ++Snake.length;

        if(this.num == 1){
            Snake.first = this;
            rndmSnk();
        }
        else{
            Snake tmp = getElement(this.num - 1);//previous Point
            Point point;
            do{
                point = rndmConsequtivePoint(tmp.getCenter());
            }while( ! availabePoint(point) );
            setPoint(point);
        }
        Snake.last = this;
    }


    //======================= Static Methods ===================================

    public static void move(){
        //moving the first point and shifting the Coordinates and directions
    }

    public static void addPoint(){
        Snake.last.next = new Snake();
    }

    public static boolean availabePoint(Point point, int numToAvoid){
        boolean availabeWithOtherPoints = true;

        Snake tmp = Snake.first;

        do{
            if(tmp.getNum() != numToAvoid){
                if(cCDistance(tmp.getCenter(), point) < radius*2){
                    availabeWithOtherPoints = false;
                    break;
                }
            }
            tmp = tmp.next;
        }while(tmp != null);

        if(availableWithCoordiantes(point) && availabeWithOtherPoints){
            return true;
        }else{
            return false;
        }
    }

    public static boolean availabePoint(Point point){

        boolean availabeWithOtherPoints = true;

        Snake tmp = Snake.first;

        do{
            if(cCDistance(tmp.getCenter(), point) < radius*2){
                availabeWithOtherPoints = false;
                break;
            }
            tmp = tmp.next;
        }while(tmp != null);

        if( availableWithCoordiantes(point) && availabeWithOtherPoints){
            return true;
        }else{
            return false;
        }
    }

    public static boolean availableWithCoordiantes(Point center){
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

    public static void rndmSnk(){
        int x,y;
        Point point = new Point();
        do{
            x = new Random().nextInt(DM.getWidth() - radius);
            y = new Random().nextInt(DM.getHeight() - radius);
            point.setLocation(x, y);
            if(availabePoint(point, first.num)){
                Snake.first.setPoint(point);
                Snake.first.dir = new Random().nextInt(8);//from 0 to 7
                return;
            }
        }while(true);
    }

    public static Graphics draw(Graphics g){
        Snake tmp = Snake.first;
        do{
            g.drawOval((int)(tmp.getCenter().getX()-Snake.radius), (int)(tmp.getCenter().getY()-Snake.radius), Snake.radius*2, Snake.radius*2);
            tmp = tmp.next;
        }while(tmp != null);
        return g;
    }
    
    private static Point rndmConsequtivePoint(Point point){

        int count = 0;
        Point result;
        do{
            int x = Random_NextInt((int)point.getX()-Snake.radius*2, (int)point.getX()+Snake.radius*2);
            int y = Random_NextInt((int)point.getY()-Snake.radius*2, (int)point.getY()+Snake.radius*2);
            result = new Point(x,y);
            if(++count > 10000){
                return null;
            }
        }while((int)Snake.cCDistance(point, result) != Snake.radius*2);
        return result;
    }

    public static int Random_NextInt(int min, int max){
        int num;

        do{
            num = new Random().nextInt(max+1);
        }while(num < min);

        return num;
    }

    public static double cCDistance(Point one, Point two){
        double diffXSquare = Math.pow(Math.abs((one.getX() - two.getX()) * 1.0), 2.0);
        double diffYSquare = Math.pow(Math.abs((one.getY() - two.getY()) * 1.0), 2.0);
        double result = Math.sqrt(diffXSquare + diffYSquare);
        return result;
    }


    //==================== Getters & Setters ===================================

    public Point getCenter(){
        return center;
    }

    public int getNum(){
        return this.num;
    }

    public int getDir() {
        return dir;
    }

    public boolean setDir(int dir) {

        if(dir < 0 || dir > 7){
            return false;
        }else{
            this.dir = dir;
            return true;
        }
    }

    public void setPoint(Point point){
        this.center = point;
    }

    //=============== Static Getter & Setters ==================================

    public static Snake getElement(int num){
        Snake tmp = Snake.first;
        do{
            if(tmp.num == num){
                return tmp;
            }
            tmp = tmp.next;
        }while(tmp != null);
        return null;
    }

    public static void setRadius(int radius){
        Snake.radius = radius;
    }

    public static int getLength(){
        return Snake.length;
    }

    public static int getRadius(){
        return Snake.radius;
    }

    public static Snake getFirst(){
        return Snake.first;
    }

    public static Snake getLast(){
        return Snake.last;
    }

    public static GraphicsEnvironment getGE(){
        return Snake.GE;
    }

    public static GraphicsDevice getGD(){
        return Snake.GD;
    }

    public static DisplayMode getDM(){
        return Snake.DM;
    }
}
