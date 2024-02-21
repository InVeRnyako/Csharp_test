// Программа-оболочка для проверки работоспособности библиотеки

using System.Collections;
using System.Text;
using AreaMath;

class Program
{
    static void Main(string[] args)
    {
        String inputString = "";
        if (inputString.Length > 0){ // Возможность програмного редактирования входящих данных по необходимости
            // 
        } else { 
            StringBuilder inputStringBuilder = new StringBuilder();
            // ! Проверки на правильность введенных данных на этом этапе не проводятся
            Console.WriteLine("ВНИМАНИЕ! Данная оболочка не поддерживает заведомо неправильно вводимые данные");
            Console.WriteLine("Выберите тип фигуры:\n0. Без указания типа фигуры\n1. Круг\n3. Треугольник");
            inputStringBuilder.Append(Console.ReadLine());
            int ShapeSides = 0;
            switch (int.Parse(inputStringBuilder.ToString())){
                case 0:
                    Console.WriteLine("Введите количество сторон фигуры (1 для круга)");
                    ShapeSides = int.Parse(Console.ReadLine());
                    break;
                case 1:
                    ShapeSides = 1;
                    break;
                case 3:
                    ShapeSides = 3;
                    break;
                default:
                    Console.WriteLine("Ошибка ввода данных");
                    return;
            }
            for (int i = 0; i < ShapeSides; i++)
            {
                Console.WriteLine("Введите сторону #" + (i+1).ToString() + ":");
                inputStringBuilder.Append(';');
                inputStringBuilder.Append(Console.ReadLine());
            }
            inputString = inputStringBuilder.ToString();
            Console.WriteLine(inputString);
        }
        Area area = new Area();
        double output = area.Calculate(inputString);
        Console.WriteLine(output);
        if (double.IsNaN(output) || output == 0.0){
            Console.WriteLine("Ошибка рассчета площади. Проверьте вводимые данные");
        } else {
            Console.WriteLine(output);
        }
        
    }
}