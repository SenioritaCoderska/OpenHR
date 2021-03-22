using OpenHR.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHR
{
    public class UserSettings
    {


        public bool IsWindowMaximized
        {
            get
            {
                return Settings.Default.IsMaximized;
            }
            set
            {
                Settings.Default.IsMaximized = value;
            }
        }

    }
}
