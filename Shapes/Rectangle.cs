using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace SVGParser.Shapes
{
    public class Rectangle : Shape
    {
        public double x, y;
        public double width, height;
        public double rx, ry;


        public Rectangle(double x, double y, double width, double height, double rx, double ry, string stroke, string fill, double strokeWidth) : base(stroke, fill, strokeWidth)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.rx = rx;
            this.ry = ry;
        }

        public Rectangle(XElement rectangle) : base(rectangle)
        {
            x = (double)rectangle.Attribute("x");
            y = (double)rectangle.Attribute("y");
            width = (double)rectangle.Attribute("width");
            height = (double)rectangle.Attribute("height");
            rx = (rectangle.Attribute("rx") == null ? 0 : (double)rectangle.Attribute("rx"));
            ry = (rectangle.Attribute("ry") == null ? 0 : (double)rectangle.Attribute("ry"));          
        }

        public override string GetTranslatedTag()
        {
            string tag = File.ReadAllText(Config.TemplatesDirPath + "RectangleTemplate.txt");
            tag = ReplaceSpecificTagAttributes(tag);
            return ReplaceGeneralTagAttributes(tag);
        }
        
        public override string ReplaceSpecificTagAttributes(string tag)
        {
            return tag.Replace("${X}", ((x * Config.ScaleX) + Config.ShiftX).ToString())
                .Replace("${Y}", ((y * Config.ScaleY) + Config.ShiftY).ToString())
                .Replace("${WIDTH}", (width * Config.ScaleX).ToString())
                .Replace("${HEIGHT}", (height * Config.ScaleY).ToString())
                .Replace("${RX}", (rx * Config.ScaleX).ToString())
                .Replace("${RY}", (ry * Config.ScaleY).ToString());
        }



    }
}
