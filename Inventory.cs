using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    public class Inventory {

        private Dictionary<string, Item> items;

        public Inventory() {
            items = new Dictionary<string, Item>();
        }

        public void GetItems()
        {

        }
        public void Take(Item item) {

        }
        public void Drop(Item item) {

        }
        public void add(Item item, string name) {
            items.Add(name, item);
        }
    }
}
