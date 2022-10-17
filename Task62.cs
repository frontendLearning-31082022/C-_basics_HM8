using System.Collections;
class Task62
{

    // Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
    // Например, на выходе получается вот такой массив:
    // 01 02 03 04
    // 12 13 14 05
    // 11 16 15 06
    // 10 09 08 07


    public static string Execute()
    {

        int[,] spiralArray = new int[4, 4];

        SpiralMechanism spiralMechanism = new SpiralMechanism(spiralArray);

        int iter = 1;
        while (spiralMechanism.isNonFull()) spiralMechanism.FillOneMore(iter++);

        return "\nСпирально заполненный массив\n" + PrintArray(spiralArray);
    }

    public static string PrintArray(int[,] array)
    {

        String result = "";

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                string number = string.Format("{0:00}", array[i, j]);
                if ((array[i, j] % 1) == 0) number = ((int)array[i, j]).ToString();
                result = result + number + "\t";

            }
            result = result + "\n";
        }
        return result;
    }


    class SpiralMechanism
    {

        ArrayList chain = new ArrayList();
        int chainState = 0;

        private int currentX = 0;
        private int currentY = -1;

        public IDictionary<string, string> alreadyFilled = new Dictionary<string, string>();


        int[,] array;

        public SpiralMechanism(int[,] array)
        {
            this.array = array;
            chain.Add(new int[] { 0, 1 }); //"Right"
            chain.Add(new int[] { 1, 0 });  //Down
            chain.Add(new int[] { 0, -1 }); //Left
            chain.Add(new int[] { -1, 0 });  //Top
        }

        void SetDirection()
        {
            int testX = currentX + ((int[])chain[chainState])[0];
            int testY = currentY + ((int[])chain[chainState])[1];


            string keyAlready = testX.ToString() + testY.ToString();
            if (testX >= array.GetLength(0) || testY >= array.GetLength(1)
            || testX == -1 || testY == -1 || alreadyFilled.ContainsKey(keyAlready)) chainState++;
            if (chainState > 3) chainState = 0;

            currentX = currentX + ((int[])chain[chainState])[0];
            currentY = currentY + ((int[])chain[chainState])[1];
            string tt = "";
        }

        int GetCurrentX()
        {
            return currentX;
        }

        int GetCurrentY()
        {
            return currentY;
        }

        public bool isNonFull()
        {
            return alreadyFilled.Count < array.Length;
        }

        public void FillOneMore(int value)
        {
            SetDirection();
            array[currentX, currentY] = value;
            alreadyFilled.Add((currentX.ToString() + currentY.ToString()), null);
        }

    }


}