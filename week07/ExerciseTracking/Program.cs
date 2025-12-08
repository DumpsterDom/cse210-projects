using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Activities
        Running run1 = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycle1 = new Cycling("03 Nov 2022", 40, 12.0);
        Swimming swim1 = new Swimming("03 Nov 2022", 25, 20);

        activities.Add(run1);
        activities.Add(cycle1);
        activities.Add(swim1);

        // Summary
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}