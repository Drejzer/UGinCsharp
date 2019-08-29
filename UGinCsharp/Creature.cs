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
        private static  int Type = 0;
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
        private int _baseSpeed;
        private int _baseHealth;
        private int _baseEnergy;

        /// <summary>
        /// Maximal amount of Health of a creature
        /// </summary>
        public int MaxHealth { get; private set; }
        /// <summary>
        /// current health of a creature
        /// </summary>
        public int Health { get; private set; }
        /// <summary>
        /// Maximal amount of energy of a creature 
        /// </summary>
        public int MaxEnergy { get; private set; }
        /// <summary>
        /// current Energy of a creature
        /// </summary>
        public int Energy { get; private set; }
        public int Speed { get;  }
        /// <summary>
        /// Affects movement speed of the creature
        /// </summary>
        public double SpeedBonus { get; set; } = 1;
        /// <summary>
        /// The multiplier of the MaxEnery property
        /// <br/> default value is 1
        /// </summary>
        public double EnergyBonus { get; set; } = 1;
        /// <summary>
        /// The multiplier of the MaxHelth property
        /// <br/> default value is 1
        /// </summary>
        public double HealthBonus { get; set; } = 1; 
        /// <summary>
        /// The coordinates of a creature within a Room
        /// </summary>
        public (int x, int y) Position { get; set; }
        /// <summary>
        /// Weapon used by a creature,
        /// </summary>
        public Weapon weapon;
        /// <summary>
        /// Holds Special attacks or other such options
        /// </summary>
        public ((bool IsSloted, Module Mod) first, (bool IsSloted, Module Mod) second, (bool IsSloted, Module Mod) third, (bool IsSloted, Module Mod) fourth, (bool IsSloted, Module Mod) fifth) Upgrades { get; set; }

        /// <summary>
        /// Logic of the AI, and in case of players: control of a Creature<br/>
        /// Returns time necesary to complete the action to complete the action
        /// </summary>
        public abstract int Action();
        /// <summary>
        /// Modifies Health by specified value <paramref name="a"/>
        /// <br/> returns false if the Creature recieved lethal damage<br/>
        /// </summary>
        /// <param name="a"></param>
        public bool ModHealth(int a)
            {
            Health+=a;
            
            return (Health>0);
            }
        /// <summary>
        /// Modifies the energy by <paramref name="value"/>
        /// </summary>
        public void ModEnergy(int value)
            {
            Energy+=value;
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
