using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 10-200
            //This random number is simulating a dice roll in the game
            Random rand = new Random();
            int diceRoll = rand.Next(10, 201);
            System.Threading.Thread.Sleep(700);
            if (diceRoll + attacker.HitChance >= defender.CalcShield())
            {
                //when the attacker landded a successful attack on the defender
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //write the results to the screen
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.WriteLine($"Health remaining:\t{attacker.Life}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
                Console.WriteLine($"Health remaining:\t{attacker.Life}");
            }
        }

        public static void DoBattle(Player player, Enemy enemy)
        {
            //player gets to attack first
            DoAttack(player, enemy);

            //monster attacks second if they are alive
            if (enemy.Life > 0)
            {
                DoAttack(enemy, player);
            }
           
        }

        public static void EnemyFreeAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100
            //This random number is simulating a dice roll in the game
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(1000);
            if ((diceRoll + attacker.HitChance) * 1.5m >= defender.CalcShield())
            {
                //when the attacker landded a successful attack on the defender
                int damageDealt = attacker.CalcDamage() / 2;

                //assign the damage
                defender.Life -= damageDealt;

                //write the results to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }

     

    }//end class
}//end namespace
