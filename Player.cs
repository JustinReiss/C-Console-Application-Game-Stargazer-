using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Player : Character
    {

        //fields




        //properties
        public int Kills { get; set; }
        public int Credits { get; set; }


        //ctor
        public Player(int maxLife, int life, string name, decimal hitChance, int shield, Weapon weaponEquipped, int kills, int credits) : base (maxLife, life, name, hitChance, shield, weaponEquipped)
        {
            Kills = kills;
            Credits = credits;
        }

        //method

        public override string ToString()
        {
            return string.Format("---- {0} ---- \nHealth: {1} of {2}\nHit Chance: +{3}\nShield: {4}\nWeapon Engaged: {5}\nKills: {6}\nCredit Balance: {7}c",
              Name,
              Life,
              MaxLife,
              HitChance,
              Shield,
              WeaponEquipped,
              Kills,
              Credits);
        }


    }//end class
}//end namespace
