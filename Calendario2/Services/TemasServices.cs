using Newtonsoft.Json;
using System.Text;
using Calendario2.Models;
using Microsoft.Extensions.Configuration;

namespace Calendario2.Services
{

    public class TemasServices
    {
        private readonly IConfiguration _configuration;
        public TemasServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //builder.
        //string baseUrl = "https://localhost:7119/";
        //string baseUrl = "http://apicalCore/";
        //string baseUrl = "http://192.168.5.105:8090/";
        //string baseUrl = "http://192.168.5.105:8090/";
        string baseUrl = "http://25.82.219.42:8090/";
        //string baseUrl = CalendarioMAUI.Data.APIURL;
        //string baseUrl = _configuration.GetSection("apiurl:dataserver").Value.ToString();
        public async Task<Tema[]> GetTemasAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Temas");
            return JsonConvert.DeserializeObject<Tema[]>(json);
        }
        public async Task<Tema> GetTemaAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Temas/{id}");
            return JsonConvert.DeserializeObject<Tema>(json);
        }
        public async Task<Tema[]> GetTemaPrioridadAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Temas/Prioridad/{id}");
            return JsonConvert.DeserializeObject<Tema[]>(json);
        }


        //public async Task<Tema[]> GetTemasCitasAsync(string id)
        //{
        //    HttpClient http = new HttpClient();
        //    var json = await http.GetStringAsync($"{baseUrl}api/Temas/Prioridad/{id}");
        //    return JsonConvert.DeserializeObject<Tema[]>(json);
        //}



        public async Task<HttpResponseMessage> InsertTemasAsync(Tema Tema)
        {
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/Temas", getStringContentFromObject(Tema));
        }
        public async Task<HttpResponseMessage> UpdateTemasAsync(string id, Tema Tema)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Temas/{id}", getStringContentFromObject(Tema));
        }
        public async Task<HttpResponseMessage> DeleteTemasAsync(string id, Tema Tema)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Temas/{id}");
        }
        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }

    }
}
