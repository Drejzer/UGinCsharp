using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UGCli
    {
    /// <summary>
    /// Player Character
    /// </summary>
    [Serializable]
    public class Hero:Creature,IMobile
        {
        /// <summary>
        /// obsolete
        /// </summary>
        protected ManualResetEventSlim waitforstuff = new ManualResetEventSlim(false);

        /// <summary>
        /// Holds items gainded during gameplay
        /// </summary>
        public List<Item> Inventory { get; set; }

        public Hero()
            {
            Level=1;
            _xpToNextLvl=100;
            Inventory=new List<Item>();
            int tmp = 8;
            Strenght=1+GameHandler.roller.Next()%tmp;
            tmp-=(Strenght-1);
            Vitality=1+GameHandler.roller.Next()%tmp;
            tmp-=(Vitality-1);
            Agility=1+GameHandler.roller.Next()%tmp;
            tmp-=(Agility-1);
            Magic=1+GameHandler.roller.Next()%tmp;
            _baseHealth=(10+Vitality);
            _baseEnergy=5+Magic;
            MaxEnergy=_baseEnergy;
            MaxHealth=_baseHealth;
            Health=MaxHealth;
            Energy=MaxEnergy;
            weapon=new Pickaxe();
            Representation='@';
            }

        /// <summary>
        /// Adds XP t ocharacter's total, allowing for a levelup
        /// </summary>
        /// <param name="xp"></param>
        public void GainExperience(int xp)
            {
            _xpToNextLvl-=xp;
            if(_xpToNextLvl<=0)
                {
                LevelUp();
                }
            }
        /// <summary>
        /// Allows to modify player's HP<br/> Ends game if HP drops to or below 0
        /// </summary>
        /// <param name="a"></param>
        public override void ModHealth(int a)
            {
            base.ModHealth(a);
            if(Health<=0)
                {
                FireKicktehBucket();
                }
            }
        /// <summary>
        /// Awaits interaction with UI
        /// </summary>
        public override int Action()
            {
            waitforstuff.Reset();
            waitforstuff.Wait();
            return 0;
            }

        /// <summary>
        /// Attempts to change player's position<br/> If the space is empty, Moves teh cahracter<br/> if occupied by an enemy, initiates combat<br/> if the field is a wall, attempts to destroy it
        /// </summary>
        /// <param name="dir"></param>
        /// <seealso cref="GameHandler.ProcesCombat(Creature, Creature)"/>
        public int Move(int dir)
            {
            FireOnMoveStarted(PositionX,PositionY,dir);
            switch(dir)
                {
                case 1:
                        {
                        if(PositionY-1>=0&&GameHandler.State._Room.Layout[PositionX,PositionY-1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX,PositionY-1].IsOccupied)
                                {
                                Relocate(PositionX,PositionY-1);
                                }
                            else 
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX,PositionY-1].Occupant);
                                }
                            }
                        else if(PositionY-1>=0)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX,PositionY-1].DigThrough();
                                }
                            }
                        break;
                        }
                case 2:
                        {
                        if(PositionY-1>=0&&PositionX+1<GameHandler.State._Room.Width&&GameHandler.State._Room.Layout[PositionX+1,PositionY-1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX+1,PositionY-1].IsOccupied)
                                {
                                Relocate(PositionX+1,PositionY-1);
                                }
                            else
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX+1,PositionY-1].Occupant);
                                }
                            }
                        else if(PositionY-1>=0 && PositionX+1<GameHandler.State._Room.Width)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX+1,PositionY-1].DigThrough();
                                }
                            }
                        break;
                        }
                case 3:
                        {
                        if(PositionX+1<GameHandler.State._Room.Width&&GameHandler.State._Room.Layout[PositionX+1,PositionY].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX+1,PositionY].IsOccupied)
                                {
                                Relocate(PositionX+1,PositionY);
                                }
                            else
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX+1,PositionY].Occupant);
                                }
                            }
                        else if(PositionX+1<GameHandler.State._Room.Width)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX+1,PositionY].DigThrough();
                                }
                            }
                        break;
                        }
                case 4:
                        {
                        if(PositionX+1<GameHandler.State._Room.Width&&PositionY+1<GameHandler.State._Room.Height&&GameHandler.State._Room.Layout[PositionX+1,PositionY+1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX+1,PositionY+1].IsOccupied)
                                {
                                Relocate(PositionX+1,PositionY+1);
                                }
                            else
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX+1,PositionY+1].Occupant);
                                }
                            }
                        else if(PositionX+1<GameHandler.State._Room.Width &&PositionY+1<GameHandler.State._Room.Height)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX+1,PositionY+1].DigThrough();
                                }
                            }
                        break;
                        }
                case 5:
                        {
                        if(PositionY+1<GameHandler.State._Room.Height&&GameHandler.State._Room.Layout[PositionX,PositionY+1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX,PositionY+1].IsOccupied)
                                {
                                Relocate(PositionX,PositionY+1);
                                }
                            else
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX,PositionY+1].Occupant);
                                }
                            }
                        else if(PositionY+1<GameHandler.State._Room.Height)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX,PositionY+1].DigThrough();
                                }
                            }
                        break;
                        }
                case 6:
                        {
                        if(PositionY+1<GameHandler.State._Room.Height&&PositionX-1>=0&&GameHandler.State._Room.Layout[PositionX-1,PositionY+1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX-1,PositionY+1].IsOccupied)
                                {
                                Relocate(PositionX-1,PositionY+1);
                                }
                            else 
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX-1,PositionY+1].Occupant);
                                }
                            }
                        else if(PositionY+1<GameHandler.State._Room.Height&&PositionX-1>=0)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX-1,PositionY+1].DigThrough();
                                }
                            }
                        break;
                        }
                case 7:
                        {
                        if(PositionX-1>=0&&GameHandler.State._Room.Layout[PositionX-1,PositionY].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX-1,PositionY].IsOccupied)
                                {
                                Relocate(PositionX-1,PositionY);
                                }
                            else
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX-1,PositionY].Occupant);
                                }
                            }
                        else if(PositionX-1>=0)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX-1,PositionY].DigThrough();
                                }
                            }
                        break;
                        }
                case 8:
                        {
                        if(PositionX-1>=0&&PositionY-1>=0&&GameHandler.State._Room.Layout[PositionX-1,PositionY-1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX-1,PositionY-1].IsOccupied)
                                {
                                Relocate(PositionX-1,PositionY-1);
                                }
                            else
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX-1,PositionY-1].Occupant);
                                }
                            }
                        else if(PositionX-1>=0 && PositionY-1>=0)
                            {
                            if(GameHandler.State.Player.Energy>=1)
                                {
                                GameHandler.State._Room.Layout[PositionX-1,PositionY-1].DigThrough();
                                }
                            }
                        break;
                        }
                }
            FireOnMoveFinished(PositionX,PositionY,dir);
            waitforstuff.Set();
            return 0;
            }
        /// <summary>
        /// adds items to the inventory
        /// </summary>
        /// <param name="Loot"></param>
        public void PickLoot(Item Loot)
            {
            Inventory.Add(Loot);
            }

        }
    }
