using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartstore.ComponentModel;
using Smartstore.Core.Common.Services;
using Smartstore.Core.Content.Media;
using Smartstore.Core.Data;
using Smartstore.Core.Security;
using Smartstore.Trendyol.Configuration;
using Smartstore.Trendyol.Models;
using Smartstore.Web.Controllers;
using Smartstore.Web.Modelling.Settings;

namespace Smartstore.Trendyol.Controllers
{
    public class TrendyolController : AdminController
    {
        private readonly SmartDbContext _db;
        private readonly ICurrencyService _currencyService;
        private readonly IMediaService _mediaService;
        private readonly MediaSettings _mediaSettings;

        public TrendyolController(SmartDbContext db, ICurrencyService currencyService, IMediaService mediaService, MediaSettings mediaSettings)
        {
            _db = db;
            _currencyService = currencyService;
            _mediaService = mediaService;
            _mediaSettings = mediaSettings;
        }

        [LoadSetting, AuthorizeAdmin]
        public async Task<IActionResult> Configure(TrendyolApiSettings settings)
        {
            var model = MiniMapper.Map<TrendyolApiSettings, TrendyolApiModel>(settings);
            // model.ServiceStatus = await _trendyol.CheckStatus();
            return View(model);
        }
    }
}
