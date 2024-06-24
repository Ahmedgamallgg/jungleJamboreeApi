using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CasheService.Interface
{
    public interface ICasheService
    {
        Task<string> SetCasheResponseAsync(string cashKey, object response, TimeSpan timeToLive);
        Task<string> GetCasheResponseAsync(string cashKey);

    }
}
