using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser.Shapes.PathCmds
{
    public class zCmd : PathCmd
    {
        public static int ArgCount = 1;

        public zCmd() { }

        public override string GetTranslatedCmdText()
        {
            return "z";
        }
    }
}
