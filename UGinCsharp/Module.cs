using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    public class Perk : Item, IEquipable
        {
        public void Equip(Creature a)
            {
            a.Upgrades.Add(this);
            }
        public static ushort Type { get; private set; }
        }
    }
