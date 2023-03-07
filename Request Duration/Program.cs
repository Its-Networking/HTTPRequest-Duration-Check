using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class Program
{
    static int durationCheck = 400; // if the duration takes longer than the # put here then the response will be displayed as bad

    static async Task Main(string[] args)
    {
        Console.WriteLine("Please enter the url you would like to make a request to.");
        var output = Console.ReadLine();
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, output);
            var stopwatch = Stopwatch.StartNew();
            var response = await client.SendAsync(request);
            var duration = stopwatch.Elapsed;
            Console.WriteLine($"It took {duration.TotalMilliseconds} ms to complete the request.");

            if (duration.TotalMilliseconds >= durationCheck)
            {
                Console.WriteLine("Response time was bad");
            }
            else
            {
                Console.WriteLine("Response time was good");
            }
        }
    }
}
