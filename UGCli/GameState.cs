using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity;

namespace UGCli
    {
    public class GameState: IDBGeneratable
        {
        public int Depth;
        public Room _Room;
        public Hero Player;
        public ICollection<Creature> Actors;
        public long Timer;
        public SortedList<int,MethodInfo> ActionQueue;

        public GameState()
            {
            Depth=0;
            _Room=new Room();
            Timer=0;
            ActionQueue=new SortedList<int,MethodInfo>();
            }

        public void GenerateFromDB()
            {
            throw new NotImplementedException();
            }
        }
    }
