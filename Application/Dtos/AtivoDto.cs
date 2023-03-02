namespace Application.Dtos
{
    public class AtivoDto
    {
        public AtivoDto(string nome, DateTime data, decimal valor)
        {
            Nome = nome;
            Data = data;
            Valor = valor;
        }

        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorAnterior { get; private set; }
        public decimal ValorPrimeiro { get; private set; }

        public void DefinirVariacaoDiaAnterior(decimal? valorD1)
        {
            if (valorD1.HasValue)
                ValorAnterior = (valorD1.Value - Valor) / Valor * 100;
        }

        public void DefinirVariacaoPrimeiraData(decimal? valorDataInicial)
        {
            if (valorDataInicial.HasValue)
                ValorPrimeiro = (valorDataInicial.Value - Valor) / Valor * 100;
        }
    }
}