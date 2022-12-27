using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class lCmd : PathCmd
    {
        public static int ArgCount = 2;
        public double dx, dy;

        public lCmd(double dx, double dy) : base()
        {
            this.dx = dx;
            this.dy = dy;
        }

        public lCmd(List<string> values) : base()
        {
            dx = double.Parse(values[0]);
            dy = double.Parse(values[1]);
        }

        public override string GetTranslatedCmdText()
        {
            return "l " + (dx * Config.ScaleX) + "," + (dy * Config.ScaleY);
        }
    }
}
