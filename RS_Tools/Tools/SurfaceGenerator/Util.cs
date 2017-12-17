using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Tools.Tools.SurfaceGenerator
{
    class Util
    {

        public const string APPFOLDER = "TBPE";

        private static class SETTINGSTAG
        {
            public const string LASFOLDER = "lasfolder";
            public const string LASTOOLSFOLDER = "lastoolsfolder";
            public const string PROCESSES = "processes";
        }

        protected string userFolder = string.Empty;

        protected string lasFolder = string.Empty;
        protected string lastoolsFolder = string.Empty;
        protected decimal processes = 3;
        private const string settings = ".settings";

        public string LASFOLDER
        {
            set { lasFolder = value; }
            get
            {
                if (!Directory.Exists(lasFolder)) return string.Empty;
                return lasFolder;
            }
        }
        public string LASTOOLSFOLDER
        {
            set { lastoolsFolder = value; }
            get
            {
                if (!Directory.Exists(lastoolsFolder)) return string.Empty;
                return lastoolsFolder;
            }
        }
        public decimal PROCESSES
        {
            set { processes = value; }
            get { return processes; }
        }
        public string UserFolder
        {
            get { return userFolder; }
        }

        public Util()
        {
            userFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), APPFOLDER);
            if (!Directory.Exists(userFolder)) Directory.CreateDirectory(userFolder);
            GetFolderPath();
        }

        internal void SaveSettings()
        {
            setSetting(settings, lasFolder, SETTINGSTAG.LASFOLDER);
            setSetting(settings, lastoolsFolder, SETTINGSTAG.LASTOOLSFOLDER);
            setSetting(settings, PROCESSES.ToString(), SETTINGSTAG.PROCESSES);
        }

        protected void GetFolderPath()
        {
            lasFolder = getSetting(settings, SETTINGSTAG.LASFOLDER);
            lastoolsFolder = getSetting(settings, SETTINGSTAG.LASTOOLSFOLDER);

            string s = getSetting(settings, SETTINGSTAG.PROCESSES);
            if (s.Length > 0)
                decimal.TryParse(s, out processes);

        }

        private string getSetting(string filename, string tag)
        {
            string filepath = System.IO.Path.Combine(userFolder, filename);
            if (File.Exists(filepath))
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] split = line.Split(';');
                        if (split.Length > 1)
                        {
                            if (string.Compare(split[0], tag, true) == 0)
                                return split[1];
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void setSetting(string filename, string setting, string tag)
        {
            string tempfilepath = System.IO.Path.Combine(userFolder, "x_" + filename);
            string filepath = System.IO.Path.Combine(userFolder, filename);
            using (StreamWriter sw = new StreamWriter(tempfilepath, false))
            {
                bool found = false;
                if (System.IO.File.Exists(filepath))
                {
                    using (StreamReader sr = new StreamReader(filepath))
                    {
                        string line = string.Empty;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] split = line.Split(';');
                            if (split.Length > 1)
                            {
                                if (string.Compare(split[0], tag, true) == 0)
                                {
                                    sw.WriteLine(tag + ";" + setting);
                                    found = true;
                                }
                                else
                                    sw.WriteLine(line);
                            }
                        }
                    }
                }
                if (!found)
                    sw.WriteLine(tag + ";" + setting);
            }
            System.IO.File.Copy(tempfilepath, filepath, true);
        }
    }
}
