using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    /// <summary>
    /// Player Character
    /// </summary>
    [Serializable]
    public class Hero:Creature,IMobile
        {
        public Hero()
            {
            int tmp = 8;
            Strenght=1+GameHandler.roller.Next()%tmp;
            tmp-=(Strenght-1);
            Agility=1+GameHandler.roller.Next()%tmp;
            tmp-=(Agility-1);
            Vitality=1+GameHandler.roller.Next()%tmp;
            tmp-=(Vitality-1);
            Magic=1+GameHandler.roller.Next()%tmp;
            
            }

        /// <summary>
        /// Awaits interaction with UI
        /// </summary>
        public override int Action()
            {
            throw new NotImplementedException();
            }

        public int Move(int x,int y)
            {
            throw new NotImplementedException();
            }

        }
    }
