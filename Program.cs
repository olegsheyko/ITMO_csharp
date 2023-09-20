// Лабораторная работа 1, вариант 12. Шейко Олег P3266

// Задание - часть 1
double[] arr = randArrFill(30);
Console.WriteLine("Source Array:");
printArr(arr);

Console.WriteLine("Number of elements in specific range: " + findCount(arr, -15, 45));
Console.WriteLine("Sum after max: " + getSumAfterMax(arr));
SortArrayByAbsoluteValue(arr);
Console.WriteLine("Sorted Array:");
printArr(arr);

double[] randArrFill(int size)
{
    double[] arr = new double[size];
    Random n = new Random();
    int l = arr.Length;
    for (int i = 0; i < l; i++)
    {
        arr[i] = n.Next(-15, 15);
    }
    return arr;
}

void printArr(double[] arr)
{
    foreach (var elmt in arr)
    {
        Console.Write(elmt + "  ");
    }
    Console.WriteLine();
    Console.WriteLine();
}

int findCount(double[] arr, double a, double b)
{
    int count = 0;
    int l = arr.Length;
    for (int i = 0; i < l; i++)
        if (arr[i] >= a && arr[i] <= b)
            count++;
    return count;
}

double getSumAfterMax(double[] arr)
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

void SortArrayByAbsoluteValue(double[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (Math.Abs(arr[i]) < Math.Abs(arr[j]))
            {
                double hold = arr[i];
                arr[i] = arr[j];
                arr[j] = hold;
            }
        }
    }
}

// Задание - часть 2

int[,] matrix = RandFillMatrix(5, 6);

int N = 7; // Количество элементов для сдвига
string direction = "right"; // Режим сдвига: "right" или "down"

Console.WriteLine("Source Matrix:");
PrintMatrix(matrix);

PushElements(matrix, N, direction);

Console.WriteLine("After push operation:");
PrintMatrix(matrix);

int[,] RandFillMatrix(int a, int b)
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

void PushElements(int[,] matrix, int N, string direction)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);

    if (direction == "right")
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
    else if (direction == "down")
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


void PrintMatrix(int[,] matrix)
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