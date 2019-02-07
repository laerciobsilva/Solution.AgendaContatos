using AgendaContatos.Repository.EntityMapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace AgendaContatos.Repository.Helpers
{
    public class InMemorySessionFactory
    {
        private static InMemorySessionFactory _instance;

        private ISessionFactory _sessionFactory;

        private Configuration _configuration;

        public static InMemorySessionFactory GetInstance
        {
            get { return _instance ?? (_instance = new InMemorySessionFactory()); }
        }

        private InMemorySessionFactory()
        {

        }        

        public  static ISession OpenSession()
        {

            var _sessionFactory = Fluently
                 .Configure()
                 .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source = PLSMSERVER\SQLEXPRESS; Initial Catalog=AgendaContatos; Integrated Security = SSPI;"))

                 .Mappings(m => m.FluentMappings.Add<ContactMap>())
                 .Mappings(m => m.FluentMappings.Add<ContactMailMap>())
                 .Mappings(m=> m.FluentMappings.Add<ContactTypeMap>())
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ContactPhoneMap>())
                 .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false,false))
                 .BuildSessionFactory();

            return _sessionFactory.OpenSession();
        }        

        public void Dispose() {

            if (_sessionFactory != null)
                _sessionFactory.Dispose();

            _sessionFactory = null;
            _configuration = null;
        }       
    }
}
