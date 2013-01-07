using System;
using System.Threading;
enum SnakeDirection
{
    Right,
    Left,
    Up,
    Down

}
namespace Game
{
    class Program
    {
        static public Point snake;
        static public Point last;
        static public Worm doda;
        static SnakeDirection dodaDirection;

        static public int minBorderWidth;
        static public int maxBorderWidth;
        static public int minBorderHeight;
        static public int maxBorderHeight;
        static public bool isPlaying;

        public static void intialize()
        {
            snake = new Point();
            last = snake;
            doda = new Worm();
            minBorderWidth = 5;
            maxBorderWidth = 74;
            minBorderHeight = 5;
            maxBorderHeight = 54;
            addPoint();
            addPoint();
            snake.setPoint(20, 20);
            isPlaying = true;
            dodaDirection = SnakeDirection.Right;
            drawBordersFullAccess();
        }
        static public void drawBordersFullAccess()
        {
            for (int i = minBorderWidth; i <= maxBorderWidth; i++)//width = 70 ( from 5 to 74 )
            {
                Console.SetCursorPosition(i, maxBorderHeight);
                Console.Write((char)18);
                Console.SetCursorPosition(i, minBorderHeight);
                Console.Write((char)18);
                if (i <= maxBorderHeight)//height = 50 ( from 5 to 54 )
                {
                    Console.SetCursorPosition(minBorderWidth, i);
                    Console.Write((char)29);
                    Console.SetCursorPosition(maxBorderWidth, i);
                    Console.Write((char)29);
                }
            }
                
        }
        static public void addPoint()
        {
            if (snake == last)
            {
                last.next = new Point();
                last.next.updateCoordinates(last.getLeft() - 1, last.getTop());//worng >>> you have to keep it dynamic to not exceed borders or such it self
            }
            last = last.next;
            last.next = new Point();// to delete the last Point in every move
            last.next.updateCoordinates(last.getLeft() - 1, last.getTop());
        }
        static public void takeUserInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo input = new ConsoleKeyInfo();
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.RightArrow) dodaDirection = SnakeDirection.Right;
                if (input.Key == ConsoleKey.LeftArrow) dodaDirection = SnakeDirection.Left;
                if (input.Key == ConsoleKey.UpArrow) dodaDirection = SnakeDirection.Up;
                if (input.Key == ConsoleKey.DownArrow) dodaDirection = SnakeDirection.Down;

            }

            switch (dodaDirection )
            {
                case   SnakeDirection.Up :
                    snake.updateCoordinates(snake.getLeft(), snake.getTop() - 1);
      
                    break;
                case SnakeDirection.Down:
                    snake.updateCoordinates(snake.getLeft(), snake.getTop() + 1);
                
                    break;
                case SnakeDirection.Right:
                    snake.updateCoordinates(snake.getLeft() + 1, snake.getTop());
                           
                    break;
                case SnakeDirection.Left:
                    snake.updateCoordinates(snake.getLeft() - 1, snake.getTop());
                            
                    break;
            }
            doda.updateWorm();     
        }

        static void Main(string[] args)
        {
            Program.intialize();

            while (isPlaying)
            {
                drawGame();
                updateGame();
            }
        }

        private static void updateGame()
        {
            takeUserInput();
            Thread.Sleep(90);
        }

        private static void drawGame()
        {
            snake.Draw();
        }
    }
}