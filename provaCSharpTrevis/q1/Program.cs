﻿using System;

double[] array = new double[]
{
    6.6, 7.2, 7.2, 8.4, 8.6, 8.4, 9.4, 9.8, 10.0
};
Console.WriteLine(mediaEspecial(array));
double mediaEspecial(double[] array)
{
    return Math.Round((float)((array[3]+array[4]+array[5])/3), 3);
}