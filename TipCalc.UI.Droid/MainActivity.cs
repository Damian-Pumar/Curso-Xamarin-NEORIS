using Android.App;
using Android.Widget;
using Android.OS;
using System;
using TipCalc.Core;

namespace TipCalc.UI.Droid
{
    [Activity(Label = "TipCalc.UI.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private readonly Model info;

        private TextView TipPercent;
        private TextView Total;
        private TextView TipValue;

        public MainActivity()
        {
            this.info = new Model()
            {
                TipPercent = 15
            };

            this.info.TipValueChanged += (sender, e) =>
            {
                TipValue.Text = info.TipValue.ToString();
                Total.Text = info.Total.ToString();
            };
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Main);

            this.TipValue = FindViewById<TextView>(Resource.Id.TipValue);

            this.Total = FindViewById<TextView>(Resource.Id.Total);

            this.TipPercent = FindViewById<TextView>(Resource.Id.TipPercent);

            this.TipPercent.AfterTextChanged += (sender, e) =>
            {
                info.TipPercent = Parse(TipPercent);
            };

            FindViewById<SeekBar>(Resource.Id.TipPercentSeekbar).SetOnSeekBarChangeListener(new SeekBarChangeListener(this));

            TextView subtotal = FindViewById<TextView>(Resource.Id.Subtotal);

            subtotal.AfterTextChanged += (sender, e) =>
            {
                info.Subtotal = Parse(subtotal);
            };
        }

        private static decimal Parse(TextView field)
        {
            if (field.Text == "")
                return 0m;
            try
            {
                return Convert.ToDecimal(field.Text);
            }
            catch (Exception)
            {
                field.Text = "";
                return 0m;
            }
        }

        public class SeekBarChangeListener : Java.Lang.Object, SeekBar.IOnSeekBarChangeListener
        {
            MainActivity context;

            public SeekBarChangeListener(MainActivity context)
            {
                this.context = context;
            }

            public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
            {
                context.TipPercent.Text = progress.ToString();
            }

            public void OnStartTrackingTouch(SeekBar seekBar)
            {
            }

            public void OnStopTrackingTouch(SeekBar seekBar)
            {
            }
        }
    }
}


