using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Enemy : Character
    {

        //fields

        //properties
        public string Description { get; set; }

        //ctor
        public Enemy(int maxLife, int life, string name, string description, decimal hitChance, int shield, Weapon weaponEquipped): base (maxLife, life, name, hitChance, shield, weaponEquipped)
        {
            Description = description;
        }
        
        //methods
        


    }//end class
}//end namespace
