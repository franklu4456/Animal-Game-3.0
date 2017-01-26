namespace AnimalGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBattleOptions = new System.Windows.Forms.Panel();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.lblInventoryTitle = new System.Windows.Forms.Label();
            this.txtInventoryListOutGame = new System.Windows.Forms.TextBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblMenuOptions = new System.Windows.Forms.Label();
            this.lblMenuTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlStore = new System.Windows.Forms.Panel();
            this.lblPlayerMoney = new System.Windows.Forms.Label();
            this.lblPurchased = new System.Windows.Forms.Label();
            this.txtStoreList = new System.Windows.Forms.TextBox();
            this.lblShopTitle = new System.Windows.Forms.Label();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.lblBattleResults = new System.Windows.Forms.Label();
            this.pnlAttacks = new System.Windows.Forms.Panel();
            this.lblAttack3 = new System.Windows.Forms.Label();
            this.lblAttack2 = new System.Windows.Forms.Label();
            this.lblAttack1 = new System.Windows.Forms.Label();
            this.btnExitAttacks = new System.Windows.Forms.Button();
            this.pnlAnimals = new System.Windows.Forms.Panel();
            this.btnSwitch2 = new System.Windows.Forms.Button();
            this.btnSwitch1 = new System.Windows.Forms.Button();
            this.btnExitAnimals = new System.Windows.Forms.Button();
            this.lblAnimal3 = new System.Windows.Forms.Label();
            this.lblAnimal2 = new System.Windows.Forms.Label();
            this.lblAnimal1 = new System.Windows.Forms.Label();
            this.pnlBattleInv = new System.Windows.Forms.Panel();
            this.btnUsedItem6 = new System.Windows.Forms.Button();
            this.btnUsedItem5 = new System.Windows.Forms.Button();
            this.btnUsedItem4 = new System.Windows.Forms.Button();
            this.btnUseItem3 = new System.Windows.Forms.Button();
            this.btnUseItem2 = new System.Windows.Forms.Button();
            this.btnUseItem1 = new System.Windows.Forms.Button();
            this.lblItem4 = new System.Windows.Forms.Label();
            this.btnExitBInv = new System.Windows.Forms.Button();
            this.lblItem6 = new System.Windows.Forms.Label();
            this.lblItem5 = new System.Windows.Forms.Label();
            this.lblItem2 = new System.Windows.Forms.Label();
            this.lblItem3 = new System.Windows.Forms.Label();
            this.lblItem1 = new System.Windows.Forms.Label();
            this.pnlInterface = new System.Windows.Forms.Panel();
            this.enemyHealthBar = new System.Windows.Forms.ProgressBar();
            this.playerHealthBar = new System.Windows.Forms.ProgressBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInv = new System.Windows.Forms.Button();
            this.btnAnimal = new System.Windows.Forms.Button();
            this.btnFight = new System.Windows.Forms.Button();
            this.lblNotification = new System.Windows.Forms.Label();
            this.pnlInventory.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlStore.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.pnlAttacks.SuspendLayout();
            this.pnlAnimals.SuspendLayout();
            this.pnlBattleInv.SuspendLayout();
            this.pnlInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBattleOptions
            // 
            this.pnlBattleOptions.Location = new System.Drawing.Point(386, 243);
            this.pnlBattleOptions.Name = "pnlBattleOptions";
            this.pnlBattleOptions.Size = new System.Drawing.Size(505, 166);
            this.pnlBattleOptions.TabIndex = 0;
            this.pnlBattleOptions.Visible = false;
            // 
            // pnlInventory
            // 
            this.pnlInventory.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pnlInventory.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlInventory.Controls.Add(this.lblInventoryTitle);
            this.pnlInventory.Controls.Add(this.txtInventoryListOutGame);
            this.pnlInventory.Controls.Add(this.pnlBattleOptions);
            this.pnlInventory.Location = new System.Drawing.Point(-1, 0);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(380, 412);
            this.pnlInventory.TabIndex = 1;
            this.pnlInventory.Visible = false;
            // 
            // lblInventoryTitle
            // 
            this.lblInventoryTitle.AutoSize = true;
            this.lblInventoryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryTitle.Location = new System.Drawing.Point(139, 26);
            this.lblInventoryTitle.Name = "lblInventoryTitle";
            this.lblInventoryTitle.Size = new System.Drawing.Size(76, 25);
            this.lblInventoryTitle.TabIndex = 2;
            this.lblInventoryTitle.Text = "label1";
            // 
            // txtInventoryListOutGame
            // 
            this.txtInventoryListOutGame.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtInventoryListOutGame.Cursor = System.Windows.Forms.Cursors.No;
            this.txtInventoryListOutGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryListOutGame.Location = new System.Drawing.Point(33, 54);
            this.txtInventoryListOutGame.Multiline = true;
            this.txtInventoryListOutGame.Name = "txtInventoryListOutGame";
            this.txtInventoryListOutGame.ReadOnly = true;
            this.txtInventoryListOutGame.Size = new System.Drawing.Size(314, 337);
            this.txtInventoryListOutGame.TabIndex = 1;
            this.txtInventoryListOutGame.Visible = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMenu.Controls.Add(this.lblMenuOptions);
            this.pnlMenu.Controls.Add(this.lblMenuTitle);
            this.pnlMenu.Controls.Add(this.panel2);
            this.pnlMenu.Location = new System.Drawing.Point(-1, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(384, 412);
            this.pnlMenu.TabIndex = 2;
            this.pnlMenu.Visible = false;
            // 
            // lblMenuOptions
            // 
            this.lblMenuOptions.AutoSize = true;
            this.lblMenuOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuOptions.Location = new System.Drawing.Point(21, 61);
            this.lblMenuOptions.Name = "lblMenuOptions";
            this.lblMenuOptions.Size = new System.Drawing.Size(57, 20);
            this.lblMenuOptions.TabIndex = 2;
            this.lblMenuOptions.Text = "label1";
            this.lblMenuOptions.Visible = false;
            // 
            // lblMenuTitle
            // 
            this.lblMenuTitle.AutoSize = true;
            this.lblMenuTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuTitle.Location = new System.Drawing.Point(123, 6);
            this.lblMenuTitle.Name = "lblMenuTitle";
            this.lblMenuTitle.Size = new System.Drawing.Size(115, 37);
            this.lblMenuTitle.TabIndex = 1;
            this.lblMenuTitle.Text = "MENU";
            this.lblMenuTitle.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(386, 243);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(505, 166);
            this.panel2.TabIndex = 0;
            this.panel2.Visible = false;
            // 
            // pnlStore
            // 
            this.pnlStore.BackColor = System.Drawing.Color.SandyBrown;
            this.pnlStore.Controls.Add(this.lblPlayerMoney);
            this.pnlStore.Controls.Add(this.lblPurchased);
            this.pnlStore.Controls.Add(this.txtStoreList);
            this.pnlStore.Controls.Add(this.lblShopTitle);
            this.pnlStore.Location = new System.Drawing.Point(-1, 0);
            this.pnlStore.Name = "pnlStore";
            this.pnlStore.Size = new System.Drawing.Size(380, 412);
            this.pnlStore.TabIndex = 3;
            this.pnlStore.Visible = false;
            // 
            // lblPlayerMoney
            // 
            this.lblPlayerMoney.AutoSize = true;
            this.lblPlayerMoney.Location = new System.Drawing.Point(271, 45);
            this.lblPlayerMoney.Name = "lblPlayerMoney";
            this.lblPlayerMoney.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerMoney.TabIndex = 14;
            this.lblPlayerMoney.Text = "label1";
            // 
            // lblPurchased
            // 
            this.lblPurchased.AutoSize = true;
            this.lblPurchased.Location = new System.Drawing.Point(40, 45);
            this.lblPurchased.Name = "lblPurchased";
            this.lblPurchased.Size = new System.Drawing.Size(35, 13);
            this.lblPurchased.TabIndex = 13;
            this.lblPurchased.Text = "label1";
            // 
            // txtStoreList
            // 
            this.txtStoreList.Cursor = System.Windows.Forms.Cursors.No;
            this.txtStoreList.Location = new System.Drawing.Point(42, 61);
            this.txtStoreList.Multiline = true;
            this.txtStoreList.Name = "txtStoreList";
            this.txtStoreList.ReadOnly = true;
            this.txtStoreList.Size = new System.Drawing.Size(301, 339);
            this.txtStoreList.TabIndex = 5;
            this.txtStoreList.TextChanged += new System.EventHandler(this.txtStoreList_TextChanged);
            // 
            // lblShopTitle
            // 
            this.lblShopTitle.AutoSize = true;
            this.lblShopTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopTitle.Location = new System.Drawing.Point(135, 6);
            this.lblShopTitle.Name = "lblShopTitle";
            this.lblShopTitle.Size = new System.Drawing.Size(131, 37);
            this.lblShopTitle.TabIndex = 3;
            this.lblShopTitle.Text = "STORE";
            this.lblShopTitle.Visible = false;
            // 
            // pnlResults
            // 
            this.pnlResults.BackColor = System.Drawing.Color.Pink;
            this.pnlResults.Controls.Add(this.lblBattleResults);
            this.pnlResults.Location = new System.Drawing.Point(639, 0);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(297, 412);
            this.pnlResults.TabIndex = 4;
            this.pnlResults.Visible = false;
            // 
            // lblBattleResults
            // 
            this.lblBattleResults.AutoSize = true;
            this.lblBattleResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattleResults.Location = new System.Drawing.Point(88, 61);
            this.lblBattleResults.Name = "lblBattleResults";
            this.lblBattleResults.Size = new System.Drawing.Size(57, 20);
            this.lblBattleResults.TabIndex = 3;
            this.lblBattleResults.Text = "label1";
            this.lblBattleResults.Visible = false;
            // 
            // pnlAttacks
            // 
            this.pnlAttacks.Controls.Add(this.lblAttack3);
            this.pnlAttacks.Controls.Add(this.lblAttack2);
            this.pnlAttacks.Controls.Add(this.lblAttack1);
            this.pnlAttacks.Controls.Add(this.btnExitAttacks);
            this.pnlAttacks.Location = new System.Drawing.Point(-1, 261);
            this.pnlAttacks.Name = "pnlAttacks";
            this.pnlAttacks.Size = new System.Drawing.Size(720, 220);
            this.pnlAttacks.TabIndex = 7;
            this.pnlAttacks.Visible = false;
            // 
            // lblAttack3
            // 
            this.lblAttack3.AutoSize = true;
            this.lblAttack3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack3.Location = new System.Drawing.Point(30, 180);
            this.lblAttack3.Name = "lblAttack3";
            this.lblAttack3.Size = new System.Drawing.Size(44, 13);
            this.lblAttack3.TabIndex = 6;
            this.lblAttack3.Text = "Attack3";
            // 
            // lblAttack2
            // 
            this.lblAttack2.AutoSize = true;
            this.lblAttack2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack2.Location = new System.Drawing.Point(389, 32);
            this.lblAttack2.Name = "lblAttack2";
            this.lblAttack2.Size = new System.Drawing.Size(44, 13);
            this.lblAttack2.TabIndex = 5;
            this.lblAttack2.Text = "Attack2";
            // 
            // lblAttack1
            // 
            this.lblAttack1.AutoSize = true;
            this.lblAttack1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack1.Location = new System.Drawing.Point(30, 32);
            this.lblAttack1.Name = "lblAttack1";
            this.lblAttack1.Size = new System.Drawing.Size(44, 13);
            this.lblAttack1.TabIndex = 4;
            this.lblAttack1.Text = "Attack1";
            // 
            // btnExitAttacks
            // 
            this.btnExitAttacks.Location = new System.Drawing.Point(392, 175);
            this.btnExitAttacks.Name = "btnExitAttacks";
            this.btnExitAttacks.Size = new System.Drawing.Size(291, 23);
            this.btnExitAttacks.TabIndex = 3;
            this.btnExitAttacks.Text = "Back";
            this.btnExitAttacks.UseVisualStyleBackColor = true;
            this.btnExitAttacks.Click += new System.EventHandler(this.btnExitAttacks_Click);
            // 
            // pnlAnimals
            // 
            this.pnlAnimals.Controls.Add(this.btnSwitch2);
            this.pnlAnimals.Controls.Add(this.btnSwitch1);
            this.pnlAnimals.Controls.Add(this.btnExitAnimals);
            this.pnlAnimals.Controls.Add(this.lblAnimal3);
            this.pnlAnimals.Controls.Add(this.lblAnimal2);
            this.pnlAnimals.Controls.Add(this.lblAnimal1);
            this.pnlAnimals.Location = new System.Drawing.Point(-1, 261);
            this.pnlAnimals.Name = "pnlAnimals";
            this.pnlAnimals.Size = new System.Drawing.Size(720, 220);
            this.pnlAnimals.TabIndex = 9;
            this.pnlAnimals.Visible = false;
            // 
            // btnSwitch2
            // 
            this.btnSwitch2.Location = new System.Drawing.Point(608, 187);
            this.btnSwitch2.Name = "btnSwitch2";
            this.btnSwitch2.Size = new System.Drawing.Size(75, 23);
            this.btnSwitch2.TabIndex = 9;
            this.btnSwitch2.Text = "Switch To";
            this.btnSwitch2.UseVisualStyleBackColor = true;
            this.btnSwitch2.Click += new System.EventHandler(this.btnSwitch2_Click_1);
            // 
            // btnSwitch1
            // 
            this.btnSwitch1.Location = new System.Drawing.Point(608, 117);
            this.btnSwitch1.Name = "btnSwitch1";
            this.btnSwitch1.Size = new System.Drawing.Size(75, 23);
            this.btnSwitch1.TabIndex = 8;
            this.btnSwitch1.Text = "Switch To";
            this.btnSwitch1.UseVisualStyleBackColor = true;
            this.btnSwitch1.Click += new System.EventHandler(this.btnSwitch1_Click_1);
            // 
            // btnExitAnimals
            // 
            this.btnExitAnimals.Location = new System.Drawing.Point(608, 14);
            this.btnExitAnimals.Name = "btnExitAnimals";
            this.btnExitAnimals.Size = new System.Drawing.Size(75, 23);
            this.btnExitAnimals.TabIndex = 6;
            this.btnExitAnimals.Text = "Back";
            this.btnExitAnimals.UseVisualStyleBackColor = true;
            this.btnExitAnimals.Click += new System.EventHandler(this.btnExitAnimals_Click_1);
            // 
            // lblAnimal3
            // 
            this.lblAnimal3.AutoSize = true;
            this.lblAnimal3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimal3.Location = new System.Drawing.Point(14, 192);
            this.lblAnimal3.Name = "lblAnimal3";
            this.lblAnimal3.Size = new System.Drawing.Size(66, 20);
            this.lblAnimal3.TabIndex = 2;
            this.lblAnimal3.Text = "Animal3";
            // 
            // lblAnimal2
            // 
            this.lblAnimal2.AutoSize = true;
            this.lblAnimal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimal2.Location = new System.Drawing.Point(14, 122);
            this.lblAnimal2.Name = "lblAnimal2";
            this.lblAnimal2.Size = new System.Drawing.Size(66, 20);
            this.lblAnimal2.TabIndex = 1;
            this.lblAnimal2.Text = "Animal2";
            // 
            // lblAnimal1
            // 
            this.lblAnimal1.AutoSize = true;
            this.lblAnimal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimal1.Location = new System.Drawing.Point(14, 49);
            this.lblAnimal1.Name = "lblAnimal1";
            this.lblAnimal1.Size = new System.Drawing.Size(66, 20);
            this.lblAnimal1.TabIndex = 0;
            this.lblAnimal1.Text = "Animal1";
            // 
            // pnlBattleInv
            // 
            this.pnlBattleInv.Controls.Add(this.btnUsedItem6);
            this.pnlBattleInv.Controls.Add(this.btnUsedItem5);
            this.pnlBattleInv.Controls.Add(this.btnUsedItem4);
            this.pnlBattleInv.Controls.Add(this.btnUseItem3);
            this.pnlBattleInv.Controls.Add(this.btnUseItem2);
            this.pnlBattleInv.Controls.Add(this.btnUseItem1);
            this.pnlBattleInv.Controls.Add(this.lblItem4);
            this.pnlBattleInv.Controls.Add(this.btnExitBInv);
            this.pnlBattleInv.Controls.Add(this.lblItem6);
            this.pnlBattleInv.Controls.Add(this.lblItem5);
            this.pnlBattleInv.Controls.Add(this.lblItem2);
            this.pnlBattleInv.Controls.Add(this.lblItem3);
            this.pnlBattleInv.Controls.Add(this.lblItem1);
            this.pnlBattleInv.Location = new System.Drawing.Point(-1, 261);
            this.pnlBattleInv.Name = "pnlBattleInv";
            this.pnlBattleInv.Size = new System.Drawing.Size(720, 220);
            this.pnlBattleInv.TabIndex = 10;
            this.pnlBattleInv.Visible = false;
            // 
            // btnUsedItem6
            // 
            this.btnUsedItem6.Location = new System.Drawing.Point(608, 178);
            this.btnUsedItem6.Name = "btnUsedItem6";
            this.btnUsedItem6.Size = new System.Drawing.Size(75, 23);
            this.btnUsedItem6.TabIndex = 12;
            this.btnUsedItem6.Text = "Back";
            this.btnUsedItem6.UseVisualStyleBackColor = true;
            this.btnUsedItem6.Click += new System.EventHandler(this.btnUsedItem6_Click_1);
            // 
            // btnUsedItem5
            // 
            this.btnUsedItem5.Location = new System.Drawing.Point(608, 153);
            this.btnUsedItem5.Name = "btnUsedItem5";
            this.btnUsedItem5.Size = new System.Drawing.Size(75, 23);
            this.btnUsedItem5.TabIndex = 11;
            this.btnUsedItem5.Text = "Back";
            this.btnUsedItem5.UseVisualStyleBackColor = true;
            this.btnUsedItem5.Click += new System.EventHandler(this.btnUsedItem5_Click_1);
            // 
            // btnUsedItem4
            // 
            this.btnUsedItem4.Location = new System.Drawing.Point(608, 128);
            this.btnUsedItem4.Name = "btnUsedItem4";
            this.btnUsedItem4.Size = new System.Drawing.Size(75, 23);
            this.btnUsedItem4.TabIndex = 10;
            this.btnUsedItem4.Text = "Back";
            this.btnUsedItem4.UseVisualStyleBackColor = true;
            this.btnUsedItem4.Click += new System.EventHandler(this.btnUsedItem4_Click_1);
            // 
            // btnUseItem3
            // 
            this.btnUseItem3.Location = new System.Drawing.Point(608, 103);
            this.btnUseItem3.Name = "btnUseItem3";
            this.btnUseItem3.Size = new System.Drawing.Size(75, 23);
            this.btnUseItem3.TabIndex = 9;
            this.btnUseItem3.Text = "Back";
            this.btnUseItem3.UseVisualStyleBackColor = true;
            this.btnUseItem3.Click += new System.EventHandler(this.btnUseItem3_Click_1);
            // 
            // btnUseItem2
            // 
            this.btnUseItem2.Location = new System.Drawing.Point(608, 77);
            this.btnUseItem2.Name = "btnUseItem2";
            this.btnUseItem2.Size = new System.Drawing.Size(75, 23);
            this.btnUseItem2.TabIndex = 8;
            this.btnUseItem2.Text = "Use";
            this.btnUseItem2.UseVisualStyleBackColor = true;
            this.btnUseItem2.Click += new System.EventHandler(this.btnUseItem2_Click_1);
            // 
            // btnUseItem1
            // 
            this.btnUseItem1.Location = new System.Drawing.Point(608, 53);
            this.btnUseItem1.Name = "btnUseItem1";
            this.btnUseItem1.Size = new System.Drawing.Size(75, 23);
            this.btnUseItem1.TabIndex = 7;
            this.btnUseItem1.Text = "Use";
            this.btnUseItem1.UseVisualStyleBackColor = true;
            this.btnUseItem1.Click += new System.EventHandler(this.btnUseItem1_Click_1);
            // 
            // lblItem4
            // 
            this.lblItem4.AutoSize = true;
            this.lblItem4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem4.Location = new System.Drawing.Point(25, 133);
            this.lblItem4.Name = "lblItem4";
            this.lblItem4.Size = new System.Drawing.Size(33, 13);
            this.lblItem4.TabIndex = 6;
            this.lblItem4.Text = "Item4";
            // 
            // btnExitBInv
            // 
            this.btnExitBInv.Location = new System.Drawing.Point(608, 16);
            this.btnExitBInv.Name = "btnExitBInv";
            this.btnExitBInv.Size = new System.Drawing.Size(75, 23);
            this.btnExitBInv.TabIndex = 5;
            this.btnExitBInv.Text = "Back";
            this.btnExitBInv.UseVisualStyleBackColor = true;
            this.btnExitBInv.Click += new System.EventHandler(this.btnExitBInv_Click_1);
            // 
            // lblItem6
            // 
            this.lblItem6.AutoSize = true;
            this.lblItem6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem6.Location = new System.Drawing.Point(25, 183);
            this.lblItem6.Name = "lblItem6";
            this.lblItem6.Size = new System.Drawing.Size(33, 13);
            this.lblItem6.TabIndex = 4;
            this.lblItem6.Text = "Item6";
            // 
            // lblItem5
            // 
            this.lblItem5.AutoSize = true;
            this.lblItem5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem5.Location = new System.Drawing.Point(25, 158);
            this.lblItem5.Name = "lblItem5";
            this.lblItem5.Size = new System.Drawing.Size(33, 13);
            this.lblItem5.TabIndex = 3;
            this.lblItem5.Text = "Item5";
            // 
            // lblItem2
            // 
            this.lblItem2.AutoSize = true;
            this.lblItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem2.Location = new System.Drawing.Point(25, 82);
            this.lblItem2.Name = "lblItem2";
            this.lblItem2.Size = new System.Drawing.Size(33, 13);
            this.lblItem2.TabIndex = 2;
            this.lblItem2.Text = "Item2";
            // 
            // lblItem3
            // 
            this.lblItem3.AutoSize = true;
            this.lblItem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem3.Location = new System.Drawing.Point(25, 108);
            this.lblItem3.Name = "lblItem3";
            this.lblItem3.Size = new System.Drawing.Size(33, 13);
            this.lblItem3.TabIndex = 1;
            this.lblItem3.Text = "Item3";
            // 
            // lblItem1
            // 
            this.lblItem1.AutoSize = true;
            this.lblItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem1.Location = new System.Drawing.Point(25, 58);
            this.lblItem1.Name = "lblItem1";
            this.lblItem1.Size = new System.Drawing.Size(33, 13);
            this.lblItem1.TabIndex = 0;
            this.lblItem1.Text = "Item1";
            // 
            // pnlInterface
            // 
            this.pnlInterface.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlInterface.Controls.Add(this.enemyHealthBar);
            this.pnlInterface.Controls.Add(this.playerHealthBar);
            this.pnlInterface.Controls.Add(this.btnRun);
            this.pnlInterface.Controls.Add(this.btnInv);
            this.pnlInterface.Controls.Add(this.btnAnimal);
            this.pnlInterface.Controls.Add(this.btnFight);
            this.pnlInterface.Location = new System.Drawing.Point(0, 235);
            this.pnlInterface.Name = "pnlInterface";
            this.pnlInterface.Size = new System.Drawing.Size(720, 247);
            this.pnlInterface.TabIndex = 11;
            this.pnlInterface.Visible = false;
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.Location = new System.Drawing.Point(374, 3);
            this.enemyHealthBar.Name = "enemyHealthBar";
            this.enemyHealthBar.Size = new System.Drawing.Size(343, 23);
            this.enemyHealthBar.TabIndex = 6;
            // 
            // playerHealthBar
            // 
            this.playerHealthBar.Location = new System.Drawing.Point(3, 3);
            this.playerHealthBar.Name = "playerHealthBar";
            this.playerHealthBar.Size = new System.Drawing.Size(341, 23);
            this.playerHealthBar.TabIndex = 5;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(374, 139);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(343, 105);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click_1);
            // 
            // btnInv
            // 
            this.btnInv.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInv.Location = new System.Drawing.Point(374, 31);
            this.btnInv.Name = "btnInv";
            this.btnInv.Size = new System.Drawing.Size(343, 105);
            this.btnInv.TabIndex = 3;
            this.btnInv.Text = "Inventory";
            this.btnInv.UseVisualStyleBackColor = false;
            this.btnInv.Click += new System.EventHandler(this.btnInv_Click_1);
            // 
            // btnAnimal
            // 
            this.btnAnimal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimal.Location = new System.Drawing.Point(3, 139);
            this.btnAnimal.Name = "btnAnimal";
            this.btnAnimal.Size = new System.Drawing.Size(341, 105);
            this.btnAnimal.TabIndex = 2;
            this.btnAnimal.Text = "Animals";
            this.btnAnimal.UseVisualStyleBackColor = false;
            this.btnAnimal.Click += new System.EventHandler(this.btnAnimal_Click_1);
            // 
            // btnFight
            // 
            this.btnFight.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnFight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFight.Location = new System.Drawing.Point(3, 31);
            this.btnFight.Name = "btnFight";
            this.btnFight.Size = new System.Drawing.Size(341, 105);
            this.btnFight.TabIndex = 1;
            this.btnFight.Text = "Fight";
            this.btnFight.UseVisualStyleBackColor = false;
            this.btnFight.Click += new System.EventHandler(this.btnFight_Click_1);
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.BackColor = System.Drawing.Color.Transparent;
            this.lblNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.Location = new System.Drawing.Point(406, 6);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(156, 25);
            this.lblNotification.TabIndex = 12;
            this.lblNotification.Text = "lblNotification";
            this.lblNotification.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 482);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.pnlInterface);
            this.Controls.Add(this.pnlAnimals);
            this.Controls.Add(this.pnlAttacks);
            this.Controls.Add(this.pnlBattleInv);
            this.Controls.Add(this.pnlInventory);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlStore);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Animal Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.pnlInventory.ResumeLayout(false);
            this.pnlInventory.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlStore.ResumeLayout(false);
            this.pnlStore.PerformLayout();
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
            this.pnlAttacks.ResumeLayout(false);
            this.pnlAttacks.PerformLayout();
            this.pnlAnimals.ResumeLayout(false);
            this.pnlAnimals.PerformLayout();
            this.pnlBattleInv.ResumeLayout(false);
            this.pnlBattleInv.PerformLayout();
            this.pnlInterface.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBattleOptions;
        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.TextBox txtInventoryListOutGame;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMenuOptions;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.Panel pnlStore;
        private System.Windows.Forms.Label lblShopTitle;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Label lblBattleResults;
        private System.Windows.Forms.Label lblInventoryTitle;
        private System.Windows.Forms.Panel pnlAttacks;
        private System.Windows.Forms.Label lblAttack3;
        private System.Windows.Forms.Label lblAttack2;
        private System.Windows.Forms.Label lblAttack1;
        private System.Windows.Forms.Button btnExitAttacks;
        private System.Windows.Forms.Panel pnlAnimals;
        private System.Windows.Forms.Button btnSwitch2;
        private System.Windows.Forms.Button btnSwitch1;
        private System.Windows.Forms.Button btnExitAnimals;
        private System.Windows.Forms.Label lblAnimal3;
        private System.Windows.Forms.Label lblAnimal2;
        private System.Windows.Forms.Label lblAnimal1;
        private System.Windows.Forms.Panel pnlBattleInv;
        private System.Windows.Forms.Button btnUsedItem6;
        private System.Windows.Forms.Button btnUsedItem5;
        private System.Windows.Forms.Button btnUsedItem4;
        private System.Windows.Forms.Button btnUseItem3;
        private System.Windows.Forms.Button btnUseItem2;
        private System.Windows.Forms.Button btnUseItem1;
        private System.Windows.Forms.Label lblItem4;
        private System.Windows.Forms.Button btnExitBInv;
        private System.Windows.Forms.Label lblItem6;
        private System.Windows.Forms.Label lblItem5;
        private System.Windows.Forms.Label lblItem2;
        private System.Windows.Forms.Label lblItem3;
        private System.Windows.Forms.Label lblItem1;
        private System.Windows.Forms.Panel pnlInterface;
        private System.Windows.Forms.ProgressBar enemyHealthBar;
        private System.Windows.Forms.ProgressBar playerHealthBar;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInv;
        private System.Windows.Forms.Button btnAnimal;
        private System.Windows.Forms.Button btnFight;
        private System.Windows.Forms.TextBox txtStoreList;
        private System.Windows.Forms.Label lblPurchased;
        private System.Windows.Forms.Label lblPlayerMoney;
        private System.Windows.Forms.Label lblNotification;
    }
}

