using System.Xml;

namespace TrayWeather2
{
    internal class XMLWorker
    {
        public XMLWorker() { }

        public TwOptions LoadConfig(string xmlFile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            // получим корневой элемент
            XmlElement? xRoot = doc.DocumentElement;
            TwOptions opt = new TwOptions();
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    if (xnode.Name == "key")
                    {
                        opt.key = xnode.InnerText;
                    }
                    if (xnode.Name == "q")
                    {
                        opt.q = xnode.InnerText;
                    }
                    if (xnode.Name == "rph")
                    {
                        opt.rph = xnode.InnerText;
                    }
                }
            }
            return opt;
        }

        public void SaveConfig(string xmlFile, TwOptions opt)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<opt>\r\n    <key>{opt.key}</key>\r\n    <q>{opt.q}</q>\r\n    <rph>{opt.rph}</rph>\r\n</opt>");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            // Save the document to a file and auto-indent the output.
            XmlWriter writer = XmlWriter.Create(xmlFile, settings);
            doc.Save(writer);
        }
    }
}
