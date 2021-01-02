using System;
using System.Collections.Generic;
using System.Linq;

namespace LoodosPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            isPermutation("baba", "abab");
            isPermutation("baba", "abc");
            isPermutation("lds", "loodos");

            Console.ReadLine();
        }

        public static void isPermutation(string s1, string s2)
        {
            string subString, mainString;
            if(s1.Length > s2.Length)
            {
                mainString = s1;
                subString = s2;
            }
            else
            {
                mainString = s2;
                subString = s1;
            }
            List<string> permutations = GetPermutations(mainString).Distinct().ToList();

            if (permutations.Any(x=>x.Contains(subString)))
                Console.WriteLine($"{s1} , {s2} => {true}");
            else
                Console.WriteLine($"{s1} , {s2} => {false}");
        }

        public static List<string> GetPermutations(string str)
        {
            List<string> permutations = new List<string>();

            if (str == null)
                return null;

            if (str.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }

            char c = str.ElementAt(0);
            var perms = GetPermutations(str.Substring(1));

            foreach (var word in perms)
            {
                for (int i = 0; i <= word.Length; i++)
                {
                    permutations.Add(word.Substring(0, i) + c + word.Substring(i));
                }
            }

            return permutations;
        }
    }
}
