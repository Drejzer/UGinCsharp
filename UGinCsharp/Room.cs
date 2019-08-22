using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    class Room
        {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public ICollection<ICollection<TileInstance> > Tiles;
        }
    }
