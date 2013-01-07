
package ScreenSavers;

import Interfaces.ScreenSavers;
import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class RectWhirlpool extends JFrame implements ScreenSavers{
    private panel rW;
    public RectWhirlpool() throws InterruptedException {
        super("RectWhirlpool");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        rW = new panel();
        rW.addMouseListener(mouseHandler);
        rW.addMouseMotionListener(mouseHandler);
        rW.setSize(DM.getWidth(), DM.getHeight());
        add(rW);
        GD.setFullScreenWindow(this);
        
        while(true){
            rW.repaint();
            Thread.sleep(10);// can taken as input from user ( but not time for it )
        }

    }

    private class panel extends JPanel{
        private int i;
        private int x;
        private int y;
        private int lineLength;
        Color c;
        public panel(){
            lineLength = 10;
            i = -1;
        }
            @Override
        protected void paintComponent(Graphics g) {
            i++;
            if( i == 0){
                super.paintComponent(g);
                x = getWidth()/2;
                y = getHeight()/2;
            }
            if(i == 95){
                i = 1;
                x = getWidth()/2;
                y = getHeight()/2;
                lineLength = 10;
                super.paintComponent(g);
            }
            c = new Color(random.nextInt(256),random.nextInt(256),random.nextInt(256));
            g.setColor(c);



            g.drawLine(x, y, x, y+(lineLength*i));
            y = y + (lineLength*i);

            c = new Color(random.nextInt(256),random.nextInt(256),random.nextInt(256));
            g.setColor(c);

            g.drawLine(x, y, x - (lineLength*i), y);
            x = x - (lineLength*i);
            lineLength =  - lineLength;
            
        }
    }
    public static void main(String args[]) throws InterruptedException{
        new RectWhirlpool();
    }
}
