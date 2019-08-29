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
        public int Id { get; private set; }
        public String Name { get; private set; }

        public Item()
            {
            Id=-1;
            Name="Placeholder";
            }
        public abstract void GeneratefromDB();
        }
    }
