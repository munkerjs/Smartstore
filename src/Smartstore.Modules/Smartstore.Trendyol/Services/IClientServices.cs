using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Smartstore.Trendyol.Services
{
    public interface IClientServices
    {
        Task<bool> CheckStatus();
    }
}
