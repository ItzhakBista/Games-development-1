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
    public static string timeInWords(int h, int m)
    {
        string time = "";
        string[] hours = ["twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven"];
        int minutes = m;
        
        switch(m){
            case 00:
                time = hours[h] + " o' clock";
                break;
            case 15:
                time = "quarter past " + hours[h];
                break;
            case 30:
                time = "half past " + hours[h];
                break;
            case 45:
                time ="quarter to " + hours[h+1];
                break;
            default:
                if(m > 30){
                    int num = 60-m;
                    time = numToWord(num) + " minutes to " + hours[h+1];
                }else{
                    if(m == 1){
                        time = numToWord(m) + " minute past " + hours[h];
                    }else{
                        time = numToWord(m) + " minutes past " + hours[h];
                    }
                }
                break;
        }
        return time;
    }
    
    public static string numToWord(int num){
        
        string[] ones = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "ninteen"];
        if (num <= 20){
            return ones[num-1];
        }else{
            return "twenty " + ones[num%10 -1];
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
