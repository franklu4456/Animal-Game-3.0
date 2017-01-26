/*
 * Megan Hong
 * Player class: Creates a new player with the necessary information
 * controlst he player's movements and facing direction
 * 1/24/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalGame
{
    class Player
    {
        //variables store the information of the player
        private int _row;
        private int _column;
        private bool _inBattle = false;
        private int _money;
        private Direction _facingDirection;
        private List<Animal> _roster;
        private List<Item> _items;
        private int _level;

        //gets if the player is in battle
        //sets if the player is in battle
        public bool InBattle
        {
            get
            {
                return _inBattle;
            }
            set
            {
                _inBattle = value;
            }
        }
        //states if the 
        public Player(List<Item>setUpItems)
        {
            _money = 1000;
            _level = 1;
            _facingDirection = Direction.Down;
            _items = setUpItems;
        }
        public Player(List<Animal>animalList)
            :this (0,animalList,null,0)
        {

        }

        public Player(int money, List<Animal> animalList, List<Item> item, int level)
        {
            _facingDirection = Direction.Up;
            _money = money;
            _roster = animalList;
            _items = item;
            _level = level;
        }

        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }

        public List<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
 
        }

        public List<Animal> Roster
        {
            get
            {
                
                return _roster;
            }
            set
            {
                _roster = value;
            }
        }

        public int Row
        {
            get
            {
                return _row;
            }
        }

        public int Column
        {
            get
            {
                return _column;
            }
        }

        public int Money
        {
            get
            
            {
                if (_money < 0)
                {
                    _money = 0;
                }
                return _money;
            }
            set
            {
                _money = value;
            }
        }

        public Direction FacingDirection
        {
            get
            {
                return _facingDirection;
            }
        }

        public bool Move(MapTile tile)
        {
            if (tile != MapTile.Wall && tile != MapTile.Enemy && tile != MapTile.Shop && tile != MapTile.HealStn && tile != MapTile.Animal&&tile!=MapTile.CantWalk)
            {
                if (_facingDirection == Direction.Up)
                {
                    _row--;
                }
                else if (_facingDirection == Direction.Down)
                {
                    _row++;
                }
                else if (_facingDirection == Direction.Right)
                {
                    _column++;
                }
                else if (_facingDirection == Direction.Left)
                {
                    _column--;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // Missed rotate left and right?
        public void RotateLeft()
        {
            if (_facingDirection == Direction.Up)
            {
                _facingDirection = Direction.Left;
            }
            else if (_facingDirection == Direction.Down)
            {
                _facingDirection = Direction.Right;
            }
            else if (_facingDirection == Direction.Right)
            {
                _facingDirection = Direction.Up;
            }
            else if (_facingDirection == Direction.Left)
            {
                _facingDirection = Direction.Down;
            }
        }

        public void RotateRight()
        {
            if (_facingDirection == Direction.Up)
            {
                _facingDirection = Direction.Right;
            }
            else if (_facingDirection == Direction.Down)
            {
                _facingDirection = Direction.Left;
            }
            else if (_facingDirection == Direction.Right)
            {
                _facingDirection = Direction.Down;
            }
            else if (_facingDirection == Direction.Left)
            {
                _facingDirection = Direction.Up;
            }
        }
    }
}
