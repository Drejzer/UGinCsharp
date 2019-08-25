using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    /// <summary>
    /// Holds the structure of a single level
    /// </summary>
    [Serializable]
    public class Room
        {
        /// <summary>
        /// Describes the width of the room
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Describes the height of the room
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// holds the layout of the room<br/>
        /// </summary>
        public ICollection<ICollection<TileInstance>> Tiles { get; private set; }

        }
    }
