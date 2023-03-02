using Application.Interfaces;
using Domain.Entidades;
using Domain.EntitysExternal;

using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Application
{
    public class ApplicationYahoo : IApplicationYahoo
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public ApplicationYahoo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Ativo> BuscaAtivos(string ativo)
        {
            var resposta = await _httpClient.GetFromJsonAsync<AtivosReposta>($"chart/{ativo}");

            var teste = MapearParaEntidade(resposta);

            return null;
        }

        private AtivosReposta MapearParaEntidade(AtivosReposta respostaApi)
        {
            var teste = respostaApi;

            return teste;
        }
    }
}