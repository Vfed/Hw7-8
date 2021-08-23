using System;
using System.Collections.Generic;
using System.Text;

namespace Hw8
{
    class Validator
    {
        public Validator()
        { }
        public bool SetMinLength(string val, int i)
        {
            if (val.Length >= i)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Wrong enter, too short < " + i);
                return false;
            }
        }
        public bool SetMaxLength(string val, int i)
        {
            if (val.Length <= i)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Wrong enter, too long > " + i);
                return false;
            }
        }
        public bool IsProf(int i)
        {
            switch (i)
            {
                case 1:
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                default: return false;
            }
        }
    }
}
