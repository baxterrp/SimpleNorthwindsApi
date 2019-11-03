namespace SimpleNorthwindsApi.Configuration
{
    public class NorthwindsConfiguration
    {
        public string ConnectionString { get; }

        public NorthwindsConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
