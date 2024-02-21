namespace AreaMath
{
    public class Area
    {
        // Принять входящую строку, отправить строку на определение типа фигуры, получившиеся данные
        //  формата (тип_фигуры;сторона1[;сторона2;сторона3]) отправить на обработку соответствующему типу фигуры
        private int FigureTypeId;
        private double[] FigureMeasures;

        // Список id поддерживаемых фигур, простой вариант
        const int Circle = 1;
        const int Triangle = 3;

        public double Calculate(string inputString)
        {
            if (inputString.Contains('-'))
                return 0.0;
            // Отправить строку на определение типа фигуры
            (int, double[]) definedFigure = new DefineFigure(inputString).define();
            // Назначить класс вычисления соответствующий фигуре
            Figure figure;
            switch (definedFigure.Item1)
            {
                case Circle:
                    figure = new Circle(definedFigure.Item2[0]);
                    break;
                case Triangle:
                    figure = new Triangle(definedFigure.Item2[0], definedFigure.Item2[1], definedFigure.Item2[2]);
                    break;
                default:
                    return 0.0;
            }
            return figure.CalculateArea();
        }
    }
}