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
        //variable stores the information for the animal
        protected int _maxHealth;
        protected int _currentHealth;
        protected int _attack;
        protected int _defense;
        protected int _speed;
        protected int _level;
        protected Type _species;
        protected bool _hasEvolved;
        //array stores all the attacks for every single animal
        protected Attack[] _attackArray = new Attack[3];

        //constructor to create the new animal
        //declares the private variables for each of 
        //the private variables
        public Animal(int maxHealth, int attack, int defense, int speed, Type species, int level,Attack attack1, Attack attack2, Attack attack3)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _attack = attack;
            _defense = defense;
            _speed = speed;
            _level = level;
            _species = species;
            _attackArray[0] = attack1;
            _attackArray[1] = attack2;
            _attackArray[2] = attack3;
            _hasEvolved = false;
        }
        //returns if the animal can evolve
        public bool CanAnimalEvolve
        {
            get
            {
                //icheck if the animal's level is 3 and the animal isn't evolved yet
                if (Level == 3 && IsEvolved == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //state if the animal has evolved yet
        public bool IsEvolved
        {
            get
            {
                //check if the player is greater than level 3
                if (_level >= 3)
                {
                    //if true, state that the animal has evolved
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //return the type of species that the animal is
        public Type Species
        {
            get
            {
                return _species;
            }
        }

        //return the level that the animal is at
        public int Level
        {
            //be able to set the animal's level 
            //after it wins a battle
            set
            {
                _level = value;
            }
            get
            {
                return _level;
            }
        }
        
        //return the current health of the animal
        public int Health
        {
            get
            {
                //check if the health is greater than the max health
                if (_currentHealth > MaxHealth)
                {
                    // if true, ake the current health of the animal
                    //it's max health
                    _currentHealth = MaxHealth;
                }
                //check if the current health is less than 0
                //state that the health is zero
                else if (_currentHealth < 0)
                {
                    _currentHealth = 0;
                }
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
            }
        }

        //return the maximum health of the player
        public int MaxHealth
        {
            //state that the maximum health is relative to level
            get
            {
                return Level * _maxHealth;
            }

        }

        //return the max amount of attack that the
        //animal has
        public int Attack
        {
            get
            {
                return _attack;
            }
            //set the animal's attack value,
            //through the use of items, etc.
            set
            {
                _attack = value;
            }
        }

        //return  and set the maximum 
        //amount of defense of the animal
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

        //return and set the animal's speed
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

        //returns and sets the array
        //the animal's attacks 
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

        //returns if the animal has 
        //fainted or not
        public bool HasFainted
        {
            get
            {
                //gets if the animal's health is below 
                //or at zero
                if (Health <= 0)
                {
                    //state that the player has fainted
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        
    }

    
}
