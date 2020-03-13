using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCommandLineParser.Arguments
{
    public class BaseArgument : IArgument
    {
        public ArgumentTypeEnum Type { get; set; }
        public Type ArgType { get; set; }
        public string MemberName { get; set; }
        public string Description { get; set; }
        public string Help { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public int PassParemeterCount { get; set; }

    }
}
