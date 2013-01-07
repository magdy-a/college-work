package Shapes;

import java.awt.Color;
import java.awt.Graphics;



public class Bubble extends Oval{
    private int dirX;
    private int dirY;

    private boolean winkingEye;
    private boolean laughing;

    public Bubble(){
        super();
    }
    public Bubble(int uX,int uY,int w,int h){
        super(uX,uY,w,h);
        setUpperLeftX(uX);
        setUpperLeftY(uY);
        setWidth(w);
        setHeigth(h);
    }
    
    @Override
    public Graphics draw(Graphics g) {

        return super.draw(g);
    }

    public Graphics drawFaces(Graphics g, boolean change){
        if(change){
            if(getRandom(2) == 0)
                winkingEye = true;
            else
                winkingEye = false;
            if(getRandom(2) == 1)
                laughing = true;
            else
                laughing = false;

            setColor(new Color(getRandom(256),getRandom(256),getRandom(256)));
        }
        g.setColor(getColor());
        //face
        g.fillOval(getUpperLeftX(), getUpperLeftY(), 200, 200);
        //mouth
        g.setColor(Color.BLACK);
        g.fillOval(getUpperLeftX()+40, getUpperLeftY()+100, 120, 60);
        g.setColor(getColor());
        if(laughing){
            g.fillRect(getUpperLeftX()+40, getUpperLeftY()+100, 120, 30);
        }else{//smiling
            g.fillRect(getUpperLeftX()+40, getUpperLeftY()+100, 120, 30);
            g.fillOval(getUpperLeftX()+40, getUpperLeftY()+105, 120, 40);
        }
        g.setColor(Color.BLACK);
        if(winkingEye){
            g.fillOval(getUpperLeftX()+55, getUpperLeftY()+70, 15, 5);
            g.fillOval(getUpperLeftX()+125, getUpperLeftY()+55, 30, 30);
        }else{//normal eye
            g.fillOval(getUpperLeftX()+45, getUpperLeftY()+55, 30, 30);
            g.fillOval(getUpperLeftX()+125, getUpperLeftY()+55, 30, 30);
        }

        return g;
    }


    public boolean isTangent(Oval bubble){
        if(distance(bubble) <= getRadius()+ bubble.getRadius())
            return true;
        return false;
    }
    public boolean isTangent(int screenW,int screenH){
        if(
           getUpperLeftX()<=0 || getUpperLeftX()+getWidth() >= screenW   ||
           getUpperLeftY()<=0 || getUpperLeftY()+getHeigth()>= screenH
          )
            return true;
        return false;
    }
    public boolean isTangent(Oval bubble,int ScreenW,int ScreenH){
        return isTangent(bubble) || isTangent(ScreenW, ScreenH);
    }
    private double distance(Oval bubble){
        double difXSquare =  Math.pow(( getCenter().getX() - bubble.getCenter().getX()), 2.0 );
        double difYSquare =  Math.pow(( getCenter().getY() - bubble.getCenter().getY()), 2.0 );
        return (Math.sqrt(difXSquare + difYSquare));
    }

    public int getDirX() {
        return dirX;
    }
    public void setDirX(int dirX) {
        this.dirX = dirX;
    }
    public int getDirY() {
        return dirY;
    }
    public void setDirY(int dirY) {
        this.dirY = dirY;
    }
}