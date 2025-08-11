using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public class Napos : Típus
    {
        private static Napos? _instance;

        public static Napos Instance()
        {
            if (_instance == null)
            {
                _instance = new Napos();
            }
            return _instance;
        }
        public int ParaNő(int m, int p) {
            return p+m;
        }
        public FöldTerület VizMod(FöldTerület t)
        {
            return t.VizValt(this);
        }
    }
}
