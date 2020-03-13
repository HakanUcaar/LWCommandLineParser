using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCommandLineParser.Attributies
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValueArgumentAttribute  : Attribute
    {
        public Type ValueType { get; set; }
        public object DefaultValue { get; set; }
        public string Description { get; set; }
        public string Help { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public ValueArgumentAttribute(Type ValueType, string ShortName = "", string LongName = "", string Description = "",  string Help = "", object DefaultValue = null)
        {
            this.ValueType = ValueType;
            this.Description = Description;
            this.Help = Help;
            this.LongName = LongName;
            this.ShortName = ShortName;
            this.DefaultValue = DefaultValue;
        }
    }
}
