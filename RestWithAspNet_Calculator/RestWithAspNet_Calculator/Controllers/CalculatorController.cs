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
        
        // GET api/values/5
        [HttpGet("{number1}/{number2}")]
        public IActionResult Sum(string number1, string number2)
        {
            if(IsNumber(number1) && IsNumber(number2))
            {
                var sum = ConvertToDecimal(number1) + ConvertToDecimal(number2);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
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
