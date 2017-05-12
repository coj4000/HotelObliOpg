using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelObliOpg.Persistency;

namespace HotelObliOpg.Model
{
   public class GuestCatalogSingleton
    {
        private ObservableCollection<Guest> guests;

        public ObservableCollection<Guest> GuestsCollection 
        {
            get { return guests; }
            set { guests = value; }

        }

        

        private static GuestCatalogSingleton instance;

        public static GuestCatalogSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuestCatalogSingleton();
                }
                return instance;
            }

        }

        

        public GuestCatalogSingleton()
        {
            GuestsCollection = new ObservableCollection<Guest>();
            GetGuestsAsync();

        }

        //post
        public void AddGuest(Guest GAdd)
        {
            GuestsCollection.Add(GAdd);
            PersistencyService.CreateGuestAsync(GAdd);
        }

        //delete    
        public void RemoveGuest(Guest GRemove)
        {
            GuestsCollection.Remove(GRemove);
            PersistencyService.DeleteGuestAsync(GRemove);
        }

        // read
        public async Task GetGuestsAsync()
        { 
            
            foreach (var item in await PersistencyService.GetGuestsAsync())
            {
                this.GuestsCollection.Add(item);
            }

    }

            
        
        //put
        //public void UpdateGuest(Guest GUpdate)
        //{
            
        //    PersistencyService.UpdateGetGuest(GUpdate);
            
            
        //}

        
        

    }
}
