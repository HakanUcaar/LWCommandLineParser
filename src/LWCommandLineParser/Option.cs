using LWCommandLineParser.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCommandLineParser
{
    public sealed class Option : IOption
    {
        public List<IArgument> Arguments { get; set; }
        public Type RawType { get; set; }

        public Option()
        {
            this.Arguments = new List<IArgument>();
        }

        public Option AddArgument(IArgument Argument)
        {
            Arguments.Add(Argument);
            return this;
        }
        public Option AddArgument<T>()
        {
            var Arg = Activator.CreateInstance(typeof(T));
            Arguments.Add(Arg as IArgument);
            return this;
        }
    }
}
