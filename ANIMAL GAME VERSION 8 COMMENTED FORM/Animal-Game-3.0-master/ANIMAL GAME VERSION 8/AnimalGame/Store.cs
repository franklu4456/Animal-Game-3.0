using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalGame
{
    class Store
    {
        private bool _itemWasPurchased;

        public List <Item> SetupShop()
        {
            Item atkBuff = new Item("Attack Buff", 5, 1, Stat.Attack, 100);
            Item defBuff = new Item("Defense Buff", 5, 1, Stat.Defense, 60);
            Item speedBuff = new Item("Speed Buff", 2, 1, Stat.Speed, 40);
            Item heal = new Item("Heal", 30, 1, Stat.Heal, 100);
            Item maxHeal = new Item("Max Heal", 1000, 1, Stat.MaxHeal, 300);
            Item net = new Item("Net", 1, 1, Stat.Catch, 100);

            List<Item> availableItems = new List<Item> { atkBuff, defBuff, speedBuff, heal, maxHeal, net };
            return availableItems;
        }

        public void PurchaseItem(List<Item> playerList, Item shopItem, Player player1)
        {
            if (player1.Money >= shopItem.Price)
            {
                player1.Money = player1.Money - shopItem.Price;
                _itemWasPurchased = true;
                foreach (Item x in playerList)
                {
                    if (x.Name == shopItem.Name)
                    {
                        x.Quantity++;
                    }
                }
            }
            else
            {
                _itemWasPurchased = false;
            }
        }

        public bool ItemWasPurchased
        {
            get
            {
                return _itemWasPurchased;
            }
        }
    }
}