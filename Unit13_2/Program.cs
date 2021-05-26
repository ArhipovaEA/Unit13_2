using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Unit13_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> WorldBook = new List<string>();

            Dictionary<string, int> MyDictionary = new Dictionary<string, int>();

            string readstring;
            char[] separators = new char[] { ' ', '.' ,'!', '?', '<', '>', ';', ':', '-'};

            try
            {
                using (StreamReader sr = new StreamReader("D:\\Text1.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        readstring = sr.ReadLine();
                        string[] subs = readstring.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var sub in subs)
                        {
                            WorldBook.Add(sub);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл не найден! " + e.Message);

            }

            foreach (string word in WorldBook)
            {
                if (MyDictionary.ContainsKey(word.ToLower()))
                    {

                    MyDictionary[word.ToLower()] += 1; }
                else
                    { MyDictionary.Add(word.ToLower(), 1); }
                
            }

            var items = from pair in MyDictionary
                        orderby pair.Value descending
                        select pair;

            int count = 0;

            foreach (KeyValuePair<string, int> pair in items)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                count += 1;
                if (count == 10)
                { break; }
            }

        }
    }
}
