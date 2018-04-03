using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.WebService
{
    public abstract class BaseRestClient
    {
        protected RestClient client;

        public BaseRestClient()
        {
            client = new RestClient("http://localhost:50049/api/");
        }
    }
}
