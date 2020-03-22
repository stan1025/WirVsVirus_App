using System;
using System.Collections.Generic;
using System.Text;

namespace DPER_App.ViewModel
{
    public class Item<T>
    {

        public string Name { get; set; }
        public T Value { get; set; }
        public T Min { get; set; }
        public T Max { get; set; }
        public string ID { get; set; }

        public Item()
        {

        }
    }
}
