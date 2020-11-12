using App1.Models;
using App1.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App1.Services
{
    
    public class AnnouncesService
    {
        public async System.Threading.Tasks.Task<ObservableCollection<Announce>> GetAnnouncesAsync ()
        {
            ObservableCollection<Announce> announces = new ObservableCollection<Announce>();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SecureStorage.GetAsync("key").Result);
                User user = new User("", "", SecureStorage.GetAsync("user").Result);
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://10.0.2.2:51713/api/announces/get";
                var response = await client.PostAsync(url,data);
                var result = JsonConvert.DeserializeObject<ObservableCollection<Announce>>(response.Content.ReadAsStringAsync().Result);
                announces = result;
                return announces;
            }           
            
        }

        internal async Task<ObservableCollection<Announce>> GetFilteredAnnouncesAsync(string location, string sport, DateTime date)
        {
            ObservableCollection<Announce> announces = new ObservableCollection<Announce>();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SecureStorage.GetAsync("key").Result);
                Announce announce = new Announce("", location, "", sport, date);
                var json = JsonConvert.SerializeObject(announce);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://10.0.2.2:51713/api/announces/filter";
                var response = await client.PostAsync(url,data);
                var result = JsonConvert.DeserializeObject<ObservableCollection<Announce>>(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                {
                    announces = result;
                    return announces;
                }
                else return null;
            }
        }

        internal async Task<ObservableCollection<Announce>> deleteAnnounce(Announce announce)
        {
            ObservableCollection<Announce> announces = new ObservableCollection<Announce>();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SecureStorage.GetAsync("key").Result);
                var url = "http://10.0.2.2:51713/api/announces/delete";
                //User user = new User("", "", SecureStorage.GetAsync("user").Result);
                var json = JsonConvert.SerializeObject(announce);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, data);
                var result = JsonConvert.DeserializeObject<ObservableCollection<Announce>>(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                {
                    announces = JsonConvert.DeserializeObject<ObservableCollection<Announce>>(response.Content.ReadAsStringAsync().Result);
                    return announces;
                    //Console.WriteLine("usunieted");
               
                }
                return null;
             
            }
        }

        internal async Task<IEnumerable<Announce>> GetUserAnnouncesAsync()
        {
            ObservableCollection<Announce> announces = new ObservableCollection<Announce>();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SecureStorage.GetAsync("key").Result);
                var url = "http://10.0.2.2:51713/api/announces/user";
                User user = new User("", "",SecureStorage.GetAsync("user").Result);
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url,data);
                var result = JsonConvert.DeserializeObject<ObservableCollection<Announce>>(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                {
                    announces = result;
                    return announces;
                }
                else return null;
            }
        }

        public async System.Threading.Tasks.Task<Announce> PostAnnounceAsync(Announce announce)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SecureStorage.GetAsync("key").Result);
                var url = "http://10.0.2.2:51713/api/announces";
                var json = JsonConvert.SerializeObject(announce);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url,data);
                if (response.IsSuccessStatusCode)
                {
                    //announce = await GetAnnouncesAsync();
                    return announce;
                }
                else return null;              
            }

        }

    }
}
