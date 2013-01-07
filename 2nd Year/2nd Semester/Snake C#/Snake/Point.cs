using System;

namespace Game
{
    class Point
    {
        private int left;
        private int top;
        private int num;
        private static int length = 0;
        public Point next = null;
        static public int ASCII;

        public Point()
        {
            num = ++length;
            left = 0;
            top = 0;
            ASCII = 1;
        }
        public void Draw()
        {
            Console.SetCursorPosition(left, top);
            Console.Write((char)ASCII);
            if (next != null)
                next.Draw();
        }
        public void updateCoordinates(int x, int y)
        {
            int a, b;
            a = left;
            b = top;
            if (x < 74 && x > 5)
                left = x;
            else if (x == 74)
                left = 6;
            else
                left = 73;

            if (y < 54 && y > 5)
                top = y;
            else if (y == 54)
                top = 6;
            else
                top = 53;
            if (next != null)
                next.updateCoordinates(a, b);
            else
            {
                Console.SetCursorPosition(a, b);
                Console.Write((char)0);
            }
        }
        public void searchIfExist(int x, int y)
        {
            Program.doda.existInSanke = false;
            if (left == x && top == y)
                Program.doda.existInSanke = true;
            else if (next != null)
                next.searchIfExist(x, y);
        }
        //public bool crash()
        //{
        //    searchIfExist(Program.snake.getLeft(), Program.snake.getTop());
        //    if (Program.doda.existInSanke)
        //    {

        //    }
        //    return false;
        //}
        public void setPoint(int x, int y){left = x;
            top = y;}

        public int getLeft() { return left; }
        public int getTop() { return top; }
        public int getNum() { return num; }
        public int getLength() { return length; }
    }
}
