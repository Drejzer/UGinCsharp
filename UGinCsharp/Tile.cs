using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UGinCsharp
    {
    /// <summary>
    /// Tile
    /// </summary>
    public class TileType
        {
        /// <summary>
        /// ID, used by database, determines type of
        /// </summary>
        public static int Id { get; private set; }
        /// <summary>
        /// location of the image used to display teh tile
        /// </summary>
        #warning "remember to add some placeholders"
        private string _imgSrc;
        public virtual ICollection<TileInstance> TileInstances;
        }
    }
