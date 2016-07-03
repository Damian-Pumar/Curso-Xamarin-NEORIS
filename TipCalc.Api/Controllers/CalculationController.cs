using System;
using System.Web.Http;
using Service;

namespace TipCalcApi.Controllers
{
    public class CalculationController : ApiController, ICalculation
    {
        [Route("Calculation/GetTipValue/{subtotal}/{tipPercent}")]
        public Decimal GetTipValue(Decimal subtotal, Decimal tipPercent)
        {
            if (subtotal == Decimal.Zero || tipPercent == Decimal.Zero)
                return Decimal.Zero;

            return Math.Round(subtotal * (tipPercent / 50), 2);
        }
    }
}