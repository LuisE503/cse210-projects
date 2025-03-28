using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var running = new Running("03 Nov 2022", 30, 5.0);      // Distancia en km
        var cycling = new Cycling("03 Nov 2022", 40, 15.0);     // Velocidad en kph
        var swimming = new Swimming("03 Nov 2022", 25, 20);     // Laps en la piscina

        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
