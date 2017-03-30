using BCSsolution.onStart.model;

namespace BCSsolution.onStart.model
{
    public class AnonymousIdentity : UserIdentity
    {
        public AnonymousIdentity() : base(string.Empty, string.Empty, new string[] { })
        { }
    }
}
