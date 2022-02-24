using System;

namespace IdentityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringHandler stringHandler = new StringHandler();
            Console.WriteLine("Hello World!");
            stringHandler.ParseURI();
        }
    }
}
