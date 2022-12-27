using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class HCmd : PathCmd
    {
        public static int ArgCount = 1;
        public double x;

        public HCmd(double x) : base()
        {
            this.x = x;
        }

        public HCmd(List<string> values) : base()
        {
            x = double.Parse(values[0]);
        }

        public override string GetTranslatedCmdText()
        {
            return "H " + ((x * Config.ScaleX) + Config.ShiftX);
        }
    }
}
