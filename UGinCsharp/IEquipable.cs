﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    interface IEquipable
        {
        void Equip(Creature a);
        void Unequip(Creature a);
        }
    }
