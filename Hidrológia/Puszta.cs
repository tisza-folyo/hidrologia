using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public class Puszta : FöldTerület
    {
        public Puszta(string n, int k) : base(n,k) {
        }
        public override Típus ParaMod(Atmoszféra a) { return a.ParaValt(this); }

        public override FöldTerület VizValt(Esős s)
        {
            this.km3 += 5;
            if (this.km3 > 15)
            {
                return new Zöld(this.név, this.km3);
            }
            return this;
        }
        public override FöldTerület VizValt(Felhős f)
        {
            this.km3 -= 1;
            NincsViz(this.km3);
            return this;
        }
        public override FöldTerület VizValt(Napos n)
        {
            this.km3 -= 3;
            NincsViz(this.km3);
            return this;
        }

        private void NincsViz(int p) {
            if (p < 0) this.km3 = 0;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} Puszta", név, km3);
        }
    }
}
