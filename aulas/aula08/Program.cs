using System;

using System.Collections.Generic;

List<int> list = new List<int>();

list.Add(10);
list.Add(12);
list.Add(14);
list.Add(16);
list.Add(18);
list.Add(20);
list.Add(22);

list 
    .Skip(2)
    .Take(3)
    .ToStringList()
    .Concat()
    .Print();
foreach (var x in list.Skip(2).Take(3));
