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
    class Hero:Creature,IMobile
        {
        /// <summary>
        /// Awaits interaction with UI
        /// </summary>
        public override void Action()
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
