using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    /// <summary>
    /// Weapon used by a creature to atack other creatures.
    /// </summary>
    [Serializable]
    public class Weapon: Item,IEquipable
        {
        /// <summary>
        /// Damage dealt by a succesful attack, depends on the Strenght of a creature
        /// </summary>
        public int Damage { get; private set; }
        private int _baseDamage;
        private int _range;
        private double _scaling;
        public void Equip(Creature a)
            {
            a.weapon=this;
            Damage=_baseDamage+(int)((double)(a.Strenght)*_scaling);
            }
        public void Unequip(Creature a)
            {
            if(a.weapon.Id==1)
                {
                return;
                }
            else if(a.weapon==this)
                {
                a.weapon=null;
                }
            }
        }
    }
