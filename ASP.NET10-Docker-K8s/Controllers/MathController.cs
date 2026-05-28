using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET10_Docker_K8s.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok(ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber));
            
            return BadRequest("Invalid request!");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public ActionResult Sub(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok(ConvertDecimal(firstNumber) - ConvertDecimal(secondNumber));

            return BadRequest("Invalid request!");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public ActionResult Mult(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok(ConvertDecimal(firstNumber) * ConvertDecimal(secondNumber));

            return BadRequest("Invalid request!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public ActionResult Div(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok(ConvertDecimal(firstNumber) / ConvertDecimal(secondNumber));

            return BadRequest("Invalid request!");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult Mean(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok((ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber)) / 2);

            return BadRequest("Invalid request!");
        }

        [HttpGet("sqrt/{firstNumber}/{secondNumber}")]
        public ActionResult Sqrt(string number)
        {
            if(IsNumeric(number))
                return Ok(Math.Sqrt(ConvertDouble(number)));

            return BadRequest("Invalid request!");
        }

        #region Private Methods 
        
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

        private double ConvertDouble(string strNumber)
        {
            double doubleValue;

            if (double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out doubleValue
            ))
            {
                return doubleValue;
            }

            return 0;
        }

        #endregion
    }
}
