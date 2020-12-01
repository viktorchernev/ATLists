using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATListsConsole
{
    public class Payload
    {
        public Dictionary<string, List<Cmd>> CommandEntries;
        public Dictionary<string, List<Aux>> InfoEntries;

        public Payload()
        {
            CommandEntries = new Dictionary<string, List<Cmd>>();
            InfoEntries = new Dictionary<string, List<Aux>>();
        }
    }
    public class Cmd
    {
        public string command_text;
        public string what_does;
        public string explanation;
        public string example;
        public string example_explanation;
        public string[] tags;
    }
    public class Aux
    {
        public string command_text;
        public string description;
        public string[] tags;
    }
}
