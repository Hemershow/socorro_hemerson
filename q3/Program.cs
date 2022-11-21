using System;
using System.Collections.Generic;

App.Run();

public class BluerControl
{   
    public void ApplyBlur(byte[] data)
    {
        byte[] newData = new byte[data.Length];
        data.CopyTo(newData, 0);

        for (int i = 0; i < newData.Length-40; i++)
        {
            int sum = 0;
            for (int j = -20; j < 21; j++)
            {
                sum += (int)(newData[i+20+j]);
            }
            newData[i+20] = (byte)(sum/41);
        }

        Array.Copy(newData, data,newData.Length);
    }
}