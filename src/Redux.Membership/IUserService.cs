using System.Web.Security;
using ReduxArch.Core.PagedList;
using ReduxArch.Web.PagedList;

namespace Redux.Membership
{
    public interface IUserService
    {
        int TotalUsers { get; }
        int UsersOnline{ get; }
        IPagedList<MembershipUser> FindAll(int pageIndex, int pageSize);
        IPagedList<MembershipUser> FindByEmail(string emailAddressToMatch, int pageIndex, int pageSize);
        IPagedList<MembershipUser> FindByUserName(string userNameToMatch, int pageIndex, int pageSize);
        MembershipUser Get(string userName);
        MembershipUser Get(object providerUserKey);
        void Update(MembershipUser user);
        void Delete(MembershipUser user);
        MembershipUser Touch(MembershipUser user);
        MembershipUser Touch(string userName);
        MembershipUser Touch(object providerUserKey);
    }
}