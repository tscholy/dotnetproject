using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatClient.WebService
{
    public  class UserRestClient : BaseRestClient
    {
        public UserRestClient() : base()
        {
        }

        public bool Login(string username, string password)
        {
            try
            {
                var request = new RestRequest("user/login", Method.POST);
                request.AddParameter("username", username);
                request.AddParameter("password", password);

                request.AddHeader("header", "value");

                IRestResponse response = client.Execute(request);
                var content = response.Content;
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
