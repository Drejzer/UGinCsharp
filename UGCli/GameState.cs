using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public static class GameState
        {
        public static int Level;
        public static Room _Room = new Room();
        public static Hero Player;
        public static ICollection<Creature> Actors;
        public static ICollection<Creature> Actors;
        public static long timer=0;
        }
    }
