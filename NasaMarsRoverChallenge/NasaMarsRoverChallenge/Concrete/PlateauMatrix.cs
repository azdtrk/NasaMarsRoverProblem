using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsRoverChallenge.Concrete
{
    public class PlateauMatrix
    {
        public Position LowerLeft { get; set; }
        public Position UpperRight { get; set; }

        public PlateauMatrix(Position UpperRight)
        {
            this.UpperRight = UpperRight;
            LowerLeft = new Position(0, 0);
        }
    }
}
