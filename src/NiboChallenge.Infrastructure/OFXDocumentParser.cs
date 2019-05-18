using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NiboChallenge.Infrastructure.Entities;

namespace NiboChallenge.Infrastructure
{
    public static class OFXDocumentParser
    {
        private static OFXDocument Load(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.Default))
            {
                return Parse(reader.ReadToEnd());
            }
        }

        public static IEnumerable<OFXDocument> Load(params Stream[] streams)
        {
            IList<OFXDocument> documents = new List<OFXDocument>();
            foreach (var stream in streams)
            {
                documents.Add(Load(stream));
            }
            return documents;
        }

        private static OFXDocument Load(string ofx)
        {
            return Parse(Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(ofx))));
        }

        public static IEnumerable<OFXDocument> Load(params string[] ofxs)
        {
            IList<OFXDocument> documents = new List<OFXDocument>();
            foreach (var ofx in ofxs)
            {
                documents.Add(Load(ofx));
            }
            return documents;
        }

        private static string ConvertSGMLTOXML(string sgml)
        {
            //TODO: Enhance function
            using (var reader = new StringReader(sgml))
            {
                string line;

                var stringBuilder = new StringBuilder();

                while ((line = reader.ReadLine()) != null)
                {
                    var tagEnd = line.IndexOf(">", StringComparison.CurrentCultureIgnoreCase);

                    if (tagEnd != line.Length - 1)
                    {
                        var tagStart = line.IndexOf("<", StringComparison.CurrentCultureIgnoreCase);

                        var tagName = line.Substring(tagStart + 1, (tagEnd - tagStart) - 1);

                        if (line.IndexOf($"</{tagName}>", StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            stringBuilder.AppendLine(line);
                        }
                        else
                        {
                            stringBuilder.AppendLine(String.Concat(line, string.Format("</{0}>", tagName)));
                        }
                    }
                    else
                    {
                        stringBuilder.AppendLine(line);
                    }
                }

                return stringBuilder.ToString();
            }
        }

        private static OFXDocument Parse(string data)
        {
            var xmlDocument = new XmlDocument();

            if (!data.StartsWith("OFXHEADER", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new InvalidDataException();
            }

            //TODO: Store data information (?)
            var ofx = data.Remove(0, data.IndexOf("<", StringComparison.CurrentCultureIgnoreCase));

            ofx = ConvertSGMLTOXML(ofx);

            xmlDocument.LoadXml(ofx);

            TextReader ofxReader = new StringReader(xmlDocument.InnerXml);
            OFXDocument ofxDocument = (OFXDocument)new XmlSerializer(typeof(OFXDocument)).Deserialize(ofxReader);

            return ofxDocument;
        }
    }
}
