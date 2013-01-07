
package ScreenSavers;

import Interfaces.ScreenSavers;
import Shapes.Bubble;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class MovingBubbles extends JFrame implements ScreenSavers{

    private panel mB;
    public MovingBubbles() throws InterruptedException {
        super("MovingBubbles");

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        mB = new panel();
        mB.addMouseListener(mouseHandler);
        mB.addMouseMotionListener(mouseHandler);
        mB.setSize(DM.getWidth(), DM.getHeight());
        add(mB);
        GD.setFullScreenWindow(this);

        while(true){

            mB.repaint();
            Thread.sleep(50);
            
        }
    }


    private class panel extends JPanel{
        private int numOfRepaint;
        private int screenW;
        private int screenH;
        private int bubbleW;//can be taken a input form user ( but no time for it )
        private int bubbleH;//can be taken a input form user ( but no time for it )
        private Bubble []bubble;
        private int numberOfBubbles;//can be taken a input form user ( but no time for it )


        private int[] checkOfBubbles;

        public panel() {

            

            numOfRepaint = 1;
            numberOfBubbles = 20;
            bubbleW = 100;
            bubbleH = 100;
            bubble = new Bubble[numberOfBubbles];
            checkOfBubbles = new int[numberOfBubbles];

            for(int k = 0 ; k < numberOfBubbles ; k ++){
                bubble[k] = new Bubble();
                generateRandomDirection(k);
            }
     }
        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            if(numOfRepaint == 1){
                screenW = getWidth();
                screenH = getHeight();
                for(int k = 0 ; k < numberOfBubbles ; k ++)
                    generateRandomValidCoordinates(k);
                numOfRepaint ++;
            }
            
            reactionMove();
            for(int k = 0 ; k < numberOfBubbles ; k ++)
                g = bubble[k].draw(g);
        }

        private void generateRandomValidCoordinates(int k){
            int check;
            bubble[k].setWidth(bubbleW);
            bubble[k].setHeigth(bubbleH);
            while(true){
                check = 0;
                bubble[k].generateRandomUpperLeftX(screenW - bubbleW);
                bubble[k].generateRandomUpperLeftY(screenH - bubbleH);
                for(int j = 0 ; j < numberOfBubbles ; j ++)
                    if(j != k)
                        check += bubble[k].isTangent(bubble[j], screenW, screenH)? 0 : 1;
                if(check == numberOfBubbles-1)
                    break;
            }
        }
        private void generateRandomDirection(int k){
            
            boolean xZero = false;
            int pixels = 10;
            switch(random.nextInt(3)){//random X direction
                case 0:
                    bubble[k].setDirX(-pixels);
                    break;
                case 1:
                    bubble[k].setDirX(pixels);
                    break;
                case 2:
                    xZero = true;
                    bubble[k].setDirX(0);
                    break;
            }
            switch(random.nextInt(3)){//random Y direction
                case 0:
                    bubble[k].setDirY(-pixels);
                    break;
                case 1:
                    bubble[k].setDirY(pixels);
                    break;
                case 2:
                    if(xZero)
                        switch(random.nextInt(2)){
                            case 0:
                                bubble[k].setDirY(-pixels);
                                break;
                            case 1:
                                bubble[k].setDirY(pixels);
                                break;
                        }
                    else
                        bubble[k].setDirY(0);
                    break;
            }
        } 
        private void reactionMove(){
            boolean cleanMove = false;
            while( ! cleanMove ){
                stepForward();
                for(int j = 0 ; j < numberOfBubbles ; j ++){
                    checkOfBubbles[j] = 0;
                    checkBubble(j);
                }

                cleanMove = true;
                for(int j = 0 ; j < numberOfBubbles ; j ++)
                    if(checkOfBubbles[j] > 0){
                        cleanMove = false;
                        stepBackward();
                        break;
                    }
           
                        

                for(int x = 0 ; x < numberOfBubbles ; x++){
                    if(checkOfBubbles[x] > 0)
                        generateRandomDirection(x);
                }
            }
        }
        private void stepForward(){
            for(int j = 0 ; j < numberOfBubbles ; j++){
                bubble[j].setUpperLeftX(bubble[j].getUpperLeftX() + bubble[j].getDirX());
                bubble[j].setUpperLeftY(bubble[j].getUpperLeftY() + bubble[j].getDirY());
            }
        }
        private void stepBackward(){
            for(int j = 0 ; j < numberOfBubbles ; j++){
                bubble[j].setUpperLeftX(bubble[j].getUpperLeftX() - bubble[j].getDirX());
                bubble[j].setUpperLeftY(bubble[j].getUpperLeftY() - bubble[j].getDirY());
            }
        }
        private void checkBubble(int k){
            for(int j = 0 ; j < numberOfBubbles ; j ++)
                if(j != k){
                    checkOfBubbles[k] += bubble[k].isTangent(bubble[j])?  1 : 0;
                }

                checkOfBubbles[k] += bubble[k].isTangent(screenW, screenH)? 1 : 0;
        }
    }
    
    public static void main(String args[]) throws InterruptedException{
        new MovingBubbles();
    }
}
