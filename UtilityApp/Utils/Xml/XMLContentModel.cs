using System.Collections.Generic;

namespace Utils.Xml
{
    /// <summary>
    /// Xml content model
    /// </summary>
    public class XMLContentModel
    {
        /// <summary>
        /// Root name
        /// </summary>
        public string RootName { get; set; } = string.Empty;

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// List of node
        /// </summary>
        public List<XMLNodeModel> Nodes { get; set; } = new List<XMLNodeModel>();
    }
}
