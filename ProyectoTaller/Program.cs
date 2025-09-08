using Proyecto1;
using System;

class Program
{
    static void Main(string[] args)
    {
        Time[] tiempos = new Time[]
        {
            new Time(0, 0, 0, 0),
            new Time(2, 0, 0, 0),
            new Time(9, 34, 0, 0),
            new Time(7, 45, 56, 0),
            new Time(11, 3, 45, 678),
            new Time(45, 0, 0, 0) // Inválida
        };

        foreach (var t in tiempos)
        {
            Time suma = t.Add(new Time(9, 34, 0, 0));

            Console.WriteLine("Time: {0}", t.ToString());
            Console.WriteLine("Milliseconds : {0}", t.ToMilliseconds().ToString("N0"));
            Console.WriteLine("Seconds      : {0}", t.ToSeconds().ToString("N0"));
            Console.WriteLine("Minutes      : {0}", t.ToMinutes().ToString("N0"));
            Console.WriteLine("Add          : {0}", suma.ToString());
            Console.WriteLine("Is Other day : {0}", t.IsOtherDay(new Time(9, 34, 0, 0)));
            Console.WriteLine();
        }

        //Mostrar el error al final
        if (!string.IsNullOrEmpty(Time.LastError))
        {
            Console.WriteLine(Time.LastError);
        }
    }
}
