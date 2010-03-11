using System.Web.Security;

namespace Redux.Membership
{
    public interface IPasswordService
    {
        void Unlock(MembershipUser user);
        string ResetPassword(MembershipUser user, string passwordAnswer);
    }
}