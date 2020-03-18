using LWCommandLineParser.Arguments;
using System;
using System.Collections.Generic;

namespace LWCommandLineParser
{
    public interface IOption
    {
        List<IArgument> Arguments { get; set; }
        Type RawType { get; set; }
    }
}
