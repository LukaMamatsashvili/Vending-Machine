using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Strategy
{
    public interface IVM
    {
        public void CurrencyInfo(List<ItemInfo> List);
        public void CurrencyOption(List<ItemInfo> Items);
    }
}
