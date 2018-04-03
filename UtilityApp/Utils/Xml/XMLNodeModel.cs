using System.Collections.Generic;

namespace Utils.Xml
{
    /// <summary>
    /// Xml node data model
    /// </summary>
    public class XMLNodeModel
    {
        /// <summary>
        /// Data of node
        /// </summary>
        public XmlNodeDataModel Data { get; set; } = new XmlNodeDataModel();

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Child nodes
        /// </summary>
        public List<XMLNodeModel> Childs { get; set; } = new List<XMLNodeModel>();

        /// <summary>
        /// Properties of node
        /// </summary>
        public List<XmlNodeDataModel> Properties { get; set; } = new List<XmlNodeDataModel>();


    }
}
