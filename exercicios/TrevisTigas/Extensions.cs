using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
public static class ExtensionMethods
{
    public static IEnumerable<string> Open(this string path)
    {
        var stream = new StreamReader(path);

        while(!stream.EndOfStream)
            yield return stream.ReadLine();
        stream.Close();


    }
    public static IEnumerable<string> Read(this IEnumerable<string> coll)
    {
        var it = coll.GetEnumerator();

        var header = it.MoveNext() ? it.Current.Replace("\"", "").Split(";").ToList() : null;

        while (it.MoveNext())
            yield return it.Current;
    }

}