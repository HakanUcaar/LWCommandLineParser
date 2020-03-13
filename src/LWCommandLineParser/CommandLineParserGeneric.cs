using LWCommandLineParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDonusum.HKNCommanLineParser
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
