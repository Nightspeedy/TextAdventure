using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    public class Item {

        public string description { get; set; }
        public bool badItem;
        public string name;
        public string type;

        public Item() {
            description = "A generic Item";
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