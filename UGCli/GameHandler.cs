using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UGCli
    {
    /// <summary>
    /// I'm lazy, so I made this to handle Events from the rest of the things, enjoy 
    /// </summary>
    public static class GameHandler
        {
        public static event EventHandler TurnPassed = delegate { };
        public static GameState State;
        public static Random roller;
        public static bool Playing = false;
        
        public static void StartNewGame()
            { 
            roller=new Random();
            State=new GameState();
            State._Room.GenerateRoom();
            State.Player.OnStartingMove+=Player_StartingMove;
            }

        private static void Player_StartingMove(object sender,MoveDirData e)
            {
            State._Room.Layout[e.StartPos.x,e.StartPos.y].IsOccupied=false;
            State._Room.Layout[e.StartPos.x,e.StartPos.y].Occupant=null;
            }

        public static void LoadSavedGame()
            {
            roller=new Random();
            GameState tmp = new GameState();
            tmp.GenerateFromDB();
            }

        public static void Gameplay()
            {
            UG_Context context = new UG_Context();
            while(State.Player.Health>0)
                {
                State.Player.Action();
                foreach(Creature a in State.Actors)
                    {
                    a.Action();
                    }
                TurnPassed(null,EventArgs.Empty);
                }
            }
        }
    }
