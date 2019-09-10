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
            
            }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Creature>().ToTable("Creatures");
            modelBuilder.Entity<AgressiveMonster>().ToTable("Creatures");
            modelBuilder.Entity<RoamingMonster>().ToTable("Creatures");
            modelBuilder.Entity<Creature>().HasKey<int>(s => s.CreatureID);
            modelBuilder.Entity<AgressiveMonster>().HasKey<int>(s => s.CreatureID);
            modelBuilder.Entity<RoamingMonster>().HasKey<int>(s => s.CreatureID);

            modelBuilder.Entity<Creature>().HasOptional(s => s.Loot);
            modelBuilder.Entity<AgressiveMonster>().HasOptional(s => s.Loot);
            modelBuilder.Entity<RoamingMonster>().HasOptional(s => s.Loot);

            modelBuilder.Entity<Hero>().ToTable("Players");

            modelBuilder.Entity<Hero>().HasMany<Item>(g => g.Inventory).WithOptional(s => (Hero)s.Owner).HasForeignKey(s => s.ItemID);

            modelBuilder.Entity<CellType>().ToTable("CellTypes");
            modelBuilder.Entity<CellInstance>().ToTable("CellInstances");

            modelBuilder.Entity<Room>().ToTable("Rooms");

            modelBuilder.Entity<Room>().HasMany<CellInstance>(g => g.cellInstances).WithRequired(s => s.room).HasForeignKey<int>(s => s.CellInstanceID).WillCascadeOnDelete();
            modelBuilder.Entity<CellInstance>().HasRequired<CellType>(s => s.cellType).WithMany(g => g.TileInstances).HasForeignKey<int>(s => s.CellInstanceID);

            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Gem>().ToTable("Items");
            modelBuilder.Entity<Module>().ToTable("Items");
            modelBuilder.Entity<Weapon>().ToTable("Items");

            modelBuilder.Entity<GameState>().ToTable("GameStates");

            

            }
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Hero> Players { get; set; } 
        public DbSet<CellType> CellTypes { get; set; }
        public DbSet<CellInstance> TileInstances { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<GameState> GameStates { get; set; }

        //poddałem się, nie byłem w stanie zmusić tego do współpracy
        }
    }
