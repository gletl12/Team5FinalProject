﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class IniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private string path = "";

        public IniFile(string spath)
        {
            path = spath;
        }

        public void WriteIniFile(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, path);
        }

        public string ReadIniFile(string section, string key, string defaultValue)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, defaultValue, temp, 255, path);
            return temp.ToString();
        }
    }
}

