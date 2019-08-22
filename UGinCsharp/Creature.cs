using System;
using System.Collections.Generic;

namespace UGinCsharp
    {
    /// <summary>
    /// Parent class for all enemies and player characters.
    /// Contains basic statistics shared by all, as well as required 
    /// </summary>
    [Serializable]
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
        private int _baseSpeed;
        private int _baseHealth;
        private int _baseEnergy;

        public int MaxHealth { get; private set; }
        public int Health { get; private set; }
        public int MaxEnergy { get; private set; }
        public int Energy { get; private set; }
        public short Facing { get; private set; }
        public double SpeedBonus { get; private set; }
        public double EnergyBonus { get; private set; }
        public double HealthBonus { get; private set; } 
        /// <summary>
        /// The coordinates of a creature within a Room
        /// </summary>
        public (int x, int y) Position { get; private set; }
        public Weapon weapon;
        /// <summary>
        /// Holds Special attacks or other such options
        /// </summary>
        public ((bool IsSloted, Item Mod) first, (bool IsSloted, Item Mod) second, (bool IsSloted, Item Mod) third, (bool IsSloted, Item Mod) fourth, (bool IsSloted, Item Mod) fifth) Upgrades { get; set; }
        /// <summary>
        /// Logic of the AI, and in case of players: control of a Creature<br/>
        /// Returns time necesary to complete the action to complete the action
        /// </summary>
        public abstract int Action();
        /// <summary>
        /// Modifies Health by specified value
        /// returns false if the Creature recieved lethal damage<br/>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool ModHealth(int a)
            {
            Health+=a;
            
            return (Health>0);
            }
        /// <summary>
        /// modifies the energy by specified value
        /// </summary>
        /// <param name="a"></param>
        public void ModEnergy(int a)
            {
            Energy+=a;
            Energy=Math.Min(Energy,MaxEnergy);
            Energy=Math.Max(Energy,0);
            }
        /// <summary>
        /// Calculates stats based on equipped items, and V/A/M/S
        /// </summary>
        private void Recalc()
            {
            _baseHealth=15+5*Vitality;
            _baseEnergy=5*Magic;
            MaxHealth=(int)(((double)_baseHealth)*HealthBonus);
            MaxEnergy=(int)(((double)_baseEnergy)*EnergyBonus);
            }
        }
    }
