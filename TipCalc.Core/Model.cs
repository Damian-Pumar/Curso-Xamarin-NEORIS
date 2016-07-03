using System;
using Service;

namespace TipCalc.Core
{
    public class Model
    {
        #region Events

        public event EventHandler TipValueChanged;

        private readonly ICalculation calculation;

        #endregion

        #region Constructor

        public Model(/*ICalculation calculation*/)
        {
            this.calculation = new CalculationLocal();
        }

        #endregion

        #region Properties

        private Decimal subTotal;

        public Decimal Subtotal
        {
            get
            {
                return this.subTotal;
            }
            set
            {
                if (this.subTotal != value)
                {
                    subTotal = value;
                    OnTipValueChanged();
                }
            }
        }

        private Decimal tipPercent;

        public Decimal TipPercent
        {
            get
            {
                return this.tipPercent;
            }
            set
            {
                if (this.tipPercent != value)
                {
                    this.tipPercent = value;

                    OnTipValueChanged();
                }
            }
        }

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

        #region Methods

        private void OnTipValueChanged()
        {
            var h = TipValueChanged;
            if (h != null)
                h(this, EventArgs.Empty);
        }

        #endregion
    }
}

