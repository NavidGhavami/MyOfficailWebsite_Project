using _0_Framework;
using _0_Framework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public long RoleId { get; private set; }
        public Role.Role Role { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account(string fullName, string username, string password, long roleId, string mobile, string profilePhoto)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            RoleId = roleId;

            if (roleId == 0)
            {
                RoleId = 2;
            }

            Mobile = mobile;
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullName, string username, long roleId, string mobile, string profilePhoto)
        {
            FullName = fullName;
            Username = username;
            RoleId = roleId;
            Mobile = mobile;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
            {
                ProfilePhoto = profilePhoto;
            }
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
