
package Interfaces;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.util.Random;

public interface Shapes {
    
    public void generateRandomAll(int max);
    public void generateRandomAll(int maxX,int maxY,int maxWidth,int maxHeigth);

    public void generateRandomBorder(int max);
    
    public void generateRandomUpperLeftX(int max);
    public void generateRandomUpperLeftY(int max);
    public void generateRandomWidth(int max);
    public void generateRandomHeigth(int max);

    public void generateRandomColor();
    
    public void generateRandomFill();
    
    public abstract Graphics draw(Graphics g);
    
    public int getUpperLeftX();
    public void setUpperLeftX(int upperLeftX);
    public int getUpperLeftY();
    public void setUpperLeftY(int upperLeftY);
    public int getWidth();
    public void setWidth(int width);
    public int getHeigth();
    public void setHeigth(int heigth);
    public boolean isFillFlag();
    public void setFillFlag(boolean fillFlag);
    public Color getColor();
    public void setColor(Color Color);
    public Random getRandom();
    public void setRandom(Random random);
    public Point getCenter();
    @Override
    public String toString();
}
