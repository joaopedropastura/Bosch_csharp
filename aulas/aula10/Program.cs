//funcao anonima

// MeuDelegate func = delegate(string s)
// {
//     Console.WriteLine("Função anonima diz: "+s);
// } 


// //funcao lambda

// MeuDelegate func2 = s => Console.WriteLine("Lambda diz:" + s);


// //funcao lambda

// ChameNvezes(s => Console.WriteLine("Lambda direto diz:" + s), 3);
var pessoas = new List<Pessoa>()
{
    new Pessoa()
    {
        Nome = "Edjalma",
        Idade = 830
    },
    new Pessoa()
    {
        Nome = "Eu",
        Idade = 23
    },
    new Pessoa()
    {
        Nome = "Voces",
        Idade = 16
    }
};
var arr = new int[] {1,2,3,4,5,6,7,8,9};
var lala = arr.Where(x => x < 4);
var lili = pessoas.Max(i => i.Idade);


    Console.WriteLine(lili);
public class Pessoa
{
    public string Nome{get;set;}
    public int Idade{get;set;}
}
public static class MyExtensionMethod
{
    public static IEnumerable<T> Where<T>(this IEnumerable<T> coll, Func<T, bool> condition)
    {
        var it = coll.GetEnumerator();
        while(it.MoveNext())
        {
            if(condition(it.Current))
                yield return it.Current;
        }
    }

    public static int Max<T>(this IEnumerable<T> coll, Func<T,int> func)
    {
        var it = coll.GetEnumerator();
        it.MoveNext();
        var max = func(it.Current);
        while(it.MoveNext())
        {
            if(func(it.Current)>max)
                max = func(it.Current);
        }
        return max;
    }
}



































//ex01

// int[] Arr = new int[] {1,2,3,4,5,6,7,78}; 

// int[] Transforme(int[] entrada, Transformador t)
// {
//     int[] novo = new int[entrada.Length];
//     int index = 0;
//     foreach (int i in entrada)
//     {
//         novo[index] = t(i);
//         index++;
//     }
//     return novo;
// }
// Print printa = s => Console.WriteLine(s);

// int[] novoArr = Transforme(Arr, n => n*n);

// foreach (int x in novoArr)
//     printa(x);

// public delegate int Transformador(int n);
// public delegate void Print(object s);



// public delegate void MeuDelegate(string s);


// void ChamaDuasVezes(MeuDelegate f)
// {
//     f("Ola mundo");
//     f("Ola mundo");
// }


// MeuDelegate print = Console.WriteLine;


// MeuDelegateComClasse




//como chamar a funcao?

// public abstract class MeuDelegateComClasse
// {
//     public abstract void Run(string s);
//     public class MeuPrint : MeuDelegateComClasse
//     {
//         public override void Run(string s)
//         {
//             Console.WriteLine("Mensagem: "+s);
//         }
//     }
// }
