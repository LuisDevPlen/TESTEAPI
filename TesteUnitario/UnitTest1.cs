using desafioAPI.Controllers;
using desafioAPI.Business;
using desafioAPI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using desafioAPI.Automacao;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.OpenApi.Extensions;

namespace TesteUnitario
{

    [TestClass]
    public class UnitTest1
    {
        //Teste para validar regra de negócio que não precisa pesquisar na automação o mesmo teste
        [TestMethod]
        public void TestValidaMesmaConsultaEsperandoMensagemQueConsultaFoiRealizada()
        {
            //Arrange
            var cotacao = new Cotacao() { MoedaAlvo = TipoMoeda.EUR, MoedaBase = TipoMoeda.BRL };

            // Act
            CotacaoBusiness.GetCotacaoPorTipoMoeda(cotacao.MoedaBase, cotacao.MoedaAlvo);
            var result = CotacaoBusiness.GetCotacaoPorTipoMoeda(cotacao.MoedaBase, cotacao.MoedaAlvo);

            // Assert
            Assert.AreEqual("Consulta já realizada", result.Message);
        }

        //Teste esperando uma resposta ok!
        [TestMethod]
        public void TestConsultaRealizadaComSucesso()
        {
            //Arrange
            var cotacao = new Cotacao() { MoedaAlvo = TipoMoeda.EUR, MoedaBase = TipoMoeda.BRL };

            // Act
            var result = CotacaoBusiness.GetCotacaoPorTipoMoeda(cotacao.MoedaBase, cotacao.MoedaAlvo);

            // Assert
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(true,result.Success);
            Assert.AreEqual("Consulta realizada com Sucesso!", result.Message);
        }
    }
}