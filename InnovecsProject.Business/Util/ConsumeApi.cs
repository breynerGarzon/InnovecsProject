using InnovecsProject.Model.Dto.BestDeal;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
//using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;

namespace InnovecsProject.Business.Util
{
    public static class ConsumeApi
    {
        public static async Task<string> Consume<T>(IHttpClientFactory clientFactory, string urlApi, HttpMethod tipoConsumo, T filterRequest)
        {
            HttpRequestMessage request = new HttpRequestMessage(tipoConsumo, urlApi);
            request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("Content-Type", "application/json");
            HttpClient cliente = clientFactory.CreateClient();
            //request.Content = filterRequest;

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(filterRequest)
        , Encoding.UTF8, "application/json");

            HttpResponseMessage respuesta = await cliente.PostAsync(urlApi, httpContent);
            if (respuesta.IsSuccessStatusCode)
            {
                respuesta.EnsureSuccessStatusCode();
                string respuestaString = await respuesta.Content.ReadAsStringAsync();
                return respuestaString;
            }
            string respuestaError = await respuesta.Content.ReadAsStringAsync();
            return respuestaError;
            // return string.Empty;
        }

        public static T ConsumeDeserialize<T>(string responseData)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(
                                                    responseData,
                                                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public static string RealizarDeserualizacionError(string respuestaError)
        {
            // var dataRespuesta = JsonSerializer.Deserialize<RespuestaDto<object>>(respuestaError, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).Errores;
            // return dataRespuesta.FirstOrDefault();
            return "";
        }
    }
}