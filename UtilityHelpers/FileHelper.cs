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
                if (isFileNameEmpty(_unsortedFile))
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
                if (isFileNameEmpty(_sortedFile))
                    return false;

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
            if(isFileNameEmpty(_sortedFile))
                return;

            string[] strNameArray = File.ReadAllLines(_sortedFile);
            foreach (string strName in strNameArray)
            {
                Console.WriteLine(strName);
            }

        }
        private bool isFileNameEmpty(string sFileName){
            if(string.IsNullOrEmpty(sFileName)){
                Console.WriteLine("Cannot find the file, please check the file name, fileName : " + sFileName);
            }
            return string.IsNullOrEmpty(sFileName);
        }
    }
}