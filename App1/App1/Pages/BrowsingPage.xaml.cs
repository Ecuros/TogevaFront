using App1.Models;
using App1.Services;
using App1.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowsingPage : ContentPage
    {
        public AnnouncesViewModel announcesViewModel;
        public BrowsingPage()
        {
           
            InitializeComponent();
            announcesViewModel = new AnnouncesViewModel();
           
            //AnnouncesService service = new AnnouncesService();    
        }

        
        // public async void GetAnnouncesAsync(object sender, EventArgs args)

    }
}