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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            Python.Move(Python);
            Python.IsEat(Python,F);
            Python.Complexity(Python,timer1);
            Python.Border(PB_Field);
            Python.DrawSnake(F.ParentGraphics);
            F.FoodDirectory(F);
            F.DrawFood(F.ParentGraphics);
            L_Score.Text = "Счёт: " + Convert.ToString(Python.snake.Count-3);
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
            if (e.KeyCode == Keys.P && timer1.Enabled == true)
                timer1.Enabled = false;
            else if (e.KeyCode == Keys.P && timer1.Enabled == false)
                timer1.Enabled = true;
        }


    }
}
