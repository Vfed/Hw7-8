using System;
using System.Collections.Generic;
using System.Text;

namespace Hw8
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> LanguageSpeaks { get; set; }
    }
    public class Worker : Person
    {
        public string Position { get; set; }
        public Worker(string name, int age, string position, List<string> languges)
        {
            Name = name;
            Age = age;
            Position = position;
            LanguageSpeaks = languges;
        }
    }
    public class Turist : Person
    {
        public string CountryFrom { get; set; }
        public Turist(string name, int age, string country, List<string> languges)
        {
            Name = name;
            Age = age;
            CountryFrom = country;
            LanguageSpeaks = languges;
        }
    }

}
