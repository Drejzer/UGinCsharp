﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGCli
    {/// <summary>
    /// most common tye of cells, walls and empty spaces
    /// </summary>
    class GenericCell:CellType
        {        
        public GenericCell(int k=0)
            {
            Type=TypeOfCell.Generic;
            CellTypeID=k;
            IsEnterable=(k>0);
            switch(k)
                {
                case 0:
                        {
                        Representation='#';
                        break;
                        }
                case 1:
                        {
                        Representation=' ';
                        break;
                        }
                case 2:
                        {
                        Representation='.';
                        break;
                        }
                case 3:
                        {
                        Representation='~';
                        break;
                        }
                default:
                        {
                        Representation=' ';
                        break;
                        }
                }
            }
        }
    }