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
            date_picker.MinimumDate = DateTime.Today;
            this.BarBackgroundColor = Color.FromHex("#ffa500");
           


        }

        private async void AddAnnounce(object sender, EventArgs e)
        {
            string UserId = await SecureStorage.GetAsync("user");
            Announce announce = new Announce(description_entry.Text, location_entry.Text, UserId,sport_entry.Text, date_picker.Date);   
            if(await viewModel.addAnnounce(announce))
            {
                await DisplayAlert("", "Announce added", "Ok");
            }
            else
            {
                await DisplayAlert("Whoops", "Something went wrong", "Ok");
            }                      
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //string previous = (e.PreviousSelection.FirstOrDefault() as Announce)?.location;
           // await DisplayAlert("selection changed",previous,"fajnie");
            Announce selection = (e.CurrentSelection.FirstOrDefault() as Announce);
            //await DisplayAlert("selection changed", selection.UserId, selection.description);
            viewModel.SelectedAnnounce = selection;
            await Navigation.PushAsync(new DetailsPage(selection, viewModel) { BindingContext = selection as Announce });
        }

        private async void filter_button_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(location_filter.Text) && string.IsNullOrEmpty(sport_filter.Text))
            {
                viewModel.getAnnounces();
            }
            else
            {
                await viewModel.filterAnnounces(location_filter.Text,sport_filter.Text,date_picker.Date);
            }
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnnouncesPage());
        }

        private async void SettingsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountDetailsPage());
        }
    }
}