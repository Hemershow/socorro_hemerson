using System;
using System.Linq;

double[] array = new double[]
{
    6.6, 7.2, 7.2, 8.4, 8.6, 8.4, 9.4, 9.8, 10.0
};
Console.WriteLine(mediaEspecial(array));

double mediaEspecial(double[] array)
{
    double[] arrayAux = new double[array.Length];

    array.CopyTo(arrayAux, 0);

    while(arrayAux.Length > 4)
    {
        double high = arrayAux.Max();
        double low = arrayAux.Min();

        var list = arrayAux.ToList();

        list.Remove(high);
        list.Remove(low);

        arrayAux = list.ToArray();
    }

    return (arrayAux.Sum()/3);
}