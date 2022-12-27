using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace SVGParser.Shapes
{
    public class Ellipse : Shape
    {
        public double cx, cy;
        public double rx, ry;

        public Ellipse(double cx, double cy, double rx, double ry, string stroke, string fill, double strokeWidth) : base (stroke, fill, strokeWidth)
        {
            this.cx = cx;
            this.cy = cy;
            this.rx = rx;
            this.ry = ry;
        }

        public Ellipse(XElement ellipse) : base(ellipse)
        {
            cx = (double)ellipse.Attribute("cx");
            cy = (double)ellipse.Attribute("cy");
            rx = (double)ellipse.Attribute("rx");
            ry = (double)ellipse.Attribute("ry");
        }

        public override string GetTranslatedTag()
        {
            string tag = File.ReadAllText(Config.TemplatesDirPath + "EllipseTemplate.txt");
            tag = ReplaceSpecificTagAttributes(tag);
            return ReplaceGeneralTagAttributes(tag);
        }

        public override string ReplaceSpecificTagAttributes(string tag)
        {
            return tag.Replace("${CX}", ((cx * Config.ScaleX) + Config.ShiftX).ToString())
                .Replace("${CY}", ((cy * Config.ScaleY) + Config.ShiftY).ToString())
                .Replace("${RX}", (rx * Config.ScaleX).ToString())
                .Replace("${RY}", (ry * Config.ScaleY).ToString());
        }

    }
}
