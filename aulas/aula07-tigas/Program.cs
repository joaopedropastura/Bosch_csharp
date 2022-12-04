Mundo.GerarJogadores(100,400,500);

while (Mundo.Rodada < 99900)
{
    Mundo.Jogada();


}

Console.WriteLine($"Rodada: {Mundo.Rodada}");
Console.WriteLine($"Falidos: {Mundo.Falidos}");
Console.WriteLine($"Total de : {Mundo.TotalMoedas}");