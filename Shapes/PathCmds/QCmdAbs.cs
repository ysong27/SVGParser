using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class QCmd : PathCmd
    {
        public static int ArgCount = 4;
        public double x1, y1;
        public double x, y;

        public QCmd(double x1, double y1, double x, double y) : base()
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x = x;
            this.y = y;
        }

        public QCmd(List<string> values) : base()
        {
            x1 = double.Parse(values[0]);
            y1 = double.Parse(values[1]);
            x = double.Parse(values[2]);
            y = double.Parse(values[3]);
        }

        public override string GetTranslatedCmdText()
        {
            return "Q " + ((x1 * Config.ScaleX) + Config.ShiftX) + "," + ((y1 * Config.ScaleY) + Config.ShiftY) + " " + ((x * Config.ScaleX) + Config.ShiftX) + "," + ((y * Config.ScaleY) + Config.ShiftY);
        }
    }

}
