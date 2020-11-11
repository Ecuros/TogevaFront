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
            GetUserAnnounces();
            getAnnounces();
            selectedAnnounce = Announces.FirstOrDefault();
           
        }

        public async Task<bool> addAnnounce(Announce announce)
        {
            Announce result = await service.PostAnnounceAsync(announce);
            if (result != null)
            {
                userAnnounces.Add(result);
                return true;
            }
            return false;
        }
       
        public async void getAnnounces()
        {
            Announces = await service.GetAnnouncesAsync();
            /*foreach (Announce announce in await service.GetAnnouncesAsync())
            {
                Announces.Add(announce);
            }        */    
        }
        public async void GetUserAnnounces()
        {
            foreach (Announce announce in await service.GetUserAnnouncesAsync())
            {
                userAnnounces.Add(announce);
            }
        }

        public async Task filterAnnounces(string location,string sport,DateTime date)
        {
            Announces = await service.GetFilteredAnnouncesAsync(location,sport,date);
        }

        public async Task<bool> deleteAnnounce (Announce announce)
        {
            userAnnounces = await service.deleteAnnounce(announce);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
