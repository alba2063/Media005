using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MediaInfo
{
    class Writer
    {
        public void WriteSettings(string fileName)
        {
            //fileName = "MediaInfo_ini.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Settings");
                //writer.WriteElementString("ConnectionString", "Data Source=validatordb.sqlite;Version=3;");

                writer.WriteStartElement("Orquectras");

                writer.WriteStartElement("Orquectra");
                //writer.WriteElementString("Index", "0");
                writer.WriteElementString("Orq_name", "Donato");
                writer.WriteElementString("Image_file", "Images\\EDGARDO DONATO.jpg");
                writer.WriteElementString("Info_1", "");
                writer.WriteElementString("Info_2", "");
                writer.WriteElementString("Info_3", "");
                writer.WriteEndElement();

                writer.WriteStartElement("Orquectra");
                //writer.WriteElementString("Index", "1");
                writer.WriteElementString("Orq_name", "Canaro");
                writer.WriteElementString("Image_file", "Images\\Francisco Canaro.jpg");
                writer.WriteElementString("Info_1", "Birth name: Francisco Canarozzo");
                writer.WriteElementString("Info_2", "Born: November 26, 1888 (Uruguay)");
                writer.WriteElementString("Info_3", "Died: December 14, 1964 (Argentina)(aged 76)");
                writer.WriteEndElement();

                writer.WriteStartElement("Orquectra");
                //writer.WriteElementString("Index", "2");
                writer.WriteElementString("Orq_name", "Di Sarli");
                writer.WriteElementString("Image_file", "Images\\Carlos Di Sarli.jpg");
                writer.WriteElementString("Info_1", "");
                writer.WriteElementString("Info_2", "");
                writer.WriteElementString("Info_3", "");
                writer.WriteEndElement();

                writer.WriteStartElement("Orquectra");
                //writer.WriteElementString("Index", "3");
                writer.WriteElementString("Orq_name", "Troilo");
                writer.WriteElementString("Image_file", "Images\\Aníbal Troilo.jpg");
                writer.WriteElementString("Info_1", "");
                writer.WriteElementString("Info_2", "");
                writer.WriteElementString("Info_3", "");
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static string CreateXML(UISettingsCollection ui)
        {
            XmlDocument xmlDoc = new XmlDocument();

            // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(ui.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, ui);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        public static UISettingsCollection CreateObject(string XMLString, UISettingsCollection ui)
        {
            

            if (!XMLString.Equals(""))
            {           
                XmlSerializer xmlSerializer = new XmlSerializer(ui.GetType());
                //The StringReader will be the stream holder for the existing XML file 
                byte[] bytes = Convert.FromBase64String(XMLString);
                MemoryStream stream = new MemoryStream(bytes);
                var ui1 = xmlSerializer.Deserialize(stream);
                //initially deserialized, the data is represented by an object without a defined type 
                return (UISettingsCollection)ui1;
            }
            else
            {
                return ui;
            }
            
        }
    }
}
