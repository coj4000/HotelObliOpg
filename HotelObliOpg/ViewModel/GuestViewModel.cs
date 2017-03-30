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


        public int Guest_No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public GuestViewModel()
        {
            CreateGuestCommand = new RelayCommand(CreateGuest, null);
            DeleteGuestCommand = new RelayCommand(DeleteGuest, CanDeleteGuest);
            UpdateGuestCommand = new RelayCommand(UpdateGuest, CanUpdateGuest);
        }
            
    }
}
