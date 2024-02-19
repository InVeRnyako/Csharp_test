// Программа-оболочка для проверки работоспособности библиотеки


using System.Collections;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder inputString = new StringBuilder(); 
        if (inputString.Length > 0){ // Возможность програмного редактирования входящих данных по необходимости
            // 
        } else { 
            // ! Проверки на правильность введенных данных на этом этапе не проводятся
            Console.WriteLine("Выберите тип фигуры:\n1. Круг\n3. Треугольник");
            inputString.Append(System.Console.ReadLine());
            Console.WriteLine("Введите количество сторон фигуры (1 для круга)");
            int ShapeSides = int.Parse(System.Console.ReadLine());
            inputString.Append(';');
            inputString.Append(ShapeSides.ToString());
            for (int i = 0; i < ShapeSides; i++)
            {
                Console.WriteLine("Введите сторону #" + (i+1).ToString() + ":");
                inputString.Append(';');
                inputString.Append(System.Console.ReadLine());
            }
        }
        Console.WriteLine(inputString.ToString());
    }
}