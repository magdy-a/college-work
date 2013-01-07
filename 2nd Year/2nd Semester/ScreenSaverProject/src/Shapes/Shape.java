
package Shapes;

import Interfaces.Shapes;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.util.Random;


public abstract class Shape implements Shapes{

    private int upperLeftX;
    private int upperLeftY;
    private int width;
    private int heigth;
    private int center;
    
    private boolean fillFlag;

    private Color color;

    private Random random;

    public Shape(){
        upperLeftX = 0;
        upperLeftY = 0;
        width = 0;
        heigth = 0;
        center = 0;
        fillFlag = false;
        color = Color.BLACK;
        random = new Random();
    }

    public Shape(int uX,int uY,int w,int h){
        this();
        setUpperLeftX(uX);
        setUpperLeftY(uY);
        setWidth(w);
        setHeigth(h);
    }
    public void generateRandomAll(int max){
        generateRandomBorder(max);
        generateRandomColor();
        generateRandomFill();
    }
    public void generateRandomAll(int maxX,int maxY,int maxWidth,int maxHeight){
        setBorders(maxX,maxY,maxWidth,maxHeight);
        generateRandomColor();
        generateRandomFill();
    }

    public void generateRandomBorder(int max){
        generateRandomUpperLeftX(max);
        generateRandomUpperLeftY(max);
        generateRandomWidth(max);
        generateRandomHeigth(max);
    }
    public void setBorders(int upperX,int upperY,int width,int height){
        setUpperLeftX(upperX);
        setUpperLeftY(upperY);
        setWidth(width);
        setHeigth(height);
    }

    public void generateRandomUpperLeftX(int max){
        setUpperLeftX(random.nextInt(max));
    }
    public void generateRandomUpperLeftY(int max){
        setUpperLeftY(random.nextInt(max));
    }
    public void generateRandomWidth(int max){
        setWidth(random.nextInt(max));
    }   
    public void generateRandomHeigth(int max){
        setHeigth(random.nextInt(max));
    }

    public void generateRandomColor(){
        setColor(new Color(random.nextInt(256), random.nextInt(256), random.nextInt(256)));
    }

    public void generateRandomFill(){
        if(random.nextInt(2) == 1)
            fillFlag = true;
        else
            fillFlag = false;
    }

    public abstract Graphics draw(Graphics g);

    public int getUpperLeftX() {
        return upperLeftX;
    }
    public void setUpperLeftX(int upperLeftX) {
        this.upperLeftX = upperLeftX;
    }
    public int getUpperLeftY() {
        return upperLeftY;
    }
    public void setUpperLeftY(int upperLeftY) {
        this.upperLeftY = upperLeftY;
    }
    public int getWidth() {
        return width;
    }
    public void setWidth(int width) {
        this.width = width;
    }
    public int getHeigth() {
        return heigth;
    }  
    public void setHeigth(int heigth) {
        this.heigth = heigth;
    }
    public boolean isFillFlag() {
        return fillFlag;
    }
    public void setFillFlag(boolean fillFlag) {
        this.fillFlag = fillFlag;
    }
    public Color getColor() {
        return color;
    }
    public void setColor(Color Color) {
        this.color = Color;
    }
    public int getRandom(int max) {
        return random.nextInt(max);
    }
    public Random getRandom() {
        return random;
    }
    public void setRandom(Random random) {
        this.random = random;
    }
    public Point getCenter() {
        int x = getUpperLeftX() + getWidth()/2;
        int y = getUpperLeftY() + getHeigth()/2;
        return new Point(x,y);
    }
    


    

    @Override
    public String toString() {
        return String.format("upperLeftX: %d, upperLeftY : %d, width: %d, height: %d",getUpperLeftX(),getUpperLeftY(),getWidth(),getHeigth());
    }
}
