using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DevExpress.Utils;
using DevExpress.XtraPrinting.Native;

namespace Mihoyo_Tools
{
    public partial class Control_Account : DevExpress.XtraEditors.XtraUserControl
    {

        #region 常量

        private static readonly byte[] KeyGenshin = Encoding.ASCII.GetBytes(GlobalVar.KeyGenshin);
        private static readonly byte[] KeyGenshinCloud = Encoding.ASCII.GetBytes(GlobalVar.KeyGenshinCloud);
        private static readonly byte[] KeyGenshinOversea = Encoding.ASCII.GetBytes(GlobalVar.KeyGenshinOversea);
        private static readonly byte[] KeyHonkaiImpact3 = Encoding.ASCII.GetBytes(GlobalVar.KeyHonkaiImpact3);
        private static readonly byte[] KeyStarRail = Encoding.ASCII.GetBytes(GlobalVar.KeyStarRail);
        private static readonly byte[] KeyStarRailOversea = Encoding.ASCII.GetBytes(GlobalVar.KeyStarRailOversea);
        private static readonly byte[] KeyZZZ = Encoding.ASCII.GetBytes(GlobalVar.KeyZZZ);
        private static readonly byte[] KeyZZZOversea = Encoding.ASCII.GetBytes(GlobalVar.KeyZZZOversea);
        #endregion

        #region 字段
        private List<AccountGenshin> _accountsGenshin = new List<AccountGenshin>();
        private List<AccountGenshinCloud> _accountsGenshinCloud = new List<AccountGenshinCloud>();
        private List<AccountGenshinOversea> _accountsGenshinOversea = new List<AccountGenshinOversea>();
        private List<AccountHonkaiImpact3> _accountsHonkaiImpact3 = new List<AccountHonkaiImpact3>();
        private List<AccountStarRail> _accountsStarRail = new List<AccountStarRail>();
        private List<AccountStarRailOversea> _accountsStarRailOversea = new List<AccountStarRailOversea>();
        private List<AccountZZZ> _accountsZZZ = new List<AccountZZZ>();
        private List<AccountZZZOversea> _accountsZZZOversea = new List<AccountZZZOversea>();
        #endregion
        #region 初始化
        public Control_Account()
        {
            InitializeComponent();
            //InitializeSkin();
            ConfigureGrid();
            LoadAccountsGenshin();
            LoadAccountsGenshinCloud();
            LoadAccountsGenshinOversea();
            LoadAccountsHonkaiImpact3();
            LoadAccountsStarRail();
            LoadAccountsStarRailOversea();
            LoadAccountsZZZ();
            LoadAccountsZZZOversean();
        }
        private void Control_Account_Load(object sender, EventArgs e)
        {
            txtGenshinPath.Text = INIFile.getString("Config", "Genshin_patch", "", GlobalVar.IniName);
            txtStarRailPath.Text = INIFile.getString("Config", "StarRail_patch", "", GlobalVar.IniName);
        }
        private void ConfigureGrid()
        {
            #region 原神账号列表
            // 列配置
            gridView1.Columns.Clear();
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "AccountName",
                Caption = "账号名称",
                VisibleIndex = 0,
                Width = 200
            });

            // 网格设置
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            #endregion

            #region 崩坏：星穹铁道账号列表
            // 列配置
            gridView2.Columns.Clear();
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "AccountName",
                Caption = "账号名称",
                VisibleIndex = 0,
                Width = 200
            });

            // 网格设置
            gridView2.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsSelection.MultiSelect = true;
            gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            #endregion

            #region 崩坏3账号列表
            // 列配置
            gridView3.Columns.Clear();
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "AccountName",
                Caption = "账号名称",
                VisibleIndex = 0,
                Width = 200
            });

            // 网格设置
            gridView3.OptionsView.ShowGroupPanel = false;
            gridView3.OptionsBehavior.Editable = false;
            gridView3.OptionsSelection.MultiSelect = true;
            gridView3.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            #endregion

            #region 云原神账号列表
            // 列配置
            gridView4.Columns.Clear();
            gridView4.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "AccountName",
                Caption = "账号名称",
                VisibleIndex = 0,
                Width = 200
            });

            // 网格设置
            gridView4.OptionsView.ShowGroupPanel = false;
            gridView4.OptionsBehavior.Editable = false;
            gridView4.OptionsSelection.MultiSelect = true;
            gridView4.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            #endregion

            #region 原神国际服账号列表
            // 列配置
            gridView5.Columns.Clear();
            gridView5.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "AccountName",
                Caption = "账号名称",
                VisibleIndex = 0,
                Width = 200
            });

            // 网格设置
            gridView5.OptionsView.ShowGroupPanel = false;
            gridView5.OptionsBehavior.Editable = false;
            gridView5.OptionsSelection.MultiSelect = true;
            gridView5.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            #endregion

            #region 崩坏：星穹铁道国际服账号列表
            // 列配置
            gridView6.Columns.Clear();
            gridView6.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "AccountName",
                Caption = "账号名称",
                VisibleIndex = 0,
                Width = 200
            });

            // 网格设置
            gridView6.OptionsView.ShowGroupPanel = false;
            gridView6.OptionsBehavior.Editable = false;
            gridView6.OptionsSelection.MultiSelect = true;
            gridView6.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            #endregion

            #region 绝区零账号列表
            // 列配置
            gridView7.Columns.Clear();
            gridView7.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "AccountName",
                Caption = "账号名称",
                VisibleIndex = 0,
                Width = 200
            });

            // 网格设置
            gridView7.OptionsView.ShowGroupPanel = false;
            gridView7.OptionsBehavior.Editable = false;
            gridView7.OptionsSelection.MultiSelect = true;
            gridView7.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            #endregion

        }
        #endregion
        #region 数据操作
        private void LoadAccountsGenshin()
        {
            try
            {
                if (File.Exists(GlobalVar.genshin))
                {
                    var genshin = File.ReadAllBytes(GlobalVar.genshin);
                    var jsonGenshin = DecryptGenshin(genshin);
                    _accountsGenshin = JsonConvert.DeserializeObject<List<AccountGenshin>>(jsonGenshin);
                    gridControl1.DataSource = _accountsGenshin;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountsGenshinCloud()
        {
            try
            {
                if (File.Exists(GlobalVar.genshinCloud))
                {
                    var genshinCloud = File.ReadAllBytes(GlobalVar.genshinCloud);
                    var jsonGenshinCloud = DecryptGenshinCloud(genshinCloud);
                    _accountsGenshinCloud = JsonConvert.DeserializeObject<List<AccountGenshinCloud>>(jsonGenshinCloud);
                    gridControl4.DataSource = _accountsGenshinCloud;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountsGenshinOversea()
        {
            try
            {
                if (File.Exists(GlobalVar.genshinOversea))
                {
                    var genshinOversea = File.ReadAllBytes(GlobalVar.genshinOversea);
                    var jsonGenshinOversea = DecryptGenshinOversea(genshinOversea);
                    _accountsGenshinOversea = JsonConvert.DeserializeObject<List<AccountGenshinOversea>>(jsonGenshinOversea);
                    gridControl5.DataSource = _accountsGenshinOversea;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountsHonkaiImpact3()
        {
            try
            {
                if (File.Exists(GlobalVar.HonkaiImpact3))
                {
                    var HonkaiImpact3 = File.ReadAllBytes(GlobalVar.HonkaiImpact3);
                    var jsonHonkaiImpact3 = DecryptHonkaiImpact3(HonkaiImpact3);
                    _accountsHonkaiImpact3 = JsonConvert.DeserializeObject<List<AccountHonkaiImpact3>>(jsonHonkaiImpact3);
                    gridControl3.DataSource = _accountsHonkaiImpact3;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountsStarRail()
        {
            try
            {
                if (File.Exists(GlobalVar.StarRail))
                {
                    var StarRail = File.ReadAllBytes(GlobalVar.StarRail);
                    var jsonStarRail = DecryptStarRail(StarRail);
                    _accountsStarRail = JsonConvert.DeserializeObject<List<AccountStarRail>>(jsonStarRail);
                    gridControl2.DataSource = _accountsStarRail;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountsStarRailOversea()
        {
            try
            {
                if (File.Exists(GlobalVar.StarRailOversea))
                {
                    var StarRailOversea = File.ReadAllBytes(GlobalVar.StarRailOversea);
                    var jsonStarRailOversea = DecryptStarRailOversea(StarRailOversea);
                    _accountsStarRailOversea = JsonConvert.DeserializeObject<List<AccountStarRailOversea>>(jsonStarRailOversea);
                    gridControl6.DataSource = _accountsStarRailOversea;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountsZZZ()
        {
            try
            {
                if (File.Exists(GlobalVar.ZZZ))
                {
                    var ZZZ = File.ReadAllBytes(GlobalVar.ZZZ);
                    var jsonZZZ = DecryptZZZ(ZZZ);
                    _accountsZZZ = JsonConvert.DeserializeObject<List<AccountZZZ>>(jsonZZZ);
                    gridControl7.DataSource = _accountsZZZ;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAccountsZZZOversean()
        {
            try
            {
                if (File.Exists(GlobalVar.ZZZOversea))
                {
                    var ZZZOversea = File.ReadAllBytes(GlobalVar.ZZZOversea);
                    var jsonZZZOversea = DecryptZZZOversea(ZZZOversea);
                    _accountsZZZOversea = JsonConvert.DeserializeObject<List<AccountZZZOversea>>(jsonZZZOversea);
                    //gridControl8.DataSource = _accountsZZZOversea;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 核心功能
        private void SaveAccountsGenshin()
        {
            try
            {
                var jsonGenshin = JsonConvert.SerializeObject(_accountsGenshin);
                var encrypted = EncryptGenshin(jsonGenshin);
                File.WriteAllBytes(GlobalVar.genshin, encrypted);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"数据保存失败：{ex.Message}", "错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveAccountsGenshinCloud()
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
        private void SaveAccountsGenshinOversea()
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
        private void SaveAccountsHonkaiImpact3()
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
        private void SaveAccountsStarRail()
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
        private void SaveAccountsStarRailOversea()
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
        private void SaveAccountsZZZ()
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
        private void SaveAccountsZZZOversea()
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
        **/
        private AccountGenshin BackupCurrentAccountGenshin()
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
        private AccountGenshinCloud BackupCurrentAccountGenshinCloud()
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
        private AccountGenshinOversea BackupCurrentAccountGenshinOversea()
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
        private AccountHonkaiImpact3 BackupCurrentAccountHonkaiImpact3()
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
        private AccountStarRail BackupCurrentAccountStarRail()
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
        private AccountStarRailOversea BackupCurrentAccountStarRailOversea()
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
        private AccountZZZ BackupCurrentAccountZZZ()
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
        /**
        private AccountZZZOversea BackupCurrentAccountZZZOversea()
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
        **/
        private void UpdateRegistryGenshin(AccountGenshin acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.Genshin_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        private void UpdateRegistryGenshinCloud(AccountGenshinCloud acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.GenshinCloud_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_0", acc.MIHOYOSDK_ADL_0, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }
        private void UpdateRegistryGenshinOversea(AccountGenshinOversea acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.GenshinOversea_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810", acc.MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810, RegistryValueKind.Binary);
                key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        private void UpdateRegistryHonkaiImpact3(AccountHonkaiImpact3 acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.HonkaiImpact3_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        private void UpdateRegistryStarRail(AccountStarRail acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.StarRail_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        private void UpdateRegistryStarRailOversea(AccountStarRailOversea acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.StarRailOversea_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810", acc.MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }

        private void UpdateRegistryZZZ(AccountZZZ acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.ZZZ_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_CN_h3123967166", acc.MIHOYOSDK_ADL_PROD_CN_h3123967166, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }
        /**
        private void UpdateRegistryZZZOversea(AccountZZZOversea acc)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(GlobalVar.ZZZOversea_REG_PATH))
            {
                key.SetValue("MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810", acc.MIHOYOSDK_ADL_PROD_OVERSEA_h1158948810, RegistryValueKind.Binary);
                //key.SetValue("GENERAL_DATA_h2389025596", acc.GENERAL_DATA_h2389025596, RegistryValueKind.Binary);

            }
        }
        **/
        private void KillGameProcessGenshin()
        {
               foreach (var proc in Process.GetProcessesByName("YuanShen")) proc.Kill();
        }
        private void KillGameProcessGenshinCloud()
        {
            foreach (var proc in Process.GetProcessesByName("Genshin Impact Cloud Game")) proc.Kill();
        }
        private void KillGameProcessGenshinOversea()
        {
            foreach (var proc in Process.GetProcessesByName("GenshinImpact")) proc.Kill();
        }
        private void KillGameProcessHonkaiImpact3()
        {
            foreach (var proc in Process.GetProcessesByName("BH3")) proc.Kill();
        }
        private void KillGameProcessStarRail()
        {
            foreach (var proc in Process.GetProcessesByName("StarRail")) proc.Kill();
        }
        private void KillGameProcessStarRailOversea()
        {
            foreach (var proc in Process.GetProcessesByName("StarRailOversea")) proc.Kill();
        }
        private void KillGameProcessZZZ()
        {
            foreach (var proc in Process.GetProcessesByName("ZenlessZoneZero")) proc.Kill();
        }
        /**
        private void KillGameProcessZZZOversea()
        {
            foreach (var proc in Process.GetProcessesByName("ZenlessZoneZero")) proc.Kill();
        }
        **/
        #endregion

        #region 加密方法
        private byte[] EncryptGenshin(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyGenshin, DataProtectionScope.CurrentUser);
        }

        private string DecryptGenshin(byte[] cipherText)
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

        private byte[] EncryptGenshinCloud(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyGenshinCloud, DataProtectionScope.CurrentUser);
        }

        private string DecryptGenshinCloud(byte[] cipherText)
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

        private byte[] EncryptGenshinOversea(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyGenshinOversea, DataProtectionScope.CurrentUser);
        }

        private string DecryptGenshinOversea(byte[] cipherText)
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

        private byte[] EncryptHonkaiImpact3(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyHonkaiImpact3, DataProtectionScope.CurrentUser);
        }

        private string DecryptHonkaiImpact3(byte[] cipherText)
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

        private byte[] EncryptStarRail(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyStarRail, DataProtectionScope.CurrentUser);
        }

        private string DecryptStarRail(byte[] cipherText)
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

        private byte[] EncryptStarRailOversea(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyStarRailOversea, DataProtectionScope.CurrentUser);
        }

        private string DecryptStarRailOversea(byte[] cipherText)
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

        private byte[] EncryptZZZ(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyZZZ, DataProtectionScope.CurrentUser);
        }

        private string DecryptZZZ(byte[] cipherText)
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

        private byte[] EncryptZZZOversea(string plainText)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), KeyZZZOversea, DataProtectionScope.CurrentUser);
        }

        private string DecryptZZZOversea(byte[] cipherText)
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
        #region 原神面板代码
        private void btnGenshinAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new AccountNameDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var acc = BackupCurrentAccountGenshin();
                    acc.AccountName = dlg.AccountName;
                    _accountsGenshin.Add(acc);
                    gridControl1.RefreshDataSource();
                    SaveAccountsGenshin();
                    LoadAccountsGenshin();
                }
            }
        }

        private void btnGenshinSwitch_Click(object sender, EventArgs e)
        {
            if(txtGenshinPath.Text=="")
            {
                XtraMessageBox.Show("原神游戏路径不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (gridView1.GetFocusedRow() is AccountGenshin acc)
                {
                    try
                    {
                        KillGameProcessGenshin();
                        UpdateRegistryGenshin(acc);
                        XtraMessageBox.Show($"已切换到 [{acc.AccountName}]", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process p = Process.Start(txtGenshinPath.Text + @"\yuanshen.exe");

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"切换失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGenshinDelete_Click(object sender, EventArgs e)
        {
            var selected = gridView1.GetSelectedRows();
            if (selected.Length > 0)
            {
                if (XtraMessageBox.Show($"确认删除选中的 {selected.Length} 个账号？", "警告",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (var handle in selected)
                    {
                        var acc = gridView1.GetRow(handle) as AccountGenshin;
                        if (acc != null) _accountsGenshin.Remove(acc);
                        //_accounts.RemoveAt(handle);
                    }
                    gridControl1.RefreshDataSource();
                    SaveAccountsGenshin();
                }
            }
        }

        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            // 游戏目录
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择 YuanShen.exe";
            openFileDialog.Filter = "程序文件|YuanShen.exe";
            openFileDialog.InitialDirectory = @"D:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string folder;
                string selectedFile = openFileDialog.FileName;
                folder = System.IO.Path.GetDirectoryName(selectedFile);
                txtGenshinPath.Text = folder;
                INIFile.writeString("Config", "Genshin_patch", folder, GlobalVar.IniName);
                // XtraMessageBox.Show("选择的文件夹为：" +  GlobalVar.SelectedFolder);
            }
            else
            {
                txtGenshinPath.Text = "";
                INIFile.writeString("Config", "Genshin_patch", txtGenshinPath.Text, GlobalVar.IniName);
            }
            
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            // 获取双击的行句柄
            var hitInfo = gridView1.CalcHitInfo(gridControl1.PointToClient(MousePosition));
            if (hitInfo.RowHandle < 0) return; // 非数据行点击时忽略

            // 获取绑定的 Account 对象
            var selectedAccount = gridView1.GetRow(hitInfo.RowHandle) as AccountGenshin;
            if (selectedAccount == null) return;

            // 直接复用「切换账号」按钮的逻辑
            btnGenshinSwitch_Click(selectedAccount, e);
        }


        #endregion

        private void btnChooseStraRailPath_Click(object sender, EventArgs e)
        {
            // 游戏目录
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择 StarRail.exe";
            openFileDialog.Filter = "程序文件|StarRail.exe";
            openFileDialog.InitialDirectory = @"D:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string folder;
                string selectedFile = openFileDialog.FileName;
                folder = System.IO.Path.GetDirectoryName(selectedFile);
                txtStarRailPath.Text = folder;
                INIFile.writeString("Config", "StarRail_patch", folder, GlobalVar.IniName);
                // XtraMessageBox.Show("选择的文件夹为：" +  GlobalVar.SelectedFolder);
            }
            else
            {
                txtGenshinPath.Text = "";
                INIFile.writeString("Config", "StarRail_patch", txtStarRailPath.Text, GlobalVar.IniName);
            }
            
        }
        private void btnStarRailAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new AccountNameDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var acc = BackupCurrentAccountStarRail();
                    acc.AccountName = dlg.AccountName;
                    _accountsStarRail.Add(acc);
                    gridControl2.RefreshDataSource();
                    SaveAccountsStarRail();
                    LoadAccountsStarRail();
                }
            }
        }
    }
 
        
}
