using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UGCli
    {
    /// <summary>
    ///A generic type of upgrades 
    /// </summary>
    [Serializable]
    public abstract class Perk
        {
        /// <summary>
        /// Identifier of a perk, (DB stuff)
        /// </summary>
        public int PerkID { get; private set; }
        /// <summary>
        /// name of a perk
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// verbal description of a perk
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// DB connection
        /// </summary>
        public virtual ICollection<Module> Modules { get; set; }
        /// <summary>
        /// Applies the effets of a perk to a creature
        /// </summary>
        /// <param name="kappa"></param>
        public abstract void Activate(Creature kappa);
        /// <summary>
        /// removes the effects of a perk from a creacute
        /// </summary>
        /// <param name="kappa"></param>
        public abstract void Deactivate(Creature kappa);


        }
    }
