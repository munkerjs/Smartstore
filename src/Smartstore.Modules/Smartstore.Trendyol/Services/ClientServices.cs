using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Smartstore.Core.Configuration;
using Smartstore.Core.Stores;
using Smartstore.Trendyol.Configuration;

namespace Smartstore.Trendyol.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingFactory _settingFactory;

        public ClientServices(IStoreContext storeContext, ISettingFactory settingFactory)
        {
            _storeContext = storeContext;
            _settingFactory = settingFactory;
        }

        public HttpClient TrendyolClient(string url, string apiKey, string apiSecret)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url ?? "https://api.trendyol.com/sapigw/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(apiKey + ":" + apiSecret)));

            return client;
        }

        public async Task<bool> CheckStatus()
        {
            var settings = _settingFactory.LoadSettings<TrendyolApiSettings>(_storeContext.CurrentStore.Id);
            HttpResponseMessage response = TrendyolClient(settings.ApiUrl, settings.ApiKey, settings.ApiSecret).GetAsync($"suppliers/{settings.BuyerId}/products?approved=true&page=0&size=1").Result;
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

    }
}
