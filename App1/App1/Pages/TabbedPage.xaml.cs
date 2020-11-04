using App1.Models;
using App1.Services;
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
    public partial class TabbedPage1 : TabbedPage
    {
        private AnnouncesViewModel viewModel;
        public TabbedPage1()
        {
            InitializeComponent(); 
            viewModel = new AnnouncesViewModel();
            announcesPage.BindingContext = viewModel;
            accountPage.BindingContext = viewModel;
            
        }

        private async void AddAnnounce(object sender, EventArgs e)
        {
            string UserId = await SecureStorage.GetAsync("user");
            Announce announce = new Announce(description_entry.Text, location_entry.Text, UserId,sport_entry.Text);           
            await viewModel.addAnnounce(announce);
            
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string previous = (e.PreviousSelection.FirstOrDefault() as Announce)?.location;
            await DisplayAlert("selection changed",previous,"fajnie");
        }

        private async void filter_button_Clicked(object sender, EventArgs e)
        {
            await viewModel.filterAnnounces(location_filter.Text);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnnouncesPage());
        }
    }
}