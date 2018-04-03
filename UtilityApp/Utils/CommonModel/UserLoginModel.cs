namespace Utils.CommonModel
{
    /// <summary>
    /// User login model
    /// </summary>
    public class UserLoginModel
    {
        /// <summary>
        /// User id
        /// </summary>
        public System.Guid UserID { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Session id
        /// </summary>
        public string SessionID { get; set; }

        /// <summary>
        /// Token string
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Second
        /// </summary>
        public System.DateTime ExpireTime { get; set; }
    }
}
