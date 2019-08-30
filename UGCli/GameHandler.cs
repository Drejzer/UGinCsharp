using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UGCli
    {
    public static class GameHandler
        {
        public static GameState State;
        public static Random roller;
        public static bool Playing = false;


        public static void StartNewGame()
            { 
            roller=new Random();
            State=new GameState();
            }
        public static void LoadSavedGame()
            {
            roller=new Random();
            GameState tmp = new GameState();
            }

        public static void Gameplay()
            {
            while(State.Player.Health>0)
                {

                }
            }
        }
    }
