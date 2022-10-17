
class Task58
{

    // Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
    // Например, даны 2 матрицы:
    //   (умножение как массивы)
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // 5 2 6 7
    // и
    // 1 5 8 5
    // 4 9 4 2
    // 7 2 2 6
    // 2 3 4 7
    // Их произведение будет равно следующему массиву:
    // 1 20 56 10
    // 20 81 8 6
    // 56 8 4 24
    // 10 6 24 49


    public static string Execute()
    {

        Random rnd = new Random();
        int columns = rnd.Next(2, 10);
        int lines = rnd.Next(5, 10);

        double[,] matrix1 = Task54.ArrayGenerator(lines, columns, 20, true);
        Console.WriteLine("Дан массив");
        Console.WriteLine(Task54.PrintArray(matrix1));
        double[,] matrix2 = Task54.ArrayGenerator(lines, columns, 20, true);
        Console.WriteLine("Дан массив");
        Console.WriteLine(Task54.PrintArray(matrix2));


        double[,] result = MultiplyMatrix(matrix1, matrix2);

        return "\nРезультат умножения массивов\n" + Task54.PrintArray(result);
    }


    public static double[,] MultiplyMatrix(double[,] matrix1, double[,] matrix2)
    {
        double[,] result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];

        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = matrix1[i, j] * matrix2[i, j];

            }
        }

        return result;

    }



}