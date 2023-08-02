using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IMS.Dao.Mappings;
using log4net;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using System.Configuration;

namespace IMS.Services.Helpers
{
    public class NHibernateConfig
    {
        private static ISessionFactory _sessionFactory;
        private static readonly ILog log = LogManager.GetLogger(typeof(NHibernateConfig));
        public static ISessionFactory SessionFactory
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                if (_sessionFactory == null)
                {
                    ConfigureLog4Net();
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                        .Mappings(mapper =>
                        {
                            mapper.FluentMappings.AddFromAssemblyOf<PaymentTypeMap>();
                        })
                        .ExposeConfiguration(config =>
                        {
                            config.SetProperty(Environment.ShowSql, "true"); // Enable ShowSql
                            config.SetProperty(Environment.FormatSql, "true");
                        })
                        .BuildSessionFactory();

                    log.Info("HELLO FROM SERVICE CONFIG CLASS");

                }
                return _sessionFactory;
            }
        }
        private static void ConfigureLog4Net()
        {
            XmlConfigurator.Configure(); // Load log4net configuration from app.config or web.config
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
