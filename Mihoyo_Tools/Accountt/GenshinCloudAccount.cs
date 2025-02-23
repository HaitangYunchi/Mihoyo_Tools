using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools
{
    [Serializable]
    public class GenshinCloudAccount : MiHoYoAccount
    {
        public GenshinCloudAccount() : base("GenshinCloud", @"HKEY_CURRENT_USER\Software\miHoYo\云·原神", "MIHOYOSDK_ADL_0")
        {
        }
    }
}
