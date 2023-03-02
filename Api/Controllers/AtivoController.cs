using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtivoController : Controller
    {
        private readonly IApplicationAtivo _applicationAtivo;

        public AtivoController(IApplicationAtivo applicationAtivo)
        {
            _applicationAtivo = applicationAtivo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    return NotFound();

                var ativos = _applicationAtivo.BuscaDadosAtivo(nome);
                return Ok(ativos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}