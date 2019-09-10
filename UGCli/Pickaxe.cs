using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {/// <summary>
    /// special weapon of teh player character, can be upgraded (not implemented )
    /// </summary>
    public class Pickaxe:Weapon
        {
        protected double _UntillScalingUpgrade;
        protected int _UntillBaseDamageUpgrade;
        protected int _UntilSpeedUpgrade;


        public Pickaxe():base()
            {
            ItemID+=1000;
            Name="Pickaxe";
            _scaling=1;
            _baseDamage=3;
            _UntillScalingUpgrade=_scaling;
            _UntillBaseDamageUpgrade=_baseDamage;

            }

        }
    }
