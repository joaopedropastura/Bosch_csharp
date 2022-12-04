
// Input a = new Input();

// public abstract class Component 
// {
//     public abstract bool Output {get;}
//     public abstract void Update();
//     protected Component Next{get;private set;}
//     public void Connect(Component component)
//     {
//         this.Next = component;
//     }
// }

// public class input : Component
// {
//     private bool ison = false;
//     public bool IsOn
//     get
//     {
//         return ison;
//     }
//     set
//     {
//         this.ison = value;
//         this.Update();
//     }
//     public override bool Output => throw new System.NotImplementedException();

//     public override void Update()
//     {
//      this.Next?.Update();
//     }
// }

// public class AndGate : Component
// {
//     private Component inputA = null;
//     private Component inputB = null;



// }