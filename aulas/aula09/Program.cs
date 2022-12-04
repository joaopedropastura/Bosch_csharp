// See https://aka.ms/new-console-template for more information

// var stream = new StreamReader("aquivoaqui.csv");


// while(!stream.EndOfStream)
// {
//     var line = stream.ReadLine();
//     Console.WriteLine(line);
// }

// stream.Close();


// com iteradores

// var stream = new StreamReader("aquivoaqui.csv");

// foreach (var line in file)
// {
//     Console.WriteLine(line);
// }


// IEnumerable<string> open(string file)
// {
//     var stream = new StreamReader(file);
//     while(!stream.EndOfStream)
//     {
//         var line = stream.ReadLine();
//         yield return line;
//     }
//     stream.Close();
// }
var coll = "C:/Users/disrct/Downloads/INFLUD21-24-10-2022.csv"
    .Open()
    .Skip(4)
    .Take(5)
    .ToList();

// filtrar strings 
//    var contains = "OLA MUNDO".Contains("MUNDO");

//fazer uma funcao link q filtra utilizando contais

foreach (var x in coll)
    Console.WriteLine(x);
public static class MyExtensionMethod
//atv1 tentar separar as vacinas e adicionar em um arquivo
//atv2 bonus transformar uma colecao de str em colecao de obj
//SRAG 2021
{
    public static IEnumerable<string[]> Split(this IEnumerable<string> coll)
    {
        foreach (var el in coll)
        {
            yield return el.Split(',');
        }
    }
    //pular qt de linhas inciais do meu database
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++);
        while(it.MoveNext())
            yield return it.Current;
    }
    // pegar qt de linhas do meu database
    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++)
            yield return it.Current;
    }
    //cria uma lista para que possamos utlizar a idexação
    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();

        var it = coll.GetEnumerator();
        while(it.MoveNext())
            list.Add(it.Current);

        return list;
    }
    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        var count = 0;
        var it = coll.GetEnumerator();
        T[] array = new T[coll.Count()];
        while(it.MoveNext())
        {
            array[count] = it.Current;
            count++;
        }
        return array;
    }

    public static T LastOrDefault<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();
        while(it.MoveNext())
            count++;
        return count == 0 ? default(T) : it.Current;
    }

    public static T FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        return it.MoveNext() ? it.Current : default(T);
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        while(it.MoveNext())
            yield return it.Current;

        yield return item;
    }
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> coll, T item)
    {
        yield return item;

        var it = coll.GetEnumerator();
        while (it.MoveNext())
            yield return it.Current;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            count++;
        return count;
    }

    public static IEnumerable<string> Open(this string file)
    {
        var stream = new StreamReader(file);
        while(!stream.EndOfStream)
        {
            var line = stream.ReadLine();
            yield return line;
        }
        stream.Close();
    }


}

public delegate void MeuDelegate(string s);


// void ChamaDuasVezes(MeuDelegate f)
// {
//     f("Ola mundo");
//     f("Ola mundo");
// }


// MeuDelegate print = Console.WriteLine;


// MeuDelegateComClasse


//como chamar a funcao?

public abstract class MeuDelegateComClasse
{
    public abstract void Run(string s);
    public class MeuPrint : MeuDelegateComClasse
    {
        public override void Run(string s)
        {
            Console.WriteLine("Mensagem: "+s);
        }
    }
}

//funcao anonima

// MeuDelegate func = delegate(string s)
// {
//     Console.WriteLine("Função anonima diz: "+s);
// } 


// //funcao lambda

// MeuDelegate func2 = s => Console.WriteLine("Lambda diz:" + s);


// //funcao lambda

// ChameNvezes(s => Console.WriteLine("Lambda direto diz:" + s), 3);

// var coll = exemplo("Trevisan ");


// foreach (var x in coll)
// {
//     Console.Write(x);
// }

// // var it = coll.GetEnumerator();

// // while(it.MovwNext())
// // {
// //     var x = it.Current;

// //     Console.WriteLine(x);
// // }

// IEnumerable<string> exemplo(string parametroLegal)
// {
//     yield return parametroLegal;

//     yield return "Disse: ";
//     yield return "Java";
//     yield return " é ";
//     yield return "Ruim!";
// }   