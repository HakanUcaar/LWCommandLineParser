using System;

namespace LWCommandLineParser.Arguments
{
    public interface IArgument
    {
        ArgumentTypeEnum Type { get; set; }
        Type ArgType { get; set; }
        string MemberName { get; set; }
        string ShortName { get; set; }
        string LongName { get; set; }
        string Description { get; set; }
        string Help { get; set; }
        int PassParemeterCount { get; set; }
    }
}
