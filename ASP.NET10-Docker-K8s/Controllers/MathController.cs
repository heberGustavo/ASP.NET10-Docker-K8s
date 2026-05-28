using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET10_Docker_K8s.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult Get(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber);
                return Ok(sum);
            }
            
            return BadRequest("Invalid request!");
        }

        private bool IsNumeric(string strNumber)
        {
            decimal decimalValue;

            bool isNumber = decimal.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue
            );

            return isNumber;
        }

        private decimal ConvertDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue
            ))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}
