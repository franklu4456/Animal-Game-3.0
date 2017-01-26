/*
 * Megan Hong
 * Animal Class: creates a new animal with the needed information
 * holds their attacks, if they've evolved and their species
 * 1/24/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalGame
{
    class Animal
    {
        //protected variables
        //hold the animal's information
        protected int _maxHealth;
        protected int _currentHealth;
        protected int _attack;
        protected int _defense;
        protected int _speed;
        protected int _level;
        protected Type _species;
        protected bool _hasEvolved;
        //array stores all of the animal's attacks
        //3 attacks per animal
        protected Attack[] _attackArray = new Attack[3];

        //Creates a new animal
        //takes in all the information to create a new animal
        public Animal(int maxHealth, int attack, int defense, int speed, Type species, int level,Attack attack1, Attack attack2, Attack attack3)
        {
            //stores all the information into the proper variables
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _attack = attack;
            _defense = defense;
            _speed = speed;
            _level = level;
            _species = species;
            //stores al three attacks in the attack array
            _attackArray[0] = attack1;
            _attackArray[1] = attack2;
            _attackArray[2] = attack3;
            //state that the animal hasn't evolved
            _hasEvolved = false;
        }
        //get if the animal can evovle or not
        public bool CanAnimalEvolve
        {
            get
            {
                //check if the animal is at level 3 and hasn't evolved yet
                if (Level == 3 && IsEvolved == false)
                {
                    _hasEvolved = true;
                    //return that the animal can evolve
                    return true;
                }
                else
                {
                    _hasEvolved = false;
                    //return that the animal can't
                    return false;
                }
            }
        }
        //get if the animal has evolved or not
        public bool IsEvolved
        {
            get
            {
                //check if the animal is greater than level 3
                if (_level > 3||_hasEvolved==true)
                {
                    //state that the animal has evolved
                    return true;
                }
                else
                {
                    //state that the animal hasn't evolved
                    return false;
                }
            }
        }

        //return the species of the animal
        public Type Species
        {
            get
            {
                return _species;
            }
        }

        //get the level of the animal
        public int Level
        {
            set
            {
                _level = value;
            }
            get
            {
                return _level;
            }
        }
        
        //gets the animal's health
        //sets the animal's health
        public int Health
        {
            get
            {
                //checks if the current health is above the maximum
                if (_currentHealth > MaxHealth)
                {
                    //makes them equal
                    _currentHealth = MaxHealth;
                }
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
            }
        }
        //gets the maximum health of the animal 
        public int MaxHealth
        {
            get
            {
                //returns a maximum health relative to the animal's level
                return Level * _maxHealth;
            }

        }
        //gets and gets the amount of attack for the animal
        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
            }
        }
        //gets and gets the amount of defense for the animal
        public int Defense
        {
            get
            {
                return _defense;
            }
            set
            {
                _defense = value;
            }
        }

        //gets and sets the speed of the animal
        public int Speed
        {
            get
            {

                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        //gets the attack array of the animal
        //sets the attack array for the animal
        public Attack[] AttackArray
        {
            get
            {
                return _attackArray;
            }
            set
            {
                _attackArray = value;
            }
        }

        //states if the animal has fainted or not
        public bool HasFainted
        {
            get
            {
                //checks if the health is below or equal to 0
                if (Health <= 0)
                {
                    //states that the animal has fainted
                    return true;
                }
                else
                {
                    //states that the animal hasn't fainted
                    return false;
                }
            }
        }

        
    }

    
}
