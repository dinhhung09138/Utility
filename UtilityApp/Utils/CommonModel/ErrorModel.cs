namespace Utils.CommonModel
{
    /// <summary>
    /// Error model
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Error code
        /// </summary>
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Detail error
        /// </summary>
        public string DetailedError { get; set; }
    }
}
