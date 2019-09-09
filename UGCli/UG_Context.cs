using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UGCli
    {
    /// <summary>
    /// Database Context
    /// </summary>
    public class UG_Context: DbContext
        {
        public UG_Context() : base()
            {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UG_Context>());
            }
       // public DbSet<Creature> Creatures { get; set; }
       // public DbSet<Hero> Players { get; set; } 
        public DbSet<CellType> TileTypes { get; set; }
        public DbSet<CellInstance> TileInstances { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //public DbSet<Perk> Perks { get; set; }
        //public DbSet<Item> Weapons { get; set; }
        //public DbSet<GameState> GameStates { get; set; }

        //poddałem się, nie byłem w stanie zmusić tego do współpracy
        }
    }
