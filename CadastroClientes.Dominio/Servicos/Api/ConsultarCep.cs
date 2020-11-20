using CadastroClientes.Dominio.DTO;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CadastroClientes.Dominio.Servicos.Api
{
    public class ConsultarCep
    {
        public static async Task<EnderecoDTO> ObterDados(string cep)
        {
            try
            {
                var httpClient = HttpClientFactory.Create();

                string url = "https://viacep.com.br/ws/" + cep + "/json/";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var content = httpResponseMessage.Content;
                    var data = await content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<EnderecoDTO>(data);
                }
            }
            catch (Exception) { }

            return null;

        }
    }
}
