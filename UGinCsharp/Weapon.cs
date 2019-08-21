using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    public class Weapon: Item,IEquipable
        {
        public int Damage { get; private set; }
        private int _baseDamage;
        private double _scaling;
        public static ICollection<Creature> Creatures;
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
