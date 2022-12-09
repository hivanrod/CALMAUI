using ClasesMAUI.Models;
using Newtonsoft.Json;
using System.Text;


namespace CalendarioMAUI.Services
{
    public class RepeticionesServices
    {
        //string baseUrl = "https://localhost:7119/";
        //string baseUrl = "http://apicalCore/";
        //string baseUrl = "http://192.168.5.105:8090/";
        string baseUrl = "http://25.82.219.42:8090/";

        public async Task<Repeticion[]> GetRepeticionesAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Repeticiones");
            return JsonConvert.DeserializeObject<Repeticion[]>(json);
        }
        public async Task<Repeticion> GetRepeticionAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Repeticiones/{id}");
            return JsonConvert.DeserializeObject<Repeticion>(json);
        }
        public async Task<Repeticion[]> GetRepeticionesTemaAsync(int id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Repeticiones/Tema/{id}");
            return JsonConvert.DeserializeObject<Repeticion[]>(json);
        }
        public async Task<Repeticion[]> GetRepeticionesCitaAsync(int id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Repeticiones/Cita/{id}");
            return JsonConvert.DeserializeObject<Repeticion[]>(json);
        }
        public async Task<Repeticion[]> GetRepeticionesTareaAsync(int id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Repeticiones/Tarea/{id}");
            return JsonConvert.DeserializeObject<Repeticion[]>(json);
        }

        public async Task<Repeticion[]> GetRepeticionPrioridadAsync(int id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Repeticiones/Prioridad/{id}");
            return JsonConvert.DeserializeObject<Repeticion[]>(json);
        }

        public async Task<HttpResponseMessage> InsertRepeticionesAsync(Repeticion Repeticion)
        {
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/Repeticiones", getStringContentFromObject(Repeticion));
        }
        public async Task<HttpResponseMessage> UpdateRepeticionesAsync(string id, Repeticion Repeticion)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Repeticiones/{id}", getStringContentFromObject(Repeticion));
        }
        public async Task<HttpResponseMessage> DeleteRepeticionesAsync(string id, Repeticion Repeticion)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Repeticiones/{id}");
        }
        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }

    }
}
