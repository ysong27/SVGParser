using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class mCmd : PathCmd
    {
        public static int ArgCount = 2;
        public double dx, dy;

        public mCmd(double dx, double dy) : base()
        {
            this.dx = dx;
            this.dy = dy;
        }

        public mCmd(List<string> values) : base()
        {
            dx = double.Parse(values[0]);
            dy = double.Parse(values[1]);
        }

        public override string GetTranslatedCmdText()
        {
            return "m " + (dx * Config.ScaleX) + "," + (dy * Config.ScaleY);
        }
    }

}
