using CALMAUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace CALMAUI.Services
{
    public class CitasServices
    {
        //string baseUrl = "https://localhost:7119/";
        //string baseUrl = "http://localhost:5093/";
        //string baseUrl = "http://apicalCore/";
        string baseUrl = "http://192.168.5.105:8090/";
//        baseUrl = "http://25.82.219.42/"; 
        public async Task<Cita[]> GetCitasAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Citas");
            return JsonConvert.DeserializeObject<Cita[]>(json);
        }
        public async Task<Cita[]> GetCitasHistoricoAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Citas/Historico/{id}");
            return JsonConvert.DeserializeObject<Cita[]>(json);
        }
        public async Task<Cita> GetCitasAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Citas/{id}");
            return JsonConvert.DeserializeObject<Cita>(json);
        }
        public async Task<Cita[]> GetCitasFechaAsync(string fecha)
        {
            var ano = Convert.ToDateTime(fecha).Year;
            var mes = Convert.ToDateTime(fecha).Month;
            var dia = Convert.ToDateTime(fecha).Day;
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Citas/Fecha/{ano}-{mes}-{dia}");
            return JsonConvert.DeserializeObject<Cita[]>(json);
        }

        public async Task<HttpResponseMessage> InsertCitasAsync(Cita Cita)
        {
            //if(Cita.Id == 0)
            //{ 
            //Cita.FechaHora = (DateTime)Cita.FechaHora.Value;
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/Citas", getStringContentFromObject(Cita));
        }
        public async Task<HttpResponseMessage> UpdateCitasAsync(string id, Cita Cita)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Citas/{id}", getStringContentFromObject(Cita));
        }
        public async Task<HttpResponseMessage> DeleteCitasAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Citas/{id}");
        }
        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }

    }
}
