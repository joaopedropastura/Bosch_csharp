string email = "meuemail@email.com";
var valido = email.Count(c => c == '@') == 1;
var initial = email.TakeWhile(c => c != '@');
var resto = email.SkipWhile(c => c != '@').Skip(1);

List<Dinossauro> dinos = new List<Dinossauro>();
dinos.Add(new Dinossauro()
{
    Nome = "Brotossauro",
    Peso = 300,
    Era = 2
});
dinos.Add(new Dinossauro()
{
    Nome = "Deodicrou",
    Peso = 2,
    Era = 1
});
dinos.Add(new Dinossauro()
{
    Nome = "Trex",
    Peso = 10,
    Era = 2
});

List<Era> eras = new List<Era>();
eras.Add(new Era()
{
    Codigo = 1,
    Nome = "Cretacio"
});
eras.Add(new Era()
{
    Codigo = 2,
    Nome = "Jurassico"
});

var query = dinos.Join(eras,
    d => d.Era,
    e => e.Codigo,
    (d, e) => new {
        Dinossaure = d.Nome,
        Era = e.Nome
    }
);

foreach (var x in query)
    Console.WriteLine(x);

public class Dinossauro
{
    public string Nome { get; set; }
    public float Peso { get; set; }
    public int Era { get; set; }
}

public class Era
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public int Inicio { get; set; }
    public int Fim { get; set; }
}