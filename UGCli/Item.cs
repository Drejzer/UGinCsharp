using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    /// <summary>
    /// Base class for all kinds of loot
    /// </summary>
    [Serializable]
    public abstract class Item
        {
        public int ItemID { get; protected set; }
        public String Name { get; protected set; }
        /// <summary>
        /// Value in points
        /// </summary>
        public int Value { get; protected set; }
        }
    }
