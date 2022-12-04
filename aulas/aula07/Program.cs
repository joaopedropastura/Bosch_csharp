// See https://aka.ms/new-console-template for more information

// var rand = new Random();
// public abstract class Player
// {
//     public int Moedas{get;set;} = 1;

//     public abstract bool Decide();
//     public void Recebe(int moedas);
// }

// public class Amigo : Player
// {
//     public override bool Decide() => true;
// }

// public class Trapaceiro : Player
// {
//     public override bool Decide() => false;
// }
// public abstract class Word
// {
//     Player[] players = new Player[500];
// }


// public static List<Player>  GetPlayers()
// {

// }

string GetWeatherDisplay(double tempCelsius) => tempCelsius < 20.0 ? "Cold." : "Perfect!";

Console.WriteLine(GetWeatherDisplay(190));