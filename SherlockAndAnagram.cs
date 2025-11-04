using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static int sherlockAndAnagrams(string s)
    {
        var dict = new Dictionary<string, int>();
        int n = s.Length;

        for (int i = 0; i < n; i++)
        {
            int[] freq = new int[26];
            for (int j = i; j < n; j++)
            {
                freq[s[j] - 'a']++;

                var sb = new System.Text.StringBuilder(26 * 2);
                for (int k = 0; k < 26; k++)
                {
                    sb.Append('#').Append(freq[k]);
                }
                string key = sb.ToString();

                if (dict.TryGetValue(key, out int c)) dict[key] = c + 1;
                else dict[key] = 1;
            }
        }

        int ans = 0;
        foreach (var v in dict.Values)
            if (v > 1) ans += v * (v - 1) / 2;

        return ans;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
