using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace MediaInfo
{
    //The class is for to create XML document from an object (collection of UISettings objects)
    //and then build the collection of objects from the XML document
    class Serialization
    {
        public static XmlDocument CreateXML(UISettingsCollection ui)
        {

            XmlDocument xmlDoc = new XmlDocument();

            // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(ui.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                try
                {
                    xmlSerializer.Serialize(xmlStream, ui);
                    xmlStream.Position = 0;
                    //Loads the XML document from the specified string.
                    xmlDoc.Load(xmlStream);
                    //xmlDoc.Save("settings.xml");
                }
                finally
                {
                    if (xmlStream != null)
                    {
                        xmlStream.Close();
                    }
                }
            }
                return xmlDoc;
            
        }

        public static UISettingsCollection CreateObject(XmlDocument XMLString, UISettingsCollection ui)
        {

            UISettingsCollection ui1 = new UISettingsCollection();

            if (XMLString != null)
            {

                XmlSerializer oXmlSerializer = new XmlSerializer(ui.GetType());

                XmlNodeReader reader = null;

                try
                {
                    reader = new XmlNodeReader(XMLString);

                    ui1 = oXmlSerializer.Deserialize(reader) as UISettingsCollection;
                    //initially deserialized, the data is represented by an object without a defined type 
                }
                finally
                {
                    if (reader != null)
                    { 
                        reader.Close();
                    }
                }
                return ui1;

            }
            else
            {
                return ui;
            }

        }
    }
}
