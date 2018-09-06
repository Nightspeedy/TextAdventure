using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    public class Key : Item {

        public int damage;


        public Key() {

            damage = 15;
            this.badItem = false;
            this.name = "Attic-Key";

        }

        public override void use(Object o) {

            if (o.GetType() == typeof(Room)) {

                Room r = (Room)o; // must cast
                r.unlock();

            } else {

                Console.WriteLine("You can't use this item on this object!");

            }
        }
    }
}