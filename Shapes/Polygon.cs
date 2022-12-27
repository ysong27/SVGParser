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
    public class Polygon : Shape
    {
        public List<Coord> points = new List<Coord>();

        public Polygon(List<Coord> points, string stroke, string fill, double strokeWidth) : base(stroke, fill, strokeWidth)
        {
            this.points = points;
        }       

        public Polygon(XElement polygon) : base(polygon)
        {
            string pointsStr = (string)polygon.Attribute("points");
            List<string> pointsList = Program.Explode(pointsStr);
            for (int i = 0; i < pointsList.Count; i += 2)
            {
                Coord coord = new Coord(int.Parse(pointsList[i]), int.Parse(pointsList[i + 1]));
                points.Add(coord);
            }
        }

        public override string ReplaceSpecificTagAttributes(string tag, List<string> coordStrList)
        {
            return tag.Replace("${POINTS}", string.Join(" ", coordStrList));
        }

        public override string GetTranslatedTag()
        {
            List<string> coordStrList = new List<string>();
            foreach(Coord p in points)
            {
                coordStrList.Add(p.GetCoordText());
            }
            string tag = File.ReadAllText(Config.TemplatesDirPath + "PolygonTemplate.txt");
            tag = ReplaceSpecificTagAttributes(tag, coordStrList);
            return ReplaceGeneralTagAttributes(tag);
        }


    }
}
