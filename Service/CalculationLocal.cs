using System;

namespace Service
{
    public class CalculationLocal : ICalculation
    {
        public Decimal GetTipValue(Decimal subtotal, Decimal tipPercent)
        {
            if (subtotal == Decimal.Zero || tipPercent == Decimal.Zero)
                return Decimal.Zero;

            return Math.Round(subtotal * (tipPercent / 100), 2);
        }
    }
}

