using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace LGI.Core.Model
{
    public class PathnetEfContextPool
    {
        private static PathnetEntities _db = null;

        public static PathnetEntities GetContext()
        {
            if (_db == null)
            {
                _db = PathnetEntities.ConnectToSqlServer("LDYXPS15", "pathnet", "pathnet", "4s3c2a1p", false);
                //   _db.Database.Connection.ConnectionString = "Data Source=LDYXPS15;Initial Catalog=pathnet;User ID=pathnet;Password=4s3c2a1p";
            }

            return _db;
        }
    }

    public partial class PathnetEntities
    {
        private PathnetEntities(string connStr)
            : base(connStr)
        {
        }

        public static PathnetEntities ConnectToSqlServer(string host, string catalog, string user, string pass,
            bool winAuth)
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = host,
                InitialCatalog = catalog,
                PersistSecurityInfo = true,
                IntegratedSecurity = winAuth,
                MultipleActiveResultSets = true,
                UserID = user,
                Password = pass,
            };

            // assumes a connectionString name in .config of MyDbEntities
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlBuilder.ConnectionString,
                Metadata = "res://*/",
            };

            return new PathnetEntities(entityConnectionStringBuilder.ConnectionString);
        }
    }
}