using System;

public class Animais
{
	string nome{get;set;}
	public int patas;
	public int espec_vida;
	public string cor_pelo;

	public void som()
	{

	}
	public void comer()
	{

	}
	public string getName()
	{
		return nome;
	}
	public void SetNome(string nome)
	{
		this.nome = nome;
	}
}

// public class Gato : Animais
// {

// }


// Herança é a capacidade de criar novas abstrações a partir de outras ja existentes

// Métodos são utilizados para descrever as funcionalidades de uma classe, funções que implementamos para definir comportamentos

// Atributos são as variáveis da classe, utilizamos para descrever caracteristicas da classe

// Para utilizar uma classe é necessario instanciar um objeto e atribui-lo a classe
//EX: (classe) (objeto) = new (classe)() => Pessoa marcos = new Pessoa();
