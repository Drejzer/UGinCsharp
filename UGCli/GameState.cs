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
        public int Score;
        public long TurnCount;
        public ICollection<Creature> Actors;
        //public (bool IsSlotted,Item Fuel, int )

        public GameState()
            {
            Score=0;
            Depth=0;
            _Room=new Room();
            Player=new Hero();
            Player.OnStartingMove+=PlayerStartedMove;
            Player.OnFinishedMove+=PlayerFinishedMove;
            Player.OnLevelUP+=Player_Levelled;
            }

        private void Player_Levelled(object sender,EventArgs e)
            {
            Score+=450;
            }

        private void PlayerFinishedMove(object sender,EventArgs e)
            {
            _Room.Layout[Player.PositionX,Player.PositionY].IsOccupied=true;
            _Room.Layout[Player.PositionX,Player.PositionY].Occupant=Player;
            }

        private void PlayerStartedMove(object sender,EventArgs e)
            {
            _Room.Layout[Player.PositionX,Player.PositionY].IsOccupied=false;
            _Room.Layout[Player.PositionX,Player.PositionY].Occupant=null;
            }
        
        public void SpawnPlayer(int x, int y)
            {
            }
        public void SpawnPlayer()
            {

            }

        public void GenerateFromDB()
            {
            throw new NotImplementedException();
            }
        }
    }
