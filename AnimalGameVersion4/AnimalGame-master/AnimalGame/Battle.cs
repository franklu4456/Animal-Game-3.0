//Mershab Arafat and Frank Lu
//January 24th, 2017
//Battle Class
//This class will handle all of the battling that goes on.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalGame
{
    class Battle
    {

        //Constant to store the amount that StatChangeAttacks buff or debuff.
        public const int STAT_BUFF = 50;

        //Create Lists of animals to store the player's animals and the enemy's animals.
        private List<Animal> _playerAnimals, _enemyAnimals;

        //Create a list of items to store the player's items.
        private List<Item> _playerItems;

        //Booleans to store whether
        private bool _win, _isWild;

        private int _status;

        public Queue<string> messages = new Queue<string>();

        public bool Win
        {
            get
            {
                return _win;
            }
            set
            {
                _win = value;
            }
        }

        public bool IsWild
        {
            get
            {
                return _isWild;
            }
            set
            {
                _isWild = value;
            }
        }

        public List<Animal> PlayerAnimals
        {
            get
            {
                return _playerAnimals;
            }
            set
            {
                _playerAnimals = value;
            }
        }

        public List<Animal> EnemyAnimals
        {
            get
            {
                return _enemyAnimals;
            }
            set
            {
                _enemyAnimals = value;
            }
        }

        public List<Item> PlayerItems
        {
            get
            {
                return _playerItems;
            }
            set
            {
                _playerItems = value;
            }
        }

        public int Status
        {
            get
            {
                return Status;
            }
            set
            {
                _status = value;
            }
        }

        public Battle(List<Animal> playerAnimals, List<Animal> enemyAnimals, List<Item> playerItems, bool IsWild)
        {
            PlayerAnimals = playerAnimals;
            EnemyAnimals = enemyAnimals;
            PlayerItems = playerItems;
            _isWild = IsWild;
            Status = 2;
        }


        public bool AvailableAnimals(List<Animal> inputAnimals)
        {
            foreach (Animal x in inputAnimals)
            {
                if (!x.HasFainted)
                    return true;

            }
            return false;
        }


        /// <summary>
        /// The method that pits the two leading animals in each roster against eachother.
        /// </summary>
        /// <param name="selectionNumber">The number of the move selected by the user</param>
        /// <returns></returns>
        public void Fight(int selectionNumber)
        {
            //If the Player's animal is faster than the enemy's animal then the player's animal will execute their move first.
            if (PlayerAnimals.First().Speed > EnemyAnimals.First().Speed)
            {
                //If the Player's animal's selected attack is a damage attack continue.
                if (PlayerAnimals.First().AttackArray[selectionNumber].IsDamageAttack)
                {
                    //Retrive the damage attack and store it into a DamageAttack variable.
                    DamageAttack selectedAttack = (DamageAttack)PlayerAnimals.First().AttackArray[selectionNumber];

                    //Calculate the amount of damage that the attack will inflict.
                    //Calculation is based on the attack strength of the move, and the attack stat of the animal.
                    int damageCalculation = (int)(selectedAttack.Damage * (PlayerAnimals.First().Attack * 0.2) - EnemyAnimals.First().Defense);

                    //Enqueue a message displaying the player's leading animal and the attack it just used.
                    messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just used " + selectedAttack.Name);
                    //Enqueue a message displaying the attacking animal, the recieving animal, and the damage.
                    messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just attacked " + EnemyAnimals.First().Species.ToString() + "for " + damageCalculation + "damage");

                    //If the recieving animal would not survive the impending attack then continue
                    if (EnemyAnimals.First().Health <= damageCalculation)
                    {
                        //Subtract the damage from the health of the enemy.
                        EnemyAnimals.First().Health -= damageCalculation;
                        //Level up the attacker, as they have slain an enemy.
                        PlayerAnimals.First().Level += 1;
                        //If the enemy has no more animals that can fight then the player has won.
                        if (!AvailableAnimals(EnemyAnimals))
                            Status = 1;

                    }
                    //If the recieving animal would survive the impending attack then continue.
                    else
                    {
                        //Subtract the damage from the health of the enemy.
                        EnemyAnimals.First().Health -= damageCalculation;

                        //Create a random number generator to determine the move of the enemy.
                        Random rng = new Random();

                        //Store a random integer between 0 and 3 
                        int enemySelectedAttack = rng.Next(0, 3);

                        //If the enemy's attack is a DamageAttack then proceed
                        if (EnemyAnimals.First().AttackArray[enemySelectedAttack].IsDamageAttack)
                        {
                            //Cast the enemy's selected attack as a DamageAttack and save it onto the DamageAttack called enemyDamageAttack.
                            DamageAttack enemyDamageAttack = (DamageAttack)EnemyAnimals.First().AttackArray[enemySelectedAttack];

                            //Calculate the amount of damage the enemy's attack will inflict
                            int enemyDamageCalculation = (int)(enemyDamageAttack.Damage * (EnemyAnimals.First().Attack * 0.2) - PlayerAnimals.First().Defense);

                            //Enqueue the message of what move the enemy used
                            messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just used " + enemyDamageAttack.Name);
                            //Enqueue the message that the enemy animal just attacked the player's animal for the damage calculated earlier.
                            messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just attacked " + PlayerAnimals.First().Species.ToString() + "for " + enemyDamageCalculation + "damage");

                            //If the plyayer will not survive 
                            if (PlayerAnimals.First().Health <= enemyDamageCalculation)
                            {
                                PlayerAnimals.First().Health -= enemyDamageCalculation;
                                if (AvailableAnimals(PlayerAnimals))
                                    Status = 0;
                            }
                            else
                                PlayerAnimals.First().Health -= enemyDamageCalculation;
                        }
                        else
                        {
                            StatChangeAttack enemyStatAttack = (StatChangeAttack)EnemyAnimals.First().AttackArray[enemySelectedAttack];

                            if (enemyStatAttack.Effect == AttackEffect.PlayerStatBuff)
                            {
                                messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just got their" + enemyStatAttack.StatChangeValue.ToString() + "buffed for" + STAT_BUFF + " Points");
                                if (enemyStatAttack.StatChangeValue == Stat.Attack)
                                {
                                    EnemyAnimals.First().Attack += STAT_BUFF;

                                }
                                else if (enemyStatAttack.StatChangeValue == Stat.Heal)
                                {
                                    EnemyAnimals.First().Health += STAT_BUFF;

                                }
                                else if (enemyStatAttack.StatChangeValue == Stat.Defense)
                                {
                                    EnemyAnimals.First().Defense += STAT_BUFF;
                                }
                                else if (enemyStatAttack.StatChangeValue == Stat.Speed)
                                {
                                    EnemyAnimals.First().Speed += STAT_BUFF;
                                }
                            }
                            else
                            {
                                messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just got their" + enemyStatAttack.StatChangeValue.ToString() + "debuffed for" + STAT_BUFF + " Points");

                                if (enemyStatAttack.StatChangeValue == Stat.Attack)
                                {
                                    PlayerAnimals.First().Attack -= STAT_BUFF;

                                }
                                else if (enemyStatAttack.StatChangeValue == Stat.Defense)
                                {
                                    PlayerAnimals.First().Defense -= STAT_BUFF;
                                }
                                else if (enemyStatAttack.StatChangeValue == Stat.Speed)
                                {
                                    PlayerAnimals.First().Speed -= STAT_BUFF;
                                }
                            }

                        }
                    }
                }
                else
                {
                    StatChangeAttack selectedAttack = (StatChangeAttack)PlayerAnimals.First().AttackArray[selectionNumber];

                    messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just used " + selectedAttack.Name);

                    if (selectedAttack.Effect == AttackEffect.PlayerStatBuff)
                    {
                        messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just got their" + selectedAttack.StatChangeValue.ToString() + "buffed for" + STAT_BUFF + " Points");
                        if (selectedAttack.StatChangeValue == Stat.Attack)
                        {
                            PlayerAnimals.First().Attack += STAT_BUFF;
                        }
                        else if (selectedAttack.StatChangeValue == Stat.Heal)
                        {
                            PlayerAnimals.First().Health += STAT_BUFF;
                        }
                        else if (selectedAttack.StatChangeValue == Stat.Defense)
                        {
                            PlayerAnimals.First().Defense += STAT_BUFF;
                        }
                        else if (selectedAttack.StatChangeValue == Stat.Speed)
                        {
                            PlayerAnimals.First().Speed += STAT_BUFF;
                        }
                    }
                    else
                    {
                        messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just got their" + selectedAttack.StatChangeValue.ToString() + "debuffed for" + STAT_BUFF + " Points");

                        if (selectedAttack.StatChangeValue == Stat.Attack)
                        {
                            EnemyAnimals.First().Attack -= STAT_BUFF;
                        }
                        else if (selectedAttack.StatChangeValue == Stat.Defense)
                        {
                            EnemyAnimals.First().Defense -= STAT_BUFF;
                        }
                        else if (selectedAttack.StatChangeValue == Stat.Speed)
                        {
                            EnemyAnimals.First().Speed -= STAT_BUFF;
                        }
                    }


                    Random rng = new Random();

                    int enemySelectedAttack = rng.Next(0, 3);

                    if (EnemyAnimals.First().AttackArray[enemySelectedAttack].IsDamageAttack)
                    {
                        DamageAttack enemyDamageAttack = (DamageAttack)EnemyAnimals.First().AttackArray[enemySelectedAttack];

                        messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just used " + enemyDamageAttack.Name);


                        int enemyDamageCalculation = (int)(enemyDamageAttack.Damage * (EnemyAnimals.First().Attack * 0.2) - PlayerAnimals.First().Defense);

                        messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just attacked " + PlayerAnimals.First().Species.ToString() + "for " + enemyDamageCalculation + "damage");


                        if (PlayerAnimals.First().Health <= enemyDamageCalculation)
                        {
                            PlayerAnimals.First().Health -= enemyDamageCalculation;
                            messages.Enqueue(PlayerAnimals.First().Species.ToString() + " has fainted");
                            if (!AvailableAnimals(PlayerAnimals))
                                Status = 0;

                        }
                        else
                            PlayerAnimals.First().Health -= enemyDamageCalculation;
                    }
                    else
                    {
                        StatChangeAttack enemyStatAttack = (StatChangeAttack)EnemyAnimals.First().AttackArray[enemySelectedAttack];

                        if (enemyStatAttack.Effect == AttackEffect.PlayerStatBuff)
                        {
                            messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just got their" + enemyStatAttack.StatChangeValue.ToString() + "buffed for" + STAT_BUFF + " Points");

                            if (enemyStatAttack.StatChangeValue == Stat.Attack)
                            {
                                EnemyAnimals.First().Attack += STAT_BUFF;
                            }
                            else if (enemyStatAttack.StatChangeValue == Stat.Heal)
                            {
                                EnemyAnimals.First().Health += STAT_BUFF;
                            }
                            else if (enemyStatAttack.StatChangeValue == Stat.Defense)
                            {
                                EnemyAnimals.First().Defense += STAT_BUFF;
                            }
                            else if (enemyStatAttack.StatChangeValue == Stat.Speed)
                            {
                                EnemyAnimals.First().Speed += STAT_BUFF;
                            }
                        }
                        else
                        {
                            messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just got their" + enemyStatAttack.StatChangeValue.ToString() + "debuffed for" + STAT_BUFF + " Points");
                            if (enemyStatAttack.StatChangeValue == Stat.Attack)
                            {
                                PlayerAnimals.First().Attack -= STAT_BUFF;
                            }
                            else if (enemyStatAttack.StatChangeValue == Stat.Defense)
                            {
                                PlayerAnimals.First().Defense -= STAT_BUFF;
                            }
                            else if (enemyStatAttack.StatChangeValue == Stat.Speed)
                            {
                                PlayerAnimals.First().Speed -= STAT_BUFF;
                            }
                        }
                    }
                }
            }
            else
            {
                //Enemy Attack

                Random rng = new Random();

                int enemySelectedAttack = rng.Next(0, 3);

                if (EnemyAnimals.First().AttackArray[enemySelectedAttack].IsDamageAttack)
                {
                    DamageAttack enemyDamageAttack = (DamageAttack)EnemyAnimals.First().AttackArray[enemySelectedAttack];

                    messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just used " + enemyDamageAttack.Name);


                    int enemyDamageCalculation = (int)(enemyDamageAttack.Damage * (EnemyAnimals.First().Attack * 0.2) - PlayerAnimals.First().Defense);

                    messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just attacked " + PlayerAnimals.First().Species.ToString() + "for " + enemyDamageCalculation + "damage");


                    if (PlayerAnimals.First().Health <= enemyDamageCalculation)
                    {
                        messages.Enqueue(PlayerAnimals.First().Species.ToString() + " has fainted");
                        PlayerAnimals.First().Health -= enemyDamageCalculation;
                        if (!AvailableAnimals(PlayerAnimals))
                            Status = 0;

                    }
                    else
                    {
                        PlayerAnimals.First().Health -= enemyDamageCalculation;

                        if (PlayerAnimals.First().AttackArray[selectionNumber].IsDamageAttack)
                        {
                            //Player Calculation
                            DamageAttack selectedAttack = (DamageAttack)PlayerAnimals.First().AttackArray[selectionNumber];

                            int damageCalculation = (int)(selectedAttack.Damage * (PlayerAnimals.First().Attack * 0.2) - EnemyAnimals.First().Defense);

                            messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just used " + selectedAttack.Name);

                            messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just attacked " + EnemyAnimals.First().Species.ToString() + "for " + damageCalculation + "damage");

                            if (EnemyAnimals.First().Health <= damageCalculation)
                            {
                                EnemyAnimals.First().Health -= damageCalculation;
                                PlayerAnimals.First().Level += 1;
                                if (!AvailableAnimals(EnemyAnimals))
                                    Status = 1;
                            }
                            else
                                EnemyAnimals.First().Health -= damageCalculation;
                        }
                        else
                        {
                            StatChangeAttack selectedAttack = (StatChangeAttack)PlayerAnimals.First().AttackArray[selectionNumber];

                            messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just used " + selectedAttack.Name);


                            if (selectedAttack.Effect == AttackEffect.PlayerStatBuff)
                            {
                                messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just got their" + selectedAttack.StatChangeValue.ToString() + "buffed for" + STAT_BUFF + " Points");

                                if (selectedAttack.StatChangeValue == Stat.Attack)
                                {
                                    PlayerAnimals.First().Attack += STAT_BUFF;
                                }
                                else if (selectedAttack.StatChangeValue == Stat.Heal)
                                {
                                    PlayerAnimals.First().Health += STAT_BUFF;
                                }
                                else if (selectedAttack.StatChangeValue == Stat.Defense)
                                {
                                    PlayerAnimals.First().Defense += STAT_BUFF;
                                }
                                else if (selectedAttack.StatChangeValue == Stat.Speed)
                                {
                                    PlayerAnimals.First().Speed += STAT_BUFF;
                                }
                            }
                            else
                            {
                                messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just got their" + selectedAttack.StatChangeValue.ToString() + "debuffed for" + STAT_BUFF + " Points");

                                if (selectedAttack.StatChangeValue == Stat.Attack)
                                {
                                    EnemyAnimals.First().Attack -= STAT_BUFF;
                                }
                                else if (selectedAttack.StatChangeValue == Stat.Defense)
                                {
                                    EnemyAnimals.First().Defense -= STAT_BUFF;
                                }
                                else if (selectedAttack.StatChangeValue == Stat.Speed)
                                {
                                    EnemyAnimals.First().Speed -= STAT_BUFF;
                                }
                            }
                        }

                    }
                }
                else
                {
                    StatChangeAttack enemyStatAttack = (StatChangeAttack)EnemyAnimals.First().AttackArray[enemySelectedAttack];

                    messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just used " + enemyStatAttack.Name);

                    if (enemyStatAttack.Effect == AttackEffect.PlayerStatBuff)
                    {
                        messages.Enqueue(EnemyAnimals.First().Species.ToString() + "just got their" + enemyStatAttack.StatChangeValue.ToString() + "buffed for" + STAT_BUFF + " Points");

                        if (enemyStatAttack.StatChangeValue == Stat.Attack)
                        {
                            EnemyAnimals.First().Attack += STAT_BUFF;
                        }
                        else if (enemyStatAttack.StatChangeValue == Stat.Heal)
                        {
                            EnemyAnimals.First().Health += STAT_BUFF;
                        }
                        else if (enemyStatAttack.StatChangeValue == Stat.Defense)
                        {
                            EnemyAnimals.First().Defense += STAT_BUFF;
                        }
                        else if (enemyStatAttack.StatChangeValue == Stat.Speed)
                        {
                            EnemyAnimals.First().Speed += STAT_BUFF;
                        }
                    }
                    else
                    {
                        messages.Enqueue(PlayerAnimals.First().Species.ToString() + "just got their" + enemyStatAttack.StatChangeValue.ToString() + "debuffed for" + STAT_BUFF + " Points");
                        if (enemyStatAttack.StatChangeValue == Stat.Attack)
                        {
                            PlayerAnimals.First().Attack -= STAT_BUFF;
                        }
                        else if (enemyStatAttack.StatChangeValue == Stat.Defense)
                        {
                            PlayerAnimals.First().Defense -= STAT_BUFF;
                        }
                        else if (enemyStatAttack.StatChangeValue == Stat.Speed)
                        {
                            PlayerAnimals.First().Speed -= STAT_BUFF;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Switch the player's animal
        /// </summary>
        /// <param name="roster">The player's roster</param>
        /// <param name="selected">The animal that was selected</param>
        /// <returns>The updated roster</returns>
        public List<Animal> SwitchPlayerAnimal(List<Animal> roster, int selected)
        {
            // Get the current animal
            Animal current = roster.First();

            // Remove that from the roster
            roster.Remove(current);

            // Create an array to temporarily holy the remaining 2
            Animal[] tempRoster = new Animal[2];

            // Create counter
            int count = 0;

            // Put the remaining 2 animals into the array and remove from the roster,
            // roster is now empty
            foreach (Animal x in roster)
            {
                tempRoster[count] = x;
                roster.Remove(x);
                count++;
            }

            // Put the animal that was selected at the front of the new roster
            roster.Add(tempRoster[selected]);

            // Add the animal that was not selected and the animal 
            // that WAS the one in battle
            if (selected == 0)
            {
                roster.Add(tempRoster[1]);
                roster.Add(current);
            }
            else if (selected == 1)
            {
                roster.Add(tempRoster[0]);
                roster.Add(current);
            }

            // Return the update roster
            return roster;
        }

        /// Method to switch the enemy's current animal (when fainted)
        /// </summary>
        /// <param name="roster">The enemy's roster</param>
        /// <returns>The enemy's updated roster</returns>
        public List<Animal> SwitchEnemyAnimal(List<Animal> roster)
        {
            // Get the animal that fainted
            Animal fainted = roster.First();

            // How to use .First ask mershab in 2nd
            roster.Remove(fainted);

            // Create a temporary animal array
            Animal[] tempRoster1 = new Animal[2];
            int count = 0;

            // Create a temporary roster
            List<Animal> tempRoster = new List<Animal>();

            // Create foreach loop to go through the 2 backup animals
            foreach (Animal x in roster)
            {
                // Add both backup animals to the temporary animal array
                tempRoster1[count] = x;
                count++;

                // Empty out the roster
                roster.Remove(x);
            }

            // Check if the first backup animal has health
            if (tempRoster1[0].Health > 0)
            {
                // If so put it at the front, and add the other 2
                roster.Add(tempRoster1[0]);
                roster.Add(tempRoster1[1]);
                roster.Add(fainted);

                // Return the new roster
                return roster;
            }

            // Check if the second backup animal has health
            else if (tempRoster1[1].Health > 0)
            {
                // If so put it at the front, and add the other 2
                roster.Add(tempRoster1[1]);
                roster.Add(tempRoster1[0]);
                roster.Add(fainted);

                // Return the new roster
                return roster;
            }

            // If both backup animals don't have health
            else
            {
                // Put the fainted pokemon at the front (enemy lost)
                roster.Add(fainted);

                // Return new roster
                return roster;
            }
        }

        /// <summary>
        /// Method to run
        /// </summary>
        /// <returns></returns>
        public bool Run(Battle currentBattle)
        {
            // Create a random number generator
            Random numberGenerator = new Random();

            // Check if the enemy animal is wild
            if (currentBattle.IsWild == true)
            {
                // Get a random number between 1 and 2
                int getAwayChance = numberGenerator.Next(1, 3);

                // If that number is 1 (50% chance)
                if (getAwayChance == 1)
                {
                    // Display 'success' message
                    messages.Enqueue("Your escape was successful!");

                    // Return true for 'successfully escaped'
                    return true;
                }

                // If not,
                else
                {
                    // Display 'failed' message
                    messages.Enqueue("Your escape failed!");

                    // Return false for 'escape was unsuccessful'
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Use a net to attempt a catch on enemy animal
        /// </summary>
        /// <param name="net">The item that was used, net</param>
        /// <param name="enemy">The opposing animal</param>
        /// <param name="isWild">Boolean, if the animal is wild or not</param>
        /// <param name="playerRoster">The player's roster</param>
        /// <returns></returns>
        public List<Animal> UsedNet(Item net, Animal enemy, bool isWild, List<Animal> playerRoster)
        {
            // Check if the player has less than 3 animals
            if (playerRoster.Count < 3)
            {
                // Check if the animal is wild
                if (isWild == true)
                {
                    // If so, check if the player has at least 1 net
                    if (net.Quantity > 0)
                    {
                        // Create a random number generator
                        Random numberGenerator = new Random();

                        // Get a random number out of 10
                        int randomChance = numberGenerator.Next(1, 11);

                        // Check if the enemy animal's health is above 50%
                        if (enemy.Health > (enemy.MaxHealth / 2))
                        {
                            // If so, check if the number generated was less than or equal to 3 (30% chance)
                            if (randomChance <= 3)
                            {
                                // If so, the player has caught the enemy animal
                                // and it will be added to the player's roster
                                playerRoster.Add(enemy);

                                //Display success message
                                messages.Enqueue("You've successfully caught the animal!");

                                // Return the new roster
                                return playerRoster;
                            }
                        }

                        // Check if the enemy animal's health is below 50% and above 20%
                        else if (enemy.Health < (enemy.MaxHealth / 2) && enemy.Health >= (enemy.MaxHealth / 5))
                        {
                            // If so, check if the number generated was less than or equal to 5 (50% chance)
                            if (randomChance <= 5)
                            {
                                // If so, the player has caught the enemy animal
                                // and it will be added to the player's roster
                                playerRoster.Add(enemy);

                                //Display success message
                                messages.Enqueue("You've successfully caught the animal!");

                                // Return the new roster
                                return playerRoster;
                            }
                        }

                        // Check if the enemy animal's health is below 20%
                        else if (enemy.Health < (enemy.MaxHealth / 5))
                        {
                            // If so check if the number generated is less than or equal to 7 (70% chance)
                            if (randomChance <= 7)
                            {
                                // If so, the player has caught the enemy animal
                                // and it will be added to the player's roster
                                playerRoster.Add(enemy);

                                //Display success message
                                messages.Enqueue("You've successfully caught the animal!");

                                // Return the new roster
                                return playerRoster;
                            }
                        }
                        // No matter the outcome reduce the quantity of nets by 1
                        net.Quantity--;

                        return playerRoster;
                    }

                    // If the player does not have a net
                    else
                    {
                        // Display 'out of nets' message
                        messages.Enqueue("You're out of nets! Gotta buy more~");

                        // Return the roster as it is
                        return playerRoster;
                    }
                }

                // If the enemy animal is not wild
                else
                {
                    // Display 'is wild' message
                    messages.Enqueue("That animal is not wild!");

                    // Return the player's roster as it is
                    return playerRoster;
                }
            }
            // If the player has 3 animals roster is full
            else
            {
                // Display 'full roster' message
                messages.Enqueue("Your roster is full!");

                // Return the player's roster as it is
                return playerRoster;
            }
        }

        /// <summary>
        /// Increase the attack stat of the animal in battle
        /// </summary>
        /// <param name="currentAnimal">The animal currently in battle</param>
        /// <param name="atkBoost">The item that was used, attack boost</param>
        public void UsedAtkBoost(Animal currentAnimal, Item atkBoost)
        {
            //Check if the player has at least 1 attack boost
            if (atkBoost.Quantity > 0)
            {
                // If so increase the animal current in battle's attack
                // and decrease the quantity of attack boosts by 1.
                currentAnimal.Attack += atkBoost.StatNumber;
                atkBoost.Quantity--;
            }
        }
        /// <summary>
        /// Increase the defense stat of the animal in battle
        /// </summary>
        /// <param name="currentAnimal">The animal currently in battle</param>
        /// <param name="defBoost">The item that was used, defense boost</param>
        public void UsedDefBoost(Animal currentAnimal, Item defBoost)
        {
            // Check if the player has at least 1 defense boost
            if (defBoost.Quantity > 0)
            {
                // If so increase the animal currently in battle's defense 
                // and decrease the quantity of defense boosts by 1.
                currentAnimal.Defense += defBoost.StatNumber;
                defBoost.Quantity--;
            }
        }

        /// <summary>
        /// Increase the speed stat of the animal in battle
        /// </summary>
        /// <param name="currentAnimal">The animal current in battle</param>
        /// <param name="speedBoost">The item that was used, speed boost</param>
        public void UsedSpeedBoost(Animal currentAnimal, Item speedBoost)
        {
            // Check if the player has at least 1 speed boost
            if (speedBoost.Quantity > 0)
            {
                // If so increase the animal currently in battle's defense
                // and decrease the quantity of speed boosts by 1.
                currentAnimal.Speed += speedBoost.StatNumber;
                speedBoost.Quantity--;
            }
        }

        /// <summary>
        /// Increase the health stat of the animal in battle
        /// </summary>
        /// <param name="currentAnimal">The animal currently in battle</param>
        /// <param name="heal">The item that was used, heal</param>
        public void UsedHeal(Animal currentAnimal, Item heal)
        {
            // Check if the player has at least 1 heal
            if (heal.Quantity > 0)
            {
                // If so increase the animal current in battle's health
                // and decrease the quantity of heals by 1
                currentAnimal.Health += heal.StatNumber;
                heal.Quantity--;
            }
        }

        /// <summary>
        /// Increase the health stat of the animal in battle to max health
        /// </summary>
        /// <param name="currentAnimal">The animal current in battle</param>
        /// <param name="maxHeal">The item that was used, max heal</param>
        public void UsedMaxHeal(Animal currentAnimal, Item maxHeal)
        {
            // Check if the player has at least 1 max heal
            if (maxHeal.Quantity > 0)
            {
                // If so increase the animal in battle's current health to full
                // and decrease the quantity of max heals by 1
                currentAnimal.Health = currentAnimal.MaxHealth;
                maxHeal.Quantity--;
            }
        }

        /// <summary>
        /// Check what item was used, and call methods accordingly
        /// </summary>
        /// <param name="opponent">The enemy's animal</param>
        /// <param name="playerRoster">The player's roster</param>
        /// <param name="currentBattle">The battle taking place</param>
        /// <param name="inventory">The player's inventory</param>
        /// <param name="used">The item that was used</param>
        public void UsedItem(Animal opponent, List<Animal> playerRoster, Battle currentBattle, List<Item> inventory, Item used)
        {
            // Get the animal currently in battle 
            Animal currentAnimal = playerRoster.First<Animal>();

            // Check if the player's inventory has the item that was used
            if (inventory.Contains(used))
            {
                // If so, check if the item affects the attack stat
                if (used.StatEffect == Stat.Attack)
                {
                    // If so, pass in the animal in battle, and the item used
                    UsedAtkBoost(currentAnimal, used);
                }

                // If so, check if the item affects the defense stat
                else if (used.StatEffect == Stat.Defense)
                {
                    // If so, pass in the animal in battle, and the item used
                    UsedDefBoost(currentAnimal, used);
                }

                // If so, check if the item affects the speed stat
                else if (used.StatEffect == Stat.Speed)
                {
                    // If so, pass in the animal in battle, and the item used
                    UsedSpeedBoost(currentAnimal, used);
                }

                // If so, check if the item affects the health stat
                else if (used.StatEffect == Stat.Heal)
                {
                    // If so, pass in the animal in battle, and the item used
                    UsedHeal(currentAnimal, used);
                }

                // If so, check if the item increases the health stat to full
                else if (used.StatEffect == Stat.MaxHeal)
                {
                    // If so, pass in the animal in battle, and the item used
                    UsedMaxHeal(currentAnimal, used);
                }

                // If so, check if the item is used to catch animals
                else if (used.StatEffect == Stat.Catch)
                {
                    // If so, pass in the animal in battle, and the item used
                    UsedNet(used, opponent, currentBattle.IsWild, playerRoster);
                }
            }
        }
    }
}