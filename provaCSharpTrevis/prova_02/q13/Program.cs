using System;
using System.Linq;


double[] array = new double[]
{
    8.4, 8.6, 8.4, 7.0, 7.2, 10.0, 7.2, 9.4, 9.8
};
Console.WriteLine(mediaEspecial(array));

double mediaEspecial(double[] array)
{
    array = array.OrderBy(i => i).ToArray();    
    int fim = array.Length;
    var sum = 0.0;
    if (fim > 4)
    {
        for(int i = 0; i < fim; i++)
        {
            if (i < 2)
            sum += array[i];
            if (i >= fim - 2)
            sum += array[i];
        }
    }
    else
        return (array.Sum())/fim;
    return (sum/4);
}