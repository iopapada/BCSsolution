using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System.Security.Principal;
using System;

namespace BCSsolution.onStart.model
{
    public class User
    {
        //public User() { }
        //public User(string username, string password, string firstname, string lastname, string[] roles)
        //{

        //}
        public enum Role { admin, user, visitor }
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string HashedPassword { get; set ;  }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Role UserRole {get; set; }
        public virtual string UserMail { get; set; }
        public virtual string GetFullName() { return string.Format("{1} {0}", FirstName, LastName);}

    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            this.Schema("dbo");
            this.Table("users");
            this.Id(x => x.Id, m => { m.Column("id"); m.Generator(Generators.Increment); });
            this.Property(x => x.UserName, m => { m.Column("username"); m.NotNullable(true); m.Length(20); });
            this.Property(x => x.HashedPassword, m => { m.Column("password"); m.NotNullable(true); m.Length(100); });
            this.Property(x => x.FirstName, m => { m.Column("firstname"); m.NotNullable(true); m.Length(50); });
            this.Property(x => x.LastName, m => { m.Column("lastname"); m.NotNullable(true); m.Length(50); });
            this.Property(x => x.UserMail, m => { m.Column("email"); m.NotNullable(false); m.Length(50); });
            this.Property(x => x.UserRole, m => { m.Column("role"); m.NotNullable(true); m.Length(10); });
        }
    }
}
