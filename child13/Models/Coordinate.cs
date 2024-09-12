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
        }

        // Установка новых координат для передачи в другие классы
        public void GetCoordinates(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        // Передача координат в другие классы
        public int[] SetCoordinates()
        {
            int[] coordinates = { x1, y1, x2, y2 };
            return coordinates;
        }
    }
}
