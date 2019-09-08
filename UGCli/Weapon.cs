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
        public int Damage { get; private set; }
        protected int _baseDamage;
        protected double _scaling;
        protected int _speed;
        public Creature User;

        public Weapon(int i=0)
            {
            Id=1000+i;
            Name="Basic Attack";
            _baseDamage=1;
            _scaling=0.1;
            _speed=700;
            Value=0;
            }
        
        public void Equip(Creature a)
            {
            User=a;
            a.weapon=this;
            Damage=_baseDamage+(int)((double)(a.Strenght)*_scaling);
            }
        public void Unequip(Creature a)
            {
            if(a.weapon.Id==1)
                {
                return;
                }
            else if(a.weapon==this)
                {
                }
            }
        public int GetAttackTime()
            {
            return _speed-(User.Strenght);
            }
        public int ResolveAttack()
            {
            throw new NotImplementedException();
            }
        public void GenerateFromDB()
            {
#warning finish dat
            }
        }
    }
