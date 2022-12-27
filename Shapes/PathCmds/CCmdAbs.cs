using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class CCmd : PathCmd
    {
        public static int ArgCount = 6;
        public double x1, y1;
        public double x2, y2;
        public double x, y;

        public CCmd(double x1, double y1, double x2, double y2, double x, double y) : base()
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x = x;
            this.y = y;
        }

        public CCmd(List<string> values) : base()
        {
            x1 = double.Parse(values[0]);
            y1 = double.Parse(values[1]);
            x2 = double.Parse(values[2]);
            y2 = double.Parse(values[3]);
            x = double.Parse(values[4]);
            y = double.Parse(values[5]);
        }

        public override string GetTranslatedCmdText()
        {
            return "C " + ((x1 * Config.ScaleX) + Config.ShiftX) + "," + ((y1 * Config.ScaleY) + Config.ShiftY) + " " + ((x2 * Config.ScaleX) + Config.ShiftX) + "," + ((y2 * Config.ScaleY) + Config.ShiftY) + " " + ((x * Config.ScaleX) + Config.ShiftX) + "," + (y + Config.ShiftY);
        }
    }
}
