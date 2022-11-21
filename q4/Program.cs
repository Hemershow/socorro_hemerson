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

        // List<float> averages = new List<float>();

        // for (int i = 0; i < 40; i++)
        // {
        //     var average = lastValues.TakeLast(i).Sum()/lastValues.Count();
        //     averages.Add(average);
        // }



        // return (averages.Sum()/averages.Count());



        // var average = lastValues.Sum()/lastValues.Count();
        // var average2 = lastValues.TakeLast(20).Sum()/lastValues.Count();

        

        // return (float)(average2- average);

        var average = lastValues.Sum()/lastValues.Count();

        return average;

    }
}