using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsRoverChallenge.Concrete
{
    public class Position
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }

        public Position(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
        }

    }
}
