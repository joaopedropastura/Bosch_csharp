using System;
public static class Mundo
{
    public static Player[] Players {get;set;} = new Player[1000];
    private static int index {get;set;}

    public static int Falidos { get; private set; }
    public static int TotalMoedas {get; private set;} = Mundo.Players.Length;
    public static int Rodada {get; private set;} = 0;

    public static void Jogada()
    {

        Random rand = new Random();
        Player jogador1, jogador2;

        while(true)
        {
             jogador1 = Mundo.Players[rand.Next(Mundo.Players.Length)];
             jogador2 = Mundo.Players[rand.Next(Mundo.Players.Length)];

            if((jogador1.Moeda > 0 && jogador2.Moeda > 0) && (jogador1 != jogador2))
                break;
        }
        int moedasIniciais = jogador1.Moeda + jogador2.Moeda;
        if (jogador1.Decidir() && jogador2.Decidir())
        {
            jogador1.Recebe(1);
            jogador2.Recebe(1);
        }
        else if (jogador1.Decidir() && !jogador2.Decidir())
        {
            jogador1.Recebe(-1);
            jogador2.Recebe(4);
        }
        else if (!jogador1.Decidir() && jogador2.Decidir())
        {
            jogador1.Recebe(4);
            jogador2.Recebe(-1);
        }
        else
        {
            jogador1.Recebe(0);
            jogador2.Recebe(0);
        }
        
        if (jogador1.Moeda == 0 || jogador2.Moeda == 0)
            Mundo.Falidos++;
        int moedasFinais = jogador1.Moeda + jogador2.Moeda;
        int novasMoedas = moedasFinais - moedasIniciais;
        Mundo.TotalMoedas += novasMoedas;
        Mundo.Rodada +=1;
    }

    private static void addJogador(Player player)
    {
        Mundo.Players[Mundo.index] = player;
        Mundo.index++;
    }

    public static void GerarJogadores(int cooperadores, int trapaceiros, int vingativos)
    {
        if (cooperadores + trapaceiros + vingativos > Mundo.Players.Length)
            throw new Exception();

        for (int i = 0; i < cooperadores; i++)
            Mundo.addJogador(new Cooperador());
        for (int i = 0; i < trapaceiros; i++)
            Mundo.addJogador(new Trapaceiro());
        for (int i = 0; i < vingativos; i++)
            Mundo.addJogador(new Vingativo());    

    }

}



// static posso usar os metodos da funcao sem eu necessariamente criar um objeto