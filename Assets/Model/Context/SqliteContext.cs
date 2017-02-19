using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.CityScene.Scripts;
using Assets.Model.Buildings;
using Assets.Model.GameSettings;
using Assets.SharedResources.Scripts;

namespace Assets.Model.Context
{
    public class SqliteContext
    {
        private readonly SQLiteConnection _connection;

        public SqliteContext(string connString)
        {
            _connection = new SQLiteConnection(connString, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            _connection.DropTable<Pub>();
            _connection.CreateTable<Pub>();

            _connection.DropTable<Casino>();
            _connection.CreateTable<Casino>();

            _connection.DropTable<Distillery>();
            _connection.CreateTable<Distillery>();

            _connection.DropTable<NightClub>();
            _connection.CreateTable<NightClub>();

            _connection.DropTable<User>();
            _connection.CreateTable<User>();

            _connection.DropTable<GameSettings.GameSettings>();
            _connection.CreateTable<GameSettings.GameSettings>();

            _connection.DropTable<LocalBussines>();
            _connection.CreateTable<LocalBussines>();

            _connection.DropTable<DistrictSettings>();
            _connection.CreateTable<DistrictSettings>();

            _connection.InsertOrReplace(new User {Name = "TestUser"});

            _connection.InsertAll(new List<NightClub>
            {
                new NightClub
                {
                    Income = 10
                },
                new NightClub
                {
                    Income = 15
                },
                new NightClub
                {
                    Income = 19
                },
                new NightClub
                {
                    Income = 25
                }
            });
        }

        public IEnumerable<DistrictSettings> DistrictSettings()
        {
            return _connection.Table<DistrictSettings>();
        }
    }
}
