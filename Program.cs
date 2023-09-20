// Лабораторная работа 1, вариант 12. Шейко Олег P3266

// Задание - часть 1
double[] arr = randArrFill(30);
Console.WriteLine("Source array:");
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

