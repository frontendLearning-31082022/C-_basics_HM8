using System.Collections;
class OneMore1
{

    // Доп задача 1. Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец,
    //  на пересечении которых расположен наименьший элемент массива.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // 5 2 6 7
    // Наименьший элемент - 1, на выходе получим
    // следующий массив:
    // 9 2 3
    // 4 2 4
    // 2 6 7


    public static string Execute()
    {
        Random rnd = new Random();

        int[,] array = OneMore1.ArrayGenerator(rnd.Next(3, 6), rnd.Next(3, 7), 20);
        Console.WriteLine("Дан массив");
        Console.WriteLine(Task62.PrintArray(array));

        int[] minValCoords = OneMore1.FindMinVal(array);
        Console.WriteLine("Минимальный элемент " + array[minValCoords[0], minValCoords[1]] + " (х-" + minValCoords[0] + "\ty-" + minValCoords[1] + ")");

          int[][] result=DeleteColumnAndRow(array,minValCoords[1],minValCoords[0]);

          
        // 
        // double[,] array = ArrayGenerator(rnd.Next(1, 10), rnd.Next(6, 10),20, true);
        // Console.WriteLine("Дан массив");
        //    Console.WriteLine(PrintArray(array));


        // array = SortArrayOnLine(array);

        return "\nМассив с удаленным столбцом и строкой \n"+PrintArray(result);
    }


    public static int[][] DeleteColumnAndRow(int[,] array, int column, int row)
    {
        List<List<int>> rows = new List<List<int>>();

        for (int i = 0; i < array.GetLength(0); i++)
        {

             List<int> rowList=new List<int>();
            for (int j = 0; j < array.GetLength(1); j++)
            {      
                rowList.Add(array[i, j]);
            }
            rowList.RemoveAt(column);
            rows.Add(rowList);
        }

        rows.RemoveAt(row);


        int[][] result=new int[rows.Count][];
        for (int i = 0; i <  result.GetLength(0); i++)
        {
           int[] rrow= rows[i].ToArray();
            result[i]=rrow;
        }


    
        return result;
    }


    public static int[] FindMinVal(int[,] array)
    {
        int xx = 0;
        int yy = 0;
        int minVal = array[0, 0];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < minVal) { minVal = array[i, j]; xx = i; yy = j; }
            }
        }

        //  Console.WriteLine("\n"+minVal+"\n");
        return new int[] { xx, yy };

    }
    public static int[,] ArrayGenerator(int m, int n, int maxVal)
    {
        int[,] array = new int[m, n];

        Random rnd = new Random();
        if (maxVal == -1) maxVal = rnd.Next();


        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = (rnd.NextDouble() < 0.5 ? -1 : 1) * rnd.Next(0, maxVal);
            }
        }

        return array;
    }



 public  static string PrintArray(int[][] array)
    {

        String result = ""; 

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j <array[0].Length; j++)
            {
                
                string number= array[i][j].ToString();
                result = result +  number + "\t";

            }
            result = result + "\n";
        }
       return result;
    }

}