using System;

public class Jogador
{
    public int Id{get;set;}
    public string Nome{get;set;}
    public string Apelido{get;set;}
    public DateTime DataNascimento{get;set;}
    public int Numero{get;set;}
    public string Posicao{get;set;}
    public int Qualidade {get;set;}
    public int Cartoes {get;set;}
    public bool Suspenso{get;set;}


    public bool VerificarCondicaoDeJogo() => this.Cartoes == 3 ? false : true; 

    public void AplicarCartao(int qt) => this.Cartoes += qt;

    public void CumprirSuspensao()
    {
        this.Cartoes = 0;
        this.Suspenso = false;
    } 

    public void SofrerLesao()
    {
        Random rand = new Random();
        int val = rand.Next(100);

        if (val < 5)
            this.Qualidade -= (int)(this.Qualidade*0.15);
        else if (val < 15)
            this.Qualidade -= (int)(this.Qualidade*0.10);
        else if (val < 30)
            this.Qualidade -= (int)(this.Qualidade*0.05);
        else if (val < 60)
            this.Qualidade -= 2;
        else
            this.Qualidade -= 1;
    }


    public void Treinamento()
    {
        Random rand = new Random();
        int val = rand.Next(100);

        if (val < 5)
            this.Qualidade += 5;
        else if (val < 15)
            this.Qualidade += 4;
        else if (val < 30)
            this.Qualidade += 3;
        else if (val < 60)
            this.Qualidade += 2;
        else
            this.Qualidade += 1;
    }

    public override string ToString()
    {
        return $"{this.Posicao}:{this.Id} - {this.Nome} ({this.Apelido}) - {this.DataNascimento:MM dd, yyyy} CONDIÇÃO: {Suspenso}";
    }


}

public class Time
{
    public string Nome{get;set;}
    public string Apelido{get;set;}
    public DateTime Fundacao{get;set;}
    public List<Jogador> plantel {get;set;}
    public List<Jogador> Relacionados = new List<Jogador>();

    public List<Jogador> RelacionaJogadores()
    {
        int count = 0;
        List<Jogador> plantel2 = plantel.OrderByDescending(x => x.Qualidade).ToList();
        foreach (Jogador i in plantel2)
        {
            this.Relacionados.Add(i);
            count++;
            if (count == 18)
                break;
        }
        return this.Relacionados;
    }
}

