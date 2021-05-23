using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APICalculoIMC.Models;

namespace APICalculoIMC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoIMCController : ControllerBase
    {
        private readonly ILogger<CalculoIMCController> _logger;

        public CalculoIMCController(ILogger<CalculoIMCController> logger)
        {
            _logger = logger;
        }

        [HttpGet("imc")]
        [ProducesResponseType(typeof(ClassificacaoPessoa), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FalhaCalculo), (int)HttpStatusCode.BadRequest)]
        public ActionResult<ClassificacaoPessoa> Get(double peso, double altura)
        {
            _logger.LogInformation(
                "Recebida nova requisição|" +
               $"Peso em Kg: {peso}|" +
               $"Altura em Metros: {altura}");

            if (peso <= 0)
                return new BadRequestObjectResult(new FalhaCalculo() { Mensagem = "O Peso em Kg deve ser maior do que zero!" });

            if (altura <= 0)
                return new BadRequestObjectResult(new FalhaCalculo() { Mensagem = "A Altura em Metros deve ser maior do que zero!" });

            var resultado = new ClassificacaoPessoa(peso, altura);
            _logger.LogInformation("Resultado -> " +
                $"IMC: {resultado.IMC}|" +
                $"Situação: {resultado.Situacao}");            
            return resultado;
        }
    }
}