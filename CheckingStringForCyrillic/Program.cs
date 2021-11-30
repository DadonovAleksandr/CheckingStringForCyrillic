using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Unicode;

namespace CheckingStringForCyrillic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = { "TspdBlockCode.txt", "TspdDataTypeCode.txt", "TspdGroupParamCode.txt", "TspdInstalPlaceCode.txt", "TspdParamCode.txt", "TspdTouCode.txt" };

            foreach (var file in files)
            {
                Console.WriteLine(file);
                List<string> list = File.ReadLines(file).ToList();
                list.RemoveAll(item => item.Contains("Description"));
                for(int i=0;i<list.Count;i++)
                {
                    string[] parts = list[i].Split("//");
                    list[i] = parts[0].Trim().Replace(",", "");
                }
                
                foreach (var item in list)
                {
                    var res = item.Any(ch => ch >= UnicodeRanges.Cyrillic.FirstCodePoint && ch  < (UnicodeRanges.Cyrillic.FirstCodePoint + UnicodeRanges.Cyrillic.Length));
                    if(res)
                        Console.WriteLine(item);
                }    
            }
            
        }
    }
}