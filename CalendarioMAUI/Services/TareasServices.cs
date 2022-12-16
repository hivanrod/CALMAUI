using ClasesMAUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace CalendarioMAUI.Services
{
    public class TareasServices
    {
        //string baseUrl = "https://localhost:7119/";
        //string baseUrl = "http://apicalCore/";
        //string baseUrl = "http://192.168.5.105:8090/";
        //string baseUrl = "http://192.168.5.105:8090/";
        string baseUrl = "http://25.82.219.42:8090/";

        public async Task<Tarea[]> GetTareasAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Tareas");
            return JsonConvert.DeserializeObject<Tarea[]>(json);
        }

        public async Task<Tarea[]> GettareasTemaAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Tareas/tema/{id}");
            return JsonConvert.DeserializeObject<Tarea[]>(json);
        }

        public async Task<Tarea[]> GetTareasActivasAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Tareas/Activas");
            return JsonConvert.DeserializeObject<Tarea[]>(json);
        }
        public async Task<Tarea[]> GetTareasHistoricoAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Tareas/Historico/{id}");
            return JsonConvert.DeserializeObject<Tarea[]>(json);
        }
        public async Task<Tarea> GetTareasAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Tareas/{id}");
            return JsonConvert.DeserializeObject<Tarea>(json);
        }
        public async Task<Tarea[]> GetTareasFechaAsync(string fecha)
        {
            var ano = Convert.ToDateTime(fecha).Year;
            var mes = Convert.ToDateTime(fecha).Month;
            var dia = Convert.ToDateTime(fecha).Day;
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Tareas/Fecha/{ano}-{mes}-{dia}");
            return JsonConvert.DeserializeObject<Tarea[]>(json);
        }
        public async Task<Tarea[]> GetTareasFechaMesAsync(string fecha)
        {
            var ano = Convert.ToDateTime(fecha).Year;
            var mes = Convert.ToDateTime(fecha).Month;
            var dia = Convert.ToDateTime(fecha).Day;
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Tareas/Fecha/{ano}-{mes}-{dia}");
            return JsonConvert.DeserializeObject<Tarea[]>(json);
        }

        public async Task<HttpResponseMessage> InsertTareasAsync(Tarea Tarea)
        {
            //if(Tarea.Id == 0)
            //{ 
            //Tarea.FechaHora = (DateTime)Tarea.FechaHora.Value;
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/Tareas", getStringContentFromObject(Tarea));
        }
        public async Task<HttpResponseMessage> UpdateTareasAsync(string id, Tarea Tarea)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Tareas/{id}", getStringContentFromObject(Tarea));
        }
        public async Task<HttpResponseMessage> DeleteTareasAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Tareas/{id}");
        }
        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }

    }
}
