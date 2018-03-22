using DatabaseService;
using DatabaseService.Repos;
using Models;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConnectionProvider provider = new ConnectionProvider();
                UserDataRepository userDataBroker = new UserDataRepository(provider);
                User user = userDataBroker.GetUser(null, "florian", "pwd");

                if (user != null)
                {
                    Console.WriteLine(user.Firstname);
                    Console.WriteLine(user.Lastname);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            Console.In.Read();
        }
           
    }
}
