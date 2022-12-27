using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVGParser.Shapes;
using SVGParser.Shapes.PathCmds;
using System.Xml.Linq;

namespace SVGParser
{
    public class Program
    {
        static string svgViewBox = "";
        static string svgNamespace = "";
        static string svgShapeTags = "";

        static List<Shape> shapeList = new List<Shape>();


        static void Main(string[] args)
        {
            ReadFromSrcFile();

            SaveToDstFile();
        }


        public static List<string> Explode(string s)
        {
            // Deal with multiple spaces & non-visible/printable spaces (i.e. tabs)
            s = s.Replace(',', ' ').Replace('\t', ' ');
            return s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }


        public static void ReadFromSrcFile()
        {
            XDocument doc = XDocument.Load(Config.SVGFilesDirPath + Config.srcFilename);
            XElement svg = doc.Root;
            svgViewBox = (string)svg.Attribute("viewBox");
            svgNamespace = (string)svg.Attribute("xmlns");

            ParseShapes(svg.Elements().ToList());
        }



        public static void SaveToDstFile()
        {
            string svg = File.ReadAllText(Config.TemplatesDirPath + "SVGTemplate.txt");

            foreach (Shape shape in shapeList)
            {
                svgShapeTags += shape.GetTranslatedTag() + '\n';
            }

            svg = ReplaceSVGTagAttributes(svg);
            File.WriteAllText(Config.SVGFilesDirPath + Config.dstFilename, svg);
        }

        public static string GetTagNameFromXElement(XElement element)
        {
            string nameStr = element.Name.ToString().Trim();
            return nameStr.Substring(nameStr.IndexOf("}") + 1);
        }

        public static void ParseShapes(List<XElement> elements)
        {
            foreach (XElement element in elements)
            {
                string tagName = GetTagNameFromXElement(element);

                if (tagName == "rect")
                {
                    Rectangle rectangle = new Rectangle(element);
                    shapeList.Add(rectangle);
                }
                else if (tagName == "circle")
                {
                    Circle circle = new Circle(element);
                    shapeList.Add(circle);
                }
                else if (tagName == "ellipse")
                {
                    Ellipse ellipse = new Ellipse(element);
                    shapeList.Add(ellipse);
                }
                else if (tagName == "line")
                {
                    Line line = new Line(element);
                    shapeList.Add(line);
                }
                else if (tagName == "polyline")
                {
                    Polyline polyline = new Polyline(element);
                    shapeList.Add(polyline);
                }
                else if (tagName == "polygon")
                {
                    Polygon polygon = new Polygon(element);
                    shapeList.Add(polygon);
                }
                else if (tagName == "path")
                {
                    Shapes.Path path = new Shapes.Path(element);
                    shapeList.Add(path);
                }
            }

        }

        public static string ReplaceSVGTagAttributes(string tag)
        {
            return tag.Replace("${VIEWBOX}", svgViewBox)
                .Replace("${NAMESPACE}", svgNamespace)
                .Replace("${SHAPE_TAGS}", svgShapeTags);
        }
    }


}