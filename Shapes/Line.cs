using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace SVGParser.Shapes
{
    public class Line : Shape
    {
        public double x1, y1;
        public double x2, y2;


        public Line(double x1, double y1, double x2, double y2, string stroke, string fill, double strokeWidth) : base(stroke, fill, strokeWidth)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Line(XElement line) : base(line)
        {
            x1 = (double)line.Attribute("x1");
            y1 = (double)line.Attribute("y1");
            x2 = (double)line.Attribute("x2");
            y2 = (double)line.Attribute("y2");
        }

        public override string GetTranslatedTag()
        {
            string tag = File.ReadAllText(Config.TemplatesDirPath + "LineTemplate.txt");
            tag = ReplaceSpecificTagAttributes(tag);
            return ReplaceGeneralTagAttributes(tag);
        }

        public override string ReplaceSpecificTagAttributes(string tag)
        {
            return tag.Replace("${X1}", ((x1 * Config.ScaleX) + Config.ShiftX).ToString())
                .Replace("${Y1}", ((y1 * Config.ScaleY) + Config.ShiftY).ToString())
                .Replace("${X2}", ((x2 * Config.ScaleX) + Config.ShiftX).ToString())
                .Replace("${Y2}", ((y2 * Config.ScaleY) + Config.ShiftY).ToString());
        }

    }
}
