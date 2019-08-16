﻿using System;
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
        private int _baseSpeed;
        private int _baseRange;
        private int _baseHP;
        private int _baseEn;
        private int _baseSt;
        private int _baseDmg;
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
        public short Facing { get; private set; }
        public int SpdBonus { get; private set; }
        public int EnBonus { get; private set; }
        public int HpBonus { get; private set; }
        public int DmgBonus{ get; private set; }
        public int RngBonus { get; private set; }
        public int StBonus { get; private set; }
        public (int x, int y) Position { get; private set; }
        /// <summary>
        /// Holds upgrades to a Creature (special attacks, or other qualities) and information on its state
        /// </summary>
        public ICollection<(Perk P, bool active)> Upgrades;
        public ICollection<(Item it, int Amount)> Inventory;
        /// <summary>
        /// Logic of the AI, and in case of players: control of a Creature
        /// </summary>
        public abstract void Action();
        public bool ModHP(int a)
            {
            Health+=a;
            return (Health>0);
            }
        public void ModEnergy(int a)
            {
            Energy+=a;
            Energy=Math.Min(Energy,MaxEnergy);
            Energy=Math.Max(Energy,0);
            }
        public void ModStamina(int a)
            {
            Stamina+=a;
            Energy=Math.Min(Stamina,MaxStamina);
            Energy=Math.Max(Stamina,0);
            }
        private void Recalc()
            {
            
            }
        }
    }
