using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Utils.Xml
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
        public static string ConvertToXml(this object model)
        {
            StringWriter _sw = new StringWriter();
            XmlTextWriter _tw = null;
            try
            {
                XmlSerializerNamespaces _xmlNamespace = new XmlSerializerNamespaces();
                _xmlNamespace.Add(string.Empty, string.Empty);
                XmlSerializer _xmlSerialier = new XmlSerializer(model.GetType());
                _tw = new XmlTextWriter(_sw);
                _xmlSerialier.Serialize(_tw, model, _xmlNamespace);
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
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
            StringReader _strReader = null;
            XmlSerializer _serializer = null;
            XmlTextReader _xmlReader = null;
            object _obj = null;
            try
            {
                _strReader = new StringReader(xmlContent);
                _serializer = new XmlSerializer(objectType);
                _xmlReader = new XmlTextReader(_strReader);
                _obj = _serializer.Deserialize(_xmlReader);
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            finally
            {
                if (_xmlReader != null)
                {
                    _xmlReader.Close();
                }
                if (_strReader != null)
                {
                    _strReader.Close();
                }
            }
            return _obj;
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
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        /// <summary>
        /// Get value in single node
        /// </summary>
        /// <param name="filePath">Xml file path</param>
        /// <param name="nodePath">Node path. Ex:root/node/</param>
        /// <returns>String value, empty if node is not found or error</returns>
        public static string GetValueInSingleNodeFromFile(this string filePath, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(filePath);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item != null)
                {
                    Console.WriteLine(_item.InnerText);
                    return _item.InnerText;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// Get value in single node
        /// </summary>
        /// <param name="xmlContent">Xml string</param>
        /// <param name="nodePath">Node path. Ex:root/node/</param>
        /// <returns>String value, empty if node is not found or error</returns>
        public static string GetValueInSingleNodeFromXmlContent(this string xmlContent, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.LoadXml(xmlContent);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item != null)
                {
                    Console.WriteLine(_item.InnerText);
                    return _item.InnerText;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// Get XML content inside a single node
        /// </summary>
        /// <param name="filePath">Xml file path</param>
        /// <param name="nodePath">ode path. Ex:root/node/</param>
        /// <returns>Xml string content, empty if node is not found or error</returns>
        public static string GetSingleNodeContentFromFile(this string filePath, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(filePath);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item != null)
                {
                    Console.WriteLine(_item.InnerXml);
                    return _item.InnerXml;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// Get XML content inside a single node
        /// </summary>
        /// <param name="xmlContent">Xml content</param>
        /// <param name="nodePath">ode path. Ex:root/node/</param>
        /// <returns>Xml string content, empty if node is not found or error</returns>
        public static string GetSingleNodeContentFromXmlContent(this string xmlContent, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.LoadXml(xmlContent);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item != null)
                {
                    Console.WriteLine(_item.InnerXml);
                    return _item.InnerXml;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// Get attribute value in single node
        /// </summary>
        /// <param name="filePath">Xml file path</param>
        /// <param name="nodePath">Node path. Ex:root/node/@attribute</param>
        /// <returns>String value, empty if node is not found or error</returns>
        public static string GetAttributeValueInSingleNodeFromFile(this string filePath, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(filePath);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item != null)
                {
                    Console.WriteLine(_item.InnerText);
                    return _item.InnerText;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// Get attribute value in single node
        /// </summary>
        /// <param name="xmlContent">Xml content</param>
        /// <param name="nodePath">Node path. Ex:root/node/@attribute</param>
        /// <returns>String value, empty if node is not found or error</returns>
        public static string GetAttributeValueInSingleNodeFromXmlContent(this string xmlContent, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.LoadXml(xmlContent);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item != null)
                {
                    Console.WriteLine(_item.InnerText);
                    return _item.InnerText;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// Write xml file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="node">Xml node</param>
        /// <returns>true/false</returns>
        public static bool CreateFile(string filePath, XMLContentModel node)
        {
            try
            {
                XmlWriterSettings _setting = new XmlWriterSettings();
                _setting.Indent = true;
                _setting.IndentChars = " ";
                _setting.CloseOutput = true;
                _setting.OmitXmlDeclaration = false; ////False: show xml version=1.0 encoding=utf-8, true: hidden
                using (XmlWriter writer = XmlWriter.Create(filePath, _setting))
                {
                    if (node.RootName.Length == 0)
                    {
                        return false;
                    }
                    if (node.Comment.Length > 0)
                    {
                        writer.WriteComment(node.Comment);
                    }
                    writer.WriteStartElement(node.RootName);
                    WriteNode(writer, node.Nodes);
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return false;
        }

        /// <summary>
        /// Wirte xml node
        /// </summary>
        /// <param name="writer">writer</param>
        /// <param name="nodes">list of xml node</param>
        /// <returns>true/false</returns>
        private static bool WriteNode(XmlWriter writer, List<XMLNodeModel> nodes)
        {
            try
            {
                foreach (var n in nodes)
                {
                    if (n.Comment.Length > 0)
                    {
                        writer.WriteComment(n.Comment);
                    }
                    if (n.Data.Name.Length == 0)
                    {
                        continue;
                    }
                    if (n.Data.Value.Length > 0)
                    {
                        writer.WriteElementString(n.Data.Name, n.Data.Value);
                    }
                    else
                    {
                        writer.WriteStartElement(n.Data.Name);
                        if (n.Properties.Count > 0)
                        {
                            WriteAttribute(writer, n.Properties);
                        }
                        WriteNode(writer, n.Childs);
                        writer.WriteEndElement();
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return true;
        }

        /// <summary>
        /// Write attirbute into xml node
        /// </summary>
        /// <param name="writer">Xml writer</param>
        /// <param name="properties">List of properties</param>
        /// <returns>true/false</returns>
        private static bool WriteAttribute(XmlWriter writer, List<XmlNodeDataModel> properties)
        {
            try
            {
                foreach (var p in properties)
                {
                    writer.WriteAttributeString(p.Name, p.Value);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return false;
        }

        /// <summary>
        /// Remove node from xml file
        /// </summary>
        /// <param name="filePath">Xml file path</param>
        /// <param name="nodePath">Node path</param>
        /// <returns>true/false</returns>
        public static bool RemoveNodeFromFile(this string filePath, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(filePath);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item == null)
                {
                    return false;
                }
                _item.ParentNode.RemoveChild(_item);
                _doc.Save(filePath);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return false;
        }

        /// <summary>
        /// Remove node from xml content
        /// </summary>
        /// <param name="xmlContent">Xml content</param>
        /// <param name="nodePath">Node path</param>
        /// <returns>xml content</returns>
        public static string RemoveNodeFromXmlContent(this string xmlContent, string nodePath)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.LoadXml(xmlContent);
                var _item = _doc.SelectSingleNode(nodePath);
                if (_item == null)
                {
                    return xmlContent;
                }
                _item.ParentNode.RemoveChild(_item);
                return _doc.InnerXml.ToString();
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog(string.Empty, ex);
            }
            return xmlContent;
        }

    }
}
