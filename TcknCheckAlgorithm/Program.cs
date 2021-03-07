using System;
using TcknCheckAlgorithm.Helpers;

namespace TcknCheckAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TcknCheckAlgorithm made by furkanaltaca | v2.1");
            Console.WriteLine("Press Ctrl+C to exit");
            Console.WriteLine();

            while (true)
            {
                Console.Write("TC Kimlik No: ");
                Console.WriteLine(TcknHelper.CheckTckn(Console.ReadLine()));
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
