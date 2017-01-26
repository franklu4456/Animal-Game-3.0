/*
 * Megan Hong and Frank Lu
 * World Class: controls and creates the world for the game
 * states the tiles infront of the player
 * sets the default animal and enemy list
 * 1/24/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnimalGame
{
    class World
    {
        //set the default level of the player to 1
        private int level = 1;
        //variable holds the maptile of the 
        private MapTile[,] _map;
        //variable stores the player
        private Player _P1;
        
        /// <summary>
        /// sets the default animal information
        /// </summary>
        /// <returns>the default animal array</returns>
        /// <summary>
        /// The method to create default attacks and an array of default animals
        /// </summary>
        /// <returns>The array of default animals</returns>
        public Animal[] SetAnimalStuff()
        {
            //Default Water Attacks
            //With stat change attacks and damage attacks
            Attack dirtyWater = new StatChangeAttack(Type.Water, AttackEffect.EnemyStatDebuff, Stat.Defense, "Dirty Water");

            Attack absorb = new StatChangeAttack(Type.Water, AttackEffect.PlayerStatBuff, Stat.Heal, "Absorb");

            Attack splash = new DamageAttack(Type.Water, AttackEffect.EnemyHealthDown, 20, "Splash");

            Attack sprinkler = new DamageAttack(Type.Water, AttackEffect.EnemyHealthDown, 15, "Sprinkler");

            //Default Earth Attacks
            //With stat change attacks and damage attacks
            Attack sandyWind = new StatChangeAttack(Type.Rock, AttackEffect.EnemyStatDebuff, Stat.Speed, "Sandy Wind");

            Attack mudBath = new StatChangeAttack(Type.Rock, AttackEffect.PlayerStatBuff, Stat.Defense, "Mud Bath");

            Attack pelt = new DamageAttack(Type.Rock, AttackEffect.EnemyHealthDown, 12, "Pelt");

            Attack bury = new DamageAttack(Type.Rock, AttackEffect.EnemyHealthDown, 25, "Bury");

            //Default Flying Attacks
            //With stat change attacks and damage attacks
            Attack showOff = new StatChangeAttack(Type.Air, AttackEffect.EnemyStatDebuff, Stat.Attack, "Show Off");

            Attack groom = new StatChangeAttack(Type.Air, AttackEffect.PlayerStatBuff, Stat.Attack, "Groom");

            Attack swoop = new DamageAttack(Type.Air, AttackEffect.EnemyHealthDown, 16, "Swoop");

            Attack peck = new DamageAttack(Type.Air, AttackEffect.EnemyHealthDown, 20, "Peck");

            //Default Fire Attacks
            //With stat change attacks and damage attacks
            Attack smog = new StatChangeAttack(Type.Fire, AttackEffect.EnemyStatDebuff, Stat.Speed, "Smog");

            Attack sauna = new StatChangeAttack(Type.Fire, AttackEffect.PlayerStatBuff, Stat.Defense, "Sauna");

            Attack singe = new DamageAttack(Type.Fire, AttackEffect.EnemyHealthDown, 22, "Singe");

            Attack sparkler = new DamageAttack(Type.Fire, AttackEffect.EnemyHealthDown, 20, "Sparkler");

            //Default Grass Attacks
            //With stat change attacks and damage attacks
            Attack poisonIvy = new StatChangeAttack(Type.Grass, AttackEffect.EnemyStatDebuff, Stat.Defense, "PoisonIvy");

            Attack chrysanthemum = new StatChangeAttack(Type.Grass, AttackEffect.PlayerStatBuff, Stat.Heal, "Chyrsanthemum");

            Attack pricklyThorns = new DamageAttack(Type.Grass, AttackEffect.EnemyHealthDown, 17, "Prickly Thorns");

            Attack fallingBranch = new DamageAttack(Type.Grass, AttackEffect.EnemyHealthDown, 20, "Falling Branch");

            //Default animals

            //Default Grass Animals
            //with one slightly stronger than the other
            Animal grass1 = new Animal(50, 20, 12, 5, Type.Grass, 1, pricklyThorns, fallingBranch, poisonIvy);

            Animal grass2 = new Animal(75, 15, 20, 2, Type.Grass, 2, poisonIvy, chrysanthemum, fallingBranch);

            //Default Water Animals
            //with one slightly stronger than the other
            Animal water1 = new Animal(40, 20, 8, 6, Type.Water, 1, splash, sprinkler, dirtyWater);

            Animal water2 = new Animal(60, 17, 22, 3, Type.Water, 2, absorb, splash, sprinkler);

            //Default Earth Animals
            //with one slightly stronger than the other
            Animal rock1 = new Animal(100, 5, 25, 1, Type.Rock, 1, mudBath, sandyWind, pelt);

            Animal rock2 = new Animal(90, 7, 27, 1, Type.Rock, 2, sandyWind, pelt, bury);

            //Default Fire Animals
            //with one slightly stronger than the other
            Animal fire1 = new Animal(20, 30, 5, 8, Type.Fire, 1, singe, sauna, sparkler);

            Animal fire2 = new Animal(25, 32, 4, 10, Type.Fire, 2, singe, smog, sparkler);

            //Default Flying Animals
            //with one slightly stronger than the other
            Animal air1 = new Animal(40, 18, 15, 10, Type.Air, 1, groom, swoop, peck);

            Animal air2 = new Animal(45, 22, 18, 11, Type.Air, 2, showOff, swoop, peck);

            //Create the array of the default animals with their stats and attacks
            Animal[] defaultAnimals = { grass1, grass2, rock1, rock2, fire1, fire2, water1, water2, air1, air2 };

            //Return the array of default animals
            return defaultAnimals;
        }

        /// <summary>
        /// sets the default enemy information
        /// </summary>
        /// <returns>returns an array of 5 different enemys</returns>
        public Player[] EnemyPlayerList()
        {
            List<Animal> tempEnemyAnimalList = new List<Animal>();
            Player[] enemyPlayerList = new Player[5];
            Random numberGenerator = new Random();
            int counterAnimal = 0;
            int playerCount = 0;
            while (playerCount < 5)
            {
                if (counterAnimal <= 3)
                {
                    int random = numberGenerator.Next(0, SetAnimalStuff().Length - 1);

                    tempEnemyAnimalList.Add(SetAnimalStuff()[random]);
                    counterAnimal++;
                }
                else if (counterAnimal == 4)
                {
                    counterAnimal = 0;
                    Player tempEnemyPlayer = new Player(tempEnemyAnimalList);
                    enemyPlayerList[playerCount] = tempEnemyPlayer;
                    playerCount++;

                }
            }
            return enemyPlayerList;
        }

        /// <summary>
        /// constructor of the world class
        /// sets the information and creates the world
        /// </summary>
        /// <param name="P1">passes through a player
        /// references them and changes their roster</param>
        public World( ref Player P1)
        {
            //first time game
            //set up the map for the first time
            _map = SetupGame();
            //random number generator to randomly select
            // the player's first animal
            Random numberGenerator = new Random();
            int number = numberGenerator.Next(0, SetAnimalStuff().Length);
            //creates an animal list to put into this
            //adds the randomly selected animal to the player's roster
            List<Animal> tempAnimals = new List<Animal>();
            tempAnimals.Add(SetAnimalStuff()[number]);
            P1.Roster = tempAnimals;
           
            _P1 = P1;
        }

        /// <summary>
        /// returns/ displays the maptile's 2d array
        /// </summary>
        public MapTile[,] Map
        {
            get
            {
                return _map;
            }
            //allows the map to be set
            set
            {
                _map = value;
            }
        }

        /// <summary>
        /// returns the player of the game
        /// </summary>
        public Player P1
        {
            get
            {
                return _P1;
            }
        }

        /// <summary>
        /// retrieves the row that is infront of the player
        /// Uses facing direction to find the rog
        /// </summary>
        /// <param name="P1">Passes through the player</param>
        /// <returns>returns the row number that's infront of the player</returns>
        private int GetRowInFront(Player P1)
        {
            int row = P1.Row;
            if (P1.FacingDirection == Direction.Up)
            {
                row = P1.Row - 1;

            }
            else if (P1.FacingDirection == Direction.Down)
            {

                row = P1.Row + 1;
            }

            return row;
        }

        /// <summary>
        /// Gets the row infront of the player
        /// </summary>
        /// <param name="P1">Passes through the player's information</param>
        /// <returns>returns the integer that the player is in</returns>
        private int GetColumnInFront(Player P1)
        {
            int column = P1.Column;
            if (P1.FacingDirection == Direction.Left)
            {

                column = P1.Column - 1;

            }
            else if (P1.FacingDirection == Direction.Right)
            {

                column = P1.Column + 1;

            }
            return column;
        }

        /// <summary>
        /// controls the movement of the player
        /// allows the player to move
        /// </summary>
        /// <param name="P1">Passes through the player
        /// Checks the tile infront of the player
        /// and sees if you can move</param>
        public void Move(Player P1)
        {
            P1.Move(TileInFront(P1));
        }

        /// <summary>
        /// using the user's row and column 
        /// checks the tile that's infront of the player
        /// </summary>
        /// <param name="P1">Passes through the player of the game</param>
        /// <returns>returns the maptile enumeration
        /// that's infront of the player</returns>
        public MapTile TileInFront(Player P1)
        {
            if (GetColumnInFront(P1) < 0 && P1.FacingDirection == Direction.Left)
            {
                return MapTile.CantWalk;
            }
            else if (GetRowInFront(P1) < 0 && P1.FacingDirection == Direction.Up)
            {
                return MapTile.CantWalk;
            }
            else if (GetRowInFront(P1) > _map.GetLength(1)-1 && P1.FacingDirection == Direction.Down)
            {
                return MapTile.CantWalk;
            }
            else if (GetColumnInFront(P1) > _map.GetLength(0)-1 && P1.FacingDirection == Direction.Right)
            {
                return MapTile.CantWalk;
            }
            else
            {
                return (_map[GetColumnInFront(P1), GetRowInFront(P1)]);
            }
            
        }

        /// <summary>
        /// sets up the start of the game:
        /// sets the game's map up
        /// reads the resource file for the different
        /// setups for each level
        /// </summary>
        /// <returns> 2D array of the map</returns>
        public MapTile[,] SetupGame()
        {
            //checks what level the player's on
            if (level == 1)
            {
                string stageOneGrid = Properties.Resources.Stage1;
                //calls the map setup subprogram
                MapTile[,] gridLevelOne = SetMap(stageOneGrid);
                return gridLevelOne;
            }
            else if (level == 2)
            {
                string stageTwoGrid = Properties.Resources.Stage2;
                MapTile[,] gridLevelTwo = SetMap(stageTwoGrid);
                return gridLevelTwo;
            }
            else
            {
                string stageThreeGrid = Properties.Resources.Stage3;
                MapTile[,] gridLevelThree = SetMap(stageThreeGrid);
                return gridLevelThree;
            }
        }

        /// <summary>
        /// sets up the games map
        /// retrieves the text files from the resources
        /// and transfers it into a char array
        /// to later be placed into a 2D maptile array
        /// </summary>
        /// <param name="stageGrid">the resources text file for the map</param>
        /// <returns>a 2D array for the maptile</returns>
        public MapTile[,] SetMap(string stageGrid)
        {
            //split the stageGrid and save it in an array
            string[] num = stageGrid.Split(new char[] {  '\r','\n' });
            string numbers = null;
            //loops and places the previous array into one string
            for (int i = 0; i < num.Length; i++)
            {
                numbers = numbers + num[i];
            }

            //creates a character array for all the characters/ numbers
            //creates an integer array to store all of the information
            char[] val = numbers.ToCharArray();
            int[] numberValues = new int[val.Length];

            //loops till the end of the array,
            //converts all the characters to integers
            for (int i = 0; i < val.Length; i++)
            {
                string temp;
                int number;
                //stores the values into a temporary variable 
                temp = val[i].ToString();
                //changes the string into an integer
                int.TryParse(temp, out number);
                //stores the integer into a number array
                numberValues[i] = number;
            }
            //creates a 2D array to store the values of the map
            MapTile[,] map = new MapTile[18, 12];

            //counter stores the value fo the index of the array
            int counter = 0;
            //loops through the row and column of the array
            //sets the values for the 2D array
            for (int y = 0; y < map.GetLongLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    //checks if the number value array
                    //is out of bounds
                    if (counter < 216)
                    {
                        //converts the integers into a maptile 
                        //enumeration and stores it into the 2D array
                        map[x, y] = (MapTile)numberValues[counter];
                        //adds to the counter
                        counter++;
                    }
                    //if it surpasses the index of the array
                    //break the loop
                    else
                    {
                        break;
                    }
                }
            }
            //return a 2D array
            return map;
        }

        /// <summary>
        /// Saves a player's progress in the game
        /// only saves the level, money, animals and items
        /// </summary>
        /// <param name="P1">pass through the player to save</param>
        public void SaveGame(Player P1)
        {
            //creates or overrides the text file to save a game
            using (StreamWriter file = new StreamWriter("saveGame.txt"))
            {
                //save the player's level and money
                file.WriteLine("1" + "\r\n" + P1.Level.ToString() + " " + P1.Money.ToString());

                //save and store all variables and information for each item
                foreach (Item x in P1.Items)
                {
                    file.WriteLine("2" + "\r\n" + x.Name + " " + x.Quantity.ToString() + " " + x.StatNumber.ToString() + " " + x.StatEffect.ToString());
                }
                //save and store all variables and informationf or each animal
                foreach (Animal x in P1.Roster)
                {
                    file.WriteLine("3" + "\r\n" + x.Species + " " + x.Level.ToString() + " " + x.Speed.ToString() + " " + x.MaxHealth.ToString() + " " + x.Health.ToString() + " " + x.Attack.ToString() + " " + x.Defense.ToString());
                    foreach (Attack j in x.AttackArray)
                    {
                        int damageAttackTemp = 0;
                        //checks if the attack is a damage attack or a stat attack
                        //saves accordingly
                        if (j.IsDamageAttack == true)
                        {
                            damageAttackTemp = 1;
                            DamageAttack temp = (DamageAttack)j;
                            //saves and writes all of the animal's attacks
                            file.WriteLine("4" + "\r\n" + j.AttackType.ToString() + " " + j.Effect.ToString() + " " + j.Name + " " + damageAttackTemp.ToString() + temp.Damage.ToString());
                        }
                        else
                        {
                            damageAttackTemp = 0;
                            StatChangeAttack temp = (StatChangeAttack)j;
                            file.WriteLine("4" + "\r\n" + j.AttackType.ToString() + " " + j.Effect.ToString() + " " + j.Name + " " + damageAttackTemp.ToString() + " " + temp.StatChangeValue.ToString()); ;
                        }
                    }
                }
                //when it's done saving
                //close the file
                file.Close();
            }
        }

        /// <summary>
        /// loads a saved game from an existing file
        /// </summary>
        /// <returns>returns a player</returns>
        public Player LoadGame()
        {
            //check if the file exists
            if (File.Exists("saveGame.txt"))
            {
                //variables will store the saved level and amount of money the player had
                int money = 0;
                int level = 0;

                //temporary list of the player's items, animals and a queue for their animal attacks
                List<Item> tempItems = new List<Item>();
                List<Animal> tempAnimals = new List<Animal>();
                Queue<Attack> tempAnimalAttacks = new Queue<Attack>();
                //variable to store the line that was just read
                string info;

                //variable stores all the animal information
                //initialize it to the bases that aren't applicable
                Type animalSpecies = 0;
                int animalLevel = 0;
                int animalSpeed = 0;
                int animalMaxHealth = 0;
                int animalCurrentHealth = 0;
                int animalAttackAmount = 0;
                int animalDefenseAmount = 0;

                //initialize file with the file "saveGame.txt"
                using (StreamReader file = new StreamReader("saveGame.txt"))
                {
                    //loop through this until the it has read to the end of the file
                    while (file.EndOfStream)
                    {
                        //read a line in the 
                        info = file.ReadLine();

                        if (info == "1")
                        {
                            info = file.ReadLine();
                            //retrieves the section of the array with all the player's information
                            //splits the index by the spaces, and splits it into a player info array
                            string[] playerInfo = info.Split(new char[] { ' ' });
                            //temp string will hold the variables to be changed to an integer
                            string temp = playerInfo[1];
                            //converting the strings to a integer
                            int.TryParse(temp, out money);
                            temp = playerInfo[2];
                            int.TryParse(temp, out level);
                        }
                        else if (info == "2")
                        {
                            //read the next line
                            info = file.ReadLine();
                            //splits the saved string into an array by the spaces
                            string[] playerItems = info.Split(new char[] { ' ' });
                            //variables will store the player's items requirements
                            string itemName;
                            int itemQuantity;
                            Stat itemType;
                            int itemStats;
                            int tempItemType;
                            string tempStringToInteger;

                            //stores the name of the item
                            itemName = playerItems[1];
                            //stores the string in the temp variable to change into a integer
                            //converts the temp string into an integer
                            tempStringToInteger = playerItems[2];
                            int.TryParse(tempStringToInteger, out itemQuantity);

                            tempStringToInteger = playerItems[3];
                            int.TryParse(tempStringToInteger, out itemStats);

                            tempStringToInteger = playerItems[4];
                            int.TryParse(tempStringToInteger, out tempItemType);
                            //converts the integer into a stat enumeration
                            itemType = (Stat)tempItemType;
                            //creates a new item with the saved item information
                            Item tempItemToAddToList = new Item(itemName, itemStats, itemQuantity, itemType);
                            //add it to the temp item list
                            tempItems.Add(tempItemToAddToList);
                        }
                        //checks if the information is about the player's animals
                        else if (info == "3")
                        {
                            //reads the information on that line and saves it in a file
                            info = file.ReadLine();
                            //splits the information into a character array
                            string[] playerAnimalInfo = info.Split(new char[] { ' ' });
                            //variable holds the string to convert to an integer
                            string tempStringToInteger;
                            int tempNumber;

                            //saves the string from the player animal info into the string
                            //converts and retrieves the player's species
                            tempStringToInteger = playerAnimalInfo[1];
                            int.TryParse(tempStringToInteger, out tempNumber);
                            animalSpecies = (Type)tempNumber;

                            //finds the animal's level from the text file
                            //saves converts and stores the text into a integer 
                            tempStringToInteger = playerAnimalInfo[2];
                            int.TryParse(tempStringToInteger, out animalLevel);
                            //finds the animal's speed and converts it into an integer 
                            //to be stored
                            tempStringToInteger = playerAnimalInfo[3];
                            int.TryParse(tempStringToInteger, out animalSpeed);
                            //finds the animal's max health and current health
                            //converts from a string to an integer and stores it into 
                            //a temp array
                            tempStringToInteger = playerAnimalInfo[4];
                            int.TryParse(tempStringToInteger, out animalMaxHealth);
                            tempStringToInteger = playerAnimalInfo[5];
                            int.TryParse(tempStringToInteger, out animalCurrentHealth);

                            //finds the anima's amount of attack and defense 
                            //converts from a string to an integer and stores it
                            //into a temp array
                            tempStringToInteger = playerAnimalInfo[6];
                            int.TryParse(tempStringToInteger, out tempNumber);
                            animalAttackAmount = tempNumber;
                            tempStringToInteger = playerAnimalInfo[7];
                            int.TryParse(tempStringToInteger, out tempNumber);
                            animalDefenseAmount = tempNumber;
                        }
                        //checks if the information is for attack
                        else if (info == "4")
                        {
                            //read the next line and store the information in the variable
                            info = file.ReadLine();
                            //splits the informaton in the string by a space
                            string[] animalAttacks = info.Split(new char[] { ' ' });

                            //creates local variables to temp. store
                            //all the information to create an attack
                            Type attackTypeTemp;
                            AttackEffect attackEffectTemp;
                            string attackNameTemp;
                            int damageAttackAmountTemp;
                            Stat statAttackAmountTemp;
                            string tempStringToInteger;
                            int tempNumbers;

                            //converts the first part of the saved file into 
                            //an integer, to be casted into a type of the attack
                            tempStringToInteger = animalAttacks[1];
                            int.TryParse(tempStringToInteger, out tempNumbers);
                            attackTypeTemp = (Type)tempNumbers;

                            //converts the first part of the saved file into 
                            //an integer, to be casted into an effect fromt he attack
                            tempStringToInteger = animalAttacks[2];
                            int.TryParse(tempStringToInteger, out tempNumbers);
                            attackEffectTemp = (AttackEffect)tempNumbers;
                            //stores the name of the attack
                            attackNameTemp = animalAttacks[3];
                            
                            //store the information into a temp string to convert to a variable
                            //converts it into a integer and states if it is a damage attack or a stat change effect
                            //declares and creates the attack according to this information
                            tempStringToInteger = animalAttacks[4];
                            int.TryParse(tempStringToInteger, out tempNumbers);
                            if (tempNumbers == 1)
                            {
                                tempStringToInteger = animalAttacks[5];
                                int.TryParse(tempStringToInteger, out tempNumbers);
                                damageAttackAmountTemp = tempNumbers;
                                Attack tempAttack = new DamageAttack(attackTypeTemp, attackEffectTemp, damageAttackAmountTemp, attackNameTemp);
                                tempAnimalAttacks.Enqueue(tempAttack);

                            }
                            else
                            {
                                //stores the informatation into the temp string and converts it into a stat enumeration
                                tempStringToInteger = animalAttacks[5];
                                int.TryParse(tempStringToInteger, out tempNumbers);
                                statAttackAmountTemp = (Stat)tempNumbers;
                                //create a new attack and add it to the temp attack array
                                Attack tempAttack = new StatChangeAttack(attackTypeTemp, attackEffectTemp, statAttackAmountTemp, attackNameTemp);
                                tempAnimalAttacks.Enqueue(tempAttack);
                            }
                        }
                        //when the animal has created 3 attacks
                        //add all three attacks to a list of the animals attacks
                        //create the animal accordingly
                        if (tempAnimalAttacks.Count == 3)
                        {
                            Attack attack1 = tempAnimalAttacks.Dequeue();
                            Attack attack2 = tempAnimalAttacks.Dequeue();
                            Attack attack3 = tempAnimalAttacks.Dequeue();

                            Animal tempAnimalToAddToList = new Animal(animalMaxHealth, animalAttackAmount, animalDefenseAmount, animalSpeed, animalSpecies, animalLevel, attack1, attack2, attack3);
                            tempAnimals.Add(tempAnimalToAddToList);
                        }
                    }
                    //close the file
                    file.Close();
                }
                //variable will hold the saved player
                Player savedPlayer = new Player(money, tempAnimals, tempItems, level);

                return savedPlayer;
            }
            else
            {
                //if all the information doesn't work
                //return nothing
                return null;

            }
        }

       

       

    }
}
