using LWCommandLineParser.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCommandLineParser
{
    public interface IOption
    {
        List<IArgument> Arguments { get; set; }
        Type RawType { get; set; }
    }
}
