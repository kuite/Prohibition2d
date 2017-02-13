using System;
using System.Data;
using Mono.Data.SqliteClient;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Model.Context
{
    public class ProhibitionContext : IContext
    {
        private IDbConnection _connection;
        private IDbCommand _dbcm;
        private IDataReader _dbr;

        public ProhibitionContext(string connection)
        {
            Debug.Log(connection);
            _connection = new SqliteConnection(string.Format("URI=file:{0}", connection));
        }

        public void ExecuteQuery(string query)
        {
            IDbCommand command = _connection.CreateCommand();

            _connection.Open();

            command.CommandText = query;
            command.ExecuteNonQuery();

            command.Dispose();
            command = null;
        }
    }
}
