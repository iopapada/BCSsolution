using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSsolution.organization.model
{
    public class Supplier
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
        public virtual string Grs { get; set; }
        public virtual string Ids { get; set; }
        public virtual string Email { get; set; }
        public virtual string Tel1 { get; set; }
        public virtual string Mob1 { get; set; }
    }

    public class SupplierMap : ClassMapping<Supplier>
    {
        public SupplierMap()
        {
            this.Schema("dbo");
            this.Table("suppliers");
            this.Id(x => x.Id, m => { m.Column("id"); m.Generator(Generators.Increment); });
            this.Property(x => x.FirstName, m => { m.Column("firstname"); m.NotNullable(true); m.Length(50);  });
            this.Property(x => x.LastName, m => { m.Column("lastname") ; m.NotNullable(true); m.Length(50); });
            this.Property(x => x.Grs, m => { m.Column("grs"); m.NotNullable(true); m.Length(20); });
            this.Property(x => x.Ids, m => { m.Column("ids"); m.NotNullable(true); m.Length(20); });
            this.Property(x => x.Email, m => { m.Column("email"); m.NotNullable(false); m.Length(50); });
            this.Property(x => x.Tel1, m => { m.Column("telephone"); m.NotNullable(false); m.Length(20); });
            this.Property(x => x.Mob1, m => { m.Column("mobile"); m.NotNullable(false); m.Length(20); });
        }
    }
}
