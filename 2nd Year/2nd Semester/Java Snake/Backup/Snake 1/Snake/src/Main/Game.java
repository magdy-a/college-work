
package Main;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class Game extends JFrame{
    Game(){
        
        Panel panel = new Panel();
        this.add(panel);
        Snake.GD.setFullScreenWindow(this);
        for(int i = 0 ; i < 200 ; i++){
            try {
                Thread.sleep(100);
            } catch (InterruptedException ex) {
                Logger.getLogger(Game.class.getName()).log(Level.SEVERE, null, ex);
            }
            panel.repaint();
        }
    }
    class Panel extends JPanel{
        Snake snake;
        Panel(){
            snake = new Snake();
            Snake.rndmSnk();
        }

        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            g.setColor(Color.BLUE);
            Snake.draw(g);
            snake.setData(new Point((int)snake.getCenter().getX() + 2,(int)snake.getCenter().getY()));
        }

    }
    
    public static void main(String args[]){
        new Game();

    }
}
