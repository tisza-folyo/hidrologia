using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public abstract class FöldTerület
    {
        public string név { get; protected set; }
        public int km3 { get; protected set; }
        public FöldTerület(string n, int k) { 
            this.név = n;
            this.km3 = k;
        }
        public virtual Típus ParaMod(Atmoszféra a) { return a.típus; }

        public virtual FöldTerület VizValt(Napos n) { return this; }
        public virtual FöldTerület VizValt(Felhős f) { return this; }
        public virtual FöldTerület VizValt(Esős s) { return this; }

        public override string ToString()
        {
            return this.ToString();
        }
    }
}
