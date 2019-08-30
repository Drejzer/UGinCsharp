using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UGCli
    {
    public enum TypeOfCell:byte {Generic,Entrance,Exit,Item,Heal};
    /// <summary>
    /// Tile
    /// </summary>
    public class CellType
        {
        /// <summary>
        /// ID, used by database
        /// </summary>
        public int Id { get; protected set; }
        /// <summary>
        /// Determines type of the cell
        /// </summary>
        public TypeOfCell Type { get; protected set; }
        public bool IsEnterable;
        public char Representation;
        /// <summary>
        /// Instances of a tile (DBstufff)
        /// </summary>
        public virtual ICollection<CellInstance> TileInstances { get; set; }

        public CellType(TypeOfCell toc=0)
            {
            Id=0;
            Type=toc;
            IsEnterable=true;
            Representation=' ';
            }
        }
    }
