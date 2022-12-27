using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser
{
    public class PathCmd
    {
        public PathCmd() { }

        public virtual string GetTranslatedCmdText()
        {
            return "";
        }
    }

}
