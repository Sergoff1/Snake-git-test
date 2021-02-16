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
        enum Directions { Up, Down, Left, Right, Stand }
        public Rectangle food = new Rectangle();
        public Random R = new Random();
        Brush B = new SolidBrush(Color.Red);
        Directions FoodDir;
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
                food = new Rectangle(R.Next(50, 600), R.Next(40, 350), 20, 20);
                FoodExist = true;
            }
            FoodDir = (Directions)R.Next(0, 4);
            g.FillRectangle(B, food);
        }
        public void FoodDirectory(Field F)
        {
            switch (F.FoodDir)
            {
                case Directions.Up:
                    {
                        F.food = new Rectangle(F.food.X, F.food.Y - 10, 20, 20);
                    }
                    break;
                case Directions.Down:
                    {
                        F.food = new Rectangle(F.food.X, F.food.Y + 10, 20, 20);
                    }
                    break;
                case Directions.Left:
                    {
                        F.food = new Rectangle(F.food.X - 10, F.food.Y, 20, 20);
                    }
                    break;
                case Directions.Right:
                    {
                        F.food = new Rectangle(F.food.X + 10, F.food.Y, 20, 20);
                    }
                    break;
            }
        }
    }
}
