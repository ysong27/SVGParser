using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGParser
{
    internal class Config
    {
        public static string SVGFilesDirPath = "../../SVGFiles/";
        public static string TemplatesDirPath = "../../Templates/";
        public static string srcFilename = "src.svg";
        public static string dstFilename = "new.svg";



        public static double ShiftX = 0;
        public static double ShiftY = 0;

        public static double ScaleX = 2;
        public static double ScaleY = 2;

        public static double Rotation = 0;

    }
}
