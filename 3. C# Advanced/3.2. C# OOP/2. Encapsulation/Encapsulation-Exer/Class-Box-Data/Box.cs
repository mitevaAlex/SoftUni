using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        protected double Length
        { 
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        protected double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        protected double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double Volume => this.Length * this.Width * this.Height;

        public double SurfaceArea => 2 * (this.Length * this.Width) + this.LateralSurfaceArea;

        public double LateralSurfaceArea => 2 * (this.Length * this.Height + this.Width * this.Height);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea:F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea:F2}");
            sb.Append($"Volume - {this.Volume:F2}");
            return sb.ToString();
        }
    }
}
