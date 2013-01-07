
package ScreenSavers;

import Interfaces.ScreenSavers;
import Shapes.Bubble;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class MovingSmileyFaces extends JFrame implements ScreenSavers{

    private panel mSF;

    public MovingSmileyFaces() throws InterruptedException {
        super("MovingSmileyFaces");

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        mSF = new panel();
        mSF.addMouseListener(mouseHandler);
        mSF.addMouseMotionListener(mouseHandler);
        mSF.setSize(DM.getWidth(), DM.getHeight());
        add(mSF);
        GD.setFullScreenWindow(this);

        while(true){

            mSF.repaint();
            Thread.sleep(15);// can taken as input from user ( but not time for it )
        }

    }

    private class panel extends JPanel{
        private boolean first;
        private int screenW;
        private int screenH;
        private final int bubbleW;
        private final int bubbleH;
        private Bubble []bubble;
        private int numberOfBubbles; // can taken as input from user ( but not time for it )
        private boolean []checkOfChange;
        private int[] checkOfBubbles;

        public panel() {
            first = true;
            numberOfBubbles = 10;
            bubbleW = 200;
            bubbleH = 200;
            bubble = new Bubble[numberOfBubbles];
            checkOfBubbles = new int[numberOfBubbles];
            checkOfChange = new boolean[numberOfBubbles];
            for(int k = 0 ; k < numberOfBubbles ; k ++){
                bubble[k] = new Bubble();
                generateRandomDirection(k);
            }
     }
        @Override
        protected void paintComponent(Graphics g) {
            if(first){
                screenW = getWidth();
                screenH = getHeight();
                for(int k = 0 ; k < numberOfBubbles ; k ++){
                    generateRandomValidCoordinates(k);
                    g = bubble[k].drawFaces(g,true);
                }
                first = false;
            }
            super.paintComponent(g);

            reactionMove();

            for(int f = 0 ; f < numberOfBubbles ; f ++)
                    g = bubble[f].drawFaces(g, checkOfChange[f]);
            for(int f = 0 ; f < numberOfBubbles ; f ++)
                checkOfChange[f] = false;
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
            int speed = 5;
            switch(random.nextInt(3)){//random X direction
                case 0:
                    bubble[k].setDirX(-speed);
                    break;
                case 1:
                    bubble[k].setDirX(speed);
                    break;
                case 2:
                    xZero = true;
                    bubble[k].setDirX(0);
                    break;
            }
            switch(random.nextInt(3)){//random Y direction
                case 0:
                    bubble[k].setDirY(-speed);
                    break;
                case 1:
                    bubble[k].setDirY(speed);
                    break;
                case 2:
                    if(xZero)
                        switch(random.nextInt(2)){
                            case 0:
                                bubble[k].setDirY(-speed);
                                break;
                            case 1:
                                bubble[k].setDirY(speed);
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
                for(int j = 0 ; j < numberOfBubbles ; j ++)
                    if(checkOfBubbles[j] > 0)
                        checkOfChange[j] = true;

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
                    if(bubble[k].isTangent(bubble[j])){
                        checkOfBubbles[k] ++;
                    }
                }
                if(bubble[k].isTangent(screenW, screenH)){
                    checkOfBubbles[k] ++;
                }
        }
    }

    public static void main(String args[]) throws InterruptedException{
        new MovingSmileyFaces();
    }
}
