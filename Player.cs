using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    class Player {

        private Room currentRoom;
        private Inventory inventory;

        public int Health = 100;

        public Player() {

            inventory = new Inventory();

        }

        public Room Currentroom {
            get { return currentRoom; }
            set { currentRoom = value; }
        }

        public int damage(int amount) {

            Health -= amount;
            Console.WriteLine("Oh no! You lost some blood! Your health is now at : " + Health);



            return Health;
        }

        public int heal(int amount) {
            
            Health += amount;

            return Health;
        }

        public bool isAlive() {
            if (Health <= 0) {
                return false;
            }
            return true;
        }
    }
}
