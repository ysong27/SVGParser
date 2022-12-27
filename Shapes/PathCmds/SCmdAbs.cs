using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{

    public class SCmd : PathCmd
    {
        public static int ArgCount = 4;
        public double x2, y2;
        public double x, y;

        public SCmd(double x2, double y2, double x, double y) : base()
        {
            this.x2 = x2;
            this.y2 = y2;
            this.x = x;
            this.y = y;
        }

        public SCmd(List<string> values) : base()
        {
            x2 = double.Parse(values[0]);
            y2 = double.Parse(values[1]);
            x = double.Parse(values[2]);
            y = double.Parse(values[3]);
        }

        public override string GetTranslatedCmdText()
        {
            return "S " + ((x2 * Config.ScaleX) + Config.ShiftX) + "," + ((y2 * Config.ScaleY) + Config.ShiftY) + " " + ((x * Config.ScaleX) + Config.ShiftX) + "," + ((y * Config.ScaleY) + Config.ShiftY);
        }
    }
}
