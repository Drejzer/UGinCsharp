using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UGCli
    {
    public class UG_Context: DbContext
        {
        UG_Context() : base()
            { }
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<CellType> TileTypes { get; set; }
        public DbSet<CellInstance> TileInstances { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        }
    }
