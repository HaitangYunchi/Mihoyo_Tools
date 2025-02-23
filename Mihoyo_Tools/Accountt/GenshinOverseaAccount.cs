using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools
{
    [Serializable]
    public class GenshinOverseaAccount : MiHoYoAccount
    {
        public GenshinOverseaAccount() : base("GenshinOversea", @"HKEY_CURRENT_USER\Software\miHoYo\Genshin Impact", "MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810")
        {
        }
    }
}
