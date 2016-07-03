using System;
using Service;

namespace MVVMCross.Core
{
    public class Model
    {
        #region Members

        private readonly ICalculation calculation;

        #endregion

        #region Constructor

        public Model(/*ICalculation calculation*/)
        {
            this.calculation = new CalculationExternal();
        }

        #endregion

        #region Properties 

        public Decimal Subtotal { get; set; }

        public Decimal TipPercent { get; set; }

        public Decimal Total
        {
            get
            {
                return this.Subtotal + this.TipValue;
            }
        }

        public Decimal TipValue
        {
            get
            {
                return this.calculation.GetTipValue(this.Subtotal, this.TipPercent);
            }
        }

        #endregion
    }
}

