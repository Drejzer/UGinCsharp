using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UGCli
    {
    public enum TypeOfCell:byte {Generic, Special, Loot};
    /// <summary>
    /// Tile
    /// </summary>
    public abstract class CellType:IDBGeneratable
        {
        /// <summary>
        /// ID, used by database
        /// </summary>
        public int CellTypeID { get; set; }
        /// <summary>
        /// Determines type of the cell
        /// </summary>
        public TypeOfCell Type { get; set; }
        /// <summary>
        /// Holds information if the cell can be entered
        /// </summary>
        public bool IsEnterable { get; set; }
        /// <summary>
        /// the way the cell is displayed on map
        /// </summary>
        public char Representation { get; set; }
        /// <summary>
        /// Instances of a tile (DBstufff)
        /// </summary>
        public virtual ICollection<CellInstance> TileInstances { get; set; }
        public void GenerateFromDB()
            {

            }
        }
    }
