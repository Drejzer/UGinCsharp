using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UGCli
    {
    /// <summary>
    /// Parent class for all enemies and player characters.
    /// Contains basic statistics shared by all, as well as common methods
    /// </summary>
    [Serializable]
    public abstract class Creature
        {
        public event EventHandler OnHealthChanged = delegate { }, OnLevelUP = delegate { }, OnRecalc = delegate { }, OnEnergyChanged = delegate { };
        public event EventHandler<MoveDirData> OnStartingMove, OnFinishedMove;
        public event EventHandler<CorpseArgs> OnKickedThebucket = delegate { };

    /// <summary>
    /// Name of the Creture
    /// </summary>
    public string Name { get; set; }
        [Key]
        public int CreatureID{ get; set; }
        /// <summary>
        /// Designates power of a creature, Affects Health and Enegry
        /// </summary>
        public int Level { get; set; }
        protected int _xpToNextLvl { get; set; }
        /// <summary>
        /// Influences Damage and carrying capcity (TODO)
        /// </summary>
        public int Strenght { get; protected set; }
        /// <summary>
        /// To-hit, Defense, order of actions
        /// </summary>
        public int Agility { get; set; }
        /// <summary>
        /// Energy Reserves
        /// </summary>
        public int Magic { get; set; }
        /// <summary>
        /// Health and general surivability
        /// </summary>
        public int Vitality { get; set; }
        protected int _baseHealth { get; set; }
        protected int _baseEnergy { get; set; }
        /// <summary>
        /// What character is used to display this creature
        /// </summary>
        public char Representation { get; set; }

        protected int _baseAtack { get; set; }
        protected int _baseDefense { get; set; }
        /// <summary>
        /// bonuses to combat effectivenes
        /// </summary>
        public int CombatBonus { get; set; }
        /// <summary>
        /// Maximum health capacit of a  ceature, baed on level and Vitality
        /// </summary>
        public int MaxHealth { get; set; }
        /// <summary>
        /// curent health of a creature
        /// </summary>
        public int Health { get; set; }
        public int MaxEnergy { get; set; }
        public int Energy { get; set; }
        /// <summary>
        /// obsolete
        /// </summary>
        public double SpeedBonus { get; set; }
        /// <summary>
        /// bonuses to maximum energy capacity
        /// </summary>
        public int EnergyBonus { get; set; }
        public int HealthBonus { get; set; }
        /// <summary>
        /// The X coorinate of a creature within a Room
        /// </summary>
        public int PositionX { get; set; }
        /// <summary>
        /// The Y coordinate of a creature within a Room
        /// </summary>
        public int PositionY { get; set; }
        /// <summary>
        /// weapon used by the creature.
        /// </summary>
        public Weapon weapon { get; set; }
        /// <summary>
        /// Holds loot dropped at death
        /// </summary>
        public Item Loot { get; set; }

        public Creature()
            {

            }


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
        public virtual void ModHealth(int a)
            {
            Health+=a;
            OnHealthChanged(this,EventArgs.Empty);
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
        /// <summary>
        /// raises the power of the creature
        /// </summary>
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

        /// <summary>
        /// changes teh location of the creature
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Relocate(int x,int y)
            {
            PositionX=x;
            PositionY=y;
            }

        protected void FireHealthChanged()
            {
            OnHealthChanged(this,EventArgs.Empty);
            }
        protected void FireEnergyChanged()
            {
            OnEnergyChanged(this,EventArgs.Empty);
            }
        protected void FireOnMoveStarted(int PositionX,int PositionY,int dir)
            {
            OnStartingMove(this,new MoveDirData(PositionX,PositionY,dir));
            }
        protected void FireOnMoveFinished(int PositionX,int PositionY,int dir)
            {
            OnFinishedMove(this,new MoveDirData(PositionX,PositionY,dir));
            }
        /// <summary>
        /// used to signal that a creature died(necessary when enemies initiate combat)
        /// </summary>
        public void FireKicktehBucket()
            {
            OnKickedThebucket(this,new CorpseArgs(this));
            }
        }
    }
