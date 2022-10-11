using desafioAPI.Automacao;
using desafioAPI.Model;

namespace desafioAPI.Business
{
    public class CotacaoBusiness
    {
        public static List<Cotacao> ListaJaConsultados;

        public static Response<Cotacao> GetCotacaoPorTipoMoeda(TipoMoeda moedaBase, TipoMoeda moedaAlvo)
        {
            var cotacao = new Response<Cotacao>();

            if (ListaJaConsultados == null)
            {
                ListaJaConsultados = new List<Cotacao>();
            }

            foreach (var item in ListaJaConsultados)
            {
                if (item.MoedaBase.Equals(moedaBase) && (item.MoedaAlvo.Equals(moedaAlvo)))
                {
                    cotacao.Message = "Consulta já realizada";
                    cotacao.Data = item;
                    cotacao.Success = false;
                    return cotacao;
                }
            }

            var NovaCotacao = new Cotacao();

            string vlrBase, vlrAlvo = string.Empty;

            vlrBase = GetTipoMOeda(moedaBase);
            vlrAlvo = GetTipoMOeda(moedaAlvo);

            NovaCotacao.valor = RealizaConsultaAutomacao.BuscaCotacao(vlrBase, vlrAlvo);
            NovaCotacao.MoedaBase = moedaBase;
            NovaCotacao.MoedaAlvo = moedaAlvo;
            NovaCotacao.Data =  DateTime.Now;

            ListaJaConsultados.Add(NovaCotacao);

            cotacao.Data = NovaCotacao;
            cotacao.Success = true;
            cotacao.Message = "Consulta realizada com Sucesso!";

            return cotacao;
        }

        private static string GetTipoMOeda(TipoMoeda tipoMoeda)
        {
            switch (tipoMoeda)
            {
                case TipoMoeda.BRL:
                    {
                        return "BRL"; 
                    }

                case TipoMoeda.USD:
                    {
                        return "USD";
                    }

                case TipoMoeda.EUR:
                    {
                        return "EUR";

                    }
                    default:
                    return null;

            }
        }
    }
}
