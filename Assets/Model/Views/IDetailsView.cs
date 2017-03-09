using Assets.Model.Buildings;

namespace Assets.Model.Views
{
    public interface IDetailsView
    {
        void UpdateStructure(IStructure structure);
        void UpgradeStructureAttribute();
    }
}