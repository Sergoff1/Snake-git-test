using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Field F;
        Snakes Python;
        
        public Form1()
        {
            InitializeComponent();
            F = new Field(PB_Field,new Rectangle(0,0,PB_Field.Width,PB_Field.Height));
            Python = new Snakes();
            timer1.Interval = 200; 
            timer1.Enabled = true;
            F.FoodExist = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
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
            Python.DrawSnake(F.ParentGraphics);
            F.DrawFood(F.ParentGraphics);
            if (Math.Abs(Python.snake[0].X - F.food.X) <= 20 && Math.Abs(Python.snake[0].Y - F.food.Y) <= 20)
            {
                F.FoodExist = false;
                Python.snake.Add(new Rectangle(Python.snake[Python.snake.Count-1].X+20, Python.snake[Python.snake.Count - 1].Y + 20, 20, 20));
                F.DrawFood(F.ParentGraphics);
            }
            switch (F.FoodDir)
            {
                case Snakes.Directions.Up:
                    {
                        F.food = new Rectangle(F.food.X, F.food.Y - 5, 20, 20);
                    }
                    break;
                case Snakes.Directions.Down:
                    {
                        F.food = new Rectangle(F.food.X, F.food.Y + 5, 20, 20);
                    }
                    break;
                case Snakes.Directions.Left:
                    {
                        F.food = new Rectangle(F.food.X - 5, F.food.Y, 20, 20);
                    }
                    break;
                case Snakes.Directions.Right:
                    {
                        F.food = new Rectangle(F.food.X + 5, F.food.Y, 20, 20);
                    }
                    break;
            }
            if (Python.EatYourselve()) 
                Python.snake.RemoveRange(Python.snake.Count - Python.snake.Count / 3, Python.snake.Count / 3);
            Python.Border(PB_Field);            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && Python.direct != Snakes.Directions.Down)
                Python.direct = Snakes.Directions.Up;
            else if (e.KeyCode == Keys.Down && Python.direct != Snakes.Directions.Up)
                Python.direct = Snakes.Directions.Down;
            else if (e.KeyCode == Keys.Left && Python.direct != Snakes.Directions.Right)
                Python.direct = Snakes.Directions.Left;
            else if (e.KeyCode == Keys.Right && Python.direct != Snakes.Directions.Left)
                Python.direct = Snakes.Directions.Right;
        }
    }
}
