using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class aCmd : PathCmd
    {
        public static int ArgCount = 7;
        public double rx, ry;
        public double angle;
        public bool largeArcFlag;
        public bool sweepFlag;
        public double dx, dy;

        public aCmd(double rx, double ry, double angle, bool largeArcFlag, bool sweepFlag, double dx, double dy) : base()
        {
            this.rx = rx;
            this.ry = ry;
            this.angle = angle;
            this.largeArcFlag = largeArcFlag;
            this.sweepFlag = sweepFlag;
            this.dx = dx;
            this.dy = dy;
        }

        public aCmd(List<string> values) : base()
        {
            rx = double.Parse(values[0]);
            ry = double.Parse(values[1]);
            angle = double.Parse(values[2]);
            largeArcFlag = bool.Parse(values[3]);
            sweepFlag = bool.Parse(values[4]);
            dx = double.Parse(values[5]);
            dy = double.Parse(values[6]);
        }

        public override string GetTranslatedCmdText()
        {
            return "a " + (rx * Config.ScaleX) + "," + (ry * Config.ScaleY) + " " + angle + " " + (largeArcFlag ? "1" : "0") + " " + (sweepFlag ? "1" : "0") + " " + (dx * Config.ScaleX) + "," + (dy * Config.ScaleY);
        }

    }
}
