using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    class Snakes
    {
        public List<Rectangle> snake = new List<Rectangle>();
        public enum Directions {Up,Down,Left,Right,Stand}
        public Directions direct;
        public Rectangle prev_segment, segment;
        public Snakes()
        {
            snake.Add(new Rectangle(300, 200, 20, 20));
            snake.Add(new Rectangle(300, 220, 20, 20));
            snake.Add(new Rectangle(300, 240, 20, 20));
        }
        public void DrawSnake(Graphics g)
        {
            Brush body = new SolidBrush(Color.Green);
            Brush head = new SolidBrush(Color.Blue);
            g.FillRectangle(head, snake[0]);
            for (int i = 1; i < snake.Count; i++)
                g.FillRectangle(body, snake[i]);
        }
        public bool EatYourselve()
        {
            bool c=false;
            for (int i = 1; i < snake.Count; i++)
                if (snake[0] == snake[i])
                    c = true;
            return c;
        }
        public void Border(Control g)
        {
            if (snake[0].Y >= g.Height)
                snake[0] = new Rectangle(snake[0].X, 0, 20, 20);
            if (snake[0].Y <= 0)
                snake[0] = new Rectangle(snake[0].X, g.Height, 20, 20);
            if (snake[0].X >= g.Width)
                snake[0] = new Rectangle(0, snake[0].Y, 20, 20);
            if (snake[0].X <= 0)
               snake[0] = new Rectangle(g.Width, snake[0].Y, 20, 20);
        }
    }
}
