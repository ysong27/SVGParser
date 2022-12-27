using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{

    public class sCmd : PathCmd
    {
        public static int ArgCount = 4;
        public double dx2, dy2;
        public double dx, dy;

        public sCmd(double dx2, double dy2, double dx, double dy) : base()
        {
            this.dx2 = dx2;
            this.dy2 = dy2;
            this.dx = dx;
            this.dy = dy;
        }

        public sCmd(List<string> values) : base()
        {
            dx2 = double.Parse(values[0]);
            dy2 = double.Parse(values[1]);
            dx = double.Parse(values[2]);
            dy = double.Parse(values[3]);
        }

        public override string GetTranslatedCmdText()
        {
            return "s " + (dx2 * Config.ScaleX) + "," + (dy2 * Config.ScaleY) + " " + (dx * Config.ScaleX) + "," + (dy * Config.ScaleY);
        }
    }

}
