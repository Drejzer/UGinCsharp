using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    public class Weapon: Item,IEquipable
        {
        public void Equip(Creature a)
            {
            a.weapon=this;
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
