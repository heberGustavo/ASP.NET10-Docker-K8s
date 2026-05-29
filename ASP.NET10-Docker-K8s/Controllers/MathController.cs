using ASP.NET10_Docker_K8s.Service;
using ASP.NET10_Docker_K8s.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET10_Docker_K8s.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly MathService _mathService;

        public MathController(MathService mathService)
        {
            _mathService = mathService;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult Sum(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
                return Ok(_mathService.Sum(NumberHelper.ConvertDecimal(firstNumber), NumberHelper.ConvertDecimal(secondNumber)));
            
            return BadRequest("Invalid request!");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public ActionResult Sub(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
                return Ok(_mathService.Sub(NumberHelper.ConvertDecimal(firstNumber), NumberHelper.ConvertDecimal(secondNumber)));

            return BadRequest("Invalid request!");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public ActionResult Mult(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
                return Ok(_mathService.Mult(NumberHelper.ConvertDecimal(firstNumber), NumberHelper.ConvertDecimal(secondNumber)));

            return BadRequest("Invalid request!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public ActionResult Div(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(firstNumber))
                return Ok(_mathService.Div(NumberHelper.ConvertDecimal(firstNumber), NumberHelper.ConvertDecimal(secondNumber)));

            return BadRequest("Invalid request!");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult Mean(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
                return Ok(_mathService.Mean(NumberHelper.ConvertDecimal(firstNumber), NumberHelper.ConvertDecimal(secondNumber)));

            return BadRequest("Invalid request!");
        }

        [HttpGet("sqrt/{number}")]
        public ActionResult Sqrt(string number)
        {
            if(NumberHelper.IsNumeric(number))
                return Ok(_mathService.Sqrt(NumberHelper.ConvertDouble(number)));

            return BadRequest("Invalid request!");
        }

    }
}
