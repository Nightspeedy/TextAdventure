using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS
{

    public class Knife : Item {

        public int damage;


        public Knife() {

            damage = 15;
            this.badItem = true;
            this.name = "Knife";

        }

        public override void use(Object o) {

            if (o.GetType() == typeof(Player)) {

                Player p = (Player)o; // must cast
                p.damage(damage);
                Console.WriteLine("You've cut youself...");

            }
            else {

                Console.WriteLine("You can't use this item on this object!");

            }
        }
    }
}