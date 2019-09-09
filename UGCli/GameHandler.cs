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
        public static GameState State { get; set; }
        public static Random roller;
        public static bool Playing = false;

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
                a.OnKickedThebucket+=A_OnKickedThebucket;
                }
            }

    

        private static void A_OnKickedThebucket(object sender,CorpseArgs e)
            {
            if(e.Corpse.Loot!=null)
                {
                State.Player.PickLoot(e.Corpse.Loot);
                }
            State._Room.Layout[e.Corpse.PositionX,e.Corpse.PositionY].IsOccupied=false;
            State._Room.Layout[e.Corpse.PositionX,e.Corpse.PositionY].Occupant=null;
            State.Actors.Remove(e.Corpse);
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
            List<Creature> corpses = new List<Creature>();
            foreach(Creature a in State.Actors)
                {
                a.Action();
                if(a.Health<=0)
                    {
                    corpses.Add(a);
                    }
                }
            foreach(Creature c in corpses)
                {
                c.FireKicktehBucket();
                }
            TurnPassed(null,EventArgs.Empty);
            }

        public static void ProcesCombat(Creature A,Creature B)
            {
            int resolution = (roller.Next(2,40)+A.Agility+A.CombatBonus) - (roller.Next(2,40)+B.Agility+B.CombatBonus);
            if(resolution==0)
                {
                A.ModHealth(-(Math.Max(1,(int)(B.weapon.ResolveDamage()/2))));
                B.ModHealth(-(Math.Max(1,(int)(A.weapon.ResolveDamage()/2))));
                }
            else if(resolution<20)
                {
                A.ModHealth(-(Math.Max(1,(int)(B.weapon.ResolveDamage()/4))));
                B.ModHealth(-(Math.Max(1,(int)(3*(A.weapon.ResolveDamage())/4))));
                }
            else if(resolution>-20)
                {
                B.ModHealth(-Math.Max(1,(int)(A.weapon.ResolveDamage()/4)));
                A.ModHealth(-Math.Max(1,(int)(3*(B.weapon.ResolveDamage())/4)));
                }
            else if(resolution>=20)
                {
                B.ModHealth(-A.weapon.ResolveDamage());
                }
            else if(resolution<=-20)
                {
                A.ModHealth(-B.weapon.ResolveDamage());
                }
            }
        }
    }

