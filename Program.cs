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

        public static void GreateHtmlDoc(string TextInBody)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html >");
            sb.Append("<head >");
            string meta = @"<meta charset=""UTF-8"">";
            sb.Append(meta);
            sb.Append("<title >");
            sb.Append("</title >");
            sb.Append("</head >");
            sb.Append("<body >");
            sb.Append(TextInBody);
            sb.Append("</body >");
            sb.Append("</html >");
            using (StreamWriter sw = new StreamWriter("MyHtml.html"))
            {
                sw.Write(sb.ToString());
                sw.Close();
                Console.WriteLine("Файл создан успешно!");
                System.Diagnostics.Process.Start("MyHtml.html");
            }
        }



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


            text = File.ReadAllText("Text.txt");
            string pattern = @"Fs([1-7])(.+)";//регулярка для 2го предложения задания по открытому и закрытому тегу
            Regex reg = new Regex(pattern);

            var el = reg.Match(text);
            var text1 = "<Font size = " + el.Groups[1].Value + ">" + el.Groups[2].Value + " </Font>";


            pattern = @"P(.+)";
            reg = new Regex(pattern);
            foreach (Match item in reg.Matches(text))
            {
                var tt = "<Pre>" + item.Groups[1].Value + "</Pre>";
                text1 += tt;
            }


            Console.ReadKey();
            GreateHtmlDoc(text1);


        }
    }
}
