namespace Utils
{
    /// <summary>
    /// Init common value
    /// </summary>
    public class CommonHelper
    {
        /// <summary>
        /// Session name for user data after login
        /// </summary>
        public static readonly string SESSION_LOGIN_NAME = "UserProfile";

        /// <summary>
        /// This name declared for set a parameter to give a model response to transfer between actions
        /// </summary>
        public static readonly string EXECUTE_RESULT = "ExecuteResult";

        /// <summary>
        /// Type of exception
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// Forbiden
            /// </summary>
            Forbiden,

            /// <summary>
            /// /Error
            /// </summary>
            Error,

            /// <summary>
            /// Not found
            /// </summary>
            NotFound
        }
    }
}
