using Assets.Model.Buildings;

namespace Assets.Model.Views
{
    public interface IDetailsView
    {
        void UpdateStructure(Structure structure);
        void UpgradeStructureAttribute();
    }
}