using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                editButton.IsVisible = false;
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
            var response = await DisplayAlert("Do you really want to delete this announce?", "Do you really want to delete this announce?", "Yes", "No");
            if (response)
            {
                await viewModel.deleteAnnounce(announce);
                await Navigation.PopAsync();               
            }
        }
    }
}