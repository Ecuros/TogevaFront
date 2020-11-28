using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Essentials;

namespace App1.Models
{
    public class Announce
    {
        public int AnnounceId { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string UserId { get; set; }
        public string sport { get; set; }

        public User User { get; set; }
        public DateTime date { get; set; }
       // public User User { get; set; }

        public Announce( string description, string location, string UserId, string sport, DateTime date)
        {
            //this.AnnounceId = AnnounceId;
            this.location = location;
            this.description = description;
            this.UserId = UserId;
            this.sport = sport;
            this.date = date;
          //  this.User = user;
        }



         
    }


}
