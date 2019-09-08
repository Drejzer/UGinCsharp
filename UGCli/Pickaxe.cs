using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public class Pickaxe:Weapon
        {
        protected double _UntillScalingUpgrade;
        protected int _UntillBaseDamageUpgrade;


        public Pickaxe():base()
            {
            Name="Pickaxe";
            _scaling=1;
            _baseDamage=3;

            }

        }
    }
