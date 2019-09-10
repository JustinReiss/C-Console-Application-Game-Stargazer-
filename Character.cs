using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Character
    {
        //fields
        private int _life;



        //properties
        public int MaxLife { get; set; }
        public string Name { get; set; }
        public decimal HitChance { get; set; }
        public int Shield { get; set; }
        public Weapon WeaponEquipped { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = 1;
                }
            }
        }


        //ctor
        public Character(int maxLife, int life, string name, decimal hitChance, int shield, Weapon weaponEquipped)
        {
            MaxLife = maxLife;
            Life = life;
            Name = name;
            HitChance = hitChance;
            Shield = shield;
            WeaponEquipped = weaponEquipped;

        }


        //method
        public override string ToString()
        {
            return string.Format("---- {0} ---- \nHealth: {1} of {2}\nHit Chance: +{3}\nShield: {4}\nWeapon Engaged: {5}",
               Name,
               Life,
               MaxLife,
               HitChance,
               Shield,
               WeaponEquipped);
        }

        public virtual int CalcShield()
        {
            //The virtual keyword allows child classed to override this but they dont have to. If this is not overridden in a child class then the child will use the bas functionality below.
            return Shield;

        }

        public int CalcDamage()
        {
            //return base.CalcDamage(); this would return 0

            //Create a Random object
            Random rand = new Random();

            //determine damage
            int damage = rand.Next(WeaponEquipped.MinDamage, WeaponEquipped.MaxDamage + 1);

            return damage;
        }

        public decimal CalcHitChance()
        {
            return HitChance + WeaponEquipped.BonusHitChance;
        }
    }
}
