using System;
namespace Service
{
    public interface ICalculation
    {
        Decimal GetTipValue(Decimal subtotal, Decimal tipPercent);
    }
}

