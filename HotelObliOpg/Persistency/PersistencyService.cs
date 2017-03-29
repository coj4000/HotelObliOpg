using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HotelObliOpg.Model;
using System.Collections;

namespace HotelObliOpg.Persistency
{
    class PersistencyService
    {

        public static async Task<ObservableCollection<Guest>> loadGuestAsync()
        {
            const string serverUrl = "http://localhost:10723/";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Guest";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var guestlist = response.Content.ReadAsAsync<List<Guest>>().Result;
                        foreach (var guest in guestlist)
                        {
                            
                        }

                    }
                }
                catch (Exception e)
                {


                }
            }
        }
    }
}
