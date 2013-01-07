
package Main;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class Game extends JFrame{

    Snake snake;

    Game() {
        Panel panel = new Panel();
        this.add(panel);
        this.addKeyListener(new KeyHandler());
        Snake.getGD().setFullScreenWindow(this);
        while(true){
            try {
                Thread.sleep(250);
            } catch (InterruptedException ex) {
                Logger.getLogger(Game.class.getName()).log(Level.SEVERE, null, ex);
            }
            panel.repaint();
        }
    }
    class Panel extends JPanel{
        
        Panel(){
           snake = new Snake();
        }

        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            g.setColor(Color.RED);
            Snake.draw(g);
            Snake.move();
        }

    }

    class KeyHandler implements KeyListener{

        public void keyTyped(KeyEvent e) {
        }

        public void keyPressed(KeyEvent e) {
            //changing the direction of the snake by increasing or
            //decreasing the dir of Actions: right arrow or left arrow respectively
            int dir = Snake.getFirst().getDir();
            if(e.getKeyCode() == KeyEvent.VK_LEFT){
                dir --;
                if(dir == -1){
                    dir = 7;
                }
            }else if(e.getKeyCode() == KeyEvent.VK_RIGHT){
                dir ++;
                if(dir == 8){
                    dir = 0;
                }
            }else if(e.getKeyCode() == KeyEvent.VK_ESCAPE){
                System.exit(0);
            }
            Snake.getFirst().setDir(dir);//**********it should be linked by other points
        }

        public void keyReleased(KeyEvent e) {
        }

    }

    public static void main(String args[]){
        new Game();

    }
}
