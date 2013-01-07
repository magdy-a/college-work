/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ScreenSavers;

import Interfaces.ScreenSavers;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class Whirlpool extends JFrame implements ScreenSavers{
    private panel w;
    public Whirlpool() throws InterruptedException {
        super("Whirlpool");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        w = new panel();
        w.addMouseListener(mouseHandler);
        w.addMouseMotionListener(mouseHandler);
        w.setSize(DM.getWidth(), DM.getHeight());
        add(w);
        GD.setFullScreenWindow(this);


        while(true){
            w.repaint();
            Thread.sleep(10);//can be taken a input form user ( but no time for it )
        }

    }
    
    private class panel extends JPanel{
        
        private int i;
        int x;
        int y;
        private int radius;
        int degree;
        public panel() {
            i = 0;
            degree = 180;
            radius = 10;
        }

        @Override
        protected void paintComponent(Graphics g) {

            if(i == 0){
                super.paintComponent(g);
                x = getWidth()/2;
                y = getHeight()/2;
            }
            i++;
            if(i == 99)//can be taken a input form user ( but no time for it )
            {
                i = 1;
                x = getWidth()/2;
                y = getHeight()/2;
                super.paintComponent(g);
            }
            
            if(i % 2 == 0)
                x = x - 10;
            y = y - 5;
            degree = degree * (-1);
            g.drawArc(x, y, i*radius, i*radius, 0, degree);
        }
        
        
    }
    public static void main(String args[]) throws InterruptedException{
        new Whirlpool();
    }
}
