using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class hCmd : PathCmd
    {
        public static int ArgCount = 1;
        public double dx;

        public hCmd(double dx) : base()
        {
            this.dx = dx;
        }

        public hCmd(List<string> values) : base()
        {
            dx = double.Parse(values[0]);
        }

        public override string GetTranslatedCmdText()
        {
            return "h " + (dx * Config.ScaleX);
        }
    }
}
