using SVGParser.Shapes.PathCmds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVGParser.Shapes
{
    public class Path : Shape
    {
        public static char[] commands = new char[] { 'M', 'm', 'L', 'l', 'H', 'h', 'V', 'v', 'C', 'c', 'S', 's', 'Q', 'q', 'T', 't', 'A', 'a', 'Z', 'z' };

        public string pathString = "";          // equivalent to d attribute

        public List<PathCmd> pathCommands = new List<PathCmd>();


        public Path(XElement path) : base(path)
        {
            pathString = ((string)path.Attribute("d")).Trim();

            string cmd = ExtractNextCmd();
            while (cmd != "")
            {
                ParseCommand(cmd);
                cmd = ExtractNextCmd();
            }

            // put translated pathString
            foreach (PathCmd p in pathCommands)
            {
                pathString += p.GetTranslatedCmdText() + '\n';
            }
        }

        public string ExtractNextCmd()
        {
            string cmd = "";
            pathString = pathString.Trim();

            if (pathString.Length < 1) return cmd;

            for (int i = 1; i <= pathString.Length; i++)
            {
                if (i == pathString.Length)
                {
                    cmd = pathString.Substring(0, i);
                    break;
                }
                if (commands.Contains(pathString[i]))
                {
                    cmd = pathString.Substring(0, i - 1);
                    break;
                }
            }
            pathString = pathString.Substring(cmd.Length).Trim();
            return cmd.Trim();
        }

        private void ParseCommand(string cmd)
        {
            List<string> argList = new List<string>();

            // explode only if cmd is not Z or z
            if (cmd != "Z" || cmd != "z")
            {
                argList = Explode(cmd.Substring(1));
            }

            // Add PathCmd child objects to pathCommands
            if (cmd.StartsWith("M"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, MCmd.ArgCount);
                    pathCommands.Add(new MCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("m"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, mCmd.ArgCount);
                    pathCommands.Add(new mCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("L"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, LCmd.ArgCount);
                    pathCommands.Add(new LCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("l"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, lCmd.ArgCount);
                    pathCommands.Add(new lCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("H"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, HCmd.ArgCount);
                    pathCommands.Add(new HCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("h"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, hCmd.ArgCount);
                    pathCommands.Add(new hCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("V"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, VCmd.ArgCount);
                    pathCommands.Add(new VCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("v"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, vCmd.ArgCount);
                    pathCommands.Add(new vCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("C"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, CCmd.ArgCount);
                    pathCommands.Add(new CCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("c"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, cCmd.ArgCount);
                    pathCommands.Add(new cCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("S"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, SCmd.ArgCount);
                    pathCommands.Add(new SCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("s"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, sCmd.ArgCount);
                    pathCommands.Add(new sCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("Q"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, QCmd.ArgCount);
                    pathCommands.Add(new QCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("q"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, qCmd.ArgCount);
                    pathCommands.Add(new qCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("T"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, TCmd.ArgCount);
                    pathCommands.Add(new TCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("t"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, tCmd.ArgCount);
                    pathCommands.Add(new tCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("A"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, ACmd.ArgCount);
                    pathCommands.Add(new ACmd(objArgList));
                }
            }
            else if (cmd.StartsWith("a"))
            {
                while (argList.Count > 0)
                {
                    List<string> objArgList = Peel(ref argList, aCmd.ArgCount);
                    pathCommands.Add(new aCmd(objArgList));
                }
            }
            else if (cmd.StartsWith("Z"))
            {
                pathCommands.Add(new ZCmd());
            }
            else if (cmd.StartsWith("z"))
            {
                pathCommands.Add(new zCmd());
            }
        }

        public List<string> Explode(string s)
        {
            // Deal with multiple spaces & non-visible/printable spaces (i.e. tabs)
            s = s.Replace(',', ' ').Replace('\t', ' ');
            return s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public List<string> Peel(ref List<string> argList, int pathCmdArgCount)
        {
            // Peel arguments based on the number of parameters for the PathCmd child class
            List<string> objArgList = new List<string>();
            for (int i = 0; i < pathCmdArgCount; i++)
            {
                objArgList.Add(argList[0]);
                argList.RemoveAt(0);
            }
            return objArgList;
        }

        public override string GetTranslatedTag()
        {
            string tag = File.ReadAllText(Config.TemplatesDirPath + "PathTemplate.txt");
            tag = ReplaceSpecificTagAttributes(tag);
            return ReplaceGeneralTagAttributes(tag);
        }

        public override string ReplaceSpecificTagAttributes(string tag)
        {
            return tag.Replace("${D}", pathString);
        }
    }
}
