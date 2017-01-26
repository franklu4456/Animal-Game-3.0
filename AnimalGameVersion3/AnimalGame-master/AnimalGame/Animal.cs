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
        protected int _maxHealth;
        protected int _currentHealth;
        protected int _attack;
        protected int _defense;
        protected int _speed;
        protected int _level;
        protected Type _species;
        protected bool _hasEvolved;

        protected Attack[] _attackArray = new Attack[3];


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
        public bool CanAnimalEvolve
        {
            get
            {
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
        public bool IsEvolved
        {
            get
            {
                if (_level >= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Type Species
        {
            get
            {
                return _species;
            }
        }

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
        
        public int Health
        {
            get
            {
                if (_currentHealth > MaxHealth)
                {
                    _currentHealth = MaxHealth;
                }
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return Level * _maxHealth;
            }

        }

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

        public bool HasFainted
        {
            get
            {
                if (Health <= 0)
                {
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
