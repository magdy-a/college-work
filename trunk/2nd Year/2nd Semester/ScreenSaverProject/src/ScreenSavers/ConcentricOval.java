/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ScreenSavers;


import Interfaces.ScreenSavers;
import Shapes.*;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class ConcentricOval extends JFrame implements ScreenSavers{

    private JPanel cO;

    public ConcentricOval() throws InterruptedException {
        super("ConcentricOval");
        setDefaultCloseOperation(EXIT_ON_CLOSE);

        cO = new panel();
        cO.addMouseListener(mouseHandler);
        cO.addMouseMotionListener(mouseHandler);
        cO.setSize(DM.getWidth(), DM.getHeight());
        add(cO);
        GD.setFullScreenWindow(this);

        while(true){
            cO.repaint();
            Thread.sleep(100);// can taken as input from user ( but not time for it )
        }
    }


    public class panel extends JPanel{
        private int Width;
        private int Heigth;
        private int i;
        Shape oval;
        public panel() {
            i = -1;
            oval = new Oval();
        }

        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            i++;
            if(i == 0){
                Width = getWidth();
                Heigth = getHeight();
                super.paintComponent(g);
            }
            if(i == 36){// can taken as input from user ( but not time for it )
                i = 1;
                super.paintComponent(g);
            }
            for(int k = i ; k >= 0 ; k --){
                oval.setBorders(Width/2-(k*10), Heigth/2-(k*10), k*20, k*20);
                oval.generateRandomColor();
                oval.setFillFlag(true);
                g = oval.draw(g);
            }
        }


    }
    
    public static void main(String args[]) throws InterruptedException{
        new ConcentricOval();
    }
}
