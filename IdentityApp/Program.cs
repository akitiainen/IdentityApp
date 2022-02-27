using System;

namespace IdentityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string uriString = UserInterface();

            StringHandler stringHandler = new StringHandler();
            try
            {
                stringHandler.ParseURI(uriString);
                switch (stringHandler.URIAction)
                {
                    case "login":
                        stringHandler.LoginAction();
                        break;
                    case "confirm":
                        stringHandler.ConfirmAction();
                        break;
                    case "sign":
                        stringHandler.SignAction();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static string UserInterface()
        {
            string netvisor = "visma-identity://confirm?source=netvisor&paymentnumber=102226";
            string severa = "visma-identity://login?source=severa";
            string sign = "visma-identity://sign?source=vismasign&documentid=47ed9186-2ba0-4e8b-b9e2-7123575fdd5b";

            Console.WriteLine("[1] Visma Severa");
            Console.WriteLine("[2] Netvisor");
            Console.WriteLine("[3] Visma Sign");
            Console.WriteLine("\n[Esc] Exit");

            do
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        return severa;
                    case ConsoleKey.D2:
                        return netvisor;
                    case ConsoleKey.D3:
                        return sign;
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Environment.Exit(0);
            return null;
        }
    }
}
