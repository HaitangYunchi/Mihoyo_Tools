using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools
{
    [Serializable]
    public class ZZZAccount : MiHoYoAccount
    {
        public ZZZAccount() : base("ZZZ", @"HKEY_CURRENT_USER\Software\miHoYo\绝区零", "MIHOYOSDK_ADL_PROD_CN_h3123967166")
        {
        }
    }
}
