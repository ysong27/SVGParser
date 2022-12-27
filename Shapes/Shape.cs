using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVGParser.Shapes
{
    public class Shape
    {
        public string stroke;
        public string fill;
        public double strokeWidth;


        public Shape() { }

        public Shape(string stroke = "", string fill = "", double strokeWidth = 1)
        {
            this.stroke = stroke;
            this.fill = fill;
            this.strokeWidth = strokeWidth;
        }

        public Shape(XElement element)
        {
            stroke = (element.Attribute("stroke") == null ? "" : (string)element.Attribute("stroke"));
            fill = (element.Attribute("fill") == null ? "" : (string)element.Attribute("fill"));
            strokeWidth = (element.Attribute("stroke-width") == null ? 1 : (double)element.Attribute("stroke-width"));
        }

        public string ReplaceGeneralTagAttributes(string tag)
        {
            return tag.Replace("${STROKE}", stroke.ToString())
                .Replace("${FILL}", fill.ToString())
                .Replace("${STROKE-WIDTH}", strokeWidth.ToString());
        }

        public virtual string GetTranslatedTag()
        {
            return "";
        }

        public virtual string ReplaceSpecificTagAttributes(string tag)
        {
            return "";
        }

        public virtual string ReplaceSpecificTagAttributes(string tagTemplate, List<string> coordStrList)
        {
            return "";
        }


    }
}
