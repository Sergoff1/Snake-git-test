using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    class Field
    {
        public bool FoodExist;
        public Graphics ParentGraphics;
        Control ParentControl;
        public Rectangle Dimensions { get; private set; }
        public Rectangle food = new Rectangle();
        public Random R = new Random();
        Brush B = new SolidBrush(Color.Red);
        public Snakes.Directions FoodDir;
        public Field(Control parent_control, Rectangle dimensions)
        {
            this.Dimensions = dimensions;
            this.ParentControl = parent_control;
            this.ParentGraphics = Graphics.FromHwnd(parent_control.Handle);

        }
        public void DrawFood(Graphics g)
        {
            if (!FoodExist)
            {
                food = new Rectangle(R.Next(0, 620), R.Next(0, 395), 20, 20);
                FoodExist = true;
            }
            FoodDir = (Snakes.Directions)R.Next(0, 4);
            g.FillRectangle(B, food);
        }
    }
}
