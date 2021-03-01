using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using NameSorter.Model;

namespace NameSorter.UtilityHelpers
{
    class NameSorterHelper
    {
        public List<string> Excute(string[] strNameArray)
        {
            Console.WriteLine("start handling Name list in NameSorterHelper");
            List<Name> nameSortedList = GetNameSortedList(strNameArray);
            List<string> sortedNameStrList = new List<string>();

            if (nameSortedList.Count > 0)
                sortedNameStrList = ConvertToSortedNameStrList(nameSortedList);

            return sortedNameStrList;
        }
        private bool ValidateName(string Name)
        {
            Regex checking = new Regex("^[a-zA-Z0-9]*$");
            return checking.IsMatch(Name.Replace(" ",""));
        }
        private List<string> ConvertToSortedNameStrList(List<Name> nameList)
        {
            return nameList.ConvertAll(x => x.firstName.ToString() + x.lastName.ToString());
        }
        private List<Name> GetNameSortedList(string[] names)
        {
            List<Name> nameList = new List<Name>();
            string[] tempNameArray = null;
            foreach (string strName in names)
            {
                try
                {
                    if (!ValidateName(strName))
                    {
                        Console.WriteLine(string.Format("Name: {0} should be alphanumeric. Cannot sort name.", strName));
                        continue;
                    }
                    tempNameArray = strName.Split(" ");
                    Name name = new Name()
                    {
                        firstName = strName.Replace(tempNameArray[tempNameArray.Length - 1], string.Empty),
                        lastName = tempNameArray[tempNameArray.Length - 1]
                    };
                    nameList.Add(name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Name: {0},{1}", strName, ex.Message));
                }
            }
            nameList = nameList.OrderBy(p => p.lastName).ThenBy(p => p.firstName).ToList();
            return nameList;
        }
    }
}