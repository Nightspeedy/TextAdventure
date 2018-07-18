using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    public class Inventory {

        private List<Item> list;
        private int maxWeight;
        private int totalWeight;

        internal List<Item> List { get => list; }

        public Inventory(int amount) {

            this.maxWeight = amount;

            list = new List<Item>();
        }

        public void GetItemsPlayer() {

            string message = "Your inventory contains the following items";

            if (list.Count != 0) {

                for (int i = 0; i < list.Count; i++) {

                    message += "\n" + list[i].name;

                }

                Console.WriteLine(message);

            } else {

                Console.WriteLine("There are no items in your inventory");

            }

        }

        public void GetItemsRoom() {

            string message = "In this room you find:";

            if (list.Count != 0) {

                for (int i = 0; i < list.Count; i++) {

                    message += "\n" + list[i].name;

                }

                Console.WriteLine(message);
            } else {

                Console.WriteLine("There are no items in this room");

            }

        }

        public Item Take(Inventory other, string item) {

            if (other == null) {

                Console.WriteLine("This inventory does not exist!");
                return null;

            }

            for (int i = list.Count - 1; i >= 0; i--) {

                if (!this.list.Any()) {

                    Console.WriteLine("This item does not exist in this room!");
                    return null;

                }

                if (list[i].name == item) {

                    other.list.Add(list[i]);
                    Console.WriteLine("You took a " + list[i].name);
                    list.Remove(list[i]);

                } else {

                    Console.WriteLine("This item does not exist in this room!");

                }
            }
            return null;
        }

        public Item Drop(Inventory other, string item) {

            if (other == null) {

                Console.WriteLine("This inventory does not exist!");
                return null;

            }

            for (int i = list.Count - 1; i >= 0; i--) {

                if (!this.list.Any()) {

                Console.WriteLine("This item does not exist in your inventory!");
                return null;

                }

                if (list[i].name == item) {

                    other.list.Add(list[i]);
                    Console.WriteLine("You dropped a " + list[i].name);
                    list.Remove(list[i]);

                } else {

                    Console.WriteLine("This item does not exist in your inventory!");

                }
            }
            return null;
        }

        public Item Use(string item) {

            for (int i = list.Count - 1; i >= 0; i--) {

                if (!this.list.Any()) {

                    Console.WriteLine("This item does not exist in your inventory!");
                    return null;

                }

                if (list[i].name == item) {

                    list[i].use(list[i].type);

                } else {

                    Console.WriteLine("This item does not exist in your inventory!");

                }
            }
            return null;
        }

        public void add(Item item) {
            this.list.Add(item);
        }
    }
}

