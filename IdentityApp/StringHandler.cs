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
            URIScheme = ValidateScheme(tmpUriString[0].ToLower());

            var tmpActionString = tmpUriString[1].Split('?');
            tmpActionString[0] = tmpActionString[0].TrimStart('/').ToLower();
            URIAction = ValidateAction(tmpActionString[0]);

            var tmpParameterStrings = tmpActionString[1].Split('&');
            tmpParameterStrings[0] = tmpParameterStrings[0].Substring(7);
            
            ValidateParameters(URIAction, tmpParameterStrings);

            Console.WriteLine($"\nAction: {URIAction}");
        }

        public string ValidateScheme(string scheme)
        {
            if (scheme != "visma-identity")
            {
                throw new Exception("URI scheme not correct");
            }
            return scheme;
        }

        public string ValidateAction(string action)
        {
            if (action != "login" && action != "confirm" && action != "sign")
            {
                throw new Exception($"URI Action '{action}' not allowed");
            }
            return action;
        }

        public void ValidateParameters(string action, string[] parameters)
        {
            if(action == "login")
            {
                if (parameters[0] == "severa")
                {
                    return;
                }
            }
            if(action == "confirm")
            {
                var parameterKey = parameters[1].Split('=');
                if (parameters[0] == "netvisor" && parameterKey[0] == "paymentnumber")
                {
                    URIParameters = parameterKey;
                    return;
                }
            }
            if(action == "sign")
            {
                var parameterKey = parameters[1].Split('=');
                if (parameters[0] == "vismasign" && parameterKey[0] == "documentid")
                {
                    URIParameters = parameterKey;
                    return;
                }
            }
            throw new Exception($"Parameters {parameters} for requested action are invalid");
        }

        public string LoginAction()
        {
            return URIAction;
        }

        public string ConfirmAction()
        {
            Console.WriteLine($"Parameter value: {URIParameters[1]}");
            return URIParameters[1];
        }
        public Guid SignAction()
        {
            Guid guid = Guid.Parse(URIParameters[1]);
            Console.WriteLine($"Parameter value: {URIParameters[1]}");
            return guid;
        }
    }
}
