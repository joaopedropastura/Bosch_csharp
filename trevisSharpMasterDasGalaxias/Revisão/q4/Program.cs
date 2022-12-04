using System.Linq;
using System.Collections.Generic;

App.Run();

public class Controller
{   
    Queue<float> queue1 = new Queue<float>();
    Queue<float> queue2 = new Queue<float>();
    public float Control(float x)
    {
        queue1.Enqueue(x);
        if (queue1.Count > 40)
            queue1.Dequeue();
            
        queue2.Enqueue(x);
        if (queue2.Count > 20)
            queue2.Dequeue();
        

        return queue1.Average() - queue2.Average();
    }
}