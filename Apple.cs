using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    public class Apple:Item {

        public int healing = 5;

        public Apple(bool bad, int heal) {

            healing = heal;
            this.badItem = bad;
            this.name = "Apple";


        }

        public override void use(Object o) {

            if (o.GetType() == typeof(Player)) {

                Player p = (Player)o; // must cast
                p.heal(healing);

            }
            else {

                Console.WriteLine("You can't use this item on this object!");

            }

        }
    }
}