using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Security.Cryptography.Core;
using HotelObliOpg.Common;
using HotelObliOpg.Model;
using HotelObliOpg.Persistency;

namespace HotelObliOpg.ViewModel
{
   public class GuestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }

    //    private RelayCommand getGuestCommand;

      //  public RelayCommand GetGuestCommand
        //{
        //    get { return getGuestCommand; }
        //    set { getGuestCommand = value; }
        //}


        public GuestCatalogSingleton GuestCatalogSingleton { get; set; }

        private ObservableCollection<Guest> guestCollection;

        public ObservableCollection<Guest> GuestCollection
        {
            get { return guestCollection; }
            set { guestCollection = value; }
        }

        private int guest_no;

        public int Guest_No
        {
            get { return guest_no; }
            set
            {
                guest_no = value;
                OnPropertyChanged(nameof(Guest_No));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private Guest selectedGuest;
        public Guest SelectedGuest
        {
            get { return selectedGuest; }
            set { selectedGuest = value; OnPropertyChanged(nameof(SelectedGuest)); }
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        





        public Handler.GuestHandler gh { get; set; }

        


        public GuestViewModel()
        {
            GuestCollection = GuestCatalogSingleton.Instance.GuestsCollection;
            gh = new Handler.GuestHandler(this);
            GuestCatalogSingleton = GuestCatalogSingleton.Instance;

            CreateGuestCommand = new RelayCommand(gh.CreateGuest, null);
            DeleteGuestCommand = new RelayCommand(gh.DeleteGuest, CanDeleteGuest);          
            UpdateGuestCommand = new RelayCommand(gh.UpdateGuest, null);

         //   GetGuestCommand = new RelayCommand(gh.LoadGuestsAsync, null);
            
            
            
        }

        public bool CanDeleteGuest()
        {
            if (GuestCollection.Count > 0)
                return true;
            else
            {
                return false;
            }

        }

        
    }
}
