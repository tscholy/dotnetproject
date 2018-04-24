using Models;
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
        private User currentUser;

        public UserRestClient() : base()
        {
        }

        public User CurrentUser { get => currentUser; set => currentUser = value; }

        public bool Login(string username, string password)
        {
            try
            {
                var request = new RestRequest("user/login", Method.POST);
                request.AddParameter("username", username);
                request.AddParameter("password", password);

                request.AddHeader("header", "value");

                var response = client.Execute<User>(request);
                var content = response.Content;
                currentUser = response.Data;
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

        public List<BaseUser> GetAllContracts(int currentUser)
        {
            try
            {
                var request = new RestRequest("user/allcontacts", Method.GET);
                request.AddParameter("user", currentUser);
                var response = client.Execute<List<BaseUser>>(request);
                var content = response.Content;
                List<BaseUser> allContacts = new List<BaseUser>();
                allContacts = response.Data;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return allContacts;
                }
                
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            return new List<BaseUser>();
        }
    }
}
