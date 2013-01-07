using System;
using System.Threading;

namespace Game
{
    class Worm
    {
        private int left;
        private int top;

        static private int specialLeft;
        static private int specialTop;
        static private bool specialEat;

        static public int ASCII;

        public bool existInSanke;

        static private Random worm = new Random();

        public Worm()
        {
            ASCII = 2;
            left = 30;
            top = 30;
            Console.SetCursorPosition(left, top);
            Console.Write((char)ASCII);

            specialLeft = 0;
            specialTop = 0;
            specialEat = false;
            existInSanke = false;

            
        }



        public void generateWorm()
        {
            do
            {
                left = worm.Next(Program.minBorderWidth + 1, Program.maxBorderWidth - 1);
                top = worm.Next(Program.minBorderHeight + 1, Program.maxBorderHeight - 1);
                Program.snake.searchIfExist(left, top);
            } while (existInSanke);
            updateWorm();
        }
        public void updateWorm()
        {
            if (Program.snake.getLeft() == Program.doda.getLeft() && Program.snake.getTop() == Program.doda.getTop())
            {
                Program.addPoint();
                Program.doda.generateWorm();
            }
            Console.SetCursorPosition(Program.doda.left, Program.doda.top);
            Console.Write((char)ASCII);
        }

        public void setSpecialEat(bool check) { specialEat = check; }

        public int getLeft() { return left; }
        public int getTop() { return top; }
        public int getSpecialLeft() { return specialLeft; }
        public int getSpecialTop() { return specialTop; }
        public bool getSpecialEat() { return specialEat; }
    }
}
