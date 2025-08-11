using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public class Táj
    {
        public Atmoszféra atmoszféra {  get; private set; }
        private List<FöldTerület> földek;

        public Táj(Atmoszféra a) { 
            this.atmoszféra = a;
            this.földek = new();
        }

        public void Add(FöldTerület f) { 
            földek.Add(f);
        }

        public List<FöldTerület> GetFöldek()
        {
            return földek;
        }

        public void Kör() {
            if (földek.Count() == 0) {
                throw new Exception("Nincs is föld tesó");
            }
            for (int i = 0; i < földek.Count(); i++)
            {
                földek[i] = atmoszféra.típus.VizMod(földek[i]);
                földek[i].ParaMod(atmoszféra);
            }
        }

        public FöldTerület LegVizesebb() { 
            if(földek.Count() == 0) { throw new Exception("Nincsen föld!"); }
            FöldTerület max = földek.First();
            foreach (FöldTerület e in földek)
            {
                if (e.km3 > max.km3) {
                    max = e;
                }
            }
            return max;
        }
    }
}
