using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETTests.Utils
{
    public class CSVReader
    {
      static List<List<string>> ListOfDataSets = new List<List<string>>();
       
        public static void Read()
        {
            using (var reader = new StreamReader(@"../../../Data.csv"))
            {            

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
 
                    ListOfDataSets.Add(values.ToList());
                }

            }

            foreach (var dataSet in ListOfDataSets)
            {
                
                foreach (var element in dataSet)
                {
                    Console.Write(element);
                }

                Console.WriteLine("");
            }
        }


        public static List<List<string>> GetListOfDataSets()
        {
            return ListOfDataSets;
        }

    }
}
