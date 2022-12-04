using System.Collections.Generic;
using System.Linq;

App.Run();

public class Controller
{   
    float sum = 0;
    Queue<float> queue = new Queue<float>();
    public float Control(float x)
    {
        queue.Enqueue(x);
        sum += x;
        if (queue.Count > 39)
            sum -= queue.Dequeue();
        var M = sum / 40;

        return 1.57f * M - 285f;
    }

    // Queue<float> queue = new Queue<float>();
    // public float Control(float x)
    // {
    //     queue.Enqueue(x);
    //     if (queue.Count > 39)
    //         queue.Dequeue();
    //     var M = queue.Average();

    //     return 1.57f * M - 285f;
    // }

    //List<float> list = new List<float>();
    // public float Control(float x)
    // {
    //     list.Add(x);
    //     if (list.Count > 39)
    //         list.Remove(list[0]);
    //     var M = list.Average();

    //     return 1.57f * M - 285f;
    // }
    
    // float[] valores = new float[40];
    // int i = 0;
    // public float Control(float x)
    // {
    //     valores[i] = x;
    //     i++;
    //     if (i > 39)
    //         i = 0;
    //     var M = valores.Average();

    //     return 1.57f * M - 285f;
    // }
}