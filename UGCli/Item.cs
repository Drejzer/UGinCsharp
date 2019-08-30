using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    [Serializable]
    public abstract class Item
        {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; protected set; }
        public String Name { get; protected set; }

        public Item()
            {
            Id=-1;
            Name="Placeholder";
            }
        }
    }
