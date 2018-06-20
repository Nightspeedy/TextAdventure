using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuulCS {

    class Player {

        private Room currentRoom;
        public int Health = 100;

        public Room Currentroom {
            get { return currentRoom; }
            set { currentRoom = value; }
        }

        public Player() {


        
        }
        public bool isAlive() {
            if (Health <= 0) {
                return false;
            }
            return true;
        }
    }
}
