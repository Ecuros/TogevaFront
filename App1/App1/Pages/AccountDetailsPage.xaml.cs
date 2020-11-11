using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountDetailsPage : ContentPage
    {
        UserViewModel viewModel;
        public AccountDetailsPage()
        {
            InitializeComponent();
            viewModel = new UserViewModel();
            page.BindingContext = viewModel;
        }

        private async void confirmButton_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(newPassword.Text) && !string.IsNullOrEmpty(newPasswordConf.Text) && !string.IsNullOrEmpty(oldPassword.Text))
            {
                if(newPassword.Text == newPasswordConf.Text)
                {
                    UsersService service = new UsersService();
                    if(await service.UpdatePassword(new User("", oldPassword.Text, await SecureStorage.GetAsync("user"), newPassword.Text)))
                    {
                        await DisplayAlert("", "Password updated", "Ok");
                        await Navigation.PopAsync();
                    }
                }
                else
                {
                    await DisplayAlert("", "New passwords don't match", "Ok");
                }
                
            }
            else
            {
                await DisplayAlert("", "Please fill all the entries", "Ok");
            }
        }
    }
}