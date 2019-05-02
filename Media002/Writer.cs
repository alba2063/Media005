using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Media002
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
                //writer.WriteElementString("SnLength", "7");

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
    }
}
