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
		public int WeaponSkill { get; set; }
		public int Aim { get; set; }
		public int Level { get; set; }

		public bool UpgradeAim()
		{
			Aim++;
			return true;
		}

		public bool DowngradeAim()
		{
			Aim--;
			return true;
		}

		public bool UpgradeLevel()
		{
			Level++;
			return true;
		}

		public bool DowngradeLevel()
		{
			Level--;
			return true;
		}

		public bool UpgradeConfidence()
		{
			WeaponSkill++;
			return true;
		}

		public bool DowngradeConfidence()
		{
			WeaponSkill--;
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
