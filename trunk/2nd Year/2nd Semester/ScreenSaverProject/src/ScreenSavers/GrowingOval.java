/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ScreenSavers;

import Interfaces.ScreenSavers;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;
import Shapes.*;
import java.awt.Color;

public class GrowingOval extends JFrame implements ScreenSavers{

    private JPanel gO;
    static int r = 0;
    static int g = 0;
    static int b = 0;
    public Color getConsecutiveColor(){
         int change = random.nextInt(50);

        b += change;

        if ( b > 255)
        {
            b = b % 255;
            g += change;
        }

        if ( g > 255 )
        {
            g = g%255;
            r += change;
        }

        if ( r > 255 )
        {
            r = r % 255;
        }

        return new Color(r, g, b);
    }

    public GrowingOval() throws InterruptedException {
        super("GrowingOval");

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        gO = new panel();
        gO.addMouseListener(mouseHandler);
        gO.addMouseMotionListener(mouseHandler);
        gO.setSize(DM.getWidth(), DM.getHeight());
        add(gO);
        GD.setFullScreenWindow(this);

        while(true){
            gO.repaint();
            Thread.sleep(50);// can taken as input from user ( but not time for it )
        }
    }

    private class panel extends JPanel{
        private int i;
        int Width;
        int Height;

        Shape oval;

        panel(){
            i = -1;
            oval = new Oval();
        }
        @Override
        protected void paintComponent(Graphics g) {
        i++;
        //super.paintComponent(g);
        if(i == 0){
            Width  = getWidth();
            Height = getHeight();
        }
        if (i == 170)// can taken as input from user ( but not time for it )
        {
            i=1;
        }
        oval.setColor(getConsecutiveColor());
        oval.setFillFlag(true);
        oval.setBorders(i*5, i*5, i*10, i*10);
        g = oval.draw(g);
        oval.setBorders(Width - i*15, Height - i*15, i*10, i*10);
        g = oval.draw(g);
        oval.setBorders(Width - i*15, i*5, i*10, i*10);
        g = oval.draw(g);
        oval.setBorders(i*5, Height - i*15, i*10, i*10);
        g = oval.draw(g);
        
        }
        
    }

    public static void main(String agrs[]) throws InterruptedException{
        new GrowingOval();
    }
}
