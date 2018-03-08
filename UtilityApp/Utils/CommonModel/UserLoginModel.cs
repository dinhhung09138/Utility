using System;
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
        public Guid UserID { get; set; }

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
    }
}
