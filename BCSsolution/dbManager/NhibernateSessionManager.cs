using BCSsolution.onStart.model;
using BCSsolution.onStart.viewmodel;
using BCSsolution.organization.model;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace BCSsolution.dbManager
{
    public class NhibernateSessionManager
    {
        protected static Configuration myConfiguration;
        protected static ISessionFactory mySessionFactory;
        protected static ISession mySession;

        public static ISession OpenSession()
        {
            mySession = mySessionFactory.OpenSession();
            return mySession;
        }

        public static ISessionFactory SessionFactory {
            get
            {
                if (mySessionFactory == null)
                {
                    //Create the session factory
                    mySessionFactory = myConfiguration.BuildSessionFactory();
                }
                return mySessionFactory;
            }
        }

        public static void initDB() {
            Setup();
            //Run only the first time
            CreateDatabaseSchema();
            DBinitialize();
        }

        public static void Setup() {
            myConfiguration = NhiberanteConfigure();
            HbmMapping mapping = GetMappings();
            myConfiguration.AddDeserializedMapping(mapping, "NHSchema");
            SchemaMetadataUpdater.QuoteTableAndColumns(myConfiguration);

            mySessionFactory = myConfiguration.BuildSessionFactory();
            OpenSession();
        }

        private static Configuration NhiberanteConfigure()
        {
            myConfiguration = new Configuration().DataBaseIntegration(db =>
            {
                db.ConnectionString = "Server=127.0.0.1;Database=bcsDB;Uid=sa;Pwd=2202;";
                db.Dialect<MsSql2012Dialect>();
                db.Driver<NHibernate.Driver.SqlClientDriver>();

                //enabled for testing
                db.LogFormattedSql = false;
                db.LogSqlInConsole = false;
                db.AutoCommentSql = false;
            });

            return myConfiguration;
        }

        private static HbmMapping GetMappings() {
            //This is dynamic way!!
            //var mapper = new ModelMapper();
            //mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            //HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping<SupplierMap>();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<MaterialMap>();
            //mapper.AddMapping<CustomerMap>();
            //mapper.AddMapping<>
            HbmMapping mapping = mapper.CompileMappingFor(new[] { typeof(Supplier), typeof(User), typeof(Material) });
            
            return mapping;
        }

        private static void CreateDatabaseSchema()
        {
            new SchemaExport(myConfiguration).Drop(false, true);
            new SchemaExport(myConfiguration).Create(false, true);
        }

        public static void DBinitialize() {

            using (ITransaction transaction = NhibernateSessionManager.OpenSession().BeginTransaction())
            {
                mySession.Save(new User { UserName = "admin", FirstName = "administrator", LastName = "Administrator", HashedPassword = UserRepository.CalculateHash("admin", "admin"), UserMail = "papadakisfruits@gmail.com" , UserRole = User.Role.admin });
                mySession.Save(new User { UserName = "user", FirstName = "user", LastName = "User", HashedPassword = UserRepository.CalculateHash("user", "user"), UserMail = "papadakisfruits@gmail.com" , UserRole = User.Role.user});
                mySession.Save(new User { UserName = "visitor", FirstName = "visitor", LastName = "Visitor", HashedPassword = UserRepository.CalculateHash("visitor", "visitor"), UserMail = "papadakisfruits@gmail.com" , UserRole = User.Role.visitor});

                mySession.Save(new Supplier { FirstName = "John", LastName = "Papa", Ids = "12345", Grs ="12345", Tel1 = "123456789", Mob1 = "123456789", Email = "test@gmail.com", LblPrintText = "--" });
                mySession.Save(new Supplier { FirstName = "Greek", LastName = "Freak", Ids = "123456", Grs = "123456", Tel1 = "123456789", Mob1 = "123456789", Email = "test@gmail.com", LblPrintText = "--"});

                mySession.Save(new Material { Code = "001", Title = "Dole bananas", Description = "", TextBox_1 = "", TextBox_2 = "", Origin = "Ecuador", Type = "cavendish" });
                mySession.Save(new Material { Code = "014", Title = "Orsero bananas", Description = "", TextBox_1 = "", TextBox_2 = "", Origin = "Ecuador", Type = "cavendish" });

                transaction.Commit();
            };
        }
    }
}
