using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class AnnouncesViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Announce> announces;
        ObservableCollection<Announce> userannounces;
        Announce selectedAnnounce;
        public ObservableCollection<Announce> Announces 
        {
            get => announces;
            set { announces = value; OnPropertyChanged("Announces"); } 
        }

        public ObservableCollection<Announce> userAnnounces
        {
            get => userannounces;
            set { userannounces = value; OnPropertyChanged("userAnnounces"); }
        }

        public Announce SelectedAnnounce
        {
            get => selectedAnnounce;
            set { selectedAnnounce = value; }
        }

        public AnnouncesService service;
        public event PropertyChangedEventHandler PropertyChanged;

        public AnnouncesViewModel()
        {
            service = new AnnouncesService();
            Announces = new ObservableCollection<Announce>();
            userAnnounces = new ObservableCollection<Announce>();
            getUserAnnounces();
            getAnnounces();
            selectedAnnounce = Announces.FirstOrDefault();
           
        }

        public async Task addAnnounce(Announce announce)
        {
            Announces.Add(await service.PostAnnounceAsync(announce));            
        }
       
        public async void getAnnounces()
        {
            foreach (Announce announce in await service.GetAnnouncesAsync())
            {
                Announces.Add(announce);
            }            
        }
        public async void getUserAnnounces()
        {
            foreach (Announce announce in await service.GetUserAnnouncesAsync())
            {
                userAnnounces.Add(announce);
            }
        }

        public async Task filterAnnounces(string location)
        {
            Announces = await service.GetFilteredAnnouncesAsync(location);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
