using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    interface ICombatant
        {
        bool Attack((int x, int y) pos);
        }
    }
