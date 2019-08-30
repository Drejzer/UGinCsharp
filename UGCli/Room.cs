using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {


    /// <summary>
    /// Holds the structure of a single level
    /// </summary>
    [Serializable]
    public class Room:IDBGeneratable
        {
        /// <summary>
        /// Describes the width of the room
        /// </summary>
        public int Widht { get; private set; }
        /// <summary>
        /// Describes the height of the room
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// holds the layout of the room<br/>
        /// </summary>
        public CellInstance[,] Layout;
        /// <summary>
        /// Creates a Room (completely useless, before doing anything, run GenerateRoom or LoadRoom)
        /// </summary>
        public Room()
            {
            Widht=85+(GameHandler.roller.Next()%15);
            Height=85+(GameHandler.roller.Next()%15);
            Layout=new CellInstance[Widht,Height];
            for(int i = 0;i<Height;++i)
                {
                for(int j=0;j<Widht;++j)
                    {
                    Layout[j,i]=new CellInstance(j,i);
                    }
                }
            }
        public void GenerateRoom()
            {

            }

        public void GenerateFromDB()
            {

            }

        public override string ToString()
            {
            string Displayed="";
            for(int i = 0;i<Height;++i)
                {
                for(int j=0;j<Widht;++j)
                    {
                    if (Layout[j,i].IsOccupied)
                        {
                        Displayed+=Layout[j,i].Occupant.Representation.ToString();
                        }
                    else
                        {
                    Displayed+=Layout[j,i].cellType.Representation.ToString();
                        }
                    }
                Displayed+="\n\r";
                }
            return Displayed; 
            }
        }
    }
