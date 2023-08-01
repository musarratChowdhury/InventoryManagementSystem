using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IMS.Dao.Mappings;
using NHibernate;
using System.Configuration;

namespace IMS.Services.Helpers
{
    public class NHibernateConfig
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)).Mappings(mapper =>
                        {
                            mapper.FluentMappings.AddFromAssemblyOf<PaymentTypeMap>();
                        })
                        .BuildSessionFactory();

                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
