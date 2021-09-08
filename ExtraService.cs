using System;
using System.Collections.Generic;
using System.Text;

namespace Hw8
{
    public class ExtraService
    {
        public string Service { get; set; }
        public bool IsAwailable { get; set; }
        public ExtraService(string Name, bool active)
        {
            Service = Name;
            IsAwailable = active;
        }
    }
}
