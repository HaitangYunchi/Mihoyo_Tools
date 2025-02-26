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
        public byte[] GENERAL_DATA_h2389025596 { get; set; } //原神设置信息，国服国际服通用
        public string AccountName { get; set; } 
        public byte[] MIHOYOSDK_ADL_PROD_CN_h3123967166 { get; set; } //国服账号
        public byte[] MIHOYOSDK_ADL_0MIHOYOSDK_ADL_0 { get; set; } //云原神账号
        public byte[] MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810 { get; set; } //国际服子账号

        //public byte[] UserIdData { get; set; }
        // public byte[] TokenData { get; set; }
    }
    #endregion
}
