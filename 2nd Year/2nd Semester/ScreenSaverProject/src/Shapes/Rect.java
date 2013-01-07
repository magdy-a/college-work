package Shapes;

import java.awt.Graphics;


public class Rect extends Shape{

    public Rect() {
        super();
    }
    public Rect(int uX,int uY,int w,int h){
        super(uX, uY, w, h);
    }
    @Override
    public Graphics draw(Graphics g) {
        g.setColor(getColor());
        if(isFillFlag())
            g.fillRect(getUpperLeftX(), getUpperLeftY(), getWidth(), getHeigth());
        else
            g.drawRect(getUpperLeftX(), getUpperLeftY(), getWidth(), getHeigth());
        return g;
    }

}
