// using System;


// Console.WriteLine("Hello, World!");

// int a = 3;
// int[] arr = new int[100];


// for (int i = 0; i < arr.Length; i++)
// {
//     arr[i] = 1;
//     Console.Write(arr[i]);
// }

// foreach(int n in arr)
// {
//     Console.WriteLine(n);
// }

// {
//     int banana = 34;

//     Console.WriteLine(banana);
// }

// switch(a)
// {
//     case 3:
//         Console.WriteLine("acertou 3");
//         break;
//     case 2:
//         Console.WriteLine("acertou 4");
//         break;
//     case 1:
//         Console.WriteLine("acertou 1");
//         break;

// }

// while (a <= 10)
// {
//     Console.Write(a);
//     a++;
// }

// //int[] arr = new int[] {8,4,2,3,8,9,12,1};

// mergeSort(arr);

// foreach (var x in arr[..^1])
// {
//     Console.Write($"{x}, ");
// }
// Console.Write($"{arr[arr.Length -1]}");

// void mergeSort(int[] arr)
// {
//     int e = arr.Length;
//     int[] arrAux = new int[e];
//     mergeSortRec(arr, arrAux, 0, e);
// }

// void mergeSortRec(int[] arr, int[] arrAux, int s, int e)
// {
//     if (e - s < 2)
//         return;
//     int p = (s + e)/2;
//     mergeSortRec(arr, arrAux, s, p);
//     mergeSortRec(arr, arrAux, p, e);
//     merge(arr, arrAux, s, p, e);
// }

// void merge(int[] arr, int[] arrAux, int s, int p, int e)
// {
//     int i = s, j = p, k = s;
//     while(i < p && j < e)
//     {
//         if (arr[i] < arr[j])
//         {
//             arrAux[k] = arr[i];
//             i++;
//             k++;
//         }
//         else
//         {
//             arrAux[k] = arr[j];
//             j++;
//             k++;
//         }
//     }
//     while (i < p)
//     {
//         arrAux[k] = arr[i];
//         i++;
//         k++;
//     }
//     while (j < e)
//     {
//         arrAux[k] = arr[j];
//         j++;
//         k++;
//     }
//     for (int t = s; t < e; t++)
//     {
//         arr[t] = arrAux[t];
//     }
// }
