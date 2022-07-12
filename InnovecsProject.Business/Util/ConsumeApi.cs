using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace InnovecsProject.Business.Util
{
    public static class ConsumeApi
    {
        public static async Task<string> Consume(IHttpClientFactory clientFactory, string urlApi, HttpMethod tipoConsumo)
        {
            HttpRequestMessage request = new HttpRequestMessage(tipoConsumo, urlApi);
            HttpClient cliente = clientFactory.CreateClient();
            HttpResponseMessage respuesta = await cliente.SendAsync(request);
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
            return JsonSerializer.Deserialize<T>(
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