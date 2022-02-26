using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApp
{
    class StringHandler
    {
        public string URIScheme;
        public string URIAction;
        public string[] URIParameters;
        public void ParseURI(string uriString)
        {
            var tmpUriString = uriString.Split(':');
            URIScheme = tmpUriString[0];
            if (URIScheme.ToLower() != "visma-identity")
            {
                throw new Exception("URI scheme not correct");
            }
            var tmpActionString = tmpUriString[1].Split('?');
            URIAction = tmpActionString[0].TrimStart('/');
            if(URIAction.ToLower() != "login" && URIAction.ToLower() != "confirm" && URIAction.ToLower() != "sign")
            {
                throw new Exception($"URI Action '{URIAction}' not allowed");
            }
            Console.WriteLine(URIAction);
            URIParameters = tmpActionString[1].Split('&');
            URIParameters[0] = URIParameters[0].Substring(7);
            if(URIAction.ToLower() == "confirm")
            {
                URIParameters[1] = URIParameters[1].Substring(14);
            }
            if(URIAction.ToLower() == "sign")
            {
                URIParameters[1] = URIParameters[1].Substring(11);
            }
        }

        public string LoginAction()
        {
            Console.WriteLine("login action completed");
            return URIAction;
        }

        public string ConfirmAction()
        {
            Console.WriteLine("Confirm action completed");
            return URIParameters[1];
        }
        public Guid SignAction()
        {
            Guid guid = Guid.Parse(URIParameters[1]);
            Console.WriteLine("Sign action completed");
            return guid;
        }
    }
}
