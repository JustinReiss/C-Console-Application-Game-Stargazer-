using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesLibrary;


namespace _CSF2DungeonGame
{
    public class Game
    {
        static void Main(string[] args)
        {

            Console.Title = "'---===:::: STARGAZER ::::===---'";
            bool exitGame = false;//exit game loop
            do
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                #region Stargazer graphic
                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                #endregion
                Console.ResetColor();
                Console.WriteLine("\n\n\t\t\t      You are the Captain aboard a mercenary ship named \"Stargazer\".\n" +
                    "\t\t\t      Your mission is to eliminate enemy forces at each planet along \n" +
                    "\t\t\t      the orbit of Star 634. Payment for the elimination of each \n" +
                    "\t\t\t      ship will be transferred to you upon confirmation of kills.\n\n\n\n\n");
                
                Console.Write("\t\t\t\t\t\tPress any key to play");
                ConsoleKey play = Console.ReadKey(true).Key;
                Console.Clear();

                //Weapons initialaization
                #region Weapons
                Weapon laser = new Weapon(40, 10, "Laser", 0);
                Weapon photonCannon = new Weapon(60, 10, "Photon Cannon", 10);
                Weapon plasmaBomb = new Weapon(80, 10, "Plasma Bomb", 10);
                Weapon matterRipper = new Weapon(100, 10, "Matter Ripper", 20);
                Weapon starDestroyer = new Weapon(200, 10, "Star Destroyer", 20);
                #endregion
               
                //Player initialization
                Player player = new Player(150, 150, "Stargazer", 10, 100, laser, 0, 0);

                //Code for the gameplay
                #region Gameplay
                bool exit = false; 
                do
                {
                    #region Enemies
                    Enemy enemy1 = new Enemy(150, 150, "Chronos Pirate Vessel", "", 10, 60, laser);

                    Enemy enemy2 = new Enemy(175, 175, "Chronos Battle Vessel", "", 10, 70, laser);

                    Enemy enemy3 = new Enemy(200, 200, "Zealot Battle Vessel ", "", 10, 80, laser);

                    Enemy enemy4 = new Enemy(225, 225, "Zealot War Ship", "", 10, 80, photonCannon);

                    Enemy enemy5 = new Enemy(250, 250, "Goliath War Ship", "", 20, 100, photonCannon);

                    Enemy enemy6 = new Enemy(275, 275, "Goliath Super Destroyer", "", 20, 100, plasmaBomb);

                    Enemy enemy7 = new Enemy(350, 350, "Titan Super Destroyer", "", 20, 130, plasmaBomb);

                    Enemy enemy8 = new Enemy(375, 375, "Titan World Destroyer", "", 20, 130, matterRipper);

                    Enemy enemy9 = new Enemy(400, 400, "Mammoth World Destroyer", "", 20, 160, matterRipper);

                    Enemy enemy10 = new Enemy(450, 450, "Mammoth Star Destroyer", "", 20, 160, starDestroyer);

                    Enemy enemy11 = new Enemy(500, 500, "Colossal Star Destroyer", "", 20, 190, starDestroyer);

                    Enemy enemy12 = new Enemy(550, 550, "Colossal Galaxy Destroyer", "", 20, 200, starDestroyer);


                    Enemy[] enemies = { enemy1, enemy1, enemy1, enemy1, enemy1, enemy1, enemy1, enemy2, enemy2, enemy2, enemy2, enemy3, enemy3, enemy4, enemy4, enemy5, enemy6, enemy7, enemy8, enemy9, enemy10, enemy11, enemy12 };

                    Random rand = new Random();
                    int randomNbr = rand.Next(enemies.Length);

                    Enemy enemy = enemies[randomNbr];
                    #endregion
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    #region Stargazer graphic
                    Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                    #endregion
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine(GetPlanet());
                    Console.WriteLine("Hostile Forces:");
                    Console.WriteLine($"{enemy.Name}\tHealth: {enemy.Life}");

                    //Menu loop
                    bool reload = false;
                    do
                    {
                        
                        //menu of decisions on what to do next in the game
                        #region Menu
                        
                        Console.WriteLine("\nChoose your action, Captain:\nA) Attack\nF) FTL jump to the next planet\nI) Stargazer's info\nE) Scan Enemy Ship\n\nS) Shop\nR) Rules\nX) Exit");

                        //catch the user input
                        ConsoleKey userChoice = Console.ReadKey(true).Key;

                        //clear the console AFTER we get the input to refresh the screen
                        Console.Clear();


                        //switch for user choice
                        switch (userChoice)
                        {
                            #region Combat Case A
                            case ConsoleKey.A:
                                //Combat
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                #region Stargazer graphic
                                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                #endregion


                                Console.ResetColor();
                                Combat.DoBattle(player, enemy);
                                System.Threading.Thread.Sleep(700);
                                if (enemy.Life <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nYou killed {0}!\n", enemy.Name);
                                    Console.ResetColor();
                                    player.Life = player.MaxLife;
                                    player.Kills++;
                                    Random random = new Random();
                                    int randomCredts = random.Next(10, 51);
                                    player.Credits += randomCredts;
                                    int bonusCredits = 0;
                                    if (enemy == enemy3 || enemy == enemy4)
                                    {
                                        bonusCredits = 10;
                                    }
                                    if (enemy == enemy5 || enemy == enemy6)
                                    {
                                        bonusCredits = 20;
                                    }
                                    if (enemy == enemy7 || enemy == enemy8)
                                    {
                                        randomCredts += 30;
                                    }
                                    if (enemy == enemy9 || enemy == enemy10)
                                    {
                                        randomCredts += 40;
                                    }
                                    if (enemy == enemy11 || enemy == enemy12)
                                    {
                                        randomCredts += 50;
                                    }
                                    Console.WriteLine("{0} credits earned \n{1} Bonus credits", randomCredts, bonusCredits);
                                    switch (player.Kills)
                                    {
                                        case 5:
                                            player.MaxLife += 25;
                                            player.HitChance += 10;
                                            break;
                                        case 10:
                                            player.MaxLife += 25;
                                            player.HitChance += 10;
                                            break;
                                        case 15:
                                            player.MaxLife += 25;
                                            player.HitChance += 10;
                                            break;
                                    }
                                    Console.Write("\n\nPress any key to continue...");
                                    ConsoleKey continues = Console.ReadKey().Key;
                                    reload = true;
                                }
                                break;
                            #endregion
                            case ConsoleKey.F:
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                #region Stargazer graphic
                                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                #endregion
                                Console.ResetColor();
                                Console.Write("\n\nCharging FTL Jump Drive");//FTL charging effect
                                System.Threading.Thread.Sleep(900);
                                Console.Write(" . ");
                                System.Threading.Thread.Sleep(900);
                                Console.Write(" . ");
                                System.Threading.Thread.Sleep(900);
                                Console.Write(" .  ");
                                System.Threading.Thread.Sleep(900);
                                Console.WriteLine($"\n{enemy.Name} attacks you as you flee!");
                                Combat.EnemyFreeAttack(enemy, player); //Enemy free attack for fleeing
                                Console.WriteLine($"Stargazer's Health: {player.Life}");
                                Console.WriteLine("\nPress any key to continue...");
                                ConsoleKey go = Console.ReadKey().Key;
                                reload = true;
                                break;

                            case ConsoleKey.I:
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                #region Stargazer graphic
                                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                #endregion
                                Console.ResetColor();
                                Console.WriteLine(player);
                                break;

                            case ConsoleKey.E:
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                #region Stargazer graphic
                                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                #endregion
                                Console.ResetColor();
                                Console.WriteLine(enemy);
                                break;

                            case ConsoleKey.S://Shop menu
                                bool shop = false;
                                do
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    #region Stargazer graphic
                                    Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                    #endregion
                                    Console.ResetColor();
                                    int repairCost = player.MaxLife - player.Life;
                                    Console.WriteLine("\n\n   Shop   \t\tCredit Balance: {0}c\nR) Repair Ship: {1}c\nW) Weapons\nS) Shields\nB) Back", player.Credits, repairCost);
                                    ConsoleKey input = Console.ReadKey(true).Key;
                                    //shop Switch statement
                                    switch (input)
                                    {
                                        case ConsoleKey.R:
                                            Console.Clear();
                                            if (repairCost == 0)
                                            {
                                                Console.WriteLine();                                                
                                                Console.WriteLine("No repairs needed at this time.\n");
                                                shop = false;
                                                reload = false;
                                            }
                                            else if (player.Credits == 0)
                                            {
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Insuffient funds...");
                                                Console.ResetColor();
                                                shop = false;
                                            }
                                            else if (player.Credits < repairCost)
                                            {
                                                Console.WriteLine();                                                
                                                player.Life += player.Credits;
                                                player.Credits = 0;
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine("Ship Partially Repaired.");
                                                Console.ResetColor();
                                                shop = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine();                                                
                                                player.Credits -= repairCost;
                                                player.Life = player.MaxLife;
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Ship Fully Repaired.");
                                                Console.ResetColor();
                                                shop = false;

                                            }

                                            break;
                                        case ConsoleKey.W://Weapon selection menu
                                            bool weapon = false;
                                            do
                                            {

                                            
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                #region Stargazer graphic
                                            Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                            #endregion
                                                Console.ResetColor();
                                                Console.WriteLine("--Weapons--\tCredit Balance: {0}c\n", player.Credits);
                                                Console.WriteLine($"\nA) --Photon Cannon-----------------------------------\nPrice: 400c\tDamage: {photonCannon.MinDamage}-{photonCannon.MaxDamage}\tBonus Hit Chance: +{photonCannon.BonusHitChance}\n\n");
                                                Console.WriteLine($"B) --Plasma Bomb-------------------------------------\nPrice: 800c\tDamage: {plasmaBomb.MinDamage}-{plasmaBomb.MaxDamage}\tBonus Hit Chance: +{plasmaBomb.BonusHitChance}\n\n");
                                                Console.WriteLine($"C) --Matter Ripper-----------------------------------\nPrice: 1600c\tDamage: {matterRipper.MinDamage}-{matterRipper.MaxDamage}\tBonus Hit Chance: +{matterRipper.BonusHitChance}\n\n");
                                                Console.WriteLine($"D) --Star Destoyer-----------------------------------\nPrice: 3200c\tDamage: {starDestroyer.MinDamage}-{starDestroyer.MaxDamage}\tBonus Hit Chance: +{starDestroyer.BonusHitChance}\n\n\n\nPress Enter to go back..."); 
                                                ConsoleKey choice = Console.ReadKey(true).Key;
                                                //Weapon switch statement
                                                switch (choice)
                                                {
                                                    case ConsoleKey.A:
                                                        if (player.Credits >= 400)
                                                        {
                                                            Console.Clear();                                                        
                                                            player.Credits -= 400;
                                                            player.WeaponEquipped = photonCannon;
                                                            Console.WriteLine("Photon Cannon has been equipped to your ship");
                                                            shop = false;
                                                            weapon = true;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shop = false;
                                                            weapon = true;
                                                        }
                                                        break;
                                                    case ConsoleKey.B:
                                                        if (player.Credits >= 800)
                                                        {
                                                            Console.Clear();                                                       
                                                            player.Credits -= 800;
                                                            player.WeaponEquipped = plasmaBomb;
                                                            Console.WriteLine("Plasma Bomb has been equipped to your ship");
                                                            shop = false;
                                                            weapon = true;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shop = false;
                                                            weapon = true;
                                                        }
                                                        break;
                                                    case ConsoleKey.C:
                                                        if (player.Credits >= 1600)
                                                        {
                                                            Console.Clear();                                                        
                                                            player.Credits -= 1600;
                                                            player.WeaponEquipped = matterRipper;
                                                            Console.WriteLine("Matter Ripper has been equipped to your ship");
                                                            shop = false;
                                                            weapon = true;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shop = false;
                                                            weapon = true;
                                                        }
                                                        break;
                                                    case ConsoleKey.D:
                                                        if (player.Credits >= 3200)
                                                        {
                                                            Console.Clear();
                                                            shop = false;
                                                            weapon = true;
                                                            player.Credits -= 3200;
                                                            player.WeaponEquipped = starDestroyer;
                                                            Console.WriteLine("Star Destroyer has been equipped to your ship");           
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shop = false;
                                                            weapon = true;
                                                        }
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        Console.Clear();
                                                        shop = false;
                                                        weapon = true;
                                                        break;
                                                    default:
                                                        //Console.Clear();                                                      
                                                        Console.WriteLine("Could not compute response...");
                                                        shop = false;
                                                        weapon = true;
                                                        break;
                                                }
                                            } while (!weapon && !shop);
                                            break;
                                        //Shield selection menu
                                        case ConsoleKey.S:
                                            bool shield = false;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                #region Stargazer graphic
                                                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                                #endregion
                                                Console.ResetColor();
                                                Console.WriteLine("--Shields--\tCredit Balance: {0}c", player.Credits);
                                                Console.WriteLine("A) --Light Shield--\nPrice: 150c\tCapacity: 120\n\n" +
                                                    "B) --Medium Shield--\nPrice: 300c\tCapacity: 140\n\n" +
                                                    "C) --Heavy Shield--\nPrice: 600c\tCapacity: 160\n\n" +
                                                    "D) --XL Heavy Shield--\nPrice: 1200\tCapacity: 180\n\n\n\nPress Enter to go back...");
                                                ConsoleKey select = Console.ReadKey(true).Key;
                                                //Shield switch statement
                                                switch (select)
                                                {
                                                    case ConsoleKey.A:
                                                        if (player.Credits >= 150)
                                                        {
                                                            Console.Clear();
                                                            player.Credits -= 150;
                                                            player.Shield = 120;
                                                            Console.WriteLine("\nLight Shield has been equipped to your ship.");
                                                            shop = false;
                                                            shield = true;                                                            
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shop = false;
                                                            shield = true;
                                                        }
                                                        break;
                                                    case ConsoleKey.B:
                                                        if (player.Credits >= 300)
                                                        {
                                                            Console.Clear();
                                                            player.Credits -= 300;
                                                            player.Shield = 140;
                                                            Console.WriteLine("\nMedium Shield has been equipped to your ship.");
                                                            shop = false;
                                                            shield = true;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shield = true;
                                                            shop = false;
                                                        }
                                                        break;
                                                    case ConsoleKey.C:
                                                        if (player.Credits >= 600)
                                                        {
                                                            Console.Clear();
                                                            player.Credits -= 600;
                                                            player.Shield = 160;
                                                            Console.WriteLine("\nHeavy Shield has been equipped to your ship.");
                                                            shop = false;
                                                            shield = true;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shop = false;
                                                            shield = true;
                                                        }
                                                        break;
                                                    case ConsoleKey.D:
                                                        if (player.Credits >= 1200)
                                                        {
                                                            Console.Clear();
                                                            player.Credits -= 1200;
                                                            player.Shield = 180;
                                                            Console.WriteLine("\nXL Heavy Shield has been equipped to your ship.");
                                                            shop = false;
                                                            shield = true;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Insuffient funds...");
                                                            Console.ResetColor();
                                                            shop = false;
                                                            shield = true;
                                                        }
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        Console.Clear();
                                                        shop = false;
                                                        shield = true;
                                                        break;
                                                    default:
                                                        Console.Clear();
                                                        Console.WriteLine("Could not compute response...");
                                                        shop = false;
                                                        shield = true;
                                                        break;
                                                }
                                            } while (!shield && !shop);
                                            break;

                                        case ConsoleKey.B:
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            #region Stargazer graphic
                                            Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                            #endregion
                                            Console.ResetColor();
                                            shop = true;
                                            break;
                                        default:
                                            Console.Clear();
                                            shop = false;
                                            reload = false;
                                            Console.WriteLine("Could not compute response...");
                                            
                                            break;
                                    }
                                } while (!shop && !reload);
                            break;
                            case ConsoleKey.R://Rules for the game
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                #region Stargazer graphic
                                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                #endregion
                                Console.ResetColor();
                                Console.WriteLine("\t-Each attack (A) will determine if you break through the shield of the enemy\n" +
                                    "\tship and if the enemy breaks through your shield.\n\n" +
                                    "\t-Roll to hit is a random number from 10-200 + any bonuses you have.\n\n" +
                                    "\t-To hit your oppenent you must roll a number (+ any bonuses you have) higher than their shield value\n\n" +
                                    "\t-If you successfully break your oppenents shield, damage based on your weapon equipped \n" +
                                    "\twill be applied to the enemy ship's health. Once the enemy ship has 0 health remaining.\n" +
                                    "\tyou will gain a kill and credits will be transferred into your credit balance.\n\n" +
                                    "\t-Upon killing an enemy you will recieve full health.\n\n" +
                                    "\t-If the enemy depletes your health then the game will be over.\n\n" +
                                    "\t-Every 5 kills up to 15 you will gain +25 points of health and +10 to your hit chance.\n\n" +
                                    "\t-Once you get 40 kills you will win the game.\n\n" + 
                                    "\t-Credits earned can be spent in the shop to rapair or upgrade your ship\n\n" +
                                    "\t-Pressing F will FTL(Faster Than Light) jump you to another planet allowing the enemy \n" +
                                    "\tto get a free attack at +50%\n");
                                break;

                            case ConsoleKey.X:
                                Console.Clear();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                #region Stargazer graphic
                                Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                                #endregion
                                Console.ResetColor();
                                Console.WriteLine("\t\t\t\t\t    The galaxy has been lost...\n\n\n");
                                exitGame = true;
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Could not compute response...");
                                break;
                        }
                        #endregion
                       

                        //check the player life and update loop
                        if (player.Life <= 0)
                        {
                            System.Threading.Thread.Sleep(100);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            #region ascii art
                            Console.WriteLine(@"**
   *'       *       .  *   '.           * *
                                                               '
       * *'          *          *        '
   .           *               |               /
               '.         |    |      ' | '     *
                 \*        \   \             /
       '          \     ' * |    | *        | ***
            *      `.       \   | *     / *'
  .                  \      |   \          / *
     *'  *     '      \      \   '.       |
        -._            `                  / *
  ' '      ``._ * '          .      '
   * *\** .   .      *
*'        *    `-._                       .         _..:=' *
             .  '      *       *    *   .       _.:--'
          *           .     .     *         .- '         *
   .               '             . ' * *         .
  * ___.-= --..-._ * '               '
                                  * *
                *_.'  .'       `.        '  *             *
     * *_.- '   .'            `.               *
                   .'                       `._             *  '
   '       '.       .  `.     .
       .                      *                  `
               *'             '.
     .                          *        .           * *
             *        .                                    '");
                            #endregion
                            Console.ResetColor();
                            Console.WriteLine("---===::::Stargazer has been destroyed::::===---\n\n");
                            Console.WriteLine("Press any key to play again");
                            ConsoleKey playAgain = Console.ReadKey().Key;
                            Console.Clear();
                            exit = true;
                        }

                    } while (!reload && !exit && !exitGame);

                    //Ending the game
                    if (player.Kills == 40)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        #region Stargazer graphic
                        Console.WriteLine(@"                  '    ,                  _                                                      ,   '
	     .	  !               ____  _| |_  __ _ _ __   ____  __ _ _____ ___  _ __               !  .      
     , 	 '     ;  | '   + <======/  __\|_   _|/ _` | ',_\ / _  |/ _` |\_  // _ \| ',_\======> +   ' | ;   .   '  ,
      -  !  - ---(o',-- --=======\__  \  | | | (_| | |   | |_| | (_| | / /_  __/| |==========-- -- (o',--- -  ! - 
    -  -(+ - - .  |  ,      <====|____/  |_|  \__,_|_|    \__, |\__,_|/____\___||_|=======>      ,  |  .  - -(+ - -
         :        !     -- + -                             __/ |                         - + --     !         :
	 .   ,	  :    '   !  .        	                  /___/                         .  !    '   :     ,   .
                  .                                                                                 .");
                        #endregion
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t   The Galaxy is now safe! Thank you for your support, Captain.\n\n\n\n\n\n\n\n\n");
                        exitGame = true;
                    }

                } while (!exit && !exitGame);//while exit is NOT TRUE, keep looping
                #endregion

            } while (!exitGame);

        }//end Main()

        //Function to randomize a planet
        #region GetPlanet()
        private static string GetPlanet()
        {
            string[] planets =
                {
                    "Planet: Ariad\n",

                    "Planet: Priyut\n",

                    "Planet: Terrene\n",

                    "Planet: Maruchikara\n",

                    "Planet: Susumna\n",

                    "Planet: Thorhild\n",

                    "Planet: Carinus\n",

                    "Planet: Vesna\n",
                };

            Random rand = new Random();

            int indexNbr = rand.Next(planets.Length);

            string planet = planets[indexNbr];

            return planet;
        }
        #endregion
    
    }//end class
}//end namespace
