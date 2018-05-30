using Models;
using Newtonsoft.Json;
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
                IRestResponse<User> response = client.Execute<User>(request);
                currentUser = response.Data;
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }

            }
            catch (Exception e)
            {
               
            }
            return false;
        }

        public List<BaseUser> GetAllContacts(int currentUser)
        {
            try
            {
                var request = new RestRequest("user/allcontacts", Method.GET);
                request.AddParameter("user", currentUser);
                var response = client.Execute<List<BaseUser>>(request);
                var content = response.Content;
                List<BaseUser> allContacts = new List<BaseUser>();
                allContacts = JsonConvert.DeserializeObject<List<BaseUser>>(content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return allContacts;
                }
            }
            catch (Exception e)
            {
                
            }
            return new List<BaseUser>();
        }

        internal bool Register(User user)
        {
            try
            {
                var request = new RestRequest("user/register", Method.POST);

                var json = JsonConvert.SerializeObject(user);
                request.AddParameter("text/json", json, ParameterType.RequestBody);
                var response = client.Execute<User>(request);
                var content = response.Content;
                User newUser = new User();
                newUser = response.Data;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    currentUser = newUser;
                    return true;
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return false;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
