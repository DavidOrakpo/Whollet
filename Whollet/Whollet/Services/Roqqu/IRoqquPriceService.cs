using System.Collections.Generic;
using System.Threading.Tasks;
using Whollet.Model.APIModels;

namespace Whollet.Services.Roqqu
{
    public interface IRoqquPriceService
    {
        Task<IEnumerable<Price>> GetPriceHistory(string symbol);
    }
}