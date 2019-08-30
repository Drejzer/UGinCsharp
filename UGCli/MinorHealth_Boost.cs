using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    /// <summary>
    /// Increases Health
    /// </summary>
    class MinorHealth_Boost:Perk
        {
        public override void Activate(Creature kappa)
            {
            kappa.HealthBonus+=5;
            }
        public override void Deactivate(Creature kappa)
            {
            kappa.HealthBonus-=5;
            }
        }
    }
