
class Task56
{

    // Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // 5 2 6 7
    // Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
    //  (нумерация строк начинается с 1)


    public static string Execute()
    {

        Random rnd = new Random();
        double[,] array = Task54.ArrayGenerator(rnd.Next(3, 6), rnd.Next(1, 10), 20, true);
        Console.WriteLine("Дан массив");
        Console.WriteLine(Task54.PrintArray(array));

        int numLine = FindLineMinSum(array);

        return "\nНомер строки с наименьшей суммой - " + numLine;
    }

    static int FindLineMinSum(double[,] array)
    {
        int numLine = 1;
        int sumTemp = SumOnLine(array, 0);

        for (int i = 0; i < array.GetLength(0); i++)
        {
            int currentLine = SumOnLine(array, i);
            if (currentLine < sumTemp) { sumTemp = currentLine; numLine = i + 1; }
        }
        return numLine;

    }

    static public int SumOnLine(double[,] array, int numLine)
    {
        int res = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            res = res + ((int)array[numLine, j]);
        }

        return res;
    }

}