using System.IO;
using System.Collections.Generic;
using System;

namespace NameSorter.UtilityHelpers
{
    class FileHelper
    {
        private string _unsortedFile = string.Empty;
        private string _sortedFile = string.Empty;

        public FileHelper(string unsortedFile, string _sortedFile)
        {
            this._unsortedFile = unsortedFile;
            this._sortedFile  = _sortedFile;
        }

        public string[] ReadFileContent()
        {
            string[] strFileContent = null;
            try
            {
                if (string.IsNullOrEmpty(_unsortedFile))
                    return strFileContent;

                strFileContent = File.ReadAllLines(_unsortedFile);
                return strFileContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return strFileContent;
            }
        }
        public bool WriteFile(List<string> content)
        {
            try
            {
                if (!string.IsNullOrEmpty(_sortedFile))
                    File.WriteAllLines(_sortedFile, content);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public void PrintFileContent()
        {
            string[] strNameArray = File.ReadAllLines(_sortedFile);
            foreach (string strName in strNameArray)
            {
                Console.WriteLine(strName);
            }

        }
    }
}