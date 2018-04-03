namespace Utils.Xml
{
    /// <summary>
    /// Data of 
    /// </summary>
    public class XmlNodeDataModel
    {
        /// <summary>
        /// Node name
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Node value. If has value, Node can not write child node inside
        /// </summary>
        public string Value { get; set; } = "";
    }
}
