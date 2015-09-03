// Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;

class QuickSort
{
    static void Main()
    {
        // Input N
        Console.Write("Input the size of list to sort: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        Random rnd = new Random();

        // Init array with random data and print input array
        Console.Write("{");
        for (int i = 0; i < n; i++)
        {
            array[i] = rnd.Next(n * n);
            Console.Write(" " + array[i]);
        }
        Console.WriteLine("}");

        // Sort the array
        RecursvieQsort(array, 0, n);

        // Print array after sorting
        Console.Write("{");
        for (int i = 0; i < n; i++)
        {
            Console.Write(" " + array[i]);
        }
        Console.WriteLine(" }");
    }

    // QuickSort recursive algorithm
    public static void RecursvieQsort(int[] arr, int start, int end)
    {
        if (end - start < 2) return; //stop clause
        int p = start + ((end - start) / 2);
        p = Partition(arr, p, start, end);
        RecursvieQsort(arr, start, p);
        RecursvieQsort(arr, p + 1, end);
    }

    // Returns partition
    private static int Partition(int[] arr, int p, int start, int end)
    {
        int l = start;
        int h = end - 2;
        int piv = arr[p];
        Swap(arr, p, end - 1);

        while (l < h)
        {
            if (arr[l] < piv)
            {
                l++;
            }
            else if (arr[h] >= piv)
            {
                h--;
            }
            else
            {
                Swap(arr, l, h);
            }
        }
        int idx = h;
        if (arr[h] < piv) idx++;
        Swap(arr, end - 1, idx);
        return idx;
    }

    // Swap elements
    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}