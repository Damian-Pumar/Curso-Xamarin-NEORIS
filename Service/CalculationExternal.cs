using System;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Service
{
    public class CalculationExternal : ICalculation
    {
        #region Members

        private readonly HttpClient client;

        private const String Server = "http://192.168.1.7/TipCalc/Calculation/GetTipValue/";

        #endregion

        public CalculationExternal()
        {
            this.client = new HttpClient() { BaseAddress = new Uri(Server) };
        }

        public Decimal GetTipValue(Decimal subtotal, Decimal tipPercent)
        {
            return this.GetAsync<Decimal>(Path.Combine(subtotal.ToString(), tipPercent.ToString())).Result;
        }

        private async Task<T> GetAsync<T>(String requestUri)
        {
            try
            {
                HttpResponseMessage response = this.client.GetAsync(requestUri).Result;

                if (response.IsSuccessStatusCode)
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            String str = await streamReader.ReadToEndAsync();

                            T objectToReturn = JsonConvert.DeserializeObject<T>(str);

                            return objectToReturn;
                        }
                    }
                }

                throw new Exception();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

