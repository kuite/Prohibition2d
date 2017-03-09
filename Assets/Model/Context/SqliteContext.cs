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

            _connection.DropTable<DistrictData>();
            _connection.CreateTable<DistrictData>();

            _connection.InsertOrReplace(new User { Name = "TestUser" });

            #region NightClubs
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
            #endregion

            #region Pubs
            _connection.InsertAll(new List<Pub>
            {
                new Pub
                {
                    AlcoholPrice = 5
                },
                new Pub
                {
                    AlcoholPrice = 2
                },
                new Pub
                {
                    AlcoholPrice = 8
                },
                new Pub
                {
                    AlcoholPrice = 3
                }
            });
            #endregion

            #region Casino
            _connection.InsertAll(new List<Casino>
            {
                new Casino
                {
                    WinMarginPercentage = 12
                },
                new Casino
                {
                    WinMarginPercentage = 2
                },
                new Casino
                {
                    WinMarginPercentage = 5
                },
                new Casino
                {
                    WinMarginPercentage = 8
                }
            });
            #endregion

            #region Distillery
            _connection.InsertAll(new List<Distillery>
            {
                new Distillery
                {
                    AlcoholProduction = 250
                },
                new Distillery
                {
                    AlcoholProduction = 200
                },
                new Distillery
                {
                    AlcoholProduction = 500
                },
                new Distillery
                {
                    AlcoholProduction = 800
                }
            });
            #endregion

            #region DistrictData
            _connection.InsertAll(new List<DistrictData>
            {
                new DistrictData
                {
                    PubId = 1,
                    NightClubId = 1,
                    DistilleryId = 1,
                    LocalBusinessId = 1,
                    LocalBusinessesCount = 4,
                    CasinoId = 2
                },
                new DistrictData
                {
                    PubId = 2,
                    NightClubId = 3,
                    DistilleryId = 3,
                    LocalBusinessId = 4,
                    LocalBusinessesCount = 8,
                    CasinoId = 1
                },
                new DistrictData
                {
                    PubId = 3,
                    NightClubId = 2,
                    DistilleryId = 1,
                    LocalBusinessId = 2,
                    LocalBusinessesCount = 15,
                    CasinoId = 3
                },
                new DistrictData
                {
                    PubId = 3,
                    NightClubId = 4,
                    DistilleryId = 1,
                    LocalBusinessId = 2,
                    LocalBusinessesCount = 4,
                    CasinoId = 4
                },
                new DistrictData
                {
                    PubId = 4,
                    NightClubId = 2,
                    DistilleryId = 4,
                    LocalBusinessId = 1,
                    LocalBusinessesCount = 11,
                    CasinoId = 4
                },
            });
            #endregion

        }

        public DistrictData Table(IEntity entity)
        {
            //dynamic v2 = entity.GetType().GetProperty("Value").GetValue(entity, null);
            return null;
        }

        public IEnumerable<DistrictData> DistrictSettings()
        {
            return _connection.Table<DistrictData>();
        }

        public Casino GetCasinoById(int id)
        {
            return _connection.Table<Casino>().First();
        }

    }
}
