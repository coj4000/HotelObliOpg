using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelObliOpg.ViewModel;
using HotelObliOpg.Model;
using System.Collections.ObjectModel;
using HotelObliOpg.Persistency;

namespace HotelObliOpg.Handler
{
   public class GuestHandler
    {
        public GuestViewModel GuestViewModel { get; set; }

       // public ObservableCollection<Guest> GuestList { get; private set; }
        public GuestHandler(GuestViewModel gvm)
        {
            this.GuestViewModel = gvm;
        }

        public void CreateGuest()
        {
            Guest tempGuest = new Guest(GuestViewModel.Guest_No, GuestViewModel.Name, GuestViewModel.Address);
            tempGuest.Name = GuestViewModel.Name;
            tempGuest.Address = GuestViewModel.Address;
            tempGuest.Guest_No = GuestViewModel.Guest_No;
            GuestCatalogSingleton.Instance.AddGuest(tempGuest);



        }

        public void DeleteGuest()
        {
            GuestCatalogSingleton.Instance.RemoveGuest(GuestViewModel.SelectedGuest);
            

        }

        
        public void UpdateGuest()
        {
            GuestCatalogSingleton.Instance.UpdateGuest(GuestViewModel.SelectedGuest);
        }

        public async void GetGuest()
        {
            await GuestCatalogSingleton.Instance.GetGuestsAsync();
        }


    }
}
