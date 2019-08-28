using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public class TileInstance
        {
        /// <summary>
        /// Posiotion of a Tile instance within a Room
        /// </summary>
        public (int X, int Y) Pos;
        public TileType tileType;
        public Room room;
        }
    }
