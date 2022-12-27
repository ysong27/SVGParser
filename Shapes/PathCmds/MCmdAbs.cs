using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class MCmd : PathCmd
    {
        public static int ArgCount = 2;
        public double x, y;

        public MCmd(double x, double y) : base()
        {
            this.x = x;
            this.y = y;
        }

        public MCmd(List<string> values) : base()
        {
            x = double.Parse(values[0]);
            y = double.Parse(values[1]);
        }

        public override string GetTranslatedCmdText()
        {
            return "M " + ((x * Config.ScaleX) + Config.ShiftX) + "," + ((y * Config.ScaleY) + Config.ShiftY);
        }

    }

}
