using System;
using System.Collections.Generic;

namespace UGCli
    {
    /// <summary>
    /// Parent class for all enemies and player characters.
    /// Contains basic statistics shared by all, as well as common methods
    /// </summary>
    [Serializable]
    public abstract class Creature
        {
        public event EventHandler OnHealthChanged, OnLevelUP, OnRecalc,OnEnergyChanged;

        /// <summary>
        /// Name of the Creture
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// Designates power of a creature, Affects Health and Enegry
        /// </summary>
        public int Level { get; protected set; }
        protected int _xpToNextLvl;
        /// <summary>
        /// Influences Damage and carrying capcity (TODO)
        /// </summary>
        public int Strenght { get; protected set; }
        /// <summary>
        /// To-hit, Defense, order of actions
        /// </summary>
        public int Agility { get; protected set; }
        /// <summary>
        /// Energy Reserves
        /// </summary>
        public int Magic { get; protected set; }
        /// <summary>
        /// Health and general surivability
        /// </summary>
        public int Vitality { get; protected set; }
        protected int _baseHealth;
        protected int _baseEnergy;
        /// <summary>
        /// What character is used to display this creature
        /// </summary>
        public char Representation { get; protected set; }

        protected int _baseAtack;
        protected int _baseDefense;
        public int AtkBonus { get; set; }
        public int DefBonus { get; set; }
        public int MaxHealth { get; protected set; }
        public int Health { get; protected set; }
        public int MaxEnergy { get; protected set; }
        public int Energy { get; protected set; }
        public double SpeedBonus { get; protected set; }
        public int EnergyBonus { get; set; }
        public int HealthBonus { get; set; } 
        /// <summary>
        /// The coordinates of a creature within a Room
        /// </summary>
        public (int x, int y) Position { get; protected set; }
        public Weapon weapon;
        /// <summary>
        /// Holds loot dropped at death
        /// </summary>
        public Item Loot;
        /// <summary>
        /// Logic of the AI<br/>
        /// In case of players, interaction logic
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
            OnHealthChanged(this,EventArgs.Empty);
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
            OnEnergyChanged(this,EventArgs.Empty);
            }
        /// <summary>
        /// Calculates stats based on equipped items, and V/A/M/S
        /// </summary>
        protected void Recalc()
            {
            int prevHP = MaxHealth, prevE = MaxEnergy;
            MaxHealth=_baseHealth*(1+Level)+HealthBonus;
            MaxEnergy=_baseEnergy*(1+Level)+EnergyBonus;
            ModEnergy(MaxEnergy-prevE);
            ModHealth(MaxHealth-prevHP);
            }
        public virtual void LevelUp()
            {
            if(_xpToNextLvl>0)
                {
                return;
                }
            else
                {
                ++Level;
                _xpToNextLvl+=100*Level*Level;
                Recalc();
                }

            }

        protected void FireHealthCHanged()
            {
            OnHealthChanged(this,EventArgs.Empty);
            }
        }
    }
