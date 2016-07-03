using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Service;

namespace MVVMCross.Core
{
    public class MainViewModel : MvxViewModel
    {
        private readonly Model info;

        public MainViewModel()
        {
            this.info = new Model()
            {
                TipPercent = 15
            };
        }

        public Decimal SubTotal
        {
            get
            {
                return this.info.Subtotal;
            }
            set
            {
                if (this.info.Subtotal != value)
                {
                    this.info.Subtotal = value;

                    this.RaisePropertyChanged(() => this.SubTotal);

                    this.RaisePropertyChanged(() => this.TipValue);

                    this.RaisePropertyChanged(() => this.Total);
                }
            }
        }

        public Decimal TipPercent
        {
            get
            {
                return this.info.TipPercent;
            }
            set
            {
                if (this.info.TipPercent != value)
                {
                    this.info.TipPercent = value;

                    this.RaisePropertyChanged(() => this.TipPercent);

                    this.RaisePropertyChanged(() => this.TipValue);

                    this.RaisePropertyChanged(() => this.Total);
                }
            }
        }

        public Decimal Total
        {
            get
            {
                return this.info.Total;
            }
        }

        public Decimal TipValue
        {
            get
            {
                return this.info.TipValue;
            }
        }
    }
}

