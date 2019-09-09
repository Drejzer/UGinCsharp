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
        public static List<Item> WallDrops;
        public static List<Item> MobDrops;

        public static void StartNewGame()
            {
            roller=new Random();
            State=new GameState();
            State._Room.GenerateRoom();
            State.Player.OnStartingMove+=Player_StartingMove;
            State.Player.OnFinishedMove+=Player_OnFinishedMove;
            foreach(Creature a in State.Actors)
                {
                a.OnStartingMove+=Player_StartingMove;
                a.OnFinishedMove+=A_OnFinishedMove;
                }
            }

        private static void A_OnFinishedMove(object sender,MoveDirData e)
            {
            State._Room.Layout[e.StartPos.x,e.StartPos.y].IsOccupied=true;
            State._Room.Layout[e.StartPos.x,e.StartPos.y].Occupant=(Creature)sender;
            }

        private static void Player_OnFinishedMove(object sender,MoveDirData e)
            {
            State._Room.Layout[e.StartPos.x,e.StartPos.y].IsOccupied=true;
            State._Room.Layout[e.StartPos.x,e.StartPos.y].Occupant=State.Player;
            ProcesTurn();
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

        public static void ProcesTurn()
            {
            foreach(Creature a in State.Actors)
                {
                a.Action();
                }
            TurnPassed(null,EventArgs.Empty);
            }

        public static void ProcesCombat(ref Creature A,ref Creature B)
            {
            int resolution = (roller.Next(2,40)+A.Agility+A.CombatBonus) - (roller.Next(2,40)+B.Agility+B.CombatBonus);
            if(resolution==0)
                {
                A.ModHealth(-(int)(B.weapon.ResolveDamage()/2));
                B.ModHealth(-(int)(A.weapon.ResolveDamage()/2));
                }
            else if(resolution<20)
                {
                A.ModHealth(-(int)(B.weapon.ResolveDamage()/4));
                B.ModHealth(-(int)(3*(A.weapon.ResolveDamage())/4));
                }
            else if(resolution>-20)
                {
                B.ModHealth(-(int)(A.weapon.ResolveDamage()/4));
                A.ModHealth(-(int)(3*(B.weapon.ResolveDamage())/4));
                }
            else if(resolution>=20)
                {
                B.ModHealth(-A.weapon.ResolveDamage());
                }
            }
        }
    }

