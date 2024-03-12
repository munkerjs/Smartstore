using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartstore.Web.TagHelpers.Shared;
using Smartstore.Web.Modelling;

namespace Smartstore.Trendyol.Models
{
    [LocalizedDisplay("Plugins.Smartstore.Trendyol.ApiSettings.")]
    public class TrendyolApiModel: ModelBase
    {
        [LocalizedDisplay("*ApiUrl")]
        public string ApiUrl { get; set; }
        [LocalizedDisplay("*BuyerId")]
        public string BuyerId { get; set; }
        [LocalizedDisplay("*ApiKey")]
        public string ApiKey { get; set; }
        [LocalizedDisplay("*ApiSecret")]
        public string ApiSecret { get; set; }
        [LocalizedDisplay("*Token")]
        public string Token { get; set; }
        [LocalizedDisplay("*ServiceStatus")]
        public bool ServiceStatus { get; set; }
    }
}
