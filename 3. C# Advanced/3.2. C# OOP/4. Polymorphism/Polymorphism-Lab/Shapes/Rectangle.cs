using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
        public override double CalculateArea() => this.height * this.width;

        public override double CalculatePerimeter() => 2 * (this.height + this.width);

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
