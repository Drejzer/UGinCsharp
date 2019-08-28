using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    interface ICombatant
        {
        bool Attack((int x, int y) pos);
        }
    }
