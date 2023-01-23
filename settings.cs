using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InnerLibs;

namespace Mechvibes.CSharp
{
    public class Settings : JsonFile
    {
        public Settings() : base()
        {
            this.FilePath = $@"{Application.StartupPath}\settings.json";
            this.IdentSize = 4;
        }

        public string pack = "CherryMX Black - ABS keycaps";
        public int volume = 50;
    }
}
