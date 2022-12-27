using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class vCmd : PathCmd
    {
        public static int ArgCount = 1;
        public double dy;

        public vCmd(double dy) : base()
        {
            this.dy = dy;
        }

        public vCmd(List<string> values) : base()
        {
            dy = double.Parse(values[0]);
        }

        public override string GetTranslatedCmdText()
        {
            return "v " + (dy * Config.ScaleY);
        }

    }
}
