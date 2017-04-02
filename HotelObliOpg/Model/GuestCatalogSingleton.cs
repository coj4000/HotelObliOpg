using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelObliOpg.Model
{
    class GuestCatalogSingleton
    {
        private ObservableCollection<Guest> guests;

        public ObservableCollection<Guest> Guests
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


    }
}
