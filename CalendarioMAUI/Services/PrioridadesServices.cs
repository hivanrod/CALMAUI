using CalendarioMAUI.Models;
using Newtonsoft.Json;
using System.Text;


namespace CalendarioMAUI.Services
{
    public class PrioridadesServices
    {
        //string baseUrl = "https://localhost:7119/";
        //string baseUrl = "http://apicalCore/";
        //string baseUrl = "http://192.168.5.105:8090/";
        string baseUrl = "http://192.168.5.105:8090/";
        //string baseUrl = "http://127.0.0.1/";
        public async Task<Prioridad[]> GetPrioridadesAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Prioridades");
            return JsonConvert.DeserializeObject<Prioridad[]>(json);
        }
        public async Task<Prioridad[]> GetPrioridadesCitaAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Prioridades/Cita");
            return JsonConvert.DeserializeObject<Prioridad[]>(json);
        }
        public async Task<Prioridad> GetPrioridadAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Prioridades/{id}");
            return JsonConvert.DeserializeObject<Prioridad>(json);
        }

        public async Task<HttpResponseMessage> InsertPrioridadesAsync(Prioridad prioridad)
        {
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/Prioridades", getStringContentFromObject(prioridad));
        }
        public async Task<HttpResponseMessage> UpdatePrioridadesAsync(string id, Prioridad prioridad)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Prioridades/{id}", getStringContentFromObject(prioridad));
        }
        public async Task<HttpResponseMessage> DeletePrioridadesAsync(string id, Prioridad prioridad)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Prioridades/{id}");
        }
        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }

    }
}
