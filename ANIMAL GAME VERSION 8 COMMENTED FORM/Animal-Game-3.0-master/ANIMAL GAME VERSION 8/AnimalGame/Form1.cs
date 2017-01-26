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
                    //through the world store purchase the items
                    //pass through the player, their items and the item for purchase
                    worldStore.PurchaseItem(player.Items, temp, player);
                    //check is the purchase went through
                    if (worldStore.ItemWasPurchased == true)
                    {
                        //display a label starting that the purchase was valid
                        lblPurchased.Text = "Attack buff was purchased";
                    }
                    else
                    {
                        //display that that there isn't enough money
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                //store the items information intot he temporary item
                //for purchase
                else if (e.KeyCode == Keys.D2)
                {
                    foreach (Item x in worldStore.SetupShop())
                    {
                        //search for the defense item stat in the list
                        if (x.StatEffect == Stat.Defense)
                        {
                            //save it in the temp variable
                            temp = x;
                        }
                    }
                    //through the world store purchase the items
                    //pass through the player, their items and the item for purchase
                    worldStore.PurchaseItem(player.Items, temp, player);
                    //check is the purchase went through
                    if (worldStore.ItemWasPurchased == true)
                    {
                        //display a label starting that the purchase was valid
                        lblPurchased.Text = "Defense buff was purchased";
                    }
                    else
                    {
                        //display that that there isn't enough money
                        lblPurchased.Text = "Player doesn't have enough money to purchase" ;
                    }
                }
                //check if the key "3" was pressed
                else if (e.KeyCode == Keys.D3)
                {
                    //search through the shope items for a speed buff
                    foreach (Item x in worldStore.SetupShop())
                    {
                        //save the sped buff into the temp variable
                        if (x.StatEffect == Stat.Speed)
                        {
                            temp = x;
                        }
                    }
                    //through the world store purchase the items
                    //pass through the player, their items and the item for purchase
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        //display a label starting that the purchase was valid
                        lblPurchased.Text = "Speed buff was purchased";
                    }
                    else
                    {
                        //display that that there isn't enough money
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                //chcek if key "4" was pressed
                else if (e.KeyCode == Keys.D4)
                {
                    //search through the world for a heal item
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.Heal)
                        {
                            //save the heal item in the temp variable
                            temp = x;
                        }
                    }
                    //through the world store purchase the items
                    //pass through the player, their items and the item for purchase
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        //display a label starting that the purchase was valid
                        lblPurchased.Text = "Heal item was purchased";
                    }
                    else
                    {
                        //display that that there isn't enough money
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                //check if the player pressed key "5"
                else if (e.KeyCode == Keys.D5)
                {
                    //search through the list for a max heal item
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.MaxHeal)
                        {
                            //save the item into the temp variable
                            temp = x;
                        }
                    }
                    //through the world store purchase the items
                    //pass through the player, their items and the item for purchase
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        //display a label starting that the purchase was valid
                        lblPurchased.Text = "Max heal item was purchased";
                    }
                    else
                    {
                        //display that that there isn't enough money
                        lblPurchased.Text = "Player doesn't have enough money to purchase";
                    }
                }
                //check if key "6" was pressed
                else if (e.KeyCode == Keys.D6)
                {
                    //check through the item list if there was an item with a stat of catch
                    foreach (Item x in worldStore.SetupShop())
                    {
                        if (x.StatEffect == Stat.Catch)
                        {
                            //save the item into the temp variable
                            temp = x;
                        }
                    }
                    //through the world store purchase the items
                    //pass through the player, their items and the item for purchase
                    worldStore.PurchaseItem(player.Items, temp, player);
                    if (worldStore.ItemWasPurchased == true)
                    {
                        //display a label starting that the purchase was valid
                        lblPurchased.Text = "Net was purchased";
                    }
                    else
                    {
                        //display that that there isn't enough money
                        lblPurchased.Text = "Player doesn't have enough money to purchase ";
                    }
                }
                //display the total amount of money that the player has
                lblPlayerMoney.Text = "Money: $" + player.Money.ToString();
            }
            //check if the player is in battle and can't move
            if (player.InBattle==GameState.InBattle&& canPlayerMove == false)
            {
                //FINISH
                if (battle.Status !=2)
                {
                    if (e.KeyCode == Keys.Q)
                    {
                        //allows the player to pick attack 1 when in battle
                        battle.Fight(1);

                        pnlResults.Visible = true;
                        DisplayResults();
                        enemyHealthBar.Value = battle.EnemyAnimals.First().Health;
                        playerHealthBar.Value = player.Roster.First().Health;

                    }
                    else if (e.KeyCode == Keys.W)
                    {
                        //allows the player to pick attack 2 in battle
                        battle.Fight(2);
                        DisplayResults();
                        enemyHealthBar.Value = battle.EnemyAnimals.First().Health;
                        playerHealthBar.Value = player.Roster.First().Health;
                    }

                    else if (e.KeyCode == Keys.E)
                    {
                        //allows the player to pick attack 3 in battle
                        battle.Fight(3);
                        DisplayResults();
                        enemyHealthBar.Value = battle.EnemyAnimals.First().Health;
                        playerHealthBar.Value = player.Roster.First().Health;
                    }
                }
            }
            //FINISH ALL THE PANELS
            if (e.KeyCode == Keys.Escape)
            {
                //close the current window 
                //check if there is a window currenty open
                if (windowOpen == true && player.InBattle!=GameState.InBattle)
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
            if (player.InBattle!=GameState.InBattle)
            {
                pnlResults.Visible = true;
                if (player.InBattle==GameState.Win)
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
                player.InBattle=GameState.InBattle;
                //battle panel needs to be made
                Random numberGenerator = new Random();
                int number = numberGenerator.Next(0, theWorld.EnemyPlayerList().Length);
                Player enemy = theWorld.EnemyPlayerList()[number];
                battle = new Battle(player.Roster, enemy.Roster, player.Items, false);

                enemyHealthBar.Maximum = battle.EnemyAnimals.First().MaxHealth;
                enemyHealthBar.Value = battle.EnemyAnimals.First().Health;
                playerHealthBar.Maximum = player.Roster.First().MaxHealth;
                playerHealthBar.Value = player.Roster.First().Health;
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



                player.InBattle = GameState.InBattle;
                //generate a random number to decide which animal the player will battle
                Random numberGenerator = new Random();
                int number = numberGenerator.Next(0, theWorld.SetAnimalStuff().Length - 1);
                //temporary array to store the wild animal that they'll be batteling
                List<Animal> tempWildAnimal = new List<Animal>();
                //add the randomly selected wild number to the list of wild animals
                tempWildAnimal.Add(theWorld.SetAnimalStuff()[number]);

                //set a battle for the wild animal
                battle = new Battle(player.Roster, tempWildAnimal, player.Items, true);                
                
                enemyHealthBar.Maximum = battle.EnemyAnimals.First().MaxHealth;
                enemyHealthBar.Value = battle.EnemyAnimals.First().Health;
                playerHealthBar.Maximum = player.Roster.First().MaxHealth;
                playerHealthBar.Value = player.Roster.First().Health;
            }
        }

        /// <summary>
        /// Override of the computer's OnPaint subprogram
        /// Drawing all the graphics of the game.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Integers to store the x and y coordinates to draw the map..
            //They start at 0.
            int xLocation = 0;
            int yLocation = 0;


            //If the player is not in battle, then draw the map.
            if (player.InBattle!=GameState.InBattle)
            {
                //Create a for loop that runs for every column.
                for (int j = 0; j < theWorld.Map.GetLength(1); j++)
                {
                    //Create a for loop that runs for every row.
                    for (int i = 0; i < theWorld.Map.GetLength(0); i++)
                    {
                        //Create a temporary rectangle with the x and y locations and the width/height of the tile.
                        RectangleF tempRectangle = new RectangleF((float)xLocation, (float)yLocation, TILE_HEIGHT, TILE_WIDTH);

                        //If it is an animal tile then draw an orange rectangle.
                        if (theWorld.Map[i, j] == MapTile.Animal)
                        {
                            e.Graphics.FillRectangle(Brushes.Orange, tempRectangle);
                        }
                        //If the tile is an enemy tile, then draw a red rectangle.
                        else if (theWorld.Map[i, j] == MapTile.Enemy)
                        {
                            e.Graphics.FillRectangle(Brushes.Red, tempRectangle);
                        }
                        //If the tile is a heal station, then draw a pink tile.
                        else if (theWorld.Map[i, j] == MapTile.HealStn)
                        {
                            e.Graphics.FillRectangle(Brushes.HotPink, tempRectangle);
                        }
                        //If the tile is a shop, then draw a blue tile.
                        else if (theWorld.Map[i, j] == MapTile.Shop)
                        {
                            e.Graphics.FillRectangle(Brushes.Blue, tempRectangle);
                        }
                        //If the tile is tall grass, then draw a dark green tile.
                        else if (theWorld.Map[i, j] == MapTile.TallGrass)
                        {
                            e.Graphics.FillRectangle(Brushes.DarkOliveGreen, tempRectangle);
                        }
                        //If the tile is a filler tile (just a normal tile) or a start/end location then draw a lightgreen tile.
                        else if (theWorld.Map[i, j] == MapTile.Filler1 || theWorld.Map[i, j] == MapTile.StartLocation || theWorld.Map[i, j] == MapTile.EndLocation)
                        {
                            e.Graphics.FillRectangle(Brushes.LightGreen, tempRectangle);
                        }
                        //If the tile is a filler tile (just a normal tile) then daw a Brown tile.
                        else if (theWorld.Map[i, j] == MapTile.Filler2)
                        {
                            e.Graphics.FillRectangle(Brushes.SandyBrown, tempRectangle);
                        }

                        //If the current iteration of the nested for loops is at the player's location then draw the player.
                        if (player.Column == i && player.Row == j)
                        {
                            //Draw the player image from the file, onto the tile rectangle.
                            e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + "Player\\" + player.FacingDirection.ToString() + ".png"), tempRectangle);

                        }

                        //Advance the xLocation to the location of the next tile.
                        xLocation += TILE_WIDTH;
                    }

                    //Reset the x location for every column.
                    xLocation = 0;

                    //Advance the y location for every column.
                    yLocation += TILE_HEIGHT;
                }
            }
            //If the player is in a battle then continue
            else
            {
                //Create rectangles to hold the enemy sprite and the player sprite. Puts them in the correct location as well
                //Player sprite location is at the center on the left side.
                //Enemy sprite location is at the top right corner.
                RectangleF enemySprite = new RectangleF((float)ClientSize.Width - SPRITE_SIZE, (float)0, (float)SPRITE_SIZE, (float)SPRITE_SIZE);
                RectangleF playerSprite = new RectangleF((float)0, (float)((ClientSize.Height / 2) - SPRITE_SIZE), (float)SPRITE_SIZE, (float)SPRITE_SIZE);

                //If the player's animal is evolved then draw the correct back facing evolved animal based on its species onto the PlayerSprite rectangle.
                if (player.Roster.First().IsEvolved)
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/BackViewEvolved.png"), playerSprite);
                //Otherwise draw the correct back facing animal based on its species onto the PlayerSprite rectangle.
                else
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/BackView.png"), playerSprite);

                //If the enemy's animal is evolved then draw the correct front facing evolved animal based on its species onto the EnemySprite rectangle.
                if (battle.EnemyAnimals.First().IsEvolved)
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/FrontViewEvolved.png"), playerSprite);
                //Otherwise draw the correct front facing animal based on its species onto the EnemySprite rectangle.
                else
                    e.Graphics.DrawImage(Image.FromFile(Environment.CurrentDirectory + IMAGE_PATH + player.Roster.First().Species.ToString() + "/FrontView.png"), playerSprite);
            }
            base.OnPaint(e);
        }

        private void txtStoreList_TextChanged(object sender, EventArgs e)
        {

        }

        // BATTLE INTERFACE
        private void btnFight_Click_1(object sender, EventArgs e)
        {
            pnlAttacks.Visible = true;
            pnlInterface.SendToBack();

            // Get the current animal in battle
            Animal current = player.Roster.First();

            // Display its first attack in the first label
            lblAttack1.Text = current.AttackArray[0].Name;

            // Display its second attack in the second label
            lblAttack2.Text = current.AttackArray[1].Name;

            // Display its thrid attack in the third label
            lblAttack3.Text = current.AttackArray[2].Name;
        }

        private void btnInv_Click_1(object sender, EventArgs e)
        {
            pnlBattleInv.Visible = true;
            pnlInterface.SendToBack();

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

        private void btnAnimal_Click_1(object sender, EventArgs e)
        {
            pnlAnimals.Visible = true;
            pnlInterface.SendToBack();

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
            if (player.Roster.Count < 2)
            {
                lblAnimal1.Text = tempRoster[0].Species.ToString() + " | " + tempRoster[0].Health.ToString() + "/" + tempRoster[0].MaxHealth.ToString() + " | " + tempRoster[0].Attack.ToString() + " | " + tempRoster[0].Defense.ToString() + " | " + tempRoster[0].Speed.ToString();
            }
            else if (player.Roster.Count < 3)
            {
                lblAnimal1.Text = tempRoster[1].Species.ToString() + " | " + tempRoster[1].Health.ToString() + "/" + tempRoster[1].MaxHealth.ToString() + " | " + tempRoster[1].Attack.ToString() + " | " + tempRoster[1].Defense.ToString() + " | " + tempRoster[1].Speed.ToString();
            }
            else if (player.Roster.Count < 4)
            {
                lblAnimal1.Text = tempRoster[2].Species.ToString() + " | " + tempRoster[2].Health.ToString() + "/" + tempRoster[2].MaxHealth.ToString() + " | " + tempRoster[2].Attack.ToString() + " | " + tempRoster[2].Defense.ToString() + " | " + tempRoster[2].Speed.ToString();
            }
        }

        private void btnRun_Click_1(object sender, EventArgs e)
        {
            battle.Run(battle);
            Refresh();
        }

        // ANIMALS INTERFACE
        private void btnExitAnimals_Click_1(object sender, EventArgs e)
        {
            pnlAnimals.Visible = false;
            pnlInterface.BringToFront();
        }

        private void btnSwitch1_Click_1(object sender, EventArgs e)
        {
            battle.SwitchPlayerAnimal(player.Roster, 0);
        }

        private void btnSwitch2_Click_1(object sender, EventArgs e)
        {
            battle.SwitchPlayerAnimal(player.Roster, 1);
        }

        // ATTACKS INTERFACE
        private void btnExitAttacks_Click(object sender, EventArgs e)
        {
            pnlAttacks.Visible = false;
            pnlInterface.BringToFront();
        }

        // ITEMS INTERFACE
        private void btnExitBInv_Click_1(object sender, EventArgs e)
        {
            pnlBattleInv.Visible = false;
            pnlInterface.BringToFront();
        }

        private void btnUseItem1_Click_1(object sender, EventArgs e)
        {
            foreach (Item x in player.Items)
            {
                if (x.StatEffect == Stat.Attack)
                {
                    battle.UsedAtkBoost(player.Roster.First(), x);
                    x.Quantity--;
                }
            }
        }

        private void btnUseItem2_Click_1(object sender, EventArgs e)
        {
            foreach (Item x in player.Items)
            {
                if (x.StatEffect == Stat.Defense)
                {
                    battle.UsedAtkBoost(player.Roster.First(), x);
                    x.Quantity--;
                }
            }
        }

        private void btnUseItem3_Click_1(object sender, EventArgs e)
        {
            foreach (Item x in player.Items)
            {
                if (x.StatEffect == Stat.Speed)
                {
                    battle.UsedAtkBoost(player.Roster.First(), x);
                    x.Quantity--;
                }
            }
        }

        private void btnUsedItem4_Click_1(object sender, EventArgs e)
        {
            foreach (Item x in player.Items)
            {
                if (x.StatEffect == Stat.Heal)
                {
                    battle.UsedAtkBoost(player.Roster.First(), x);
                    x.Quantity--;
                }
            }
            enemyHealthBar.Value = battle.EnemyAnimals.First().Health;
            playerHealthBar.Value = player.Roster.First().Health;
        }

        private void btnUsedItem5_Click_1(object sender, EventArgs e)
        {
            foreach (Item x in player.Items)
            {
                if (x.StatEffect == Stat.MaxHeal)
                {
                    battle.UsedAtkBoost(player.Roster.First(), x);
                    x.Quantity--;
                }
            }
            enemyHealthBar.Value = battle.EnemyAnimals.First().Health;
            playerHealthBar.Value = player.Roster.First().Health;
        }

        private void btnUsedItem6_Click_1(object sender, EventArgs e)
        {
            foreach (Item x in player.Items)
            {
                if (x.StatEffect == Stat.Catch)
                {
                    battle.UsedAtkBoost(player.Roster.First(), x);
                    x.Quantity--;
                }
            }
        }


    }
}
