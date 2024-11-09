using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labb_3
{
    public class Geometry
    {
        // Virtual method, all shapes have an area
        // And will be overrided by the derived classes
        public virtual double Area()
        {
            // No implementation, cause each shape calculates differently.
            return 0;
        }
        public virtual double Circumference()
        {
            return 0;
        }
    }
    public class Rectangle : Geometry
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public Rectangle()
        {
            SideA = 4;
            SideB = 6;
        }
        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException($"Invalid value {a}. Length and width must be positive");
            }
            SideA = a;
            SideB = b;
        }
        // Override the Area method from parent class
        // gives specific implementation of the rectangles area
        public override double Area()
        {

            return SideA * SideB;
        }
        public override double Circumference()
        {
            return SideA * 2 + SideB * 2;
        }
    }
    public class Square : Geometry
    {
        public double Side { get; set; }
        public Square()
        {
            Side = 5;
        }
        public Square(double a)
        {
            if (a <= 0)
            {
                throw new ArgumentException($"The value {a} must pe positive.");
            }
            Side = a;
        }
        // Override the Area method from parent class
        // gives specific implementation of the squares area
        public override double Area()
        {
            return Side * Side;
        }
        public override double Circumference()
        {
            return Side * 4;
        }
    }
    public class Circle : Geometry
    {
        public double Radius { get; set; }
        public Circle()
        {
            Radius = 3;
        }
        public Circle(double a)
        {
            if (a <= 0)
            {
                throw new ArgumentException("Invalid value {a}. Radius must be positive number.");
            }
            Radius = a;
        }
        // Override the Area method from parent class
        // gives specific implementation of the circles area
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public override double Circumference()
        {
            return 2 * Math.PI * Radius;
        }
    }
    public class Triangle : Geometry
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public bool IsRightTriangle { get; set; }
        public Triangle()
        {
            SideA = 2.5;
            SideB = 4;
            IsRightTriangle = true;
        }
        // Construct for general Triangle
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException($"Invalid value {a}, length of any side must be positive");
            }
            SideA = a;
            SideB = b;
            SideC = c;
            IsRightTriangle = false;
        }
        // Construct for right-angled triangle
        public Triangle(double a, double b, bool isRightTriangle)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException($"Invalid value {a}. Length of any side must be positive");
            }
            SideA = a;
            SideB = b;
            IsRightTriangle = isRightTriangle;
            // Calculate hypotenuse
            if (isRightTriangle)
            {
                SideC = Math.Sqrt(Math.Pow(SideA, 2) + Math.Pow(SideB, 2));
            }
        }
        public override double Area()
        {
            double area;
            if (IsRightTriangle)
            {
                return SideA * SideB / 2;
            }
            else
            {
                // Use Herons formula to calculate area of a general triangle
                double s = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
            }
        }
        public override double Circumference()
        {
            double circumference;
            if (IsRightTriangle)
            {
                // Circumference of right-angled Triangle
                return SideA + SideB + SideC;
            }
            else
            {
                // Circumference of general Triangle
                return SideA + SideB + SideC;
            }
        }
    }
}
