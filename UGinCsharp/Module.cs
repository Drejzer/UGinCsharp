using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    public class Module : Item, IEquipable<Creature>
        {
        private Perk Upgrade;
        public void Equip(Creature a)
            {
            a.Upgrades.Add((Upgrade,false));
            }

        public void Unequip(Creature a)
            {
            if(a.Upgrades.Contains((Upgrade, true)))
                {
                }
            a.Upgrades.Remove((Upgrade, false));
            }
        }
    }
