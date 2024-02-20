using System.Dynamic;

namespace AreaMath
{
    public class Circle : Figure
    {
        private double Radius;
        
        public Circle(double radius){
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }    
}
