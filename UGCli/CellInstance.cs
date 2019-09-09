using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public class CellInstance
        {
        public int CellInstanceID { get; set; }
        public event EventHandler<CorpseArgs> DiggedThrough;
        /// <summary>
        /// Posiotion of a Tile instance within a Room
        /// </summary>
        public (int X, int Y) Pos;
        public CellType cellType;
        /// <summary>
        /// reference to a room, in which this tile exists
        /// </summary>
        public Room room;
        /// <summary>
        /// informatoin about the presence of a creature in this tile
        /// </summary>
        public bool IsOccupied;
        /// <summary>
        /// reference to a creature occupying the cell
        /// </summary>
        public Creature Occupant;
        public CellInstance()
            {
            cellType=new GenericCell();
            }

        public CellInstance(int X, int Y,Room _R, TypeOfCell t=0,int r=0)
            {
            Pos.X=X;
            Pos.Y=Y;
            room=_R;
            IsOccupied=false;
            Occupant=null;
            switch(t)
                {
                case TypeOfCell.Generic:
                        {
                        cellType=new GenericCell(r);
                        break;
                        }
                case TypeOfCell.Special:
                        {
                        break;
                        }

                }
            
            }
        public void DigThrough()
            {
            GameHandler.State.Player.ModEnergy(-1);
            cellType=new GenericCell(2);
            GameHandler.State.Player.PickLoot(new Gem(GameHandler.roller.Next(1,100)));
            }
        }
    }
