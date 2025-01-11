using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Builder
{
    public class PlayerDirector
    {
        PlayerBuilder builder;
        public PlayerDirector(PlayerBuilder builder) 
        {
            this.builder = builder;
        }

        public void ChangeBuilder(PlayerBuilder builder)
        {
            this.builder = builder;
        }
        public Player BuildPlayer()
        {
            builder.reset();
            builder.createSteps();
            return ((ComputerPlayerBuilder)builder).GetResult();
        }
    }
}
