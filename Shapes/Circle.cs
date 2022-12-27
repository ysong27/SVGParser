using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SVGParser;


namespace SVGParser.Shapes
{
    public class Circle : Shape
    {
        public double cx, cy;
        public double r;

        public Circle(double cx, double cy, double r, string stroke, string fill, double strokeWidth) : base(stroke, fill, strokeWidth)
        {
            this.cx = cx;
            this.cy = cy;
            this.r = r;
        }

        public Circle(XElement circle) : base(circle)
        {
            cx = (double)circle.Attribute("cx");
            cy = (double)circle.Attribute("cy");
            r = (double)circle.Attribute("r");
        }

        public override string GetTranslatedTag()
        {
            string tag = File.ReadAllText(Config.TemplatesDirPath + "CircleTemplate.txt");
            tag = ReplaceSpecificTagAttributes(tag);
            return ReplaceGeneralTagAttributes(tag);
        }

        public override string ReplaceSpecificTagAttributes(string tag)
        {
            return tag.Replace("${CX}", ((cx * Config.ScaleX) + Config.ShiftX).ToString())
                .Replace("${CY}", ((cy * Config.ScaleY) + Config.ShiftY).ToString())
                .Replace("${R}", ((Config.ScaleX == Config.ScaleY) ? (r * Config.ScaleX) : r).ToString());
        }
    }
}
