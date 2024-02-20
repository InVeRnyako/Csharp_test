using System.Reflection.Metadata.Ecma335;

namespace AreaMath
{
    public class Triangle : Figure
    {
        private double SideOne, SideTwo, SideThree;

        public Triangle(double sideOne, double sideTwo, double sideThree)
        {
            SideOne = sideOne;
            SideTwo = sideTwo;
            SideThree = sideThree;
        }

        public override double CalculateArea()
        {
            // Определить, возможен ли треугольник с данными стронами
            if (!PossibleTriangle())
                return double.NaN; // Треугольник невозможен, возврат ошибки
            switch (SpecialCasesOfArea())
            {
                case 1: // Равносторонний треугольник
                    return SideOne * SideOne * Math.Sqrt(3) / 4;
                case 2: // Прямоугольный треугольник, сторона 3 - гипотенуза
                    return (SideOne * SideTwo) / 2;
                default:
                    double p = (SideOne + SideTwo + SideThree) / 2.0;
                    return Math.Sqrt(p * (p - SideOne) * (p - SideTwo) * (p - SideThree));
            }
        }

        bool PossibleTriangle()
        {
            if (SideOne + SideTwo > SideThree && SideThree + SideOne > SideTwo &&
                SideTwo + SideThree > SideOne){
                    return true;
            } else {
                return false;
            }
        }

        int SpecialCasesOfArea(){
            // Определение на равносторонний треугольник
            if (SideOne == SideTwo && SideOne == SideThree)
                return 1;
            
            // Определение на прямоугольный треугольник
                // Определение наибольшей строны.
            double tempDouble;
            if (SideOne > SideTwo){
                if (SideOne > SideThree){ // Наибольшая сторона 1
                    tempDouble = SideThree;
                    SideThree = SideOne;
                    SideOne = tempDouble;
                } // иначе - Наибольшая сторона 3, переназначение не требуется
            } else {
                if (SideTwo > SideThree){ // Наибольшая сторона 2
                    tempDouble = SideThree;
                    SideThree = SideTwo;
                    SideTwo = tempDouble;
                } // иначе - Наибольшая сторона 3, переназначение не требуется
            }
            // Теорема пифагора
            if (SideOne * SideOne + SideTwo * SideTwo == SideThree * SideThree){ 
                return 2;
            } 
            
            return 0;
        }
    }
}