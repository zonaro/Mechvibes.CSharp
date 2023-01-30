using InnerLibs;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
    public class Settings : JsonFile
    {
        public Settings() : base()
        {
            this.FilePath = $@"{Application.StartupPath}\settings.json";
            this.IsMinified = false;
            this.IdentSize = 4;
        }

        [DataMember(Name = "pack")]
        public string Pack { get; set; } = "CherryMX Black - ABS keycaps";
        [DataMember(Name = "volume")]
        public int Volume { get; set; } = 50;

        [DataMember(Name = "random")]
        public bool Random { get; set; } = false;

        [DataMember(Name = "state")]
        public int State { get; set; }
    }
}
