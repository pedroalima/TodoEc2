﻿using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace TodoEc2.Infrastructure.Migrations
{
    public static class DatabaseMigrations
    {
        public static void Migrate(string connectionString, IServiceProvider serviceProvider)
        {
            EnsureDatabaseCreated(connectionString);

            MigrationDatabase(serviceProvider);
        }

        private static void EnsureDatabaseCreated(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var databaseName = connectionStringBuilder.InitialCatalog;

            connectionStringBuilder.Remove("Database");

            using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

            if (!records.Any())
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
        }

        private static void MigrationDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();

            runner.MigrateUp();
        }
    }
}
