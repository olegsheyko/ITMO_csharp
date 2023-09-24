// Лабораторная работа 1, вариант 12. Шейко Олег P3266

// Задание - часть 1

class Lab1
{
    enum Direction
    {
        right,
        down
    }
    static void Main()
    {
        double[] arr = randArrFill(30, -1500, 5689);
        Console.WriteLine("Source Array:");
        printArr(arr);

        Console.WriteLine("Number of elements in specific range: " + findCount(arr, -1515, 4555));
        Console.WriteLine("Sum after Max: " + getSumAfterMax(arr));
        SortArrayByAbsoluteValue(arr);
        Console.WriteLine("Sorted Array:");
        printArr(arr);

        var matrix = RandFillMatrix(5, 6);

        int N = 2; // Количество элементов для сдвига
        Direction direction = Direction.down; // Режим сдвига: Right или Down

        Console.WriteLine("Source Matrix:");
        PrintMatrix(matrix);

        PushElements(matrix, N, direction);

        Console.WriteLine("After push operation:");
        PrintMatrix(matrix);
        
    }


    static double[] randArrFill(int size, int a, int b)
    {
        double[] arr = new double[size];
        Random n = new Random();
        int l = arr.Length;
        for (int i = 0; i < l; i++)
        {
            arr[i] = n.Next(a, b);
        }
        return arr;
    }

    static void printArr(double[] arr)
    {
        foreach (var elmt in arr)
        {
            Console.Write(elmt + "  ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    static int findCount(double[] arr, double a, double b)
    {
        int count = 0;
        int l = arr.Length;
        for (int i = 0; i < l; i++)
            if (arr[i] >= a && arr[i] <= b)
                count++;
        return count;
    }

    static double getSumAfterMax(double[] arr)
    {
        double sum = 0;
        double maxElement = Double.MinValue;
        int maxIndex = 0;
        int l = arr.Length;

        for (int i = 0; i < l; i++)
        {
            if (arr[i] > maxElement)
            {
                maxElement = arr[i];
                maxIndex = i;
            }
        }
        for (int i = maxIndex + 1; i < l; i++)
            sum += arr[i];
        return sum;
    }

    static void SortArrayByAbsoluteValue(double[] arr)
    {
        Array.Sort(arr, (a, b) => Math.Abs(b).CompareTo(Math.Abs(a))); // использование лямбда-выр для сортировки, сравнение модулей 
    }


    static int[,] RandFillMatrix(int a, int b)
    {
        int[,] matrix = new int[a, b];
        Random n = new Random();
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = n.Next(-50, 50);
            }
        }

        return matrix;
    }

    static void PushElements(int[,] matrix, int N, Direction dir)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (dir == Direction.right)
        {
            N %= cols;

            for (int i = 0; i < rows; i++)
            {
                int[] temp = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    temp[(j + N) % cols] = matrix[i, j];
                }

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
        }
        else if (dir == Direction.down)
        {
            N %= rows; 

            for (int i = 0; i < N; i++)
            {
                int[] lastRow = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    lastRow[j] = matrix[rows - 1, j];
                }

                for (int j = rows - 1; j > 0; j--)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        matrix[j, k] = matrix[j - 1, k];
                    }
                }

                for (int j = 0; j < cols; j++)
                {
                    matrix[0, j] = lastRow[j];
                }
            }
        }
    }


    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "       ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
