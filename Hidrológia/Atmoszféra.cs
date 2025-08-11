using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public class Atmoszféra
    {
        public int paraTartalom {  get; protected set; }
        public Típus típus { get; private set; }
        public Atmoszféra(int p)
        {
            this.paraTartalom = p;
            this.típus = TípusValt();
        }

        private Típus TípusValt() {
            int copy = this.paraTartalom;
            if (this.paraTartalom < 40)
            {
                return Napos.Instance();
            }
            else if (((int)Math.Round((copy - 40) * 3.3)) > 70)
            {
                return Esős.Instance();
            }
            else { 
                return Felhős.Instance();
            }
        }
        public Típus ParaValt(Puszta p) { 
            this.paraTartalom = this.típus.ParaNő(3,this.paraTartalom);
            this.típus = TípusValt();
            return this.típus;
        }
        public Típus ParaValt(Zöld z) {
            this.paraTartalom = this.típus.ParaNő(7, this.paraTartalom);
            this.típus = TípusValt();
            return this.típus;
        }
        public Típus ParaValt(Tavas t) {
            this.paraTartalom = this.típus.ParaNő(10, this.paraTartalom);
            this.típus = TípusValt();
            return this.típus;
        }

        
    }
}
