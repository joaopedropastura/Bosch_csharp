List<string> novaLista = new List<string>();

var entrada = "";
while (true)
{
    Console.Write("Digite uma frase: ");
    entrada = (Console.ReadLine());
    if (entrada == "0")
        break;
    entrada = String.Concat(entrada.OrderBy(ch => ch));
    novaLista.Add(entrada);
}
foreach (var item in novaLista)
    Console.WriteLine(item);