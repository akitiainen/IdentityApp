using System;

namespace IdentityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string uriString = "visma-identity://confirm?source=netvisor&paymentnumber=102226";
            string uriString2 = "visma-identity://login?source=severa";
            string uriString3 = "visma-identity://sign?source=vismasign&documentid=47ed9186-2ba0-4e8b-b9e2-7123575fdd5b";

            StringHandler stringHandler = new StringHandler();
            try
            {
                stringHandler.ParseURI(uriString2);
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
    }
}
