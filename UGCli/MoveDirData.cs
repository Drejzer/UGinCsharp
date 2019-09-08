using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {
    public class MoveDirData:EventArgs
        {
        public int dir;
        public (int x, int y) StartPos;
        public MoveDirData(int x,int y,int d)
            {
            StartPos.x=x;
            StartPos.y=y;
            dir=d;
            }
        }
    }
