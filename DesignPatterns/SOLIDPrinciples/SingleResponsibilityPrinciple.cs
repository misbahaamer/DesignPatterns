using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPatterns
{
    class SingleResponsibilityPrinciple
    {

    }
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add(($"{++count} : {text}"));
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        #region Violation of Single Responsibility Rule because Class Journal is also responsible for persistant methods here other than Journal
        public void SaveToFile(string filename)
        {
            File.WriteAllText(filename, ToString());
        }

        public static Journal LoadFromFile(string filename)
        {
            throw new NotImplementedException();
        }

        public void LoadFromURI(Uri Uri)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public class Persistance
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }

    }


}
