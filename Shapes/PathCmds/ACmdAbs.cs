using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class ACmd : PathCmd
    {
        public static int ArgCount = 7;
        public double rx, ry;
        public double angle;
        public bool largeArcFlag;
        public bool sweepFlag;
        public double x, y;

        public ACmd(double rx, double ry, double angle, bool largeArcFlag, bool sweepFlag, double x, double y) : base()
        {
            this.rx = rx;
            this.ry = ry;
            this.angle = angle;
            this.largeArcFlag = largeArcFlag;
            this.sweepFlag = sweepFlag;
            this.x = x;
            this.y = y;
        }

        public ACmd(List<string> values) : base()
        {
            rx = double.Parse(values[0]);
            ry = double.Parse(values[1]);
            angle = double.Parse(values[2]);
            largeArcFlag = values[3] != "0";
            sweepFlag = values[4] != "0";
            x = double.Parse(values[5]);
            y = double.Parse(values[6]);
        }

        public override string GetTranslatedCmdText()
        {
            return "A " + (rx * Config.ScaleX) + "," + (ry * Config.ScaleY) + " " + angle + " " + (largeArcFlag ? "1" : "0") + " " + (sweepFlag ? "1" : "0") + " " + ((x * Config.ScaleX) + Config.ShiftX) + "," + ((y * Config.ScaleY) + Config.ShiftY);
        }

    }

}
