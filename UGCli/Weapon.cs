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
        public Creature User;

        public Weapon(Creature u,int i=0)
            {
            Id=1000+i;
            Name="Basic Attack";
            _baseDamage=1;
            _scaling=0.1;
            _speed=700;
            Value=0;
            User=u;
            }
        
        public int GetSpeed()
            {
            return _speed-(User.Strenght);
            }
        public int ResolveDamage()
            {
            return _baseDamage+(int)(User.Strenght*_scaling);
            }
        public void GenerateFromDB()
            {
#warning finish dat
            }
        }
    }
