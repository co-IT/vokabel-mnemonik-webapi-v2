using System;
using Microsoft.Owin.Hosting;

namespace VokabelMnemonikApi.SelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var host = WebApp.Start<Startup>("http://localhost:3000"))
            {
                Console.WriteLine("Your slave Gregor is listening");
                Console.ReadLine();
            }
        }
    }
}