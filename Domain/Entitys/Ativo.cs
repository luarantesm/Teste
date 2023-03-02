using System.Security.Cryptography;

namespace Domain.Entidades
{
    public class Ativo
    {
        public Ativo(string nome, DateTime data, decimal valor)
        {
            Nome = nome;
            Data = data;
            Valor = valor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}