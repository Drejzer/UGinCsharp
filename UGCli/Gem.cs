using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    class Gem:Item
        {
        public Gem(int i=1)
            {
            Name="Shiny Thingy";
            ItemID=i;
            Value=i*10;
            }
        }
    }
