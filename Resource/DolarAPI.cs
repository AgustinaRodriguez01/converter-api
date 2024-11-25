using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace converter_api.Resource
{
    public class DolarAPI
    {
        public async Task<decimal> GetSpecificQuote()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                CurrencyRequest currency = new CurrencyRequest();
                currency.Code = "Bolsa";
                var jsonObject = JsonConvert.SerializeObject(currency);
                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync("https://localhost:7154/api/Quote", content);
                if (!response.IsSuccessStatusCode)
                {
                    var httpResponse = new HttpResponseMessage(response.StatusCode);

                    //httpResponse.ReasonPhrase = "Error to conect dolar api";
                    //httpResponse.Content = new StringContent("");
                    //throw new HttpResponseException(httpResponse);

                    throw new Exception("Error to connect dolar API");
                }

                string str = response.Content.ReadAsStringAsync().Result;
                QuoteCurrencyResponse? result = JsonConvert.DeserializeObject<QuoteCurrencyResponse>(str);
                return result.Venta;
            }
        }
    }
}
