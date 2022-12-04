using System.Collections.Generic;

App.Run();

public class BluerControl
{   
    public void ApplyBlur(byte[] data)
    {
        byte[] copy = new byte[data.Length];

        for (int i = 50; i < copy.Length - 50; i++)
        {
            int sum = 0;
            for (int j = -50; j < 51; j++)
            {
                sum += data[i + j];
            }
            copy[i] = (byte)(sum / 101);
        }

        for (int i = 0; i < data.Length; i++)
            data[i] = copy[i];
    }
}