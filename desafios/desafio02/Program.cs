using System;
using System.Collections;

Aluno[] aluno = new Aluno[100];
Disciplina[] discp = new Disciplina[100];

// List<Aluno> alunos = new List<Aluno>();

while(true)
{
    int choose;
    int indexA = 0, indexD = 0;
    Console.WriteLine("Digite a opção desejada:\n\n1 - Cadastrar aluno\n2 - Cadastrar Curso\n3 - Listar Cursos\n4 - Lançar notas\n5 - Estatisticas\n6 - Sair");
    choose = Convert.ToInt32(Console.ReadLine());
    if (choose == 6)
        return 0;
    else if (choose == 1)
    {
        aluno[indexA] = new Aluno();
        Console.WriteLine("Digite o nome do aluno:");
        aluno[indexA].Name = Console.ReadLine();

        Console.WriteLine("Digite a matricula:");
        aluno[indexA].Matricula = Console.ReadLine();

        Console.WriteLine("Digite o Curso:");
        aluno[indexA].Curso = Console.ReadLine();
        Console.WriteLine("\nOperação realizada com sucesso!");
        System.Threading.Thread.Sleep(1300);
        Console.Clear();
        indexA++;
    }
    else if (choose == 2)
    {
        discp[indexD] = new Disciplina();
        Console.WriteLine("Digite o nome da Discipina:");
        discp[indexD].NameD = Console.ReadLine();

        Console.WriteLine("Digite o código da Discipina:");
        discp[indexD].Cod = Console.ReadLine();

        Console.WriteLine("Digite a carga horária da Discipina:");
        discp[indexD].Ch = Console.ReadLine();
        Console.WriteLine("\nOperação realizada com sucesso!");
        System.Threading.Thread.Sleep(1300);
        indexD++;
        Console.Clear();
    }
    else if (choose == 3)
    {
        Console.Clear();
        int temp = 1;
        while(true)
        {
            for (int i = 0; i <= indexD; i++)
                Console.WriteLine(discp[i].Cod + " | " + discp[i].NameD + " | " + discp[i].Ch);
            Console.WriteLine("Digite 0 para voltar ao menu principal: ");
            temp = Convert.ToInt32(Console.ReadLine());
            if(temp == 0)
                break;
        }
    }
    else if (choose == 4)
    {
        string codA;
        string codC;
        int auxA = -1;
        Console.WriteLine("Digite a matricula do aluno: ");
        codA = Console.ReadLine();
        while(true)
        {
            for(int i = 0; i <= indexA; i++)
                if(String.Equals(codA, aluno[i].Matricula))
                    auxA = i;
            if(auxA < 0)
            {
                Console.WriteLine("Matricula incorreta, digite novamente: ");
                codA = Console.ReadLine();
            }
            else
                break;
        }
        Console.WriteLine(aluno[auxA].Name + " | " + aluno[auxA].Matricula);
        Console.WriteLine("Digite o Cod da disciplina: ");
        codC = Console.ReadLine();
        int auxC = -1;
        while(true)
        {
            for(int j = 0; j <= indexD; j++)
                if(String.Equals(codC, discp[j].Cod))
                    auxC = j;
            if(auxC < 0)
            {
                Console.WriteLine("Código do curso incorreto, digite novamente: ");
                codC = Console.ReadLine();
            }
            else
                break;
        }
        Console.WriteLine(discp[auxC].NameD + " | " + discp[auxC].Cod);
        Console.WriteLine("Digite a nota do aluno na disciplina: ");
        aluno[indexA].Nota = Convert.ToDouble(Console.ReadLine());
        int temp = 1;
        while(true)
        {
            Console.WriteLine("Nome: " + aluno[auxA].Name + " | Matricula: " + aluno[auxA].Matricula + " | Disciplina: " + discp[auxC].NameD + " | Nota: " + aluno[auxA].Nota);
            Console.WriteLine("Digite 0 para voltar ao menu principal: ");
            temp = Convert.ToInt32(Console.ReadLine());
            if(temp == 0)
                break;
        }

    }
    else if (choose == 5)
    {
        double notas = 0;
        double total;
        int j;
        for (int i = 0; i <= indexD; i++)
        {
            for (j = 0; j <= indexA; j++)
                notas += aluno[j].Nota;
            total = notas/j+1;
            Console.WriteLine("Media: " + discp[i].NameD + " = " + total);
        }
        int temp = 1;
        while(true)
        {
            for (int i = 0; i <= indexD; i++)
            Console.WriteLine("Digite 0 para voltar ao menu principal: ");
            temp = Convert.ToInt32(Console.ReadLine());
            if(temp == 0)
                break;
        }
    }
}