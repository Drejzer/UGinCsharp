using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public class Module : Item, IEquipable, IDBGeneratable
        {

        public ICollection<Perk> Perks { get; set; }
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
        public void GenerateFromDB()
            {
            throw new NotImplementedException();
            }
        }
    }
