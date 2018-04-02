using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Utils
{
    /// <summary>
    /// Xml extension class
    /// </summary>
    public static class XmlExtensionHelper
    {

        /// <summary>
        /// Convert to xml string from object model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ConvertToXxml(this object model)
        {
            StringWriter _sw = new StringWriter();
            XmlTextWriter _tw = null;
            try
            {
                XmlSerializerNamespaces _xmlNamespace = new XmlSerializerNamespaces();
                _xmlNamespace.Add("", "");
                XmlSerializer _xmlSerialier = new XmlSerializer(model.GetType());
                _tw = new XmlTextWriter(_sw);
                _xmlSerialier.Serialize(_tw, model, _xmlNamespace);
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog("", ex);
            }
            finally
            {
                _sw.Close();
                if (_tw != null)
                {
                    _tw.Close();
                }
            }
            return _sw.ToString();
        }

        /// <summary>
        /// Convert to object model from xml string
        /// </summary>
        /// <param name="xmlContent">Xml content</param>
        /// <param name="objectType">Object type</param>
        /// <returns></returns>
        public static object ConvertToObject(this string xmlContent, Type objectType)
        {
            StringWriter _sw = new StringWriter();
            XmlTextWriter _tw = null;
            try
            {

            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog("", ex);
            }
            finally
            {
                _sw.Close();
                if (_tw != null)
                {
                    _tw.Close();
                }
            }
            return null;
        }

        /// <summary>
        /// Format text to xml 
        /// Input value must be xml content
        /// </summary>
        /// <param name="xmlContent">Xml content</param>
        /// <returns></returns>
        public static String FormatXmlContent(this String xmlContent)
        {
            XmlDocument _doc = new XmlDocument();
            try
            {
                _doc.Load(new StringReader(xmlContent));
                StringBuilder _builder = new StringBuilder();
                using (XmlTextWriter writer = new XmlTextWriter(new StringWriter(_builder)))
                {
                    writer.Formatting = Formatting.Indented;
                    _doc.Save(writer);
                }
                return _builder.ToString();
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog("", ex);
            }
            finally
            {
                
            }
            return "";
        }
    }
}
