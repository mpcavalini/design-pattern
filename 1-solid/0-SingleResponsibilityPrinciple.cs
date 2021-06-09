﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_solid
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text) { 
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index) {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence {
        public void SaveToFile(Journal j, string filename, bool overwrite = false) {
            if (overwrite || !File.Exists(filename)) {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    //public class Demo
    //{
    //    static void Main(string[] args)
    //    {
    //        var j = new Journal();
    //        j.AddEntry("I saw Batman");
    //        j.AddEntry("Superman can fly");

    //        Console.WriteLine(j);

    //        var p = new Persistence();
    //        var filename = @"c:\temp\journal.txt";
    //        p.SaveToFile(j, filename, true);

    //        Process.Start("notepad.exe", filename);
    //    }
    //}
}
