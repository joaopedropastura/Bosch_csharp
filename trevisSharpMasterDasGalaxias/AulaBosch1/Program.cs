using System;

int[] arr = new int[]
{ 8, 4, 2, 3, 9, 12, 11, 1 };

mergesort(arr);

foreach (var x in arr[..^1])
{
    Console.Write($"{x}, ");
}
Console.Write($"{arr[arr.Length - 1]}");

void mergesort(int[] arr)
{
    int e = arr.Length;
    int[] arraux = new int[e];
    mergesortrec(arr, arraux, 0, e);
}

void mergesortrec(
    int[] arr, 
    int[] arraux, 
    int s, int e)
{
    if (e - s < 2)
        return;
    int p = (s + e) / 2;
    mergesortrec(arr, arraux, s, p);
    mergesortrec(arr, arraux, p, e);
    merge(arr, arraux, s, p, e);
}

void merge(
    int[] arr, 
    int[] arraux, 
    int s, int p, int e)
{
    int i = s, j = p, k = s;
    while (i < p && j < e)
    {
        if (arr[i] < arr[j])
        {
            arraux[k] = arr[i];
            i++;
            k++;
        }
        else
        {
            arraux[k] = arr[j];
            j++;
            k++;
        }
    }

    while (i < p)
    {
        arraux[k] = arr[i];
        i++;
        k++;
    }

    while (j < e)
    {
        arraux[k] = arr[j];
        j++;
        k++;
    }

    for (int t = s; t < e; t++)
    {
        arr[t] = arraux[t];
    }
}
