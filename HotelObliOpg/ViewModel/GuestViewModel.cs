using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelObliOpg.Common;

namespace HotelObliOpg.ViewModel
{
    class GuestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }

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

        public GuestViewModel()
        {
            CreateGuestCommand = new RelayCommand(CreateGuest, null);
            DeleteGuestCommand = new RelayCommand(DeleteGuest, CanDeleteGuest);
            UpdateGuestCommand = new RelayCommand(UpdateGuest, CanUpdateGuest);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
