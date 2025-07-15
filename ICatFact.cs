using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanierekrutacyjne
{
    internal interface ICatFact
    {
        Task<CatFactResponse> GetCatFactAsync();
    }
}
