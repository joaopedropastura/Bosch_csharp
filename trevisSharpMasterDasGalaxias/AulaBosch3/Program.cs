// See https://aka.ms/new-console-template for more information
using System;

Set empty = new EmptySet();
Set empty2 = new EmptySet();
Set empty3 = new EmptySet();
Set empty4 = new EmptySet();

Set pair = new PairSet(empty, empty2);

Set pair2 = new PairSet(empty3, empty4);

Set union = pair.Union(pair2).Union(pair2).Union(empty).Union(pair);

empty.Union(pair);
union.Union(pair);

Console.WriteLine(union.IsIn(empty));
