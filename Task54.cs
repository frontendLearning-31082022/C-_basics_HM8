
class Task54
{

    // Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // В итоге получается вот такой массив:
    // 7 4 2 1
    // 9 5 3 2
    // 8 4 4 2


    public static string Execute()
    {

        Random rnd = new Random();
        double[,] array = ArrayGenerator(rnd.Next(1, 10), rnd.Next(6, 10), 20, true);
        Console.WriteLine("Дан массив");
        Console.WriteLine(PrintArray(array));


        array = SortArrayOnLine(array);

        return "\nОтсортирован" + PrintArray(array);
    }

    public static double[,] SortArrayOnLine(double[,] array)
    {

        for (int i = 0; i < array.GetLength(0); i++)
        {

            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > array[i, j - 1])
                    {
                        double temp = array[i, j];
                        array[i, j] = array[i, j - 1];
                        array[i, j - 1] = temp;
                        sorted = false;
                    }
                }
            }
        }

        return array;
    }

    public static double[,] ArrayGenerator(int m, int n, int maxVal, Boolean integersGen = false)
    {
        double[,] array = new double[m, n];

        Random rnd = new Random();
        if (maxVal == -1) maxVal = rnd.Next();


        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = rnd.NextDouble() * (rnd.NextDouble() < 0.5 ? -1 : 1) * rnd.Next(0, maxVal);
                if (integersGen) array[i, j] = (int)array[i, j];
            }
        }

        return array;
    }


    public static string PrintArray(double[,] array)
    {

        String result = "";

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                string number = string.Format("{0:N2}", array[i, j]);
                if ((array[i, j] % 1) == 0) number = ((int)array[i, j]).ToString();
                result = result + number + "\t";

            }
            result = result + "\n";
        }
        return result;
    }

}