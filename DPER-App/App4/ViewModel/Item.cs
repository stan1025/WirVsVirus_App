using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace DPER_App.ViewModel
{
    public class Item<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {

        public string Name { get; set; }
        public T Value { get; set; }
        public T Min { get; set; }
        public T Max { get; set; }
        public string ID { get; set; }

        public void parseSettings (string settings)
        {
            T min = JsonConvert.DeserializeObject<T>("0");
            T max = JsonConvert.DeserializeObject<T>("100");
            if (!string.IsNullOrWhiteSpace(settings) & settings.Contains(";"))
            {

                string input = settings.ToLower();
                string pattern = @";";

                string[] splttingeResults = Regex.Split(input, pattern);

                foreach (string part in Regex.Split(input, pattern))
                {
                    string test = part.Substring(part.IndexOf("=") + 1);
                    switch (part.Substring(0, part.IndexOf("=")))
                    {
                        case "min":
                            Min = JsonConvert.DeserializeObject<T>(part.Substring(part.IndexOf("=") + 1));
                            break;
                        case "max":
                            Max = JsonConvert.DeserializeObject<T>(part.Substring(part.IndexOf("=") + 1));
                            break;
                        default: break;
                    }
                }
            }
        }

        public Item()
        {

        }
    }
}
