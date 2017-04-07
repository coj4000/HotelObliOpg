using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelObliTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            const string serverUrl = "http://localhost:36179/";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/guests";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var guestlist = response.Content.ReadAsAsync<List<Guest>>().Result;
                        foreach (var guest in guestlist)
                        {
                            Console.WriteLine("Guest_No" + guest.Guest_No + "Name" + guest.Name + "Address" + guest.Address);
                            
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadKey();
        }
      


    }

}
