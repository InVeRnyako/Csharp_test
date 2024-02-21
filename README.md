# Тестовое задание на "C# developer junior / middle"

## Оригинальное задание:
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 
Дополнительно к работоспособности оценим:
- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры в compile-time
- Проверку на то, является ли треугольник прямоугольным

# План выполнения задания:
## Основное задание
 ### Создать функции со следующим функционалом:
1. Вычисление площади круга.
	- Принять на вход число
		- Число должно являться положительным
			- При радиусе 0 круг имеет площадь 0, нет необходимости определять такой случай в частный
	- Вычислить площадь по формуле
		- pi * R ^ 2
	- Вернуть результат
2. Вычисление площади треугольника
	- Принять на вход 3 числа
		- Все числа должны быть положительными и отличными от нуля
	- Определить, возможен ли треугольник с данными стронами
		- Сумма длин двух любых сторон должна быть больше, чем длина третьей стороны.
	- Вычислить площадь по формуле:
		- Частные случаи:
			- Прямоугольный треугольник:
				- Определение: Сумма квадратов двух меньших сторон равна квадрату большей стороны.
				- Частная формула площади: (a * b) / 2
				- *После определения наибольшей стороны, она меняется местами со стороной 3, которая при дальнейших рассчетах будет считаться наибольшей.*
			- Равностронний треугольник:
				- Определение: Все стороны имеют равную длину
				- Частная формула площади: a ^ 2 * Sqrt(3) / 4
			- Общая формула:
				- sqrt ( p * ( p - a) * ( p - b ) * ( p - c ) ), где p = (a + b + c) / 2
		- Вернуть результат
### Создать функцию для распределения входных данных и вызова функции, соответствующей фигуре
1. Принять входные данные, в данном примере будет использован следующий формат входящих данных в текстовом формате:
	- Формат запроса: Тип фигуры;Сторона;Сторона;Сторона
		- Пример для круга с радиусом 3,2: **1;3,2**
		- Пример для треугольника со сторонами 3,4,5: **3;3;4;5**
			*- Хорошее место, чтобы проверить входящую строку на наличие символа '-', даже при условии, что входящие данные заведомо соответствуют дальнейшему формату обработки, отрицательные значения длинны сторон/радиуса условно могут считаться возможными и приведут к неявно неверному результату.* 
2. Определить тип фигуры.
	- Создать возможность предопределять тип фигуры.
		- Фигуры пронумерованы в соответствии с количеством вводимых длин. Так круг будет иметь id 1 (известен радиус), а треугольник - id = 3 (известны 3 стороны)
		- Для определения фигуры как фигуры непредопределенного типа можно использовать id 0
			*- При необходимости в будущем - точку считать как круг с радиусом 0*
		- При отсутствии предопределенного типа фигуры определять тип фигуры по количеству его сторон
			*- Если в дальнейшем может потребоваться необходимость разделения фигур на выпуклые и невыпуклые, существует возможность определить невыпуклым фигурам отрицательные значения id*
		- После определения типа фигуры программа изменяет входящие данные, переписывая id фигуры на id, соответствующий определенному ею типу и вызывает функцию обработки площади предопределенного типа фигур.
3. Отправить запрос по определению площади соответствующей функции
4. Вернуть получившийся результат
	- Полученный результат отправлять числом.
	- Ошибки в ходе выполнения возвращают 0.0 или NaN, которые могут быть обработаны оболочкой.
### Создать функцию оболочку для отправления данных.
Функция выполняет вспомогательный характер и не является полноценной частью программы,
в нее будут заложены:
- возможность чтения из консоли:
	- Запрос на тип фигуры
	- запрос на количество сторон (При неопределенности типа фигуры)
	- запрос на каждую из сторон
- На данном этапе программа не поддерживает фигуры отличные от круга и треугольника
- Реализация запроса каждой стороны реализуется через цикл, для упрощения реализации добавления новых фигур в оболочку	

### Дополнительные задания:
- Юнит-тесты
- Легкость добавления других фигур
	- Формат решения задачи подразумевает возможность добавления новых фигур путем добавления кода в функцию определения типа фигуры (DefineFigure.cs) , case'а в функцию распределения по соответствующим фигурам (Area.cs) и добавления функции, расширяющей class Figure.
	- Вычисление площади фигуры без знания типа фигуры в compile-time
		- Программа подразумевает возможность самостоятельного определения типа фигуры (Основное задание 2.2)
- Проверку на то, является ли треугольник прямоугольным
	- Программа проверяет треугольник на прямоугольность для использования формулы частного случая			(Основное задание 1.2.)
