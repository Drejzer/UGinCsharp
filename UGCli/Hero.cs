using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    /// <summary>
    /// Player Character
    /// </summary>
    [Serializable]
    public class Hero:Creature,IMobile
        {
        public event EventHandler<MoveDirData> OnStartingMove, OnFinishedMove;

        public Hero()
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
            Recalc();
            }

        /// <summary>
        /// Awaits interaction with UI
        /// </summary>
        public override int Action()
            {
            throw new NotImplementedException();
            }

        public int Move(int dir)
            {
            OnStartingMove(this,new MoveDirData(Position.x,Position.y,dir));
            switch(dir)
                {
                case 1:
                        {
                        if(GameHandler.State._Room.Layout[Position.x,Position.y].cellType.IsEnterable)
                            {
                            if(!GameHandler.State._Room.Layout[Position.x,Position.y].IsOccupied)
                                {

                                }
                            }
                        break;
                        }
                }
            return 0;
            }

        }
    }
