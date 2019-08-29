using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UGCli
    {
    /// <summary>
    /// Tile
    /// </summary>
    public class TileType
        {
        /// <summary>
        /// ID, used by database, determines type of
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Determines if a creature can enter the tile.
        /// </summary>
        public bool IsEnterable { get; private set; }
        /// <summary>
        /// location of the image used to display teh tile
        /// </summary>
        private string _imgSrc;
        /// <summary>
        /// Instances of a tile (DBstufff)
        /// </summary>
        public virtual ICollection<TileInstance> TileInstances { get; set; }

        public TileType()
            {
            Id=0;
            IsEnterable=false;
            _imgSrc="..\\..\\PHtile1.png";
            }
        }
    }
