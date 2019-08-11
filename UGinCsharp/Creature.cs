using System;
using System.Collections.Generic;

namespace UGinCsharp
    {
    /// <summary>
    /// Parent class for all enemies and player characters.
    /// Contains basic statistics shared by all, as well as required 
    /// </summary>
    public abstract class Creature
        {
        /// <summary>
        /// Type, designates what kind of creature it is, for storage and database interaction
        /// </summary>
        private static readonly int Type = 0;
        /// <summary>
        /// Influences Damage and carrying capcity (TODO)
        /// </summary>
        public int Strenght { get; private set; }
        /// <summary>
        /// To-hit, Defense, order of actions
        /// </summary>
        public int Agility { get; private set; }
        /// <summary>
        /// Energy Reserves and Perk Capacity
        /// </summary>
        public int Magic { get; private set; }
        /// <summary>
        /// Health and general surivability
        /// </summary>
        public int Vitality { get; private set; }
        /// <summary>
        /// movement speed in time per tile;<br/>
        /// negative means the creature is immobile;<br/>
        /// </summary>
        private int BaseSpeed;
        private int BaseRange;
        private int BaseHP;
        private int BaseEn;
        private int BaseSt;
        private int BaseDmg;
        /// <summary>
        /// range of basic attacks 
        /// </summary>
        public int Range { get; private set; }
        public int Damage { get; private set; }
        public int MaxHealth { get; private set; }
        public int Health { get; private set; }
        public int MaxEnergy { get; private set; }
        public int Energy { get; private set; }
        public int MaxStamina { get; private set; }
        public int Stamina { get; private set; }
        /// <summary>
        /// Holds upgrades to a Creature (special attacks, or other qualities) and information on its state
        /// </summary>
        public ICollection<(Perk P, bool active)> Upgrades;
        /// <summary>
        /// Logic of the AI, and in case of players: control of a Creature
        /// </summary>
        public abstract void Action();
        }
    }
