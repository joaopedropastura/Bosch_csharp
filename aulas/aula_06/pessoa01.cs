// using System;

// Sum sum = new Sum();

// sum.Operation("18+i20", "4+i3");
// Console.WriteLine(sum.ResultInt+" + i"+ sum.ResultComp);
// public abstract class Complex
// {
//     public string Name{get;set;}
//     public string ResultInt{get;set;}
//     public string ResultComp{get;set;}
//     public string Output{get;set;}
//     public abstract void Operation(string Input1, string Input2);
// }

// public class Sum : Complex
// {
//     public Sum()
//     {
//         this.Name = "Soma";
//     }

//     public override void Operation(string Input1, string Input2)
//     {
//         string[] temp1 = Input1.Split("+i");
//         string[] temp2 = Input2.Split("+i");
//         this.ResultInt = temp1[0] + temp2[0];
//         this.ResultComp = temp1[1] + temp2[1]; 
//     }
// }