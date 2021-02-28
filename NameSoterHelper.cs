using System.Collections.Generic;
using System.Linq;
using System;

namespace NameSorter
{
    class NameSoterHelper
    {
        public List<string> excute(string[] strNameArray)
        {
            Console.WriteLine("start handling Name list in NameSoterHelper");
            List<string> sortedNameList = new List<string>();
            List<Name> nameList = ConvertToNameList(strNameArray);

            if(nameList.Count > 0 )
                sortedNameList = SorterLastName(nameList);

            return sortedNameList;
        }
        private List<string> SorterLastName(List<Name> nameList)
        {
            return nameList.ConvertAll(x => x.firstName.ToString() + x.lastName.ToString());
        }
        private List<Name> ConvertToNameList(string[] names)
        {
            List<Name> nameList = new List<Name>();
            string[] tempNameArray = null;
            foreach (string strName in names)
            {
                try
                {
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
                    Console.WriteLine(string.Format("Name:{0},{1}", strName, ex.Message));
                }
            }
            nameList = nameList.OrderBy(p => p.lastName).ToList();
            return nameList;
        }
    }
}