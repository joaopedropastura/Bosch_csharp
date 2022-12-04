using System;
using System.Linq;

double[] array = new double[]
{
    6.6, 7.2, 7.2, 8.4, 8.6, 8.4, 9.4, 9.8, 10.0
};
Console.WriteLine(mediaEspecial(array));

double mediaEspecial(double[] array)
{
    array = array.OrderBy(i => i).ToArray();
    int meio = array.Length / 2;
    return (
        array[meio - 1] + 
        array[meio] + 
        array[meio + 1]
        ) / 3;
}