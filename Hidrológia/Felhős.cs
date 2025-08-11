using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public class Felhős : Típus
    {
        private static Felhős? _instance;

        public static Felhős Instance()
        {
            if (_instance == null)
            {
                _instance = new Felhős();
            }
            return _instance;
        }

        public int ParaNő(int m,int p)
        {

            return p + m;
        }
        public FöldTerület VizMod(FöldTerület t)
        {
            return t.VizValt(this);
        }
    }
}
