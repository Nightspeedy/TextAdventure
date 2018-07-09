using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public int weight { get; set; }
        public bool badItem { get; set; }
        public bool heal { get; set; }

        public Item() {
            description = "A generic Item";
            System.Console.WriteLine("Item Constructor");
        }

        public virtual void use(Object o) {
            System.Console.WriteLine("Item::use(Object o)");
        }

        public virtual void use() {
            System.Console.WriteLine("Item::use()");
        }

        public string Description {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}