using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HotelObliOpg.Model;
using System.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using System.Net.Http.Headers;

namespace HotelObliOpg.Persistency
{
    class PersistencyService
    {

        const string serverUrl = "http://localhost:36179/";


        public static async Task<List<Guest>> GetAllGuestAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlstring = "api/Guests";
                try
                {
                    var response = await client.GetAsync(urlstring);
                    if (response.IsSuccessStatusCode)
                    {
                        var guestList = await response.Content.ReadAsAsync<List<Guest>>();

                        return guestList;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    MessageDialog exception = new MessageDialog(e.Message);
                    return null;
                }
            }
        }


        public static async Task<ObservableCollection<Guest>> GetGuestsAsync()
        {
            ObservableCollection<Guest> TempGuestsCollection = new ObservableCollection<Guest>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/guests";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlString);
                    if (response.IsSuccessStatusCode)
                    {
                        TempGuestsCollection = response.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;


                    }
                }
                catch (Exception e)
                {
                    MessageDialog exception = new MessageDialog(e.Message);
                    return TempGuestsCollection = null;

                }
                return TempGuestsCollection;
            }

            
        }

        public static void CreateGuestAsync(Guest newGuests)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringCreate = "api/guests";

                try
                {
                    var createResponse = client.PostAsJsonAsync<Guest>(urlStringCreate, newGuests).Result;

                    if (createResponse.IsSuccessStatusCode)
                    {
                        MessageDialog guestCreated = new MessageDialog("Guest is Created");
                    }
                    else
                    {
                        MessageDialog guestNotCreated = new MessageDialog("Create guest failed");
                    }
                }
                catch (Exception e)
                {
                    MessageDialog guestNotCreated = new MessageDialog("Create guest falied" + e);
                }
            }

        }
    }
}
