using Calendario2.Models;
using Newtonsoft.Json;
using System.Text;

namespace Calendario2.Services
{
    public class ContactosServices
    {
        //string baseUrl = "https://localhost:7119/";
        //string baseUrl = "http://apicalCore/";
        //string baseUrl = "http://192.168.5.105:8090/";
        //string baseUrl = "http://192.168.5.105:8090/";
        string baseUrl = "http://25.82.219.42:8090/";

        public async Task<Contacto[]> GetContactosAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync(requestUri: $"{baseUrl}api/Contactos");
            return JsonConvert.DeserializeObject<Contacto[]>(json);
        }
        public async Task<Contacto> GetContactoAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Contactos/{id}");
            return JsonConvert.DeserializeObject<Contacto>(json);
        }
        public async Task<Contacto[]> GetContactosFechaAsync(string fecha)
        {
            var ano = Convert.ToDateTime(fecha).Year;
            var mes = Convert.ToDateTime(fecha).Month;
            var dia = Convert.ToDateTime(fecha).Day;
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Contactos/Fecha/{ano}-{mes}-{dia}");
            return JsonConvert.DeserializeObject<Contacto[]>(json);
        }

        public async Task<HttpResponseMessage> InsertContactosAsync(Contacto Contacto)
        {
            //if(Contacto.Id == 0)
            //{ 
            //Contacto.FechaHora = (DateTime)Contacto.FechaHora.Value;
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/Contactos", getStringContentFromObject(Contacto));
        }
        public async Task<HttpResponseMessage> UpdateContactosAsync(string id, Contacto Contacto)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Contactos/{id}", getStringContentFromObject(Contacto));
        }
        public async Task<HttpResponseMessage> DeleteContactosAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Contactos/{id}");
        }
        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }

    }
}
