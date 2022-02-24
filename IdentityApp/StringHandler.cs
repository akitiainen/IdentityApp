using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApp
{
    class StringHandler
    {
        
        public string[] ParseURI(string uriString)
        {
            var URIScheme = uriString.Split(':');
            Console.WriteLine("scheme: " + URIScheme[0]);
            if (URIScheme[0].ToLower() != "visma-identity")
            {
                throw new Exception("URI scheme not correct");
            }
            var URIAction = URIScheme[1].Split('?');
            URIAction[0] = URIAction[0].TrimStart('/');
            if(URIAction[0].ToLower() != "login" && URIAction[0].ToLower() != "confirm" && URIAction[0].ToLower() != "sign")
            {
                throw new Exception($"URI Action '{URIAction[0]}' not allowed");
            }

            return URIAction;

        }

        public void LoginAction(string source)
        {
            Console.WriteLine("login action completed");
            Console.WriteLine(source);
        }

        public string ConfirmAction(string source, string paymentNumber)
        {
            Console.WriteLine("Confirm action completed");
            Console.WriteLine(source);
            return paymentNumber;
        }
        public Guid SignAction(string source, string documentId)
        {
            Guid guid = Guid.Parse(documentId);
            Console.WriteLine("Sign action completed");
            Console.WriteLine(source);
            return guid;
        }
    }
}
