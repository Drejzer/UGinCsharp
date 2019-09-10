using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity;

namespace UGCli
    {
    /// <summary>
    /// Holds information about a game session
    /// </summary>
    public class GameState: IDBGeneratable
        {
        public int GameStateID { get; set; }
        /// <summary>
        /// how many rooms were genereated for this session
        /// </summary>
        public int Depth { get; set; }
        /// <summary>
        /// Current rooom
        /// </summary>
        public Room _Room { get; set; }
        /// <summary>
        /// Player caracter in this session
        /// </summary>
        public Hero Player { get; set; }
        /// <summary>
        /// points gathered by the player
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// how amn turns passed (probably OBSOLETE)
        /// </summary>
        public long TurnCount { get; set; }
        /// <summary>
        /// enemies in current room
        /// </summary>
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
        /// <summary>
        /// Generates new room for the current sesion
        /// </summary>
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
