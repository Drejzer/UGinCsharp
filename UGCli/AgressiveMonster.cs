using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    class AgressiveMonster:Creature, IMobile
        {
        public AgressiveMonster()
            {
            Level=1;
            _xpToNextLvl=100;
            int tmp = 9;
            Strenght=2+GameHandler.roller.Next()%tmp;
            tmp-=(Strenght-2);
            Vitality=1+GameHandler.roller.Next()%tmp;
            tmp-=(Vitality-1);
            Agility=2+GameHandler.roller.Next()%tmp;
            tmp-=(Agility-2);
            Magic=0+GameHandler.roller.Next()%tmp;
            _baseHealth=(10+Vitality);
            _baseEnergy=5+Magic;
            MaxEnergy=_baseEnergy;
            MaxHealth=_baseHealth;
            Health=MaxHealth;
            Energy=MaxEnergy;
            weapon=new Weapon();
            Representation='e';
            }

        /// <summary>
        /// This Enemy tries to move into Player's space, and initiate combat
        /// </summary>
        /// <returns></returns>
        public override int Action()
            {
            if(PositionX>GameHandler.State.Player.PositionX)
                {
                if(PositionY>GameHandler.State.Player.PositionY)
                    {
                    Move(8);
                    }
                else if(PositionY<GameHandler.State.Player.PositionY)
                    {
                    Move(6);
                    }
                else
                    {
                    Move(7);
                    }
                }
            else if(PositionX<GameHandler.State.Player.PositionX)
                {
                    {
                    if(PositionY>GameHandler.State.Player.PositionY)
                        {
                        Move(2);
                        }
                    else if(PositionY<GameHandler.State.Player.PositionY)
                        {
                        Move(4);
                        }
                    else
                        {
                        Move(3);
                        }
                    }
                }
            else
                {
                    {
                    if(PositionY>GameHandler.State.Player.PositionY)
                        {
                        Move(1);
                        }
                    else if(PositionY<GameHandler.State.Player.PositionY)
                        {
                        Move(5);
                        }
                    }
                }
            return 0;
            }

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
                            else if(GameHandler.State.Player.PositionX==PositionX &&GameHandler.State.Player.PositionY==PositionY-1)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX,PositionY-1].Occupant);
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
                            else if(GameHandler.State.Player.PositionX==PositionX+1&&PositionY-1==GameHandler.State.Player.PositionY)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX+1,PositionY-1].Occupant);
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
                            else if(GameHandler.State.Player.PositionX==PositionX+1&&PositionY==GameHandler.State.Player.PositionY)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX+1,PositionY].Occupant);
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
                            else if(GameHandler.State.Player.PositionX==PositionX+1&&PositionY+1==GameHandler.State.Player.PositionY)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX+1,PositionY+1].Occupant);
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
                            else if(GameHandler.State.Player.PositionX==PositionX && PositionY+1==GameHandler.State.Player.PositionY)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX,PositionY+1].Occupant);
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
                            else if(GameHandler.State.Player.PositionX==PositionX-1&&PositionY+1==GameHandler.State.Player.PositionY)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX-1,PositionY+1].Occupant);
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
                            else if(GameHandler.State.Player.PositionX==PositionX-1&&PositionY==GameHandler.State.Player.PositionY)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX-1,PositionY].Occupant);
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
                            else if(GameHandler.State.Player.PositionX==PositionX-1&&PositionY-1==GameHandler.State.Player.PositionY)
                                {
                                GameHandler.ProcesCombat(this,GameHandler.State._Room.Layout[PositionX-1,PositionY-1].Occupant);
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
