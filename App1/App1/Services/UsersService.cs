using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Essentials;

namespace App1.Services
{
    public class UsersService
    {
        public async System.Threading.Tasks.Task<bool> Login(User user)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://10.0.2.2:51713/api/authentication/logowanie";
                var response = await client.PostAsync(url, data);
                var result = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result);
                if (!string.IsNullOrEmpty(result.token))
                {
                    try
                    {
                        await SecureStorage.SetAsync("key", result.token);
                        await SecureStorage.SetAsync("user", result.userId);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("exception: " + ex);
                    }
                    Console.WriteLine(await SecureStorage.GetAsync("key"));
                    return true;
                }
            }
            return false;
        }
        public async System.Threading.Tasks.Task<bool> RegisterUserAsync(User user)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://10.0.2.2:51713/api/Users/register";
                var response = await client.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            }
        }
        public async System.Threading.Tasks.Task<bool> UpdatePassword(User user)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://10.0.2.2:51713/api/Users/np";
                var response = await client.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            }
        }
        public async System.Threading.Tasks.Task<User> getUserInfo(User user)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://10.0.2.2:51713/api/users/user";
                var response = await client.PostAsync(url,data);
                //string result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    User result = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                    return result;
                }
                else return null;
               
                //Console.WriteLine(result);

            }           
        }
    }
}
