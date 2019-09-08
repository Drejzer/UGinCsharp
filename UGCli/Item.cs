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
        public int Id { get; protected set; }
        public String Name { get; protected set; }
        public int Value { get; protected set; }

        public Item()
            {
            Id=-1;
            Name="Placeholder";
            }
        }
    }
