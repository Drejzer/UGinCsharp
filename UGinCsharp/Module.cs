using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    class Module : Item, IEquipable
        {
        private ICollection<Perk> Perks;
        public void Equip(Creature a)
            {
            foreach (Perk i in Perks)
                {
                i.Activate(a);
                }
            }
        public void Unequip(Creature a)
            {
            foreach(Perk i in Perks)
                {
                i.Deactivate(a);
                }
            }
        }
    }
