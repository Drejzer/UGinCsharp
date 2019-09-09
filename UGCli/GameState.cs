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
        public int GameStateID { get; set; }
        public int Depth { get; set; }
        public Room _Room { get; set; }
        public Hero Player { get; set; }
        public int Score { get; set; }
        public long TurnCount { get; set; }
        public List<Creature> Actors { get; set; }
        public Module ActivatedItem { get; set; }
        public Weapon WeaponBoost { get; set; }
        public bool Weapon_IsSloted { get; set; }
        public bool Item_IsSlotted{ get; set; }

public GameState()
            {
            Score=0;
            Depth=0;
            _Room=new Room();
            Player=new Hero();
            Player.OnLevelUP+=Player_Levelled;
            Actors=new List<Creature>();
            }

        private void Player_Levelled(object sender,EventArgs e)
            {
            Score+=450;
            }

        public void GoDeeper()
            {
            Score+=1000*Depth;
            Depth++;
            Actors=new List<Creature>();
            _Room.GenerateRoom();
            }

        public void GenerateFromDB()
            {
            throw new NotImplementedException();
            }
        }
    }
