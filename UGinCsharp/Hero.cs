using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    /// <summary>
    /// Player Character
    /// </summary>
    [Serializable]
    public class Hero:Creature,IMobile
        {
        /// <summary>
        /// Awaits interaction with UI
        /// </summary>
        public override int Action()
            {
            throw new NotImplementedException();
            }

        public int Move()
            {
            throw new NotImplementedException();
            }

        public int Rotate()
            {
            throw new NotImplementedException();
            }
        }
    }
