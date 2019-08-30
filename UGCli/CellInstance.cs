using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public class CellInstance
        {
        /// <summary>
        /// Posiotion of a Tile instance within a Room
        /// </summary>
        public (int X, int Y) Pos;
        public CellType cellType;
        public Room room;
        public bool IsOccupied;
        public Creature Occupant;
        public CellInstance()
            {
            cellType
            }

        public CellInstance(int X, int Y)
            {
            Pos.X=X;
            Pos.Y=Y;
            //room=GameHandler.State._Room;
            IsOccupied=false;
            Occupant=null;
            cellType=new CellType();
            }
        }
    }
