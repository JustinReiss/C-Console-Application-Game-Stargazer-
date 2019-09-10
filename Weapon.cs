using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Weapon
    {
        //fields
        private int _minDamage;

        //properties
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public decimal BonusHitChance { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than MaxDamage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //less than max and greater than 0, so let it pass
                    _minDamage = value;
                }
                else
                {
                    //tried to set the value outside of the range
                    _minDamage = 1;
                }
            }
        }

        //ctors
        public Weapon(int maxDamage, int minDamage, string name, decimal bonusHitChance)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
        }

        //methods
        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0}\t{1} to {2} Damage\nWeapon Bonus Hit: +{3}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance);
        }

    }//end class
}//end namespace
