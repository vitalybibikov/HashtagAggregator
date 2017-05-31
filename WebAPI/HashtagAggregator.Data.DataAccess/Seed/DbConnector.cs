using System;
using System.Data.SqlClient;

namespace HashtagAggregator.Data.DataAccess.Seed
{
    public class DbConnector : IDisposable
    {
        private readonly SqlConnection connection;

        public DbConnector(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void ExecuteNonQuery(params string[] commands)
        {
            if (commands != null)
            {
                foreach (var commandText in commands)
                {
                    Execute(
                        command =>
                            {
                                command.CommandText = commandText;
                                command.ExecuteNonQuery();
                            },
                        commandText);
                }
            }
        }

        private void Execute(Action<SqlCommand> runFunc, string commandText)
        {
            if (String.IsNullOrEmpty(commandText))
            {
                throw new ArgumentNullException(nameof(commandText));
            }

            try
            {
                using (var command = connection.CreateCommand())
                {
                    runFunc?.Invoke(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}
