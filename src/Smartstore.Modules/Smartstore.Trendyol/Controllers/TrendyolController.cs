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
using Smartstore.Trendyol.Services;
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
        private readonly IClientServices _trendyolClient;

        public TrendyolController(SmartDbContext db, ICurrencyService currencyService, IMediaService mediaService, MediaSettings mediaSettings, IClientServices trendyolClient)
        {
            _db = db;
            _currencyService = currencyService;
            _mediaService = mediaService;
            _mediaSettings = mediaSettings;
            _trendyolClient = trendyolClient;
        }

        [LoadSetting, AuthorizeAdmin]
        public async Task<IActionResult> Configure(TrendyolApiSettings settings)
        {
            var model = MiniMapper.Map<TrendyolApiSettings, TrendyolApiModel>(settings);
            model.ServiceStatus = await _trendyolClient.CheckStatus();
            return View(model);
        }

        [AuthorizeAdmin, HttpPost, SaveSetting]
        public async Task<IActionResult> Configure(TrendyolApiModel model, TrendyolApiSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return await Configure(settings);
            }

            ModelState.Clear();
            MiniMapper.Map(model, settings);

            return RedirectToAction(nameof(Configure));
        }
    }
}
