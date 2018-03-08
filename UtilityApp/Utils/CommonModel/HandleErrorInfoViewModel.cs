
using System.Web.Mvc;

namespace Utils.CommonModel
{
    /// <summary>
    /// Handle error infor model
    /// </summary>
    public class HandleErrorInfoViewModel
    {
        /// <summary>
        /// Error infor
        /// </summary>
        public HandleErrorInfo ErrorInfo { get; set; }

        /// <summary>
        /// Return url
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
