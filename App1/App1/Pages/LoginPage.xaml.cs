using App1.Models;
using App1.Pages;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private UsersService service;
        public LoginPage()
        {
            InitializeComponent();
            service = new UsersService();
            
        }

        public async void Login (object sender, EventArgs args)
        {
            User user = new User(email_entry.Text, password_entry.Text);
            if (await service.Login(user))
            {
                await Navigation.PushAsync(new TabbedPage1());
            }
        }

        public async void GoToRegister(object sender, EventArgs args)
        {           
            await Navigation.PushAsync(new RegisterPage());           
        }
    }
}