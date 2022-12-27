using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class cCmd : PathCmd
    {
        public static int ArgCount = 6;
        public double dx1, dy1;
        public double dx2, dy2;
        public double dx, dy;

        public cCmd(double dx1, double dy1, double dx2, double dy2, double dx, double dy) : base()
        {
            this.dx1 = dx1;
            this.dy1 = dy1;
            this.dx2 = dx2;
            this.dy2 = dy2;
            this.dx = dx;
            this.dy = dy;
        }

        public cCmd(List<string> values) : base()
        {
            dx1 = double.Parse(values[0]);
            dy1 = double.Parse(values[1]);
            dx2 = double.Parse(values[2]);
            dy2 = double.Parse(values[3]);
            dx = double.Parse(values[4]);
            dy = double.Parse(values[5]);
        }

        public override string GetTranslatedCmdText()
        {
            return "c " + (dx1 * Config.ScaleX) + "," + (dy1 * Config.ScaleY) + " " + (dx2 * Config.ScaleX) + "," + (dy2 * Config.ScaleY) + " " + (dx * Config.ScaleX) + "," + (dy * Config.ScaleY);
        }

    }
}
