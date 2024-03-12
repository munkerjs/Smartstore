using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartstore.Core.Configuration;

namespace Smartstore.Trendyol.Configuration
{
    public class TrendyolApiSettings : ISettings
    {
        public string ApiUrl { get; set; }
        public string BuyerId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string Token { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
