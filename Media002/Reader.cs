﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MediaInfo
{
    class Reader
    {
        private string setFile = "MediaInfo_ini.xml";

        public OrquestraCollection ReadIni()
        {

            OrquestraCollection orqs = new OrquestraCollection();

            if (!File.Exists(setFile))
			{
				Writer writer = new Writer();
                writer.WriteSettings(setFile);
				Application.Restart();

				//MessageBox.Show(ex.Message);
			}
			else
			{				
				try
				{
					XmlDocument doc = new XmlDocument();
                    doc.Load(setFile);

					XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Settings/Orquectras/Orquectra");

					foreach (XmlNode node in nodes)
					{
						Orquestra orq = new Orquestra();

						orq.OrqName = node.SelectSingleNode("Orq_name").InnerText;
						orq.ImageFile = node.SelectSingleNode("Image_file").InnerText;
                        orq.Info_1 = node.SelectSingleNode("Info_1").InnerText;
                        orq.Info_2 = node.SelectSingleNode("Info_2").InnerText;
                        orq.Info_3 = node.SelectSingleNode("Info_3").InnerText;

                        orqs.Add(orq);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error reading Validator_ini.xml");
					throw new ReadFileErrorException(setFile, ex);
				}
			}

			return orqs;
		}
    }
}
