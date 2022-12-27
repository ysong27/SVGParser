using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class VCmd : PathCmd
    {
        public static int ArgCount = 1;
        public double y;

        public VCmd(double y) : base()
        {
            this.y = y;
        }

        public VCmd(List<string> values) : base()
        {
            y = double.Parse(values[0]);
        }

        public override string GetTranslatedCmdText()
        {
            return "V " + ((y * Config.ScaleY) + Config.ShiftY);
        }
    }
}
