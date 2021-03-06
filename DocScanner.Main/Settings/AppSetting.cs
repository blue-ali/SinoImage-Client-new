﻿using DocScanner.Bean;
using DocScanner.LibCommon;
using System.IO;
using System.Drawing.Design;
using System.ComponentModel;

namespace DocScanner.Main
{
    public class AppSetting : IPropertiesSetting
    {

        private static readonly AppSetting instance = new AppSetting();

        private AppSetting() { }

        public static AppSetting GetInstance()
        {
            return instance;
        }

        [Browsable(false)]
        public string Name
        {
            get
            {
                return "程序设置";
            }
        }

        [Category("系统设置"), Description("临时文件目录"), Editor(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(UITypeEditor))]
        public string TmpFileDir
        {
            get
            {
                return AppContext.GetInstance().Config.GetConfigParamValue("AppSetting", "TmpFileDir");
            }
            set
            {
                bool flag = !Directory.Exists(value);
                if (flag)
                {
                    Directory.CreateDirectory(value);
                }
                AppContext.GetInstance().Config.SetConfigParamValue("AppSetting", "TmpFileDir", value.ToString());
            }
        }

        [Browsable(false), Category("系统设置"), Description("允许多个实例")]
        public bool AllowMultiInstance
        {
            get
            {
                return AppContext.GetInstance().Config.GetConfigParamValue("AppSetting", "SingleInstance").ToBool();
            }
            set
            {
                AppContext.GetInstance().Config.SetConfigParamValue("AppSetting", "SingleInstance", value.ToString());
            }
        }

        [Category("程序设置"), Description("配置文件")]
        public string CfgPath
        {
            get
            {
                return AppContext.GetInstance().Config.ConfigFileName;
            }
        }

        [Browsable(false), Category("程序设置"), Description("是否显示系统高级设置")]
        public bool ShowAdvanceSetting
        {
            get
            {
                return IniConfigSetting.Cur.GetConfigParamValue("AppSetting", "ShowAdvanceSetting").ToBool();
            }
            set
            {
                IniConfigSetting.Cur.SetConfigParamValue("AppSetting", "ShowAdvanceSetting", value.ToString());
            }
        }

    }
}
