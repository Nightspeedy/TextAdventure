using System;

namespace ZuulCS {

	public class Game {
		private Parser parser;
        private Player player;

		public Game () {

            parser = new Parser();
            player = new Player();
            createRooms();

            
		}

		private void createRooms() {

			Room outside, theatre, pub, lab, office, attic;

			// create the rooms
			outside = new Room("outside the main entrance of the university", false);
			theatre = new Room("in a lecture theatre", false);
			pub = new Room("in the campus pub", false);
			lab = new Room("in a computing lab", false);
            office = new Room("in the computing admin office", false);
            attic = new Room("on a dusty attic", true);

            // Add items to rooms
            attic.Inventory.add(new Apple(false, 5));
            theatre.Inventory.add(new Knife());


            // initialise room exits
            outside.setExit("east", theatre);
			outside.setExit("south", lab);
			outside.setExit("west", pub);

			theatre.setExit("west", outside);
            theatre.setExit("up", attic);


            attic.setExit("down", theatre);

            pub.setExit("east", outside);

			lab.setExit("north", outside);
			lab.setExit("east", office);

            office.setExit("west", lab);
            office.Inventory.add(new Key());

            player.Currentroom = outside;  // start game outside

		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play() {

			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
			}
			Console.WriteLine("Thank you for playing.");

		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome() {

			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.Currentroom.getLongDescription());

		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command) {

			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
            switch (commandWord)
            {
                case "help":
                    printHelp();
                    break;
                case "go":
                    goRoom(command);
                    if (player.Health <= 0)
                    {
                        wantToQuit = true;
                    }
                    break;
                case "ragequit":
                    wantToQuit = true;
                    break;
                case "look":
                    Console.WriteLine(player.Currentroom.getLongDescription());
                    player.Currentroom.Inventory.GetItemsRoom();
                    break;
                case "take":
                    player.Currentroom.Inventory.Take(player.Inventory, command.getSecondWord());
                    break;
                case "drop":
                    player.Inventory.Drop(player.Currentroom.Inventory, command.getSecondWord());
                    break;
                case "use":
                    use(command);
                    if (player.Health <= 0) {
                        wantToQuit = true;
                    }
                    break;
                case "inventory":
                    player.Inventory.GetItemsPlayer();
                    break;
            }

			return wantToQuit;
		}

        // implementations of user commands:
        private void use(Command command) {

            Item i = null;

            if (command.hasSecondWord()) {

                for (int e = player.Inventory.List.Count - 1; e >= 0; e--) {

                    if (command.getSecondWord() == player.Inventory.List[e].name) {

                        i = player.Inventory.List[e];

                    }

                }

                if (command.hasThirdWord()) {

                    Room roomToUnlock = player.Currentroom.getExit(command.getThirdWord());

                        if (roomToUnlock == null) {

                            Console.WriteLine("There is no door to unlock in that direction!");
                            return;

                        } else {

                            if (i == null) {

                                Console.WriteLine("This item does not exist in your inventory!");
                                return;
                            } else {

                                i.use(roomToUnlock);
                                return;
                            }

                        }

                    }

                if (i == null) {

                    Console.WriteLine("The item you're trying to use does not exist!");

                } else {

                    i.use(player);

                }

            } else {

                Console.WriteLine("Please specify an item to use!");

            }

        }
		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp() {

			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();

		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command) {

			if(!command.hasSecondWord()) {

				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");

				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.Currentroom.getExit(direction);

            if (nextRoom == null) {

                Console.WriteLine("There is no door to " + direction + "!");

            } else if (nextRoom.isLocked == true) {

                Console.WriteLine("Looks like this door is locked... You need a key to enter here");

            } else {

                Console.Clear();
                player.Currentroom = nextRoom;
                Console.WriteLine(player.Currentroom.getLongDescription());
                player.damage(10);

            }
        }
	}
}
