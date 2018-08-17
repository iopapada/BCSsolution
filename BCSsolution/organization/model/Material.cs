using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace BCSsolution.organization.model
{
    public class Material
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string TextBox_1 { get; set; }
        public virtual string TextBox_2 { get; set; }
        public virtual string Country { get; set; }
        public virtual bool IsEECountry { get; set; }
        public virtual string Origin { get; set; }
        public virtual string Type { get; set; }
        public virtual bool IsWeighed { get; set; }
        public virtual bool IsEnabled { get; set; }
        public virtual string Category { get; set; }
        public virtual string Variety { get; set; }
        public virtual string ClassProduct { get; set; }
    }
    public class MaterialMap : ClassMapping<Material>
    {
        public MaterialMap()
        {
            this.Schema("dbo");
            this.Table("materials");
            this.Id(x => x.Id, m => { m.Column("id"); m.Generator(Generators.Increment); });
            this.Property(x => x.Code, m => { m.Column("code"); m.NotNullable(true); });
            this.Property(x => x.Title, m => { m.Column("title"); m.NotNullable(true); m.Length(50); });
            this.Property(x => x.Description, m => { m.Column("description"); m.NotNullable(false); m.Length(100); });
            this.Property(x => x.TextBox_1, m => { m.Column("textbox1"); m.NotNullable(false); m.Length(100); });
            this.Property(x => x.TextBox_2, m => { m.Column("textbox2"); m.NotNullable(false); m.Length(100); });
            this.Property(x => x.Origin, m => { m.Column("origin"); m.NotNullable(false); m.Length(50); });
            this.Property(x => x.Type, m => { m.Column("type"); m.NotNullable(false); m.Length(50); });
        }
    }
}
