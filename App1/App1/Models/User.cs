using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace App1.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string UserName { get; set; }

        public User(string email, string password, string Id=null)
        {
            this.Email = email;
            this.password = password;
            this.Id = Id;
        }

        

        public async System.Threading.Tasks.Task<bool> getUser()
        {
            using (var httpClientHandler = new HttpClientHandler())
            { 
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                var url = "http://10.0.2.2:51713/api/Users/1";
                var response = await client.GetAsync(url);
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                
            }         
            return false;
        }
    }
}
