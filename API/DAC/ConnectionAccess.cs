using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;

namespace API.DAC
{
    public class ConnectionAccess
    {
        protected string ConnectionString
        {
            get
            {
                string strConn = string.Empty;
                XmlDocument configXml = new XmlDocument();
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "/Team5Connect_DEV.xml";
                configXml.Load(path);

                XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");

                foreach (XmlNode node in addNodes)
                {
                    if (node.Attributes["key"].InnerText == "MyDB")
                    {
                        strConn = (node.ChildNodes[0]).InnerText;
                        break;
                    }
                }
                return strConn;
            }
        }
    }
}