public class Lab1_2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите элементы массива:");
        int[,] array = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int element;
                if (int.TryParse(Console.ReadLine(), out element))
                {
                    array[i, j] = element;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода элемента, попробуйте еще раз.");
                    j--; // повторяем ввод элемента 
                }
            }
        }
        Console.WriteLine("Массив :");
        PrintArray(array);
        array = Replace(array);
        Console.WriteLine("После перестановки :");
        PrintArray(array);
        Console.ReadKey();
    }
    public static int[,] Replace(int[,] array)
    {
        int l;
        if ((l = array.GetLength(0)) != array.GetLength(1))
            throw new Exception();
        for (int n = 0; n < l; n++)
        {
            int row = 0, col = 0;
            int max = int.MinValue;
            for (int i = 0; i < l; i++)
                for (int j = 0; j < l; j++)
                {
                    if (i != j || i > n)
                        if (array[i, j] > max)
                        {
                            max = array[i, j];
                            row = i; col = j;
                        }
                }
            int temp = array[n, n];
            array[n, n] = array[row, col];
            array[row, col] = temp;
        }
        return array;
    }
    static void PrintArray(Array a)
    {
        Action<object> print = o => Console.Write("{0}\t", o);
        if (a.Rank > 2 || a.Rank < 1)
            throw new Exception();
        for (int i = 0; i < a.GetLength(0); i++)
            if (a.Rank == 1)
                print(a.GetValue(i));
            else
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    print(a.GetValue(i, j));
                Console.WriteLine();
            }
    }
}