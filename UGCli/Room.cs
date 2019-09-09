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
        /// Creates a Room (before doing anything, run GenerateRoom or LoadRoom, or else things break)
        /// </summary>
        public Room()
            {
            Widht=GameHandler.roller.Next(75,150);
            Height=GameHandler.roller.Next(75,150);
            Layout=new CellInstance[Widht,Height];
            }
        /// <summary>
        /// procedurally generates the room
        /// </summary>
        public void GenerateRoom()
            {
            int[,] tmp = new int[Widht,Height], tmp2;
            bool heroplaced = false;
            int Neighbourhood;
            for(int i = 0, j;i<Widht;++i)
                {
                for(j=0;j<Height;++j)
                    {
                    if(i==0||j==0||j==Height-1||i==Widht-1)
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
                for(int i = 1, j;i<Widht;++i)
                    {
                    for(j=0;j<Height;++j)
                        {
                        Neighbourhood=CountSurroundingWalls(tmp2,i,j,Widht,Height);
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
                for(j=0;j<Widht;++j)
                    {
                    Layout[j,i]=new CellInstance(j,i,this,0,tmp[j,i]);
                    if(i>0&&j>0&&j+1<Widht&&i+1<Height&&!heroplaced&&Layout[j,i].cellType.IsEnterable)
                        {
                        if(tmp[j-1,i-1]==1&&tmp[j-1,i]==1&&tmp[j-1,i+1]==1&&tmp[j,i+1]==1&&tmp[j+1,i+1]==1&&tmp[j+1,i]==1&&tmp[j+1,i-1]==1&&tmp[j,i-1]==1)
                            {
                            Layout[j,i].IsOccupied=true;
                            Layout[j,i].Occupant=GameHandler.State.Player;
                            heroplaced=true;
                            GameHandler.State.Player.Relocate(j,i);
                            RoamingMonster kappa = new RoamingMonster();
                            GameHandler.State.Actors.Add(kappa);
                            kappa.Relocate(j-1,i-1);
                            Layout[j-1,i-1].IsOccupied=true;
                            Layout[j-1,i-1].Occupant=kappa;
                            }
                        }
                    }
                }
            }

        private void SpawnMonsters(ref int[,] tab,int W,int H)
            {

            }

        private void MarkMonsterTerytories(ref int[,] tab,int W,int H,int x,int y)
            {

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

        public override string ToString()
            {
            string Displayed = new string('—',Widht);
            Displayed="+"+Displayed+"+\n";
            for(int i = 0, j;i<Height;++i)
                {
                Displayed+="|";
                for(j=0;j<Widht;++j)
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
            return Displayed+"+"+new string('—',Widht)+"+";
            }
        }
    }
