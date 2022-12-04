// using System;

// Edjalma edjFeliz = new Edjalma();
// Edjalma edjPutoDaCara = new Edjalma();
// Gustavo maluco = new Gustavo();
// Sword sword = new Sword();
// maluco.Attack(edjFeliz);
// edjFeliz.Attack(edjPutoDaCara);
// Console.WriteLine(edjPutoDaCara.Life);
// Console.WriteLine(edjFeliz.Life);


// public abstract class Entity
// {
//     public string Name {get;set;}
//     public int Life {get;set;}
//     public int Damage{get;set;}
//     public Weapon Weapon{get;set;}
//     public abstract void Attack(Entity target);
//     public abstract void ReciveDamage(int damage);
// }

// public class Edjalma : Entity
// {
//     public int Shield{get;set;}
//     public Edjalma()
//     {
//         this.Name = "Edjalma";
//         this.Life = 200;
//         this.Damage = 10;
//     }
//     public override void Attack(Entity target)
//     {
//         // int damage = this.Damage /2 + (this.Weapon.Damage * 2);
//         int damage = (this.Damage + (this.Weapon?.Damage??0))/2;
//         target.Life -= damage;
//     }

//     public override void ReciveDamage(int damage)
//     {
//         if(this.Shield > 0)
//         {
//             if (this.Shield > damage)
//             {
//                 this.Shield = 0;
//                 return;
//             }
//             else
//             {
//                 damage -= this.Shield;
//                 this.Shield = 0;
//             }
//         }
//         if(damage < 5)
//             return;
//         this.Life -= damage;
//     }

// }

// public class Gustavo : Entity
// {
//     public Gustavo()
//     {
//         this.Name = "Gustavo";
//         this.Damage = 20;
//         this.Life = 100;
//     }
//     public override void Attack(Entity target)
//     {
//         int damage = 2*(Weapon?.Damage ?? 0) + 2 * this.Damage;
//         target.ReciveDamage(Damage);
//     }
//     public override void ReciveDamage(int damage)
//     {
//         this.Life -= 2*Damage;
//     }
// }

// public abstract class Weapon
// {
//     public string Name{get;protected set;}
//     public int Damage{get;protected set;}
// }

// public class Sword : Weapon
// {
//     public Sword()
//     {
//         this.Name = "Espada";
//         this.Damage = 5;
//     }
// }