package ScreenSavers;

import Interfaces.ScreenSavers;
import Shapes.Bubble;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class SmileyFaces extends JFrame implements ScreenSavers{

    private panel sF;

    public SmileyFaces() throws InterruptedException {
        super("SmileyFaces");

        setDefaultCloseOperation(EXIT_ON_CLOSE);
        sF = new panel();
        sF.addMouseListener(mouseHandler);
        sF.addMouseMotionListener(mouseHandler);
        sF.setSize(DM.getWidth(), DM.getHeight());
        add(sF);
        GD.setFullScreenWindow(this);

        while(true){
            sF.repaint();
            Thread.sleep(1500);// can taken as input from user ( but not time for it )
        }
    }
    private class panel extends JPanel{
        private boolean first;
        private int screenW;
        private int screenH;
        private final int bubbleW;
        private final int bubbleH;
        private Bubble []bubble;
        private int numberOfBubbles;//can be taken a input form user ( but no time for it )
        public panel() {
            first = true;
            numberOfBubbles = 13;
            bubbleW = 200;
            bubbleH = 200;
            bubble = new Bubble[numberOfBubbles];
            for(int k = 0 ; k < numberOfBubbles ; k ++){
                bubble[k] = new Bubble();
            }
        }
        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            if(first){//first time
                screenW = getWidth();
                screenH = getHeight();
                for(int k = 0 ; k < numberOfBubbles ; k ++){
                    generateRandomValidCoordinates(k);
                }
                first = false;
            }
            for(int k = 0 ; k < numberOfBubbles ; k ++)
                generateRandomValidCoordinates(k);
            for(int k = 0 ; k < numberOfBubbles ; k ++)
                    g = bubble[k].drawFaces(g,true);
        }

        private void generateRandomValidCoordinates(int num){
                int check;
                while(true){
                    check = 0;
                    bubble[num].generateRandomUpperLeftX(screenW - bubbleW);
                    bubble[num].generateRandomUpperLeftY(screenH - bubbleH);
                    bubble[num].setWidth(bubbleW);
                    bubble[num].setHeigth(bubbleH);

                    for(int k = 0 ; k < numberOfBubbles ; k ++)
                        if(k != num)
                            check += bubble[num].isTangent(bubble[k], screenW, screenH)? 1 : 0;
                    if(check == 0)
                        break;
                }
            }
        }
        public static void main(String args[]) throws InterruptedException{
            new SmileyFaces();
    }
}
