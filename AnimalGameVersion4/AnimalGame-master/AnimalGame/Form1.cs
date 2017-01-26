/*
 * Megan Hong and Frank Lu
 * 1/24/2017
 * Form: Controls all the external commands to the game and displays everything
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnimalGame
{

    public partial class Form1 : Form
    {
        //variables store the
        //creation of classes
        //creates the world
        World theWorld;
        //variabels stores the created player
        Player player;
        //variable stores the created battle
        Battle battle;
        //stores the created store class
        Store worldStore = new Store();

        //variable declares if the player can move
        bool canPlayerMove = true;
        //stores if any window is open
        bool windowOpen = false;
        //stores is a menu panel is open
        bool menuOpen = false;

        const int TILE_HEIGHT = 40;
        const int TILE_WIDTH = 40;

        const int SPRITE_SIZE = 100;

        const string IMAGE_PATH = "/Pictures/";

        public Form1()
        {
            InitializeComponent();
            //creates a player
            player = new Player(worldStore.SetupShop());
            //creates the world, through passing in the player
            theWorld = new World(ref player);
            //hides all the panels in the start of the game
            HideAllPanels();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check if the player can move or if the option menu is open
            if (canPlayerMove == true || menuOpen == true)
            {
                //if the player is allowed to move
                //allow the character to move when pressing arrow keys,
                //or interact with tiles
                if (canPlayerMove == true)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        //move forward
                        theWorld.Move(player);
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        //rotate left
                        player.RotateLeft();
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        //rotate right
                        player.RotateRight();
                    }
                    else if (e.KeyCode == Keys.F)
                    {
                        //interact with a tile
                        Interact();
                    }
                }
                // if the menu is open or the player can move
                //allow the player to pick options from the menu
                if (canPlayerMove == true || menuOpen == true)
                {
                    if (e.KeyCode == Keys.O)
                    {
                        if (pnlInventory.Visible == false)
                        {
                            canPlayerMove = false;
                            //makes the open inventory panel visible
                            pnlInventory.Visible = true;

                            //state that the player can't walk
                            canPlayerMove = false;
                            //states that a window is open
                            windowOpen = true;

                            //make the menu panel open
                            pnlMenu.Visible = false;
                            //call the subprogram that displays the inventory
                            OpenInventory();
                        }
                    }
                    else if (e.KeyCode == Keys.S)
                    {
                        //save the game
                        theWorld.SaveGame(player);
                    }
                    else if (e.KeyCode == Keys.L)
                    {
                        Player tempPlayer = theWorld.LoadGame();
                        //call the subprogram to load a new game
                        theWorld = new World(ref tempPlayer);

                    }
                    else if (e.KeyCode == Keys.A)
                    {
                        if (pnlInventory.Visible == false)
                        {
                            canPlayerMove = false;
                            //state that the player can no longer move
                            canPlayerMove = false;
                            //state that a window is open
                            windowOpen = true;
                            //open the list of animals
                            //display the animal list panel
                            pnlInventory.Visible = true;
                            //make the menu panel invisible if it already isn't 
                            pnlMenu.Visible = false;
                            //show the player's animal
                            ShowAnimals();
                        }
                    }
                    else if (e.KeyCode == Keys.I)
                    {
                        canPlayerMove = false;
                        //state that the menu is now open
                        menuOpen = true;
                        //state that the player can't move
                        canPlayerMove = false;
                        //state that a window is open
                        windowOpen = true;
                        //call the subprogram to open the window
                        OpenMenu();
                    }
                }
            }
            //check if the store panels is visible
            if (pnlStore.Visible == true)
            {
                canPlayerMove = false;
                //create a temporary item to store the item to be bought
                Item temp = null;
                //if the player presses "1"
                //allow the character to purchase attack boost
                if (e.KeyCode == Keys.D1)
                {
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.Attack)
                        {
                            temp = x;
                        }
                    }
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        lblPurchased.Text = "Attack buff was purchased";
                    }
                    else
                    {
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                //store the items information intot he temporary item
                //for purchase
                else if (e.KeyCode == Keys.D2)
                {
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.Defense)
                        {
                            temp = x;
                        }
                    }
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        lblPurchased.Text = "Defense buff was purchased";
                    }
                    else
                    {
                        lblPurchased.Text = "Player doesn't have enough money to purchase" ;
                    }
                }

                else if (e.KeyCode == Keys.D3)
                {
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.Speed)
                        {
                            temp = x;
                        }
                    }
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        lblPurchased.Text = "Speed buff was purchased";
                    }
                    else
                    {
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                else if (e.KeyCode == Keys.D4)
                {
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.Heal)
                        {
                            temp = x;
                        }
                    }
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        lblPurchased.Text = "Heal item was purchased";
                    }
                    else
                    {
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                else if (e.KeyCode == Keys.D5)
                {
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.MaxHeal)
                        {
                            temp = x;
                        }
                    }
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        lblPurchased.Text = "Max heal item was purchased";
                    }
                    else
                    {
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                else if (e.KeyCode == Keys.D6)
                {
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.Catch)
                        {
                            temp = x;
                        }
                    }
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        lblPurchased.Text = "Net was purchased";
                    }
                    else
                    {
                        lblPurchased.Text = "Player doesn't have enough money to purchase ";
                    }
                }
                lblPlayerMoney.Text = "Money: $" + player.Money.ToString();
            }
            if (player.InBattle == true && canPlayerMove == false)
            {
                //FINISH
                if (battle.Status !=2)
                {
                    if (e.KeyCode == Keys.Q)
                    {
                        //allows the player to pick attack 1 when in battle
                        battle.Fight(1);

                        pnlResults.Visible = true;
                        player.InBattle = false;
                        DisplayResults();

                    }
                    else if (e.KeyCode == Keys.W)
                    {
                        //allows the player to pick attack 2 in battle
                        battle.Fight(2);
                        DisplayResults();
                    }

                    else if (e.KeyCode == Keys.E)
                    {
                        //allows the player to pick attack 3 in battle
                        battle.Fight(3);
                        DisplayResults();
                    }
                }
            }
            //FINISH ALL THE PANELS
            if (e.KeyCode == Keys.Escape)
            {
                //close the current window 
                //check if there is a window currenty open
                if (windowOpen == true && player.InBattle == false)
                {
                    //hide all the panels
                    HideAllPanels();
                    canPlayerMove = true;
                }

                else if (windowOpen == true && battle.Status != 2)
                {
                    HideAllPanels();
                }
            }

            Refresh();
        }

        public void DisplayResults()
        {
            //SHIT THING
            //problem
            if (battle.Status != 3)
            {
                pnlResults.Visible = true;
                player.InBattle = false;
                if (battle.Status == 1)
                {
                    lblBattleResults.Text = "WIN! \r\n Press ESC to exit the screen.";
                }
                else
                {
                    lblBattleResults.Text = "LOSE \r\n Press ESC to exit the screen.";
                }
            }
        }
        public void PanelSizing()
        {

            pnlMenu.Width = (ClientSize.Width / 4);
            pnlMenu.Height = ClientSize.Height;

            pnlInventory.Width = (ClientSize.Width / 4);
            pnlInventory.Height = ClientSize.Height;
            txtInventoryListOutGame.Width = pnlInventory.Width;
            txtInventoryListOutGame.Height = (pnlInventory.Height / 6) - pnlInventory.Height;

            pnlStore.Width = (ClientSize.Height / 4);
            pnlStore.Height = ClientSize.Height;
            txtStoreList.Width = (ClientSize.Width / 6) - ClientSize.Width;

            pnlResults.Width = ClientSize.Width;
            pnlResults.Height = ClientSize.Height;
            lblBattleResults.Width = ClientSize.Width / 2;


        }
        /// <summary>
        /// subprogram to hide all the panels in the game
        /// </summary>
        public void HideAllPanels()
        {
            pnlBattleOptions.Visible = false;

            pnlInventory.Visible = false;
            pnlMenu.Visible = false;
            pnlStore.Visible = false;
            pnlResults.Visible = false;
            txtStoreList.Visible = false;

            pnlBattleInv.Visible = false;
            pnlAttacks.Visible = false;
            pnlAnimals.Visible = false;
            pnlInterface.Visible = false;
            lblNotification.Visible = false;

            txtInventoryListOutGame.Text = "";
            txtStoreList.Text = "";
            lblPurchased.Text = "";
        }

        /// <summary>
        /// Shows the player's animals
        /// </summary>
        public void ShowAnimals()
        {
            pnlInventory.Visible = true;
            lblInventoryTitle.Text = "Animal List: ";
            txtInventoryListOutGame.Visible = true;
            //loop through the player's animal list
            foreach (Animal x in player.Roster)
            {
                //temporary string to hold the information that was in the label
                string temp = null;
                //store the information that's currently displayed on the textbox into a strong
                temp = txtInventoryListOutGame.Text;
                //add the additional animal information to the text box and display it
                txtInventoryListOutGame.Text = temp + "\r\n" + "Species: " + x.Species.ToString() + "\r\n" + "Level: " + x.Level.ToString() + "\r\n" + "Speed: " + x.Speed.ToString() + "\r\n" + "Attack: " + x.Attack.ToString() + "\r\n" + "Defense: " + x.Defense.ToString() + "\r\n" + "Health: " + x.Health.ToString() + "/" + x.MaxHealth.ToString() + "\r\n";
            }
        }

        public void OpenMenu()
        {
            pnlMenu.Visible = true;
            lblMenuOptions.Visible = true;
            lblMenuTitle.Visible = true;
            lblMenuOptions.Text = "Open Inventory:  Press O" + "\r\n" + "View Animals: Press A" + "\r\n" + "Save Game: Press S" + "\r\n" + "Load Game: Press L" + "\r\n" + "Exit Menu: Press esc";
        }

        public void OpenInventory()
        {
            lblInventoryTitle.Text = "Inventory:";
            lblInventoryTitle.Visible = true;
            txtInventoryListOutGame.Visible = true;
            pnlInventory.Visible = true;
            if (player.Items.Count() > 0)
            {
                foreach (Item x in player.Items)
                {
                    string temp = null;
                    temp = txtInventoryListOutGame.Text;
                    string tempDescription;

                    if (x.StatEffect == Stat.Attack)
                    {
                        tempDescription = "Increases Attack: " + x.StatNumber.ToString();
                    }
                    else if (x.StatEffect == Stat.Defense)
                    {
                        tempDescription = "Increases Defense: " + x.StatNumber.ToString();
                    }
                    else if (x.StatEffect == Stat.Speed)
                    {
                        tempDescription = "Increases Speed: " + x.StatNumber.ToString();
                    }
                    else if (x.StatEffect == Stat.Heal)
                    {
                        tempDescription = "Increases Health: " + x.StatNumber.ToString();
                    }
                    else if (x.StatEffect == Stat.Catch)
                    {
                        tempDescription = "Catches wild animals";
                    }
                    else
                    {
                        tempDescription = "Brings the animal to max health";
                    }
                    txtInventoryListOutGame.Text = temp + x.Name + ":" + "\r\n" + tempDescription + "\r\n" + "Quantity: " + x.Quantity.ToString() + "\r\n";
                }
            }
            else
            {
                txtInventoryListOutGame.Text = "Inventory is empty";
            }
        }

        /// <summary>
        /// open the list and display the information for each item
        /// to be purchased on the list
        /// </summary>
        public void OpenStore()
        {
            if (pnlStore.Visible == false)
            {
                pnlStore.Visible = true;
                txtStoreList.Visible = true;
                lblShopTitle.Visible = true;

                //temporary string to store the information that was displayed by the label
                string temp = null;
                //loop through all the items in the world
                foreach (Item x in worldStore.SetupShop())
                {
                    temp = txtStoreList.Text;
                    //stores the description for the item
                    string tempDescription;
                    //stores the keys that correspond with the item
                    string tempKeys;

                    //check the types of items on the item list
                    //set the proper information for the description and the keys to press to purchase
                    if (x.StatEffect == Stat.Attack)
                    {
                        tempDescription = "Increases Attack: " + x.StatNumber.ToString();
                        tempKeys = "Press '1' to purchase";
                    }
                    else if (x.StatEffect == Stat.Defense)
                    {
                        tempDescription = "Increases Defense: " + x.StatNumber.ToString();
                        tempKeys = "Press '2' to purchase";
                    }
                    else if (x.StatEffect == Stat.Speed)
                    {
                        tempDescription = "Increases Speed: " + x.StatNumber.ToString();
                        tempKeys = "Press '3' to purchase";
                    }
                    else if (x.StatEffect == Stat.Heal)
                    {
                        tempDescription = "Increases Health: " + x.StatNumber.ToString();
                        tempKeys = "Press '4' to purchase";
                    }
                    else if (x.StatEffect == Stat.MaxHeal)
                    {
                        tempDescription = "Brings the animal to max health";
                        tempKeys = "Press '5' to purchase";
                    }
                    else
                    {
                        tempDescription = "Catches wild animals";
                        tempKeys = "Press '6' to purchase";
                    }

                    //display the information for the item on the store list label
                    txtStoreList.Text = temp + x.Name + ":" + "\r\n" + tempDescription + "\r\n"  + tempKeys + "\r\n"+x.Price.ToString()+"\r\n";
                }
            }
        }

        public void Interact()
        {
            if (theWorld.TileInFront(player) == MapTile.Enemy)
            {
                pnlInterface.Visible = true;
                canPlayerMove = false;
                //state that the player is in battle
                player.InBattle = true;
                //battle panel needs to be made
                Random numberGenerator = new Random();
                int number = numberGenerator.Next(0, theWorld.EnemyPlayerList().Length);
                Player enemy = theWorld.EnemyPlayerList()[number];
                battle = new Battle(player.Roster, enemy.Roster, player.Items, false);
            }
            else if (theWorld.TileInFront(player) == MapTile.Shop)
            {
                canPlayerMove = false;
                windowOpen = true;
                OpenStore();

            }
            else if (theWorld.TileInFront(player) == MapTile.HealStn)
            {
                windowOpen = true;
                canPlayerMove = false;
                //loop through all the animal's in the player list
                foreach (Animal x in player.Roster)
                {
                    //bring their current health to their max health
                    x.Health = x.MaxHealth;
                }
                lblNotification.Visible = true;
                lblNotification.Text = "All of the animals were healed!";

            }
            else if (theWorld.TileInFront(player) == MapTile.Animal)
            {
                pnlInterface.Visible = true;
                //state that the player is in battle
                player.InBattle = true;
                //generate a random number to decide which animal the player will battle
                Random numberGenerator = new Random();
                int number = numberGenerator.Next(0, theWorld.SetAnimalStuff().Length - 1);
                //temporary array to store the wild animal that they'll be batteling
                List<Animal> tempWildAnimal = new List<Animal>();
                //add the randomly selected wild number to the list of wild animals
                tempWildAnimal.Add(theWorld.SetAnimalStuff()[number]);

                //set a battle for the wild animal
                battle = new Battle(player.Roster, tempWildAnimal, player.Items, true);
            }
        }

        //FRANK
        // Button to display all of the current animal's attacks 
        private void btnFight_Click(object sender, EventArgs e)
        {

            // Set the x location of the fight panel
            int attacksInterfaceX = pnlAttacks.Location.X;
            attacksInterfaceX = ClientSize.Width - pnlAttacks.Width;
            // Set the y location of the fight panel
            int attacksInterfaceY = pnlAttacks.Location.Y;
            attacksInterfaceY = ClientSize.Height - pnlAttacks.Height;

            // Get the current animal in battle
            Animal current = player.Roster.First();

            // Display its first attack in the first label
            lblAttack1.Text = current.AttackArray[0].ToString();

            // Display its second attack in the second label
            lblAttack2.Text = current.AttackArray[1].ToString();

            // Display its thrid attack in the third label
            lblAttack3.Text = current.AttackArray[2].ToString();

            // Make the attacks appear
            pnlAttacks.Visible = true;
        }

        // Button to make the inventory appear in battle
        private void btnInv_Click(object sender, EventArgs e)
        {
            // Set the x location of the inventory in battle
            int battleInventoryX = pnlInventory.Location.X;
            battleInventoryX = ClientSize.Width - pnlInventory.Width;
            // Set the y location of the inventory in battle
            int battleInventoryY = pnlInventory.Location.Y;
            battleInventoryY = ClientSize.Height - pnlInventory.Height;


            // Go through the player's inventory
            foreach (Item x in player.Items)
            {
                // If the item is an attack boost display in first label
                if (x.StatEffect == Stat.Attack)
                {
                    // and display item name, short description, and quantity
                    lblItem1.Text = x.Name + " Increases attack by: " + x.StatNumber + " #" + x.Quantity;
                }

                // If the item is a defense boost display in second label
                else if (x.StatEffect == Stat.Defense)
                {
                    // and display item name, short description, and quantity
                    lblItem2.Text = x.Name + " Increases defense by: " + x.StatNumber + " #" + x.Quantity;
                }

                // If the item is a speed boost display in third label
                else if (x.StatEffect == Stat.Speed)
                {
                    // and display item name, short description, and quantity
                    lblItem3.Text = x.Name + " Increases speed by: " + x.StatNumber + " #" + x.Quantity;
                }

                // If the item is a heal display in fourth label
                else if (x.StatEffect == Stat.Heal)
                {
                    // display item name, short description, and quantity
                    lblItem4.Text = x.Name + " Heals animal by: " + x.StatNumber + " #" + x.Quantity;
                }

                // If the item is a max heal display in fifth label
                else if (x.StatEffect == Stat.MaxHeal)
                {
                    // display item name, short description, and quantity
                    lblItem5.Text = x.Name + " Heals animal to full." + " #" + x.Quantity;
                }

                // If the item is a net display in sixth label
                else if (x.StatEffect == Stat.Catch)
                {
                    // display item name, short description, and quantity
                    lblItem6.Text = x.Name + " Catches animals." + " #" + x.Quantity;
                }
            }
        }

        // Button to open switching animals interface in battle
        private void btnAnimal_Click(object sender, EventArgs e)
        {
            // Set the x location of the switch animals panel
            int animalsPanelX = pnlAnimals.Location.X;
            animalsPanelX = ClientSize.Width - pnlAnimals.Width;
            // Set the y location of the switch animals panel
            int animalsPanelY = pnlAnimals.Location.Y;
            animalsPanelY = ClientSize.Height - pnlAnimals.Height;

            // Create an Animal array for player's roster
            Animal[] tempRoster = new Animal[3];

            // Create counter
            int count = 0;

            // Copy all animals in roster to the Animal array
            foreach (Animal x in player.Roster)
            {
                tempRoster[count] = x;
            }

            // Display each of the Animals' species, health out of max health, attack, defense and speed stats
            lblAnimal1.Text = tempRoster[0].Species.ToString() + " | " + tempRoster[0].Health.ToString() + "/" + tempRoster[0].MaxHealth.ToString() + " | " + tempRoster[0].Attack.ToString() + " | " + tempRoster[0].Defense.ToString() + " | " + tempRoster[0].Speed.ToString();

            lblAnimal1.Text = tempRoster[1].Species.ToString() + " | " + tempRoster[1].Health.ToString() + "/" + tempRoster[1].MaxHealth.ToString() + " | " + tempRoster[1].Attack.ToString() + " | " + tempRoster[1].Defense.ToString() + " | " + tempRoster[1].Speed.ToString();

            lblAnimal1.Text = tempRoster[2].Species.ToString() + " | " + tempRoster[2].Health.ToString() + "/" + tempRoster[2].MaxHealth.ToString() + " | " + tempRoster[2].Attack.ToString() + " | " + tempRoster[2].Defense.ToString() + " | " + tempRoster[2].Speed.ToString();

            // Make the Animal switching panel visible
            pnlAnimals.Visible = true;
        }

        // Button to attempt escape from a wild animal
        private void btnRun_Click(object sender, EventArgs e)
        {
            battle.Run(battle);
        }

        // Button to hide the animal roster panel,
        // returning to the battle interface
        private void btnExitAnimals_Click(object sender, EventArgs e)
        {
            pnlAnimals.Visible = false;
        }

        // Button to switch to backup animal 1
        private void btnSwitch1_Click(object sender, EventArgs e)
        {
            battle.SwitchPlayerAnimal(player.Roster, 0);
        }

        // Button to switch to backup animal 2
        private void btnSwitch2_Click(object sender, EventArgs e)
        {
            battle.SwitchPlayerAnimal(player.Roster, 1);
        }

        // Button to hide the inventory in battle,
        // returning to the battle interface
        private void btnExitBInv_Click(object sender, EventArgs e)
        {
            pnlBattleInv.Visible = false;
        }

        // Use an attack boost 
        private void btnUseItem1_Click(object sender, EventArgs e)
        {
            // Create an empty item
            Item used = null;

            // Search through the inventory
            foreach (Item x in player.Items)
            {
                // WHen the attack boost is found
                if (x.StatEffect == Stat.Attack)
                {
                    // Assign values to the empty item
                    used = x;
                }
            }
            // Use attack boost, passing in the current animal in battle and item used
            battle.UsedAtkBoost(player.Roster.First(), used);
            used.Quantity--;
        }

        // Use a defense boost 
        private void btnUseItem2_Click(object sender, EventArgs e)
        {
            // Create an empty item
            Item used = null;

            // Search through the inventory
            foreach (Item x in player.Items)
            {
                // When the defense boost is found
                if (x.StatEffect == Stat.Defense)
                {
                    // Assign values to the empty item
                    used = x;
                }
            }
            // Use defense boost, passing in the animal in battle and the item used
            battle.UsedDefBoost(player.Roster.First(), used);
            used.Quantity--;
        }

        // Use a speed boost
        private void btnUseItem3_Click(object sender, EventArgs e)
        {
            // Create an empty item
            Item used = null;

            // Search through the inventory
            foreach (Item x in player.Items)
            {
                // When the speed boost is found
                if (x.StatEffect == Stat.Speed)
                {
                    // Assign values to the empty item
                    used = x;
                }
            }
            // Use a speed boost, passing in the animal currently in battle and the item used
            battle.UsedSpeedBoost(player.Roster.First(), used);
            used.Quantity--;
        }

        // Button to use a heal
        private void btnUsedItem4_Click(object sender, EventArgs e)
        {
            // Create an empty item
            Item used = null;

            // Search through the inventory
            foreach (Item x in player.Items)
            {
                // When heal is found
                if (x.StatEffect == Stat.Heal)
                {
                    // Assign values to the empty item
                    used = x;
                }
            }
            // Use a heal, passing in the animal currently in battle and the item used
            battle.UsedHeal(player.Roster.First(), used);
            used.Quantity--;
        }

        // Button to use Max Heal
        private void btnUsedItem5_Click(object sender, EventArgs e)
        {
            // Create an empty item
            Item used = null;

            // Search through the inventory
            foreach (Item x in player.Items)
            {
                // WHen the max heal is found
                if (x.StatEffect == Stat.MaxHeal)
                {
                    // Assign values to the empty item
                    used = x;
                }
            }
            // Use a max heal, passing in the animal currently in battle, and the item used
            battle.UsedMaxHeal(player.Roster.First(), used);
            used.Quantity--;
        }

        // Button to use Net
        private void btnUsedItem6_Click(object sender, EventArgs e)
        {
            //Create an empty item
            Item used = null;

            //Search through the players inventory
            foreach (Item x in player.Items)
            {
                // When the net (Has stat of catch) is found
                if (x.StatEffect == Stat.Catch)
                {
                    // Assign values to the empty item
                    used = x;
                }
            }
            // Use a net, passing in the item used, the enemy animal, if the animal is wild and the player's roster
            battle.UsedNet(used, battle.EnemyAnimals.First(), battle.IsWild, player.Roster);
            used.Quantity--;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            int xLocation = 0;
            int yLocation = 0;


            if (!player.InBattle)
            {
                for (int j = 0; j < theWorld.Map.GetLength(1); j++)
                {
                    for (int i = 0; i < theWorld.Map.GetLength(0); i++)
                    {
                        RectangleF tempRectangle = new RectangleF((float)xLocation, (float)yLocation, TILE_HEIGHT, TILE_WIDTH);

                        if (theWorld.Map[i, j] == MapTile.Animal)
                        {
                            e.Graphics.FillRectangle(Brushes.Orange, tempRectangle);
                        }
                        else if (theWorld.Map[i, j] == MapTile.Enemy)
                        {
                            e.Graphics.FillRectangle(Brushes.Red, tempRectangle);
                        }
                        else if (theWorld.Map[i, j] == MapTile.HealStn)
                        {
                            e.Graphics.FillRectangle(Brushes.Blue, tempRectangle);
                        }
                        else if (theWorld.Map[i, j] == MapTile.Shop)
                        {
                            e.Graphics.FillRectangle(Brushes.DarkGoldenrod, tempRectangle);
                        }
                        else if (theWorld.Map[i, j] == MapTile.TallGrass)
                        {
                            e.Graphics.FillRectangle(Brushes.DarkOliveGreen, tempRectangle);
                        }
                        else if (theWorld.Map[i, j] == MapTile.Filler1 || theWorld.Map[i, j] == MapTile.StartLocation || theWorld.Map[i, j] == MapTile.EndLocation)
                        {
                            e.Graphics.FillRectangle(Brushes.LightGreen, tempRectangle);
                        }
                        else if (theWorld.Map[i, j] == MapTile.Filler2)
                        {
                            e.Graphics.FillRectangle(Brushes.SandyBrown, tempRectangle);
                        }


                        if (player.Column == i && player.Row == j)
                        {

                            e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + "Player\\" + player.FacingDirection.ToString() + ".png"), tempRectangle);

                        }

                        xLocation += TILE_WIDTH;
                    }

                    xLocation = 0;

                    yLocation += TILE_HEIGHT;
                }
            }
            else
            {
                RectangleF enemySprite = new RectangleF((float)ClientSize.Width - SPRITE_SIZE, (float)0, (float)SPRITE_SIZE, (float)SPRITE_SIZE);
                RectangleF playerSprite = new RectangleF((float)0, (float)((ClientSize.Height / 2) - SPRITE_SIZE), (float)SPRITE_SIZE, (float)SPRITE_SIZE);

                if (player.Roster.First().IsEvolved)
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/BackViewEvolved.png"), playerSprite);
                else
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/BackView.png"), playerSprite);

                if (battle.EnemyAnimals.First().IsEvolved)
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/FrontViewEvolved.png"), playerSprite);
                else
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/FrontView.png"), playerSprite);
            }
            base.OnPaint(e);
        }

        private void txtStoreList_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
