
namespace Utils.CommonModel
{
    /// <summary>
    /// Execute result model
    /// Give temporary date to transfer between two action
    /// </summary>
    public class ExecuteResultModel
    {
        /// <summary>
        /// Status code
        /// </summary>
        public ResponseStatusCodeHelper Status { get; set; } = ResponseStatusCodeHelper.Error;

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = "";
    }
}
