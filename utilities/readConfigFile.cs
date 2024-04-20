using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace iCargoUIAutomation.utilities
{
    public class readConfigFile
    {
        public static string readLocators(string section, string key)
        {
            var parser = new FileIniDataParser();
           
            string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);           
            string filepath = Path.Combine(userDirectory, "AutomateiCargoUIFunctionalities", "Configuration","config.ini");
            IniData data = parser.ReadFile(filepath);          

            return data[section][key];
            
        }
    }
}
