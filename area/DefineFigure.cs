using System.Runtime.ConstrainedExecution;

namespace AreaMath
{
    class DefineFigure
    {
        const int Circle = 1;
        const int Triangle = 3;
        string[] InputSplit;
        public DefineFigure(string inputString){
            InputSplit = inputString.Split(';');
        }

        public (int, double[]) define(){
            if (InputSplit.Length < 2){ // Минимальное количество аргументов - 2 (у круга)
                return (0, new double[0]);
            }
            if (InputSplit[0].Equals("0")){ // Тип фигуры не предопределен
                switch(InputSplit.Length - 1)
                {
                    case Circle:
                        return(1, StringToDoubleAfterFirst(InputSplit));
                    case Triangle:
                        return(3, StringToDoubleAfterFirst(InputSplit));
                }
            }
            return (int.Parse(InputSplit[0]), StringToDoubleAfterFirst(InputSplit));
        }

        public double[] StringToDoubleAfterFirst(string[] inputString){
            List<double> output = new List<double>();
            for (int i = 1; i < inputString.Length; i++)
            {
                output.Add(double.Parse(inputString[i]));
            }
            return output.ToArray();
        }
    }
}