using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    class RoamingMonster:Creature,IMobile
        {
        public RoamingMonster()
            {
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
            weapon=new Weapon();
            Representation='r';
            Loot=weapon;
            }

        /// <summary>
        /// this enemy moves around randomly
        /// </summary>
        /// <returns></returns>
        public override int Action()
            {
            return Move(GameHandler.roller.Next(1,8));
            }

        /// <summary>
        /// implements Imobile interface
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
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
                            }
                        break;
                        }
                }
            FireOnMoveFinished(PositionX,PositionY,dir);
            return 0;
            }
        }
    }
