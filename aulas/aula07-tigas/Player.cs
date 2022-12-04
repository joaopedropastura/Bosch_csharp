

public abstract class Player
{
    public int Moeda {get; protected set;} = 10;
    public abstract bool Decidir(); 
    public virtual void Recebe(int valor)
    {
        this.Moeda += valor;
    }
}






// tipo das classes define a sua visibilidade 
// public = permite manipular  
// protected = 
// private = 
// atributo = variavel da classe
//abstract = é utilizada como base 

//DIFERENÇA virtual X abstract
// abstract em sua classe pai, possui apenas uma declaracao. Nas classes herdadas torna mandatorio a sua definição. 
// virtual = possui um padrao na classe PAI porem é permitido o override