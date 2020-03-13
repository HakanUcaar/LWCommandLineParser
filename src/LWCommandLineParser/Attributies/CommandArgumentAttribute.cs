using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCommandLineParser.Attributies
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CommandArgumentAttribute : Attribute
    {
        public string Description { get; set; }
        public string Help { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public int PassParameterCount { get; set; }

        public CommandArgumentAttribute(string ShortName = "")
        {
            this.ShortName = ShortName;
        }
        public CommandArgumentAttribute(string ShortName, string LongName = "")
        {
            this.LongName = LongName;
            this.ShortName = ShortName;
        }

        public CommandArgumentAttribute(string ShortName, string LongName = "", string Description = "")
        {
            this.Description = Description;
            this.LongName = LongName;
            this.ShortName = ShortName;
        }

        public CommandArgumentAttribute(string ShortName, string LongName = "", string Description = "", string Help = "")
        {
            this.Description = Description;
            this.LongName = LongName;
            this.ShortName = ShortName;
            this.Help = Help;
        }
    }
}
