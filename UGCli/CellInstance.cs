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
        public int PosX { get; set; }
        public int PosY { get; set; }
        /// <summary>
        /// Type of cell represented by this particular instance
        /// </summary>
        public CellType cellType { get; set; }
        /// <summary>
        /// reference to a room, in which this tile exists
        /// </summary>
        public Room room { get; set; }
        /// <summary>
        /// informatoin about the presence of a creature in this tile
        /// </summary>
        public bool IsOccupied { get; set; }
        /// <summary>
        /// reference to a creature occupying the cell
        /// </summary>
        public Creature Occupant { get; set; }
        public CellInstance()
            {
            cellType=new GenericCell();
            }

        public CellInstance(int X, int Y,Room _R, TypeOfCell t=0,int r=0)
            {
            PosX=X;
            PosY=Y;
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
        /// <summary>
        /// Turns a wall into passable space
        /// </summary>
        public void DigThrough()
            {
            GameHandler.State.Player.ModEnergy(-1);
            cellType=new GenericCell(2);
            GameHandler.State.Player.PickLoot(new Gem(GameHandler.roller.Next(1,100)));
            }
        }
    }
