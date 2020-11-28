using App1.Models;
using App1.Services;
using App1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        UsersService service;
        public RegisterPage()
        {
            InitializeComponent();
            service = new UsersService();
        }

        private async void Register(object sender, EventArgs e)
        {
            if(IsValidEmail(email_entry.Text))
            {
                User user = new User(email_entry.Text, password_entry.Text, firstName: firstName_entry.Text);
                if (await service.RegisterUserAsync(user))
                {
                    await Navigation.PushAsync(new LoginPage());
                }
            }
            else
            {
                email_entry.Text = "Please enter a valid email";
                email_entry.FontSize = 14;
                email_entry.TextColor = Color.Red;
            }

        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}