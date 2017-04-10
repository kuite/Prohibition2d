using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.CityScene.Scripts;
using Assets.Model.Buildings;
using Assets.Model.GameSettings;
using Assets.Model.PlayableEntities;
using Assets.SharedResources.Scripts;

namespace Assets.Model.Context
{
    public class SqliteContext
    {
        private readonly SQLiteConnection _connection;

        public SqliteContext(string connString)
        {
            _connection = new SQLiteConnection(connString, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            _connection.DropTable<SoldierStats>();
			_connection.CreateTable<SoldierStats>();

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

            #region SoldierStats
            _connection.InsertAll(new List<SoldierStats>
                {
                    new SoldierStats
                    {
                        Hp = 5,
                        Speed = 3,
                        Aim = 2,
                        WeaponSkill = 4,
                        Level = 1,
						ImageId = 0
                    },
                    new SoldierStats
                    {
                        Hp = 3,
                        Speed = 4,
                        Aim = 3,
                        WeaponSkill = 4,
                        Level = 1,
						ImageId = 1
                    },
                    new SoldierStats
                    {
                        Hp = 2,
                        Speed = 2,
                        Aim = 5,
                        WeaponSkill = 5,
                        Level = 1,
						ImageId = 2
                    },
                    new SoldierStats
                    {
                        Hp = 6,
                        Speed = 1,
                        Aim = 4,
                        WeaponSkill = 3,
                        Level = 1,
						ImageId = 3
                    },
					new SoldierStats
					{
						Hp = 5,
						Speed = 2,
						Aim = 3,
						WeaponSkill = 4,
						Level = 3,
						ImageId = 4
					},
					new SoldierStats
					{
						Hp = 5,
						Speed = 2,
						Aim = 3,
						WeaponSkill = 4,
						Level = 3,
						ImageId = 5
					},
					new SoldierStats
					{
						Hp = 3,
						Speed = 5,
						Aim = 3,
						WeaponSkill = 2,
						Level = 4,
						ImageId = 6
					},
					new SoldierStats
					{
						Hp = 2,
						Speed = 2,
						Aim = 3,
						WeaponSkill = 4,
						Level = 5,
						ImageId = 7
					},
					new SoldierStats
					{
						Hp = 5,
						Speed = 2,
						Aim = 3,
						WeaponSkill = 4,
						Level = 3,
						ImageId = 8
					},
					new SoldierStats
					{
						Hp = 5,
						Speed = 2,
						Aim = 3,
						WeaponSkill = 4,
						Level = 3,
						ImageId = 3
					},
				});
            #endregion

            #region NightClubs
            _connection.InsertAll(new List<NightClub>
            {
                new NightClub
                {
                    Girls = 10
                },
                new NightClub
                {
                    Girls = 5
                },
                new NightClub
                {
                    Girls = 9
                },
                new NightClub
                {
                    Girls = 2
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
                    HomeWin = 0.12
                },
                new Casino
                {
                    HomeWin = 0.2
                },
                new Casino
                {
                    HomeWin = 0.15
                },
                new Casino
                {
                    HomeWin = 0.18
                }
            });
            #endregion

            #region Distillery
            _connection.InsertAll(new List<Distillery>
            {
                new Distillery
                {
                    Level = 2
                },
                new Distillery
                {
                    Level = 1
                },
                new Distillery
                {
                    Level = 3
                },
                new Distillery
                {
                    Level = 5
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
                    CasinoId = 2
                },
                new DistrictData
                {
                    PubId = 2,
                    NightClubId = 3,
                    DistilleryId = 3,
                    LocalBusinessId = 4,
                    CasinoId = 1
                },
                new DistrictData
                {
                    PubId = 3,
                    NightClubId = 2,
                    DistilleryId = 1,
                    LocalBusinessId = 2,
                    CasinoId = 3
                },
                new DistrictData
                {
                    PubId = 3,
                    NightClubId = 4,
                    DistilleryId = 1,
                    LocalBusinessId = 2,
                    CasinoId = 4
                },
                new DistrictData
                {
                    PubId = 4,
                    NightClubId = 2,
                    DistilleryId = 4,
                    LocalBusinessId = 1,
                    CasinoId = 4
                },
            });
            #endregion

            #region LocalBussines
            _connection.InsertAll(new List<LocalBussines>
            {
                new LocalBussines
                {
                    Tribute = 0.1
                },
                new LocalBussines
                {
                    Tribute = 0.12
                },
                new LocalBussines
                {
                    Tribute = 0.15
                },
                new LocalBussines
                {
                    Tribute = 0.2
                },
                new LocalBussines
                {
                    Tribute = 0.25
                }
            });
            #endregion

        }
        public IEnumerable<T> Table<T>() where T : new()
        {
            return _connection.Table<T>();
        }

        public T GetById<T>(int id) where T : new()
        {
            return _connection.Get<T>(id);
        }

    }
}
