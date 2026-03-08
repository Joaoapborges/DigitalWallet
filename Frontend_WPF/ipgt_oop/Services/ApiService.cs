using ipgt_oop.MVVM.Models;
using System;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace ipgt_oop.Services
{
    class ApiService
    {
        private const string BaseUrl = "https://localhost:7164/api";

        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> RegisterClientAsync(string Name, string Email, string Nif, string Country, string Password)
        {

            string url = BaseUrl + "/Clients";

            var payload = new
            {
                name = Name,
                email = Email,
                nif = Nif,
                country = Country,
                password = Password,
                image = "default.png"
            };

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, payload);

                if (!response.IsSuccessStatusCode)
                {
                    // LER O ERRO DA API
                    string erroDaApi = await response.Content.ReadAsStringAsync();

                    // mostrar no output
                    System.Diagnostics.Debug.WriteLine($"[ERRO DA API] Status: {response.StatusCode}");
                    System.Diagnostics.Debug.WriteLine($"[DETALHES DO ERRO]: {erroDaApi}");

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"[EXCEÇÃO HTTP]: {e.Message}");
                return false;
            }

        }
    }
}
