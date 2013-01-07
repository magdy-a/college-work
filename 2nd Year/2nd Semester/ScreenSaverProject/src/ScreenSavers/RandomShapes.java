/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ScreenSavers;
import Interfaces.ScreenSavers;
import Shapes.*;
import java.awt.Component;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class RandomShapes extends JFrame implements ScreenSavers{
    private JFrame frame;
    private JPanel rS;

    private RandomShapes() throws InterruptedException {
        super("RandomShapes");
        frame = this;

        rS = new panel();

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        rS.addMouseListener(mouseHandler);
        rS.addMouseMotionListener(mouseHandler);
        rS.setSize(DM.getWidth(),DM.getHeight());
        add(rS);
        GD.setFullScreenWindow(frame);

        while(true){
            rS.repaint();
            Thread.sleep(1000);// can taken as input from user ( but not time for it )
        }
    }

    @Override
    public Component add(Component comp) {
        return super.add(comp);
    }

    private class panel extends JPanel {
        Shape []shape;
        public panel() {
            update();
        }

        private void update()
        {
            shape = new Shape[30+random.nextInt(30)];// can taken as input from user ( but not time for it )
            int tmp = random.nextInt(30);
            for(int i = 0;i<tmp;i++)
                shape[i] = new Oval();
            for(int i = tmp;i<shape.length;i++)
                shape[i] = new Rect();
        }
        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            update();
            for(int i=0;i<shape.length;i++){

                do{
                    shape[i].generateRandomAll(900);
            }while(shape[i].getUpperLeftX() + shape[i].getWidth() > getWidth() || shape[i].getUpperLeftY() + shape[i].getHeigth() > getHeight());
                shape[i].draw(g);
                g.drawLine(5, 5, 5, 12);
            }
        }
    }

    public static void main(String args[]) throws InterruptedException{
        new RandomShapes();
    }
}
