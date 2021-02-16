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
        public enum Directions {Up,Down,Left,Right}
        public Directions direct;
        bool complexity = false;
        Rectangle prev_segment, segment;
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
            if (snake[0].Y > g.Height)
                snake[0] = new Rectangle(snake[0].X, 0, 20, 20);
            if (snake[0].Y < 0)
                snake[0] = new Rectangle(snake[0].X, g.Height, 20, 20);
            if (snake[0].X > g.Width)
                snake[0] = new Rectangle(0, snake[0].Y, 20, 20);
            if (snake[0].X < 0)
               snake[0] = new Rectangle(g.Width, snake[0].Y, 20, 20);
        }
        public void Move(Snakes Python)
        {
            switch (Python.direct)
            {
                case Snakes.Directions.Up:
                    {
                        Python.prev_segment = new Rectangle(Python.snake[0].X, Python.snake[0].Y - 20, 20, 20);
                    }
                    break;
                case Snakes.Directions.Down:
                    {
                        Python.prev_segment = new Rectangle(Python.snake[0].X, Python.snake[0].Y + 20, 20, 20);
                    }
                    break;
                case Snakes.Directions.Left:
                    {
                        Python.prev_segment = new Rectangle(Python.snake[0].X - 20, Python.snake[0].Y, 20, 20);
                    }
                    break;
                case Snakes.Directions.Right:
                    {
                        Python.prev_segment = new Rectangle(Python.snake[0].X + 20, Python.snake[0].Y, 20, 20);
                    }
                    break;
            }
            for (int i = 0; i < Python.snake.Count; i++)
            {
                Python.segment = Python.snake[i];
                Python.snake[i] = Python.prev_segment;
                Python.prev_segment = Python.segment;
            }
        }
        public void Complexity(Snakes Python, Timer timer1)
        {
            if (Python.EatYourselve())
                Python.snake.RemoveRange(Python.snake.Count - Python.snake.Count / 3, Python.snake.Count / 3);
            if (Python.snake.Count % 5 == 0 && timer1.Interval > 50 && !complexity)
            {
                timer1.Interval -= 20;
                complexity = true;
            }
        }
        public void IsEat(Snakes Python, Field F)
        {
            if (Math.Abs(Python.snake[0].X - F.food.X) <= 20 && Math.Abs(Python.snake[0].Y - F.food.Y) <= 20)
            {
                F.FoodExist = false;
                Python.snake.Add(new Rectangle(Python.snake[Python.snake.Count - 1].X, Python.snake[Python.snake.Count - 1].Y, 20, 20));
                complexity = false;
            }
        }
    }
}
