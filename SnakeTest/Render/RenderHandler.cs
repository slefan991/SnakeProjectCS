using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest.Render
{
    internal class RenderHandler
    {

        public void GameRender()
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            //Console Width: 120, Console Height: 30

            //Draws scoreboard border top
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("╔" + new string('═', windowWidth - 2) + "╗");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("║" + new string(' ', windowWidth - 2) + "║");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("║" + new string(' ', windowWidth - 2) + "║");

            //Draws top border
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("╠" + new string('═', windowWidth - 2) + "╣");

            //Draws side borders
            for (int i = 4; i < windowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║" + new string(' ', windowWidth - 2) + "║");

            }

            //Draws bottom border
            Console.SetCursorPosition(0, windowHeight - 1);
            Console.Write("╚" + new string('═', windowWidth - 2) + "╝");
        }
        
    }


}
