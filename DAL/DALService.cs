using DbEntities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Common;

namespace DAL
{
    public static class DALService  //utilisation dépréciée, voir injection de dependance
    {
        private static ServiceProvider _Provider;
        private static ServiceCollection _ServiceCollection;
        public static ServiceProvider Provider
        {
            get
            {
                if (_Provider == null)
                {
                    //register factory as Core does not natively supports System.Data.SqlClient
                    DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
                    _Provider = ServiceCollection.BuildServiceProvider();
                }
                return _Provider;
            }
            set
            {
                _Provider = value;
            }
        }
        private static ServiceCollection ServiceCollection
        {
            get
            {
                if (_ServiceCollection == null)
                {
                    _ServiceCollection = new ServiceCollection();
                }
                return _ServiceCollection;
            }
            set 
            {
                _ServiceCollection = value;
            }
        }

        //If service T isn't included in _ServiceCollection, adds it and rebuilds the provider.
        //returns service
        public static T GetService<T>() where T: class//, IService<TEntity<int>>
        {
            if (Provider.GetService<T>() == null)
            {
                ServiceCollection.AddSingleton<T>();
                Provider = ServiceCollection.BuildServiceProvider();
                Console.WriteLine("added" + typeof(T).ToString());
            }
            return Provider.GetService<T>();
        }

    }
}
