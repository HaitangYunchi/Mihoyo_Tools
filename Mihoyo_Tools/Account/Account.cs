using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools
{
    #region 实体类
    public class Account
    {
        public string AccountName { get; set; }
        public byte[] MIHOYOSDK_ADL_PROD_CN_h3123967166 { get; set; }
        public byte[] GENERAL_DATA_h2389025596 { get; set; }

        //public byte[] UserIdData { get; set; }
       // public byte[] TokenData { get; set; }
    }
    #endregion
}
