using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVGParser.Shapes
{
    public class Polyline : Shape
    {
        public List<Coord> points = new List<Coord>();

        public Polyline(List<Coord> points, string stroke, string fill, double strokeWidth) : base(stroke, fill, strokeWidth) 
        {
            this.points = points;
        }

        public Polyline(XElement polyline) : base(polyline)
        {
            string pointsStr = (string)polyline.Attribute("points");
            List<string> pointsList = Program.Explode(pointsStr);
            for (int i = 0; i < pointsList.Count; i += 2)
            {
                Coord coord = new Coord(int.Parse(pointsList[i]), int.Parse(pointsList[i + 1]));
                points.Add(coord);
            }
        }

        public override string GetTranslatedTag()
        {
            List<string> coordStrList = new List<string>();
            foreach (Coord p in points)
            {
                coordStrList.Add(p.GetCoordText());
            }
            string tag = File.ReadAllText(Config.TemplatesDirPath + "PolylineTemplate.txt");
            tag = ReplaceSpecificTagAttributes(tag, coordStrList);
            return ReplaceGeneralTagAttributes(tag);
        }

        public override string ReplaceSpecificTagAttributes(string tag, List<string> coordStrList)
        {
            return tag.Replace("${POINTS}", string.Join(" ", coordStrList));
        }

    }
}
