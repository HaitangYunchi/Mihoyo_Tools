using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools
{
    [Serializable]
    public class StarRailOverseaAccount : MiHoYoAccount
    {
        public StarRailOverseaAccount() : base("StarRailOversea", @"HKEY_CURRENT_USER\Software\Cognosphere\Star Rail", "MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810")
        {
        }
    }
}
