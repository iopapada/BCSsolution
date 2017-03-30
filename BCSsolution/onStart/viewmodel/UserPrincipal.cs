using BCSsolution.onStart.model;
using System.Security.Principal;
using System.Linq;

namespace BCSsolution.onStart.viewmodel
{
    public class UserPrincipal : IPrincipal
    {
        private UserIdentity _identity;
        public UserIdentity Identity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }
        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Roles.Contains(role);
        }
    }
}
