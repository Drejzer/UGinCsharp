using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public class CorpseArgs:EventArgs
        {
        public Creature Corpse;
        public CorpseArgs(Creature C)
            {
            Corpse=C;
            }
        }
    }
