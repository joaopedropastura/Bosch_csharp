using System;


namespace Desafio
{
    class Program
    {   
        static void main(string[] args)
        {
            Animais gato = new Animais();
            gato.SetNome("frajola");
            Console.WriteLine("A animal: " + gato.getName() + " foi criado com sucesso");

        }
    }
}
