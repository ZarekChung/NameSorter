using System;
using System.Collections.Generic;
using NameSorter.UtilityHelpers;
namespace NameSorter
{
    class Program
    {
        private static readonly string unsortedFile = "unsorted-names-list.txt";
        private static readonly string sortedfile = "sorted-names-list.txt";
        static void Main(string[] args)
        {
            Execute();
            Console.WriteLine("NameSorter has completed");

        }
        private static void Execute()
        {
            Console.WriteLine("start running NameSorter");

            FileHelper fileHelper = new FileHelper(unsortedFile,sortedfile);

            string[] strNameArray = fileHelper.ReadFileContent();
            if (strNameArray == null || strNameArray.Length == 0)
            {
                Console.WriteLine("Cannot find the file or there is no record in file");
                return;
            }

            NameSorterHelper nameSoterHelper = new NameSorterHelper();
            List<string> sortedNameList = nameSoterHelper.Excute(strNameArray);
            if(sortedNameList.Count == 0)
            {
                Console.WriteLine("There is no record in sorted list. Please check the file.");
                return; 
            }
            
            bool result = fileHelper.WriteFile(sortedNameList);
            if (result)
            {
                Console.WriteLine();
                fileHelper.PrintFileContent();
                Console.WriteLine();
            }
        }

    }
}
