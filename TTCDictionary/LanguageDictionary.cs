using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTCDictionary
{
    public class LanguageDictionary : ILanguageDictionary
    {
        private Dictionary<string, string> list;

        public LanguageDictionary(Dictionary<string, string> list)
        {
            this.list = list;
        }

        public bool Check(string language, string word)
        {
            //throw new NotImplementedException();
            if (list.Any(i => i.Key == language && i.Value == word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add(string language, string word)
        {
            if (list.Any(i => i.Key == language && i.Value == word))
            {
                return false;
            }

            list.Add(language, word);

            return true;
        }

        public IEnumerable<string> Search(string word)
        {
            List<string> result = new List<string>();
            foreach (KeyValuePair<string, string> pair in this.list)
            {
                if (pair.Value.StartsWith(word))
                {
                    result.Add(pair.Value);
                }
            }
            return result;
            
        }

        public static void Main(string[] args)
        {
            LanguageDictionary dict = new LanguageDictionary(new Dictionary<string, string>());
            //Console.WriteLine(dict.Check("English", "hello"));
            dict.Add("English", "hello");
            dict.Add("Spanish", "helio");
            IEnumerable<string> test = new List<string>();
            test = dict.Search("he");
            foreach(string word in test)
            {
                Console.WriteLine(word);
            }
            
            Console.ReadLine();
        }
    }
}
