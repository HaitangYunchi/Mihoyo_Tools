using DevExpress.XtraEditors;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mihoyo_Tools
{
    class CoreData
    {
        /**
        #region 常量

        public static readonly byte[] KeyGenshin = Encoding.ASCII.GetBytes(GlobalVar.KeyGenshin);
        public static readonly byte[] KeyGenshinCloud = Encoding.ASCII.GetBytes(GlobalVar.KeyGenshinCloud);
        public static readonly byte[] KeyGenshinOversea = Encoding.ASCII.GetBytes(GlobalVar.KeyGenshinOversea);
        public static readonly byte[] KeyHonkaiImpact3 = Encoding.ASCII.GetBytes(GlobalVar.KeyHonkaiImpact3);
        public static readonly byte[] KeyStarRail = Encoding.ASCII.GetBytes(GlobalVar.KeyStarRail);
        public static readonly byte[] KeyStarRailOversea = Encoding.ASCII.GetBytes(GlobalVar.KeyStarRailOversea);
        public static readonly byte[] KeyZZZ = Encoding.ASCII.GetBytes(GlobalVar.KeyZZZ);
        public static readonly byte[] KeyZZZOversea = Encoding.ASCII.GetBytes(GlobalVar.KeyZZZOversea);
        #endregion
        #region 字段
        public List<AccountGenshin> _accountsGenshin = new List<AccountGenshin>();
        public List<AccountGenshinCloud> _accountsGenshinCloud = new List<AccountGenshinCloud>();
        public List<AccountGenshinOversea> _accountsGenshinOversea = new List<AccountGenshinOversea>();
        public List<AccountHonkaiImpact3> _accountsHonkaiImpact3 = new List<AccountHonkaiImpact3>();
        public List<AccountStarRail> _accountsStarRail = new List<AccountStarRail>();
        public List<AccountStarRailOversea> _accountsStarRailOversea = new List<AccountStarRailOversea>();
        public List<AccountZZZ> _accountsZZZ = new List<AccountZZZ>();
        public List<AccountZZZOversea> _accountsZZZOversea = new List<AccountZZZOversea>();
        #endregion
        #region 核心功能
        public void SaveAccountsGenshin()
        {
            try
            {
                var jsonGenshin = JsonConvert.SerializeObject(_accountsGenshin);
                var encrypted = EncryptGenshin(jsonGenshin);
                File.WriteAllBytes(GlobalVar.genshin, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveAccountsGenshinCloud()
        {
            try
            {
                var jsonGenshinCloud = JsonConvert.SerializeObject(_accountsGenshinCloud);
                var encrypted = EncryptGenshinCloud(jsonGenshinCloud);
                File.WriteAllBytes(GlobalVar.genshinCloud, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveAccountsGenshinOversea()
        {
            try
            {
                var jsonGenshinOversea = JsonConvert.SerializeObject(_accountsGenshinOversea);
                var encrypted = EncryptGenshinOversea(jsonGenshinOversea);
                File.WriteAllBytes(GlobalVar.genshinOversea, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveAccountsHonkaiImpact3()
        {
            try
            {
                var jsonHonkaiImpact3 = JsonConvert.SerializeObject(_accountsHonkaiImpact3);
                var encrypted = EncryptHonkaiImpact3(jsonHonkaiImpact3);
                File.WriteAllBytes(GlobalVar.HonkaiImpact3, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveAccountsStarRail()
        {
            try
            {
                var jsonStarRail = JsonConvert.SerializeObject(_accountsStarRail);
                var encrypted = EncryptStarRail(jsonStarRail);
                File.WriteAllBytes(GlobalVar.StarRail, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveAccountsStarRailOversea()
        {
            try
            {
                var jsonStarRailOversea = JsonConvert.SerializeObject(_accountsStarRailOversea);
                var encrypted = EncryptStarRailOversea(jsonStarRailOversea);
                File.WriteAllBytes(GlobalVar.StarRailOversea, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveAccountsZZZ()
        {
            try
            {
                var jsonZZZ = JsonConvert.SerializeObject(_accountsZZZ);
                var encrypted = EncryptZZZ(jsonZZZ);
                File.WriteAllBytes(GlobalVar.ZZZ, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
        public void SaveAccountsZZZOversea()
        {
            try
            {
                var jsonZZZOversea = JsonConvert.SerializeObject(_accountsZZZOversea);
                var encrypted = EncryptZZZOversea(jsonZZZOversea);
                File.WriteAllBytes(GlobalVar.ZZZOversea, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public AccountGenshin BackupCurrentAccountGenshin()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.Genshin_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到原神用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountGenshin
                {
                    MIHOYOSDK_ADL_PROD_CN_h3123967166 = (byte[])key.GetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166"),
                    GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
        public AccountGenshinCloud BackupCurrentAccountGenshinCloud()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.GenshinCloud_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到原神用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountGenshinCloud
                {
                    MIHOYOSDK_ADL_0 = (byte[])key.GetValue("MIHOYOSDK_ADL_0"),
                    //GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
        public AccountGenshinOversea BackupCurrentAccountGenshinOversea()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.GenshinOversea_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到原神用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountGenshinOversea
                {
                    MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810 = (byte[])key.GetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810"),
                    GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
        public AccountHonkaiImpact3 BackupCurrentAccountHonkaiImpact3()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.HonkaiImpact3_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到原神用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountHonkaiImpact3
                {
                    MIHOYOSDK_ADL_PROD_CN_h3123967166 = (byte[])key.GetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166"),
                    //GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
        public AccountStarRail BackupCurrentAccountStarRail()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.StarRail_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到星铁用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountStarRail
                {
                    MIHOYOSDK_ADL_PROD_CN_h3123967166 = (byte[])key.GetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166"),
                    //GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
        public AccountStarRailOversea BackupCurrentAccountStarRailOversea()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.StarRailOversea_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到原神用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountStarRailOversea
                {
                    MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810 = (byte[])key.GetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810"),
                    //GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
        public AccountZZZ BackupCurrentAccountZZZ()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.ZZZ_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到原神用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountZZZ
                {
                    MIHOYOSDK_ADL_PROD_CN_h3123967166 = (byte[])key.GetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166"),
                    // GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
 
        public AccountZZZOversea BackupCurrentAccountZZZOversea()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(GlobalVar.ZZZOversea_REG_PATH))
            {
                if (key == null)
                {
                    XtraMessageBox.Show("未找到原神用户存储信息！");
                    return null;
                }
                // 显式类型转换确保二进制数据
                return new AccountZZZOversea
                {
                    MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810 = (byte[])key.GetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810"),
                    //GENERAL_DATA_h2389025596 = (byte[])key.GetValue("GENERAL_DATA_h2389025596")
                };
            }
        }
     
        public void UpdateRegistryGenshin(AccountGenshin acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.Genshin_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        public void UpdateRegistryGenshinCloud(AccountGenshinCloud acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.GenshinCloud_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_0", acc.MIHOYOSDK_ADL_0, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }
        public void UpdateRegistryGenshinOversea(AccountGenshinOversea acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.GenshinOversea_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810", acc.MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810, RegistryValueKind.Binary);
                key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        public void UpdateRegistryHonkaiImpact3(AccountHonkaiImpact3 acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.HonkaiImpact3_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        public void UpdateRegistryStarRail(AccountStarRail acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.StarRail_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        public void UpdateRegistryStarRailOversea(AccountStarRailOversea acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.StarRailOversea_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810", acc.MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        public void UpdateRegistryZZZ(AccountZZZ acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.ZZZ_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }
    
        public void UpdateRegistryZZZOversea(AccountZZZOversea acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.ZZZOversea_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810", acc.MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }
    
        public void KillGameProcessGenshin()
        {
            foreach (var proc in Process.GetProcessesByName("YuanShen")) proc.Kill();
        }
        public void KillGameProcessGenshinCloud()
        {
            foreach (var proc in Process.GetProcessesByName("Genshin Impact Cloud Game")) proc.Kill();
        }
        public void KillGameProcessGenshinOversea()
        {
            foreach (var proc in Process.GetProcessesByName("GenshinImpact")) proc.Kill();
        }
        public void KillGameProcessHonkaiImpact3()
        {
            foreach (var proc in Process.GetProcessesByName("BH3")) proc.Kill();
        }
        public void KillGameProcessStarRail()
        {
            foreach (var proc in Process.GetProcessesByName("StarRail")) proc.Kill();
        }
        public void KillGameProcessStarRailOversea()
        {
            foreach (var proc in Process.GetProcessesByName("StarRailOversea")) proc.Kill();
        }
        public void KillGameProcessZZZ()
        {
            foreach (var proc in Process.GetProcessesByName("ZenlessZoneZero")) proc.Kill();
        }
    
        public void KillGameProcessZZZOversea()
        {
            foreach (var proc in Process.GetProcessesByName("ZenlessZoneZero")) proc.Kill();
        }
   
        #endregion

        #region 加密方法
        public byte[] EncryptGenshin(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyGenshin, DataProtectionScope.CurrentUser);
        }

        public string DecryptGenshin(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyGenshin, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }

        public byte[] EncryptGenshinCloud(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyGenshinCloud, DataProtectionScope.CurrentUser);
        }

        public string DecryptGenshinCloud(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyGenshinCloud, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }

        public byte[] EncryptGenshinOversea(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyGenshinOversea, DataProtectionScope.CurrentUser);
        }

        public string DecryptGenshinOversea(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyGenshinOversea, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }

        public byte[] EncryptHonkaiImpact3(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyHonkaiImpact3, DataProtectionScope.CurrentUser);
        }

        public string DecryptHonkaiImpact3(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyHonkaiImpact3, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }

        public byte[] EncryptStarRail(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyStarRail, DataProtectionScope.CurrentUser);
        }

        public string DecryptStarRail(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyStarRail, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }

        public byte[] EncryptStarRailOversea(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyStarRailOversea, DataProtectionScope.CurrentUser);
        }

        public string DecryptStarRailOversea(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyStarRailOversea, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }

        public byte[] EncryptZZZ(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyZZZ, DataProtectionScope.CurrentUser);
        }

        public string DecryptZZZ(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyZZZ, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }

        public byte[] EncryptZZZOversea(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyZZZOversea, DataProtectionScope.CurrentUser);
        }

        public string DecryptZZZOversea(byte[] cipherText)
        {
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(cipherText, KeyZZZOversea, DataProtectionScope.CurrentUser));
            }
            catch
            {
                //XtraMessageBox.Show($"【账号管理】加载账号列表失败：秘钥错误或者跨设备、跨用户访问！");
                return "[]";
            }
        }
        #endregion
        **/

    }
}
