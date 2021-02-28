using System.IO;
using System.Collections.Generic;
using System;

namespace NameSorter
{
    class FileHelper
    {
        private string _filePath = string.Empty;
        public FileHelper(string filePath)
        {
            this._filePath = filePath;
        }

        public string[] getFileContent()
        {
            string[] strFileContent = null;
            try
            {
                if (string.IsNullOrEmpty(_filePath))
                    return strFileContent;

                strFileContent = File.ReadAllLines(_filePath);
                return strFileContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return strFileContent;
            }
        }
        public bool writeFile(List<string> content)
        {
            try
            {
                if (!string.IsNullOrEmpty(_filePath))
                    File.WriteAllLines(_filePath, content);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public void printFileContent()
        {
            string[] strNameArray = getFileContent();
            foreach (string strName in strNameArray)
            {
                Console.WriteLine(strName);
            }

        }
    }
}