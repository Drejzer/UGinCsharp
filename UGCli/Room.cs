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
        public int RoomID { get; set; }
        /// <summary>
        /// Describes the width of the room
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Describes the height of the room
        /// </summary>
        public int Height { get;  set; }
        /// <summary>
        /// for database stuff
        /// </summary>
        public List<CellInstance> cellInstances { get; set; }
        /// <summary>
        /// holds the layout of the room<br/>
        /// </summary>
        public CellInstance[,] Layout { get; set; }
        /// <summary>
        /// Creates a Room (before doing anything, run GenerateRoom or LoadRoom, or else things break)
        /// </summary>
        public Room()
            {
            Width=GameHandler.roller.Next(75,150);
            Height=GameHandler.roller.Next(75,150);
            Layout=new CellInstance[Width,Height];
            cellInstances=new List<CellInstance>();
            }
        /// <summary>
        /// procedurally generates the room, places teh player and enemies
        /// </summary>
        public void GenerateRoom()
            {
            int[,] tmp = new int[Width,Height], tmp2;
            bool heroplaced = false;
            int Neighbourhood;
            for(int i = 0, j;i<Width;++i)
                {
                for(j=0;j<Height;++j)
                    {
                    if(i==0||j==0||j==Height-1||i==Width-1)
                        {
                        tmp[i,j]=0;
                        continue;
                        }
                    tmp[i,j]=(GameHandler.roller.Next(0,99)>39) ? 1 : 0;
                    }
                }
            for(int obr = 0;obr<4;++obr)
                {
                tmp2=tmp;
                for(int i = 1, j;i<Width;++i)
                    {
                    for(j=0;j<Height;++j)
                        {
                        Neighbourhood=CountSurroundingWalls(tmp2,i,j,Width,Height);
                        if(tmp2[i,j]==0)
                            {
                            if(Neighbourhood>=4)
                                {
                                tmp[i,j]=0;
                                }
                            else if(Neighbourhood<2)
                                {
                                tmp[i,j]=1;
                                }
                            }
                        else
                            {
                            if(Neighbourhood>=5)
                                {
                                tmp[i,j]=0;
                                }
                            else if(Neighbourhood<3)
                                {
                                tmp[i,j]=1;
                                }
                            }
                        }
                    }
                }
            for(int i = 0, j;i<Height;++i)
                {
                for(j=0;j<Width;++j)
                    {
                    Layout[j,i]=new CellInstance(j,i,this,0,tmp[j,i]);
                    cellInstances.Add(Layout[j,i]);
                    if(i>0&&j>0&&j+1<Width&&i+1<Height&&!heroplaced&&Layout[j,i].cellType.IsEnterable)
                        {
                        if(tmp[j-1,i-1]==1&&tmp[j-1,i]==1&&tmp[j-1,i+1]==1&&tmp[j,i+1]==1&&tmp[j+1,i+1]==1&&tmp[j+1,i]==1&&tmp[j+1,i-1]==1&&tmp[j,i-1]==1)
                            {
                            Layout[j,i].IsOccupied=true;
                            Layout[j,i].Occupant=GameHandler.State.Player;
                            heroplaced=true;
                            GameHandler.State.Player.Relocate(j,i);
                            }
                        }
                    else if(i>0&&j>0&&j+1<Width&&i+1<Height&&Layout[j,i].cellType.IsEnterable)
                        {
                        Creature kappa;
                        int seed = GameHandler.roller.Next(1,100);
                        if(seed<99 &&seed>90)
                            {
                            kappa=new RoamingMonster();
                        GameHandler.State.Actors.Add(kappa);
                        kappa.Relocate(j,i);
                        Layout[j,i].IsOccupied=true;
                        Layout[j,i].Occupant=kappa;
                            }
                        else if(seed>=99)
                            {
                            kappa=new AgressiveMonster();
                            GameHandler.State.Actors.Add(kappa);
                            kappa.Relocate(j,i);
                            Layout[j,i].IsOccupied=true;
                            Layout[j,i].Occupant=kappa;
                            }
                        }
                    }
                }
            }
        /// <summary>
        /// was supposed to be the logic of placing monsters, obsolete
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="W"></param>
        /// <param name="H"></param>
        private void SpawnMonsters(ref int[,] tab,int W,int H)
            {

            }

        private void MarkMonsterTeritories(ref int[,] tab,int W,int H,int x,int y)
            {
            int[,] tab2 = tab;
            }

        private int CountSurroundingWalls(int[,] a,int x,int y,int W,int H)
            {
            int valu = 0;
            if(x-1<0||y-1<0||x-1>=W||y-1>=H)
                {
                valu++;
                }
            else if(a[x-1,y-1]==0)
                {
                valu++;
                }

            if(x<0||y-1<0||x>=W||y-1>=H)
                {
                valu++;
                }
            else if(a[x,y-1]==0)
                {
                valu++;
                }

            if(x+1<0||y-1<0||x+1>=W||y-1>=H)
                {
                valu++;
                }
            else if(a[x+1,y-1]==0)
                {
                valu++;
                }

            if(x+1<0||y<0||x+1>=W||y>=H)
                {
                valu++;
                }
            else if(a[x+1,y]==0)
                {
                valu++;
                }

            if(x+1<0||y+1<0||x+1>=W||y+1>=H)
                {
                valu++;
                }
            else if(a[x+1,y+1]==0)
                {
                valu++;
                }

            if(x<0||y+1<0||x>=W||y+1>=H)
                {
                valu++;
                }
            else if(a[x,y+1]==0)
                {
                valu++;
                }

            if(x-1<0||y+1<0||x-1>=W||y+1>=H)
                {
                valu++;
                }
            else if(a[x-1,y+1]==0)
                {
                valu++;
                }
            if(x-1<0||y<0||x-1>=W||y>=H)
                {
                valu++;
                }
            else if(a[x-1,y]==0)
                {
                valu++;
                }

            return valu;
            }

        public void GenerateFromDB()
            {
            throw new NotImplementedException();
            }
        /// <summary>
        /// returns the Room layout as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            string Displayed = new string('—',Width);
            Displayed="+"+Displayed+"+\n";
            for(int i = 0, j;i<Height;++i)
                {
                Displayed+="|";
                for(j=0;j<Width;++j)
                    {
                    if(Layout[j,i].IsOccupied)
                        {
                        Displayed+=Layout[j,i].Occupant.Representation.ToString();
                        }
                    else
                        {
                        Displayed+=Layout[j,i].cellType.Representation.ToString();
                        }
                    }
                Displayed+="|\n";
                }
            return Displayed+"+"+new string('—',Width)+"+";
            }
        }
    }
