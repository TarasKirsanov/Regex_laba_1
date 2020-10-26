using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Regex_laba
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("1.txt");
            var text = reader.ReadToEnd();
           
            
            Regex regex = new Regex(@"([0-9,A-E]{2})-([0-9,A-E]{2})-([0-9,A-E]{2})-([0-9,A-E]{2})-([0-9,A-E]{2})-([0-9,A-E]{2})");
            if(regex.IsMatch(text))
            {
                 foreach(var item in regex.Matches(text))
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}
