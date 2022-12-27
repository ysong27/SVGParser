using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes
{
    public class Coord
    {
        public double x, y;

        public Coord(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public string GetCoordText()
        {
            return ((x * Config.ScaleX) + Config.ShiftX) + "," + ((y * Config.ScaleY) + Config.ShiftY);
        }

    }
}
