using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    /// <summary>
    /// Weapon used by a creature to atack other creatures.
    /// </summary>
    [Serializable]
    public class Weapon: Item,IDBGeneratable
        {
        /// <summary>
        /// Damage dealt by a succesful attack, depends on the Strenght of a creature
        /// </summary>
        protected int _baseDamage;
        protected double _scaling;
        protected int _speed;

        public Weapon(int i=0)
            {
            ItemID=1000+i;
            Name="Basic Attack";
            _baseDamage=1;
            _scaling=0.1;
            _speed=700;
            Value=0;
            }
        
        /// <summary>
        /// obsolete
        /// </summary>
        /// <returns></returns>
        public int GetSpeed()
            {
            return _speed;
            }
        /// <summary>
        /// Returns amount of damage the weapon is capable of dealing, based on user's and weapon's stats
        /// </summary>
        /// <returns></returns>
        public int ResolveDamage(Creature User)
            {
            return _baseDamage+(int)(User.Strenght*_scaling);
            }
        /// <summary>
        /// TBD: Loading Weapon from database
        /// </summary>
        public void GenerateFromDB()
            {
#warning finish dat
            }
        }
    }
