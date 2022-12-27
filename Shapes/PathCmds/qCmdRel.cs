using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class qCmd : PathCmd
    {
        public static int ArgCount = 4;
        public double dx1, dy1;
        public double dx, dy;

        public qCmd(double dx1, double dy1, double dx, double dy) : base()
        {
            this.dx1 = dx1;
            this.dy1 = dy1;
            this.dx = dx;
            this.dy = dy;
        }

        public qCmd(List<string> values) : base()
        {
            dx1 = double.Parse(values[0]);
            dy1 = double.Parse(values[1]);
            dx = double.Parse(values[2]);
            dy = double.Parse(values[3]);
        }
        
        public override string GetTranslatedCmdText()
        {
            return "q " + (dx1 * Config.ScaleX) + "," + (dy1 * Config.ScaleY) + " " + (dx * Config.ScaleX) + "," + (dy * Config.ScaleY);
        }
    }
}
