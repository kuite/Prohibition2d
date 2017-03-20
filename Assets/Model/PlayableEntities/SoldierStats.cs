using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
	public class SoldierStats
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public int Hp { get; set; }
		public int Speed { get; set; }
		public int Confidence { get; set; }

		public bool UpgradeConfidence()
		{
			Confidence++;
			return true;
		}

		public bool DowngradeConfidence()
		{
			Confidence--;
			return true;
		}

		public bool UpgradeSpeed()
		{
			Speed++;
			return true;
		}

		public bool DowngradeSpeed()
		{
			Speed--;
			return true;
		}

		public bool UpgradeHp()
		{
			Hp++;
			return true;
		}

		public bool DowngradeHp()
		{
			Hp--;
			return true;
		}
	}
}
