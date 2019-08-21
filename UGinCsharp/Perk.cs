using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGinCsharp
    {
    public abstract class Perk
        {
        public static uint Id { get; private set; }
        public static string Name { get; private set; }
        public static string Description { get; private set; }

        public ICollection<Creature> Modules;

        public abstract bool Activate(Creature kappa);
        public abstract bool Deactivate(Creature kappa);


        }
    }
