using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    interface IEquipable<T>
        {
        void Equip(T a);
        void Unequip(T a );
        }
    }
