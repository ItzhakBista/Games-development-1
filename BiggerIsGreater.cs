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
    public static string biggerIsGreater(string w)
    {
        char[] chars = w.ToCharArray();
        int i = chars.Length - 2;
        while (i >= 0 && chars[i] >= chars[i + 1])
            i--;
            
        if (i < 0)
            return "no answer";

        int j = chars.Length - 1;
        while (chars[j] <= chars[i])
            j--;

        (chars[i], chars[j]) = (chars[j], chars[i]);

        Array.Reverse(chars, i + 1, chars.Length - i - 1);

        return new string(chars);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
