using Assets.Model.Context;

namespace Assets.Model.GameSettings
{
    public class GameSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
