
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidrológia
{
    public interface Típus
    {
        public int ParaNő(int m,int p);
        public FöldTerület VizMod(FöldTerület t);
    }
}
