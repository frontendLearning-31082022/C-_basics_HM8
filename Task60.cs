using System.Collections;
class Task60
{
    // Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
    // Массив размером 2 x 2 x 2
    // 66(0,0,0) 25(0,1,0)
    // 34(1,0,0) 41(1,1,0)
    // 27(0,0,1) 90(0,1,1)
    // 26(1,0,1) 55(1,1,1)

    public static string Execute()
    {

        ArrayList numbers = new ArrayList();

        for (int i = 10; i < 100; i++)
        {
            numbers.Add(i);
            numbers.Add(i * -1);
        }

        Queue<int> shuffled = Shuffle(numbers);

        int dim1 = MainClass.ReadInteger("Введите размерность массива 1");
        int dim2 = MainClass.ReadInteger("Введите размерность массива 2");
        int dim3 = MainClass.ReadInteger("Введите размерность массива 3");


        int[,,] array = ArrayGenerator3rd(dim1, dim2, dim3, 10, shuffled);

        return "\nТремерный массив\n" + PrintArray3rd(array);
        // Random rnd = new Random();
        // int columns = rnd.Next(2, 10);
        // int lines = rnd.Next(5, 10);

        // double[,] matrix1 = Task54.ArrayGenerator(lines, columns, 20, true);
        // Console.WriteLine("Дан массив");
        // Console.WriteLine(Task54.PrintArray(matrix1));
        // double[,] matrix2 = Task54.ArrayGenerator(lines, columns, 20, true);
        // Console.WriteLine("Дан массив");
        // Console.WriteLine(Task54.PrintArray(matrix2));


        // double[,] result = MultiplyMatrix(matrix1, matrix2);

        // return "\nРезультат умножения массивов\n"+Task54.PrintArray(result);
    }



    public static Queue<int> Shuffle(ArrayList numbers)
    {
        Random random = new Random();
        int n = numbers.Count;
        while (n > 1)
        {
            int k = random.Next(n--);
            int temp = (int)numbers[n];
            numbers[n] = numbers[k];
            numbers[k] = temp;
        }
        Queue<int> numbs = new Queue<int>(numbers.Count);
        numbers.Cast<int>().ToList().ForEach(x => numbs.Enqueue(x));

        return numbs;
    }

    public static int[,,] ArrayGenerator3rd(int dim1, int dim2, int dim3, int maxVal, Queue<int> numsAvailiable)
    {
        int[,,] array = new int[dim1, dim2, dim3];

        Random rnd = new Random();
        if (maxVal == -1) maxVal = rnd.Next();


        for (int dimension = 0; dimension < dim3; dimension++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (numsAvailiable.Count == 0) CatchError(null, "Двузначных чиел меньше чем ячеек массива, завершение с ошибкой", true);
                    array[i, j, dimension] = numsAvailiable.Dequeue();
                }
            }
        }

        return array;
    }

    public static string PrintArray3rd(int[,,] array)
    {
        string result = "";


        for (int dimension = 0; dimension < array.GetLength(2); dimension++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result = result + array[i, j, dimension] + "(" + i + ", " + j + ", " + dimension + ")" + "\t";
                }
                result = result + "\n";
            }
        }

        return result;
    }




    public static void CatchError(Exception e, String msg, bool stop)
    {
        Console.WriteLine(msg);
        if (stop) Environment.Exit(1);
    }

}