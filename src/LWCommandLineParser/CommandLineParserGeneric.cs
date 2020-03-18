using System.Collections.Generic;

namespace LWCommandLineParser
{
    public class CommandLineParserGeneric<T>
    {
        public List<IOption> Options { get; set; }

        public CommandLineParserGeneric()
        {

        }

        public CommandLineParserGeneric(string[] args)
        {

        }
    }
}
