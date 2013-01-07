package Interfaces;

import java.awt.DisplayMode;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.util.Random;

public interface ScreenSavers {

    GraphicsEnvironment GE = GraphicsEnvironment.getLocalGraphicsEnvironment();
    GraphicsDevice GD = GE.getDefaultScreenDevice();
    DisplayMode DM = GD.getDisplayMode();

    Random random = new Random();

    MouseHandler mouseHandler = new MouseHandler();

    class MouseHandler implements MouseListener,MouseMotionListener{
        public void mouseClicked(MouseEvent e) {
            System.exit(0);
        }
        public void mousePressed(MouseEvent e) {
        }
        public void mouseReleased(MouseEvent e) {
        }
        public void mouseEntered(MouseEvent e) {
        }
        public void mouseExited(MouseEvent e) {
        }
        public void mouseDragged(MouseEvent e) {
        }
        public void mouseMoved(MouseEvent e) {
        }
    }
}