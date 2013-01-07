
package Main;

import java.awt.Color;
import java.awt.DisplayMode;
import java.awt.Graphics;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.Point;
import java.util.Random;

public class Snake {

    private Snake next;
    //the next of each point as it is linked list of points that makes the snake

    private static Snake first,last;
    //just a pointer to the first and last points
    //actually u don't need it in existance of the num of each element and the length and fn. getElement(int);

    private int num;
    //num of each point

    private static int length = 0;
    //the length of all points

    //Important: DON't create a new Snake for a tmp use, because it will change
    //the static length, and then the num of the the points created later
    //Solution: Snake tmp = Snake.first; or = Snake.last; or = Snake.getElement(int);
    //or u can just create the new then as u don't notice that u should,
    //make the its previous( getElement(last-1); ) is the last and its next = null
    //and of course reduce the static length
    
    private Point center;
    //the center of the rectangle that is tangent of all side to the circle we use

    private static int radius = 10;
    //radius of the circle, or half the width and half the height of that rectangle

    private int dir;
    //dir is an int suposed to be from 0 to 7 ( 8 directions ) snake can move in,
    //starting from east and value 0 going to south east with value 1
    //going to south with value 2 and so on
    //finally reaching the end in north east with value 7

    private static Point doda = new Point();

    private static int speed = radius;

    private static GraphicsEnvironment GE = GraphicsEnvironment.getLocalGraphicsEnvironment();
    private static GraphicsDevice GD = GE.getDefaultScreenDevice();
    private static DisplayMode DM = GD.getDisplayMode();
    //using GD in setting the full screen window
    //using DM in getting the coordinates of my screen

    //constructor handles the creation of a new point, whether if it the first or not
    public Snake(){

        this.next = null;

        this.num = ++Snake.length;

        if(this.num == 1){
            Snake.first = this;
            rndmSnk();
            rndmDoda();
        }
        else{
            Point point;
            int count = 0;
            do{
                point = rndmConsequtivePoint();
                if(++count == 10000){newGame();}
            }while( ! availabePoint(point,last.num) );
            setPoint(point);
        }
        Snake.last = this;
    }

    //======================= Static Methods ===================================

    //gets the new coordinates for the first and shifts all coordinates one below
    public static void move(){
        Point nextMove = nextMove();//for the first
        if(availabePoint(nextMove, 1)){
            if(cCDistance(nextMove, doda) < radius*2){
                rndmDoda();
                addPoint();
            }
            Snake tmpSnake = Snake.first;
            Point tmpPoint;
            while(tmpSnake != null){

                tmpPoint = tmpSnake.getCenter();
                tmpSnake.setPoint(nextMove);
                nextMove = tmpPoint;

                tmpSnake = tmpSnake.next;
            }
        }else{
            newGame();
        }
    }
    //very simple (new Snake();) constructor handles it :D
    public static void addPoint(){
        Snake.last.next = new Snake();
    }
    //draws all points in Graphics object and returns it
    public static Graphics draw(Graphics g){
        Snake tmp = Snake.first;
        Color color = g.getColor();
        do{
            if(tmp == first){
                g.setColor(Color.BLUE);
                g.fillOval((int)(tmp.getCenter().getX()-radius), (int)(tmp.getCenter().getY()-radius), radius*2, radius*2);
                g.setColor(color);
            }else{
                g.fillOval((int)(tmp.getCenter().getX()-radius), (int)(tmp.getCenter().getY()-radius), radius*2, radius*2);
            }
            tmp = tmp.next;
        }while(tmp != null);
        g.setColor(Color.PINK);
        g.fillOval((int)(doda.getX()-radius), (int)(doda.getY()-radius), radius*2, radius*2);
        g.setColor(color);
        return g;
    }
    //starts a new game with random one point
    public static void newGame(){
        Snake.length = 0;
        Snake.first = new Snake();
    }
    //checks if the point given is available acording to screen coordinates 
    //and other points, but it takes the num of the point to avoid calculation on
    private static boolean availabePoint(Point point, int numToAvoid){
        /*for checking if the next move available
         but DON'T calculate on the Point with the number i give u*/
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
    //for checking if the ponit given is within the coordinates
    private static boolean availableWithCoordiantes(Point center){
        //helping method
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
    //to generate a random first point
    private static void rndmSnk(){
        int x,y;
        Point point = new Point();
        do{
            x = new Random().nextInt(DM.getWidth()/2);
            y = new Random().nextInt(DM.getHeight()/2);
            point.setLocation(x, y);
            if(availabePoint(point, first.num)){
                Snake.first.setPoint(point);
                Snake.first.dir = new Random().nextInt(8);//from 0 to 7
                return;
            }
        }while(true);
    }
    //to generate a random point consequtive to the last one
    private static Point rndmConsequtivePoint(){

        int count = 0;
        Point result;
        do{
            int x = Random_NextInt((int)last.getCenter().getX()-Snake.radius, (int)last.getCenter().getX()+Snake.radius);
            int y = Random_NextInt((int)last.getCenter().getY()-Snake.radius, (int)last.getCenter().getY()+Snake.radius);
            result = new Point(x,y);
            if(++count > 10000){
                newGame();
            }
        }while((int)Snake.cCDistance(last.getCenter(), result) != Snake.radius);
        return result;
    }
    //helper method helps generating a random number withing specified range
    private static int Random_NextInt(int min, int max){
        int num;

        do{
            num = new Random().nextInt(max+1);
        }while(num < min);

        return num;
    }
    //returns the range between to point(circles) according to there centers
    private static double cCDistance(Point one, Point two){
        double diffXSquare = Math.pow(Math.abs((one.getX() - two.getX()) * 1.0), 2.0);
        double diffYSquare = Math.pow(Math.abs((one.getY() - two.getY()) * 1.0), 2.0);
        double result = Math.sqrt(diffXSquare + diffYSquare);
        return result;
    }
    //return the next expected move of the first point
    private static Point nextMove(){
        int x = (int)first.getCenter().getX();
        int y = (int)first.getCenter().getY();
        switch(first.dir){
            case 0://east
                x += speed + speed/2;
                break;
            case 1://south east
                x += speed;
                y += speed;
                break;
            case 2://south
                y += speed + speed/2;
                break;
            case 3://south west
                x -= speed;
                y += speed;
                break;
            case 4://west
                x -= speed + speed/2;
                break;
            case 5://north west
                x -= speed;
                y -= speed;
                break;
            case 6://north
                y -= speed + speed/2;
                break;
            case 7://north east
                x += speed;
                y -= speed;
                break;
        }
        return new Point(x,y);
    }
    //generates random available point
    private static void rndmDoda(){
        int x,y;
        do{
            x = new Random().nextInt(DM.getWidth());
            y = new Random().nextInt(DM.getHeight());
            doda.setLocation(x,y);
        }while( ! availabePoint(doda, -1));
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

    public static int getSpeed(){
        return Snake.speed;
    }
}