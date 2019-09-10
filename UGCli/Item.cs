using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;

namespace UGCli
    {
    /// <summary>
    /// Base class for all kinds of loot
    /// </summary>
    [Serializable]
    public abstract class Item
        {
        /// <summary>
        /// identifier of the item
        /// </summary>
        public int ItemID { get;  set; }
        /// <summary>
        /// name of the item
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Value in points
        /// </summary>
        public int Value { get; set; }
        public Creature Owner { get; set; }
        }
    }
