
namespace ex03
{

    public class Animal
    {
        private string name{get;set;}
        private string type{get;set;}        
        public Animal(string nome, string type)
        {
            this.name = nome;
            if(type != "cachorro" && type != "peixe" && type != "gato")
                this.type = "peixe";
            else
                this.type = type;
        }

        public override string ToString()
        {
            return $"Nome: {this.name}\nTipo: {this.type}";
        }
    }



}