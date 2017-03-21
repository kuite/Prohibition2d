using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Buildings
{
    public interface IStructure
    {
        bool UpgradeLevel();
        bool DowngradeLevel();
    }
}
