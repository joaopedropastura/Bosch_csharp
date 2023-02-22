using System;
using System.Collections.Generic;
using System.Linq;



List<string> lista = new List<string> {"carro da vovó", "carambola caida no chao", "camelo com sede", "cavalo correndo"};


// string CaixaAlta (string s)
// {
//     for (int i = 0; i < s.Count(); i++)
//     {
//         s[i] -= 32;
//     }
// }

// string Capitalize(string s)
// {
//     var temp = s.ToLower().ToCharArray();
//     char.ToUpper(temp[0]);
//     return temp.ToString();
// }

string Capitalize(string s) => char.ToUpper(s[0]) + s.Substring(1).ToLower();

string CapitalizeAll(string str)
{
    var splited = str.Split(" ");
    string result = "";

    foreach (var word in splited)
    {
        result += Capitalize(word) + " ";
    }
    return result;
}


var sla = formataString(lista, Capitalize);

foreach (var item in sla)
{
    System.Console.WriteLine(item);
}
List<string> formataString(List<string> strList, Func<string, string> formatStr)
{
    List<string> result = new List<string>();

    foreach (var s in strList)
    {
        result.Add(formatStr(s));
    }
    return result;
}
