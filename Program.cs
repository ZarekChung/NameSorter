using System;
using System.Collections.Generic;

namespace NameSorter
{
    class Program
    {
        private static readonly string filePath = "unsorted-names-list.txt";
        static void Main(string[] args)
        {
           execute();
           Console.WriteLine("NameSorter has completed");

        }
        private static void execute(){
            Console.WriteLine("start running NameSorter");

            FileHelper fileHelper = new FileHelper(filePath);

            string[] strNameArray = fileHelper.getFileContent();
            if(strNameArray ==null || strNameArray.Length == 0){
                Console.WriteLine("Cannot find the file or there is no record in file");
                return;
            } 

            NameSoterHelper nameSoterHelper = new NameSoterHelper();
            List<string> sortedNameList = nameSoterHelper.excute(strNameArray);
            bool result = fileHelper.writeFile(sortedNameList);
            if(result){
                Console.WriteLine();
                fileHelper.printFileContent();
                Console.WriteLine();
            }
        }
        
    }
}
