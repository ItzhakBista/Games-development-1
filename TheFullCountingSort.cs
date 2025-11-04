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

    public static void countSort(List<List<string>> arr)
    {
        int n = arr.Count, max = 0;
        for (int i = 0; i < n; i++) max = Math.Max(max, int.Parse(arr[i][0]));
        var buckets = new List<List<string>>(max + 1);
        for (int i = 0; i <= max; i++) buckets.Add(new List<string>());
        for (int i = 0; i < n; i++)
        {
            int x = int.Parse(arr[i][0]);
            string s = (i < n / 2) ? "-" : arr[i][1];
            buckets[x].Add(s);
        }
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i <= max; i++)
            foreach (var s in buckets[i]) { sb.Append(s); sb.Append(' '); }
        Console.WriteLine(sb.ToString().TrimEnd());
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> arr = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        Result.countSort(arr);
    }
}
