﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    [Serializable]
    public abstract class Item
        {
        public int Id { get; private set; }
        public int Value { get; private set; }
        public int Name { get; private set; }
        }
    }
