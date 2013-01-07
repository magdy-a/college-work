
package Shapes;

import java.awt.Graphics;

public class Oval extends Shape{

    public Oval() {
        super();
    }
    public Oval(int uX,int uY,int w,int h){
        super(uX, uY, w, h);
    }


    @Override
    public Graphics draw(Graphics g) {
        g.setColor(getColor());
        if(isFillFlag())
            g.fillOval(getUpperLeftX(), getUpperLeftY(), getWidth(), getHeigth());
        else
            g.drawOval(getUpperLeftX(), getUpperLeftY(), getWidth(), getHeigth());
        return g;
    }

    public double getRadius() {

        return getWidth()*1.0/2;
    }
    
}
