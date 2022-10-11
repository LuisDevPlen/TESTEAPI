using desafioAPI.Business;
using desafioAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace desafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {


        // GET: CotacaoController/Details/5
        [HttpGet]
        public IActionResult GetCotacaoPorTipoMoeda(TipoMoeda moedaBase, TipoMoeda moedaAlvo)
        {
            try
            {
                return Ok(CotacaoBusiness.GetCotacaoPorTipoMoeda(moedaBase,moedaAlvo));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

 
    }
}
