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

        public GameState()
            {
            Depth=0;
            _Room=new Room();
            Player=new Hero();
            Player.OnStartingMove+=PlayerStartedMove;
            Player.OnFinishedMove+=PlayerFinishedMove;
            }

        private void PlayerFinishedMove(object sender,EventArgs e)
            {
            _Room.Layout[Player.Position.x,Player.Position.y].IsOccupied=true;
            _Room.Layout[Player.Position.x,Player.Position.y].Occupant=Player;
            }

        private void PlayerStartedMove(object sender,EventArgs e)
            {
            _Room.Layout[Player.Position.x,Player.Position.y].IsOccupied=false;
            _Room.Layout[Player.Position.x,Player.Position.y].Occupant=null;
            }

        public void GenerateFromDB()
            {
            throw new NotImplementedException();
            }
        }
    }
