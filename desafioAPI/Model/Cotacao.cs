using System.ComponentModel;

namespace desafioAPI.Model
{
    public class Cotacao
    {
        public TipoMoeda MoedaBase { get; set; }
        public TipoMoeda MoedaAlvo { get; set; } 
        public DateTime Data { get; set; } 
        public double valor { get; set; }
    }

    public enum TipoMoeda
    {
       [Description("BRL")]
       BRL,
       [Description("USD")]
       USD,
       [Description("EUR")]
       EUR,
    }
}
