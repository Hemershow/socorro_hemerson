using System.Linq;
using System.Collections.Generic;

App.Run();

public class Controller
{   
    public float Control(float x)
    {
        List<float> lastValues = new List<float>();
        
        if (lastValues.Count() < 40)
        {
            lastValues.Add(x);
        }
        else
        {
            lastValues.RemoveAt(0);
            lastValues.Add(x);
        }

        var m = lastValues.Sum()/lastValues.Count();

        var s = 1.57*m-285;

        return (float)(s);
    }
}