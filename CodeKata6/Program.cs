using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata6
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            var path = System.AppDomain.CurrentDomain.BaseDirectory + @"\wordlist.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string hashedWord = MakeHash(s);
                    if (!results.ContainsKey(hashedWord))
                    {
                        results.Add(hashedWord, s);
                    }
                    else
                    {
                        results[hashedWord] = results[hashedWord] + "," + s;
                    }
                }
            }

            foreach (var h in results)
            {
                if (h.Value.Contains(","))
                {
                    Console.WriteLine(h.Value);
                }
            }

            Console.ReadLine();
        }

        private static string MakeHash(string word)
        {
            SortedDictionary<char, ulong> characterCount = new SortedDictionary<char, ulong>();
            word = word.ToLower();
            foreach (var character in word)
            {
                if (character != '\'' && character != ' ')
                {
                    if (!characterCount.ContainsKey(character))
                    {
                        characterCount.Add(character, 1);
                    }
                    else
                    {
                        characterCount[character]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var cc in characterCount)
            {
                sb.Append(cc.Key);
                sb.Append(cc.Value);
            }
            return sb.ToString();
        }
    }


}
