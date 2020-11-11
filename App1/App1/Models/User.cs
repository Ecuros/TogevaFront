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
        public string firstName { get; set; }
        public string newPassword { get; set; }

        public User(string email, string password, string Id=null, string newPassword=null,string firstName=null)
        {
            this.Email = email;
            this.password = password;
            this.Id = Id;
            this.newPassword = newPassword;
            this.firstName = firstName;
        }              
    }
}
