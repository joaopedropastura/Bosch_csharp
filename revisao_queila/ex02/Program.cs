var aritimetica;
var poderada;
var harmonica;

var nota;
var media;

List<float> notas = new List<float>();

for (int x = 0; x < 3; x++)
{
    Console.Write($"Informe a nota 0{x+1}: ");
    nota = Int64.Parse(Console.ReadLine());
    notas.Add(nota);
}
Console.WriteLine($"Escolha a media a ser realizada:\n1 - Média Aritimética\n2 - Média Ponderada\n3 - Média Harmônica");
media = Int32.Parse(Console.ReadLine());
