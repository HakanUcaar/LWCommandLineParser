using LWCommandLineParser.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using LWCommandLineParser.Attributies;
using System.Reflection;

namespace LWCommandLineParser
{
    public class CommandLineParser
    {
        public List<IOption> Options { get; set; }
        private string[] Args { get; set; }

        public CommandLineParser(string[] args)
        {
            this.Args = args;
            this.Options = new List<IOption>();
        }

        public void Run()
        {
            var Opt = Options.Where(o => o.Arguments.Any(a => a.ShortName.In(this.Args))).FirstOrDefault();
            if (Opt != null)
            {
                var Obj = Activator.CreateInstance(Opt.RawType);

                var ValueArguments = Opt.Arguments.Where(o=>o.Type == ArgumentTypeEnum.Value);
                foreach (var arg in ValueArguments)
                {                    
                    Obj.GetType().GetProperty(arg.MemberName).SetValue(Obj, Convert.ChangeType(this.Args[arg.ShortName.InIndex(this.Args) + 1], arg.ArgType));
                }

                var MethodArguments = Opt.Arguments.Where(o => o.Type == ArgumentTypeEnum.Method);
                foreach (var arg in MethodArguments)
                {
                    Obj.GetType().GetMethod(arg.MemberName).Invoke(Obj, null);
                    if (arg.PassParemeterCount > 0)
                    {
                        var Params = new object[arg.PassParemeterCount];
                        for (int i = 0; i < arg.PassParemeterCount; i++)
                        {
                            Params[i] = this.Args[arg.ShortName.InIndex(this.Args) + i+1];
                        }
                    }
                }
            }
        }

        public CommandLineParser AddOption<T>() where T : class
        {
            var Option = new Option();
            Option.RawType = typeof(T);

            MemberInfo[] members = typeof(T).GetMembers();
            foreach (var member in members)
            {
                if (typeof(T).GetPropAttributeValue(member.Name, (ValueArgumentAttribute d) => d.ShortName) != null)
                {
                    var Arg = new BaseArgument();

                    Arg.Type = ArgumentTypeEnum.Value;
                    Arg.ArgType = typeof(T).GetPropAttributeValue(member.Name, (ValueArgumentAttribute d) => d.ValueType);
                    Arg.MemberName = member.Name;
                    Arg.ShortName = typeof(T).GetPropAttributeValue(member.Name, (ValueArgumentAttribute d) => d.ShortName);
                    Arg.LongName = typeof(T).GetPropAttributeValue(member.Name, (ValueArgumentAttribute d) => d.LongName);
                    Arg.Description = typeof(T).GetPropAttributeValue(member.Name, (ValueArgumentAttribute d) => d.Description);

                    Option.AddArgument(Arg);
                }
                if (typeof(T).GetPropAttributeValue(member.Name, (CommandArgumentAttribute d) => d.ShortName) != null)
                {
                    var Arg = new BaseArgument();

                    Arg.Type = ArgumentTypeEnum.Method;
                    Arg.MemberName = member.Name;
                    Arg.ShortName = typeof(T).GetPropAttributeValue(member.Name, (CommandArgumentAttribute d) => d.ShortName);
                    Arg.LongName = typeof(T).GetPropAttributeValue(member.Name, (CommandArgumentAttribute d) => d.LongName);
                    Arg.Description = typeof(T).GetPropAttributeValue(member.Name, (CommandArgumentAttribute d) => d.Description);
                    Arg.PassParemeterCount = typeof(T).GetPropAttributeValue(member.Name, (CommandArgumentAttribute d) => d.PassParameterCount);

                    Option.AddArgument(Arg);
                }
            }

            this.Options.Add(Option);

            return this;
        }
    }
}
