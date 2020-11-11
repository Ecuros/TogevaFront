using App1.Models;
using App1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;

public class UserViewModel : INotifyPropertyChanged
{
    User user;
    public User User
    {
        get => user;
        set { user = value; OnPropertyChanged("User"); }
    } 
    
    public event PropertyChangedEventHandler PropertyChanged;
    public UsersService service;

    public UserViewModel()
    {
        service = new UsersService();
        // Announces = new ObservableCollection<Announce>();
        //userAnnounces = new ObservableCollection<Announce>();
        getUser(new User("","",SecureStorage.GetAsync("user").Result));
       // getAnnounces();
       // selectedAnnounce = Announces.FirstOrDefault();

    }

    public async void getUser(User user)
    {
        User result = await service.getUserInfo(user);
        if (result != null)
        {
            User = result;
        }
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}