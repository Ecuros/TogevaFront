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
    public partial class AnnouncesPage : ContentPage
    {
        private AnnouncesViewModel viewModel;
        public AnnouncesPage()
        {
            InitializeComponent();
            viewModel = new AnnouncesViewModel();
            BindingContext = viewModel;            
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Announce selection = (e.CurrentSelection.FirstOrDefault() as Announce) ;
            await DisplayAlert("selection changed", selection.UserId, selection.description);
           
        }
    }
}