// using System;
// using System.Runtime.InteropServices;

// And and = new And();
// Or or = new Or();
// Not not = new Not();



// and.Connect(false, true);
// or.Connect(and.Output, false);
// not.Connect(or.Output);

// Console.WriteLine(and.Output);
// Console.WriteLine(or.Output);
// Console.WriteLine(not.Output);
// public abstract class Portas
// {
//     public string Name {get;set;}
//     public bool Output {get;set;}
//     public abstract void Connect(bool input1, bool input2 = false);

// }

// public class And : Portas
// {
//     public And()
//     {
//         this.Name = "and";
//     }
//     public override void Connect(bool input1, bool input2)
//     {
//         this.Output = input1 && input2;
//     }

// }

// public class Or : Portas
// {
//     public Or()
//     {
//         this.Name = "Or";
//     }
//     public override void Connect(bool input1, bool input2)
//     {
//         this.Output = input1 || input2;
//     }
// }

// public class Not : Portas
// {
//     public Not()
//     {
//         this.Name = "not";

//     }
//     public override void Connect(bool input1, [Optional] bool input2)
//     {
//         this.Output = input1?false:true; 
//     }
// }












// // public override void Connect(bool input1, bool input2)
// // {
// //     if (input1 == true && input2 == true)
// //     {
// //         this.Output = true;
// //         return;
// //     }
// //     else
// //         this.Output = false;
// // }


// // public override void Connect(bool input1, bool input2)
// // {
// //     if (input1 == true || input2 == true)
// //     {
// //         this.Output = true;
// //         return;
// //     }
// //     else
// //         this.Output = false;
// // }