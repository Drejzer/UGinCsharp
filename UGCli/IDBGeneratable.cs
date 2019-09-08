using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    interface IDBGeneratable
        {
        /// <summary>
        /// Generates from the database, used to load saved gamestate
        /// </summary>
        void GenerateFromDB();
        }
    }
