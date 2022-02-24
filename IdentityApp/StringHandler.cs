using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApp
{
    class StringHandler
    {
        private string _uriString = "visma-identity://confirm?source=netvisor&paymentnumber=102226";

        public void ParseURI()
        {
            var URIScheme = _uriString.Split(':');
            Console.WriteLine(URIScheme[0]);
            var URIAction = URIScheme[1].Split('?');
            Console.WriteLine(URIAction[0]);
            var UriParameters = URIAction[1].Split('=');
            Console.WriteLine(UriParameters[1]);
        }

        public void ValidateURI()
        {

        }
    }
}
