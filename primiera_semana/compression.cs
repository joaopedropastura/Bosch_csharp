using System;


// Console.Write("digite a quantidade de numeros para comprimir: ");

// int quant = Console.Read();
// int[] full = new int[quant];
// int[] compressed = new int[quant]; 
// void compression()
// {
//     int i = 0, current, past;
//     while(quant != 0)
//     {
//         int bin = Console.Read();
//         full[i] = bin;
//         current = bin << 4;

//         i++;
//         quant--;
//     }
// }

// compression();

// int[] arr = new int[] {10,20,30,40,50,60,70,80};
// int[] compress(int[] arr)
// {
//     int x,y;
//     int[] comp = new int[arr.Length/2];
//     for(int i = 0, j = 0; i < arr.Length; j++, i+=2)
//     {
//         x = arr[i] >> 4;
//         x = x << 4;
//         y = arr[i+1] >> 4;
//         comp[j] = x + y;
//         Console.Write($"{comp[j]} ");
//     }
//     return comp;
// }

// void descompress(int []compArr)
// {
//     int x,y, descomp;
//     for (int i = 0; i < compArr.Length; i++)
//     {
//         x = compArr[i] >> 4;
//         x = x << 4;
//         y = compArr[i] - x;
//         y = y << 4;
//         descomp = x + y;
//     }
// }

// int[] p = compress(arr);
// descompress(p);

// int x = 50, y =60, comp;
// Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2)}");
// x = x >> 4;
// Console.WriteLine($"After:  {Convert.ToString(x, toBase: 2)}");

// x = x << 4;
// y = y >> 4;
// comp = x + y;

// Console.Write(comp);