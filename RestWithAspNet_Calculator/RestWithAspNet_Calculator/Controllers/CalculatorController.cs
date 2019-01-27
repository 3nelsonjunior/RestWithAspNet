using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet_Calculator.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        
        // GET api/calculator/sum/5/5
        [HttpGet("sum/{number1}/{number2}")]
        public IActionResult Sum(string number1, string number2)
        {
            if(IsNumber(number1) && IsNumber(number2))
            {
                var result = ConvertToDecimal(number1) + ConvertToDecimal(number2);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input!");
        }

        // GET api/calculator/sub/5/5
        [HttpGet("sub/{number1}/{number2}")]
        public IActionResult Sub(string number1, string number2)
        {
            if (IsNumber(number1) && IsNumber(number2))
            {
                var result = ConvertToDecimal(number1) - ConvertToDecimal(number2);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input!");
        }

        // GET api/calculator/mult/5/5
        [HttpGet("mult/{number1}/{number2}")]
        public IActionResult Mult(string number1, string number2)
        {
            if (IsNumber(number1) && IsNumber(number2))
            {
                var result = ConvertToDecimal(number1) * ConvertToDecimal(number2);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input!");
        }

        // GET api/calculator/div/5/5
        [HttpGet("div/{number1}/{number2}")]
        public IActionResult Div(string number1, string number2)
        {
            if (IsNumber(number1) && IsNumber(number2))
            {
                if(ConvertToDecimal(number2) == 0)
                {
                    return BadRequest("Invalid not division for 0!");
                }

                var result = ConvertToDecimal(number1) / ConvertToDecimal(number2);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input!");
        }

        // GET api/calculator/square-root/5
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumber(number))
            {
                var result = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input!");
        }

        // GET api/calculator/mean/5/5
        [HttpGet("mean/{number1}/{number2}")]
        public IActionResult Mean(string number1, string number2)
        {
            if (IsNumber(number1) && IsNumber(number2))
            {
                var result = (ConvertToDecimal(number1) + ConvertToDecimal(number2))/2;
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input!");
        }


        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumber(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
