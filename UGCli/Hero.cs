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
        protected ManualResetEventSlim waitforstuff = new ManualResetEventSlim(false);

        public List<Item> Inventory;

        public Hero()
            {
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
            weapon=new Pickaxe(this);
            Representation='@';
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

        public int Move(int dir)
            {
            FireOnMoveStarted(PositionX,PositionY,dir);
            switch(dir)
                {
                case 1:
                        {
                        if(GameHandler.State._Room.Layout[PositionX,PositionY-1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX,PositionY-1].IsOccupied)
                                {
                                Relocate(PositionX,PositionY-1);
                                }
                            else
                                {
                                //should be combat
                                #warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                case 2:
                        {
                        if(GameHandler.State._Room.Layout[PositionX+1,PositionY-1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX+1,PositionY-1].IsOccupied)
                                {
                                Relocate(PositionX+1,PositionY-1);
                                }
                            else
                                {
                                //should be combat
#warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                case 3:
                        {
                        if(GameHandler.State._Room.Layout[PositionX+1,PositionY].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX+1,PositionY].IsOccupied)
                                {
                                Relocate(PositionX+1,PositionY);
                                }
                            else
                                {
                                //should be combat
#warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                case 4:
                        {
                        if(GameHandler.State._Room.Layout[PositionX+1,PositionY+1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX+1,PositionY+1].IsOccupied)
                                {
                                Relocate(PositionX+1,PositionY+1);
                                }
                            else
                                {
                                //should be combat
#warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                case 5:
                        {
                        if(GameHandler.State._Room.Layout[PositionX,PositionY+1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX,PositionY+1].IsOccupied)
                                {
                                Relocate(PositionX,PositionY+1);
                                }
                            else
                                {
                                //should be combat
#warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                case 6:
                        {
                        if(GameHandler.State._Room.Layout[PositionX-1,PositionY+1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX-1,PositionY+1].IsOccupied)
                                {
                                Relocate(PositionX-1,PositionY+1);
                                }
                            else
                                {
                                //should be combat
#warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                case 7:
                        {
                        if(GameHandler.State._Room.Layout[PositionX-1,PositionY].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX-1,PositionY].IsOccupied)
                                {
                                Relocate(PositionX-1,PositionY);
                                }
                            else
                                {
                                //should be combat
#warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                case 8:
                        {
                        if(GameHandler.State._Room.Layout[PositionX-1,PositionY-1].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[PositionX-1,PositionY-1].IsOccupied)
                                {
                                Relocate(PositionX-1,PositionY-1);
                                }
                            else
                                {
                                //should be combat
#warning TODO: COMBAT
                                }
                            }
                        break;
                        }
                }
            FireOnMoveFinished(PositionX,PositionY,dir);
            waitforstuff.Set();
            return 0;
            }

        }
    }
