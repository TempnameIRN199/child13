using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace child13.Models
{
    public class Coordinate
    {
        public int x1, x2, y1, y2;

        public Coordinate()
        {
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
        }

        public Coordinate(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public void SetCoordinates(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public int GetX1()
        {
            return x1;
        }

        public int GetX2()
        {
            return x2;
        }

        public int GetY1()
        {
            return y1;
        }

        public int GetY2()
        {
            return y2;
        }
    }
}
