using App1.Models;
using App1.ViewModels;
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

    public partial class DetailsPage : ContentPage
    {
        private AnnouncesViewModel viewModel;
        private Announce announce;
        public DetailsPage(Announce announce, AnnouncesViewModel viewModel, bool editsPossible=false)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.announce = announce;
            if(!editsPossible)
            {
                deleteButton.IsVisible = false;
                //editButton.IsVisible = false;
                sendMessageButton.IsVisible = true;
            }
            else
            {
                sendMessageButton.IsVisible = false;
            }
            //BindingContext = viewModel;
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Are you sure?", "Do you really want to delete this announce?", "Yes", "No");
            if (response)
            {
                await viewModel.deleteAnnounce(announce);
                await Navigation.PopAsync();               
            }
        }
        private async void sendMessageButton_ClickedAsync(object sender, EventArgs e)
        {
            //var response = await DisplayAlert("Are you sure?", "Do you really want to delete this announce?", "Yes", "No");
            //if (response)
            Console.WriteLine(announce.User.Email);
            {
                try
                {
                    var message = new EmailMessage
                    {
                        Subject = "Togeva mail",
                        Body = "elo byq przychodze na piłe",
                        To = new List<string> { announce.User.Email },
                        //Cc = ccRecipients,
                        //Bcc = bccRecipients
                    };
                    await Email.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException fbsEx)
                {
                    // Email is not supported on this device
                }
                catch (Exception ex)
                {
                    // Some other exception occurred
                }
            }
        }
    }
}