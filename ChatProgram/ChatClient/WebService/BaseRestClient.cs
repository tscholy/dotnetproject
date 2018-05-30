using Models;
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

        public IEnumerable<T> Get<T>(string route, string id, int objectid)
        {
            var request = new RestRequest(route, Method.GET);
            request.AddParameter(id, objectid);
            IRestResponse<List<T>> response = client.Execute<List<T>>(request);
            List<T> objects = response.Data;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return objects;
            }
            else
            {
                return null;
            }
        }

    }
}
