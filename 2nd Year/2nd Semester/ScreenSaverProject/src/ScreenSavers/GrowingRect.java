/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ScreenSavers;

import Interfaces.ScreenSavers;
import java.awt.Graphics;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JPanel;
import Shapes.*;
import java.awt.Color;

public class GrowingRect extends JFrame implements ScreenSavers{

    private JPanel gR;
    private GrowingRect frame;
    static int r = 255;
    static int g = 255;
    static int b = 255;
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

    public GrowingRect() throws InterruptedException {
        super("GrowingRect");
        frame = this;
        gR = new panel();

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        gR.setSize(DM.getWidth(), DM.getHeight());
        gR.addMouseListener(mouseHandler);
        gR.addMouseMotionListener(mouseHandler);
        add(gR);
        GD.setFullScreenWindow(this);

        while(true){
            gR.repaint();
            Thread.sleep(100);// can taken as input from user ( but not time for it )
        }
    }

    private class panel extends JPanel{
        private int i;
        private int Width;
        private int Height;
        Shape rect;

        public panel() {
            i = -1;
            rect = new Rect();
        }
        

        @Override
        public void paintComponent(Graphics g){
            i++;
            if(i == 0)
            {
                Width = getWidth();
                Height = getHeight();
                super.paintComponent(g);
            }
            if (i == 51)// can taken as input from user ( but not time for it )
            {
                i = 1;
                //super.paintComponent(g);
            }
            rect.setColor(getConsecutiveColor());
            rect.setFillFlag(true);

            rect.setBorders(i*5, i*5, i*10, i*10);
            g = rect.draw(g);
            rect.setBorders(Width - i*15, Height - i*15, i*10, i*10);
            g = rect.draw(g);
            rect.setBorders(Width - i*15, i*5, i*10, i*10);
            g = rect.draw(g);
            rect.setBorders(i*5, Height - i*15, i*10, i*10);
            g = rect.draw(g);
        }
    }
    
    public static void main(String args[]) throws InterruptedException{
        new GrowingRect();
    }
}
