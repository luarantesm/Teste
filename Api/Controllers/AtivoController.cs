using Application.Dtos;
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

        [HttpPost]
        public ActionResult Post([FromBody] AtivoDto ativoDto)
        {
            try
            {
                if (ativoDto == null)
                    return NotFound();

                _applicationAtivo.Add(ativoDto);
                return Ok("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}