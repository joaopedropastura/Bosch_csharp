namespace pais
{
    public class Pais
    {
        public string CodISO{get;set;}
        public string Nome{get;set;}
        public double Populacao{get;set;}
        public double Dimensao{get;set;}

        public List<Pais>PaisViz = new List<Pais>();
        public Pais(string nome, string codIso, double pop, double dim)
        {
            this.CodISO = codIso;
            this.Nome = nome;
            this.Populacao = pop;
            this.Dimensao = dim;
        }

        public double DensidadeDemo() => this.Populacao/this.Dimensao;

        public bool CheckVizinho(Pais checkVizinho)
        {
            foreach (var x in this.PaisViz)
                if (x.Nome == checkVizinho.Nome)
                    return true;
            return false;
        }
        

        public void AddVizinho(Pais novoVizinho) => this.PaisViz.Add(novoVizinho);
            
    }
}