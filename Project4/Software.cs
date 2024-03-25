using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    public class Software : Product
    {
        public string Version { get; set; } = "";

        public Software() { }
        public Software(string code, string description, string price, string version) : base(code, description, price) => 
            Version = version;

        public override string GetDisplayText(string sep) => $"Software{sep}{Code}{sep}{Description}{sep}{Price}{sep}{Version}";
    }
}
