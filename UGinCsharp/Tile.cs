using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UGinCsharp
    {
    abstract public class Tile
        {
        /// <summary>
        /// ID, used by database, determines type of
        /// </summary>
        public static int Id { get; } = 0;
        }
    }
