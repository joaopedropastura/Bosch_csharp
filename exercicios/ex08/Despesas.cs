namespace Despesas
{
    public class DespesaMes 
    {
        public int mes{get; private set;} // mes da despesa
        public float valor{get; private set;} // valor da despesa
        public DespesaMes(int mes, float valor) 
        {
            this.mes = mes;
            this.valor = valor; 
        }
    }
    // Representa o total de despesas de um dia
    public class DespesaDia : DespesaMes
    {
        public int dia{get; private set;} // dia da despesa
        public DespesaDia(int dia, int mes, float valor) : base(mes, valor)
        {
            this.dia = dia;
        }
    } 

    public class Pessoa
    {
        public string Cpf {get; set;}
        public List<DespesaMes> despesas = new List<DespesaMes>();
        public void AddDes(DespesaMes dis) => this.despesas.Add(dis);


    }
}
