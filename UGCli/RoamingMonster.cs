using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    class RoamingMonster:Creature,IMobile
        {
        public override int Action()
            {
            return Move(GameHandler.roller.Next(1,8));
            }

        public int Move(int dir)
            {
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
            return 0;
            }
        }
    }
