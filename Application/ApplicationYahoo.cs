using Application.Interfaces;
using Domain.Entidades;
using Domain.EntitysExternal;
using System.Net.Http.Json;
using static Domain.EntitysExternal.AtivosReposta;

namespace Application
{
    public class ApplicationYahoo : IApplicationYahoo
    {
        private readonly HttpClient _httpClient;

        public ApplicationYahoo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Ativo>> BuscaAtivos(string ativo, DateTime dataInicio, DateTime dataFim)
        {
            long dataI = new DateTimeOffset(dataInicio).ToUnixTimeSeconds();
            long dataF = new DateTimeOffset(dataFim).ToUnixTimeSeconds();

            var resposta = await _httpClient.GetFromJsonAsync<AtivosReposta>($"chart/{ativo}?interval=1d&period1={dataI}&period2={dataF}");

            return MapearParaEntidade(ativo, resposta.chart.result);
        }

        private IEnumerable<Ativo> MapearParaEntidade(string nomeAtivo, List<Result> result)
        {
            List<DateTime> listaDatas = new List<DateTime>();

            result.FirstOrDefault().timestamp.ForEach(e =>
            {
                DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime dateTime = Epoch.AddSeconds(e).ToLocalTime();

                listaDatas.Add(dateTime);
            });

            List<decimal> listaValores = new List<decimal>();

            result.FirstOrDefault().indicators.quote.FirstOrDefault().open.ForEach(e =>
            {
                listaValores.Add(e);
            });

            return listaDatas.Zip(listaValores, (data, valor) => new Ativo(nomeAtivo, data, valor));
        }
    }
}