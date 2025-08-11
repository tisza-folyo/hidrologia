using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public class Esős : Típus
    {
        private static Esős? _instance;

        public static Esős Instance()
        {
            if (_instance == null)
            {
                _instance = new Esős();
            }
            return _instance;
        }
        public int ParaNő(int m,int p)
        {
            return 30+m;
        }

        public FöldTerület VizMod(FöldTerület t) {
            return t.VizValt(this);
        }
    }
}
