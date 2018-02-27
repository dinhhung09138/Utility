using System;
namespace Utils.CommonModel
{
    public class UserLoginModel
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }
    }
}
