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
    public static int surfaceArea(List<List<int>> A)
    {
    int H = A.Count, W = A[0].Count;
    int area = 0;

    for (int i = 0; i < H; i++)
    {
        for (int j = 0; j < W; j++)
        {
            int h = A[i][j];
            if (h <= 0) continue;
            area += 2;
            int up = (i == 0) ? 0 : A[i - 1][j];
            area += Math.Max(0, h - up);

            int down = (i == H - 1) ? 0 : A[i + 1][j];
            area += Math.Max(0, h - down);

            int left = (j == 0) ? 0 : A[i][j - 1];
            area += Math.Max(0, h - left);

            int right = (j == W - 1) ? 0 : A[i][j + 1];
            area += Math.Max(0, h - right);
        }
    }
    return area;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
