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
    public static string encryption(string s)
    {
        int len = s.Length;
        int row = (int)Math.Floor((Math.Sqrt(len)));
        int col = (int)Math.Ceiling((Math.Sqrt(len)));
        if((row*col)<len){ row++;}
        String encrypted = "" ;
        int i=0, j=0;
        while(j < col){
            encrypted += s[i];
            i += col;
            if(i >= len){
                i = ++j;
                encrypted += " ";
            }
        }
        
        return encrypted;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
