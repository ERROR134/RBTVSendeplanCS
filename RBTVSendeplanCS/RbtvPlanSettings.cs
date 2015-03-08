using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS
{
    internal sealed partial class RbtvPlanSettings : global::System.Configuration.ApplicationSettingsBase
    {
        private static RbtvPlanSettings defaultInstance = ((RbtvPlanSettings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new RbtvPlanSettings()));

        public static RbtvPlanSettings Default
        {
            get { return defaultInstance; }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        public int UpdateInterval
        {
            get { return (int)this["UpdateInterval"];}
            set { this["UpdateInterval"] = value; }
        }
        [global::System.Configuration.UserScopedSettingAttribute()]
        public int NotificationTime
        {
            get { return (int)this["NotificationTime"]; }
            set { this["NotificationTime"] = value; }
        }
        [global::System.Configuration.UserScopedSettingAttribute()]
        public double Version
        {
            get { return (double)this["Version"]; }
            set { this["Version"] = value; }
        }

    }
}
