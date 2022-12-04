namespace Despesas
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa newPessoa = new Pessoa();

            newPessoa.Cpf = "123";
            DespesaMes despesa = new DespesaMes(12,299.3);
            newPessoa.despesas.Add(despesa);
            newPessoa.AddDes(despesa);
            newPessoa.AddDes(new DespesaMes(05,2000));
            newPessoa.AddDes(new DespesaDia(05,05,1500));
        }
    }
}