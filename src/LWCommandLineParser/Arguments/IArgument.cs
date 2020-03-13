using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCommandLineParser.Arguments
{
    public interface IArgument
    {
        ArgumentTypeEnum Type { get; set; }
        string MemberName { get; set; }
        string ShortName { get; set; }
        string LongName { get; set; }
        string Description { get; set; }
        string Help { get; set; }
        int PassParemeterCount { get; set; }
    }
}
