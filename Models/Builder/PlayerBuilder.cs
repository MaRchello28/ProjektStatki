using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Builder
{
    public interface PlayerBuilder
    {
        public void reset();
        public void createSteps(string name);
        public Player GetResult();
    }
}
