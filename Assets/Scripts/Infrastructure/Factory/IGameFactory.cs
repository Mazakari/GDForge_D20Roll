using UnityEngine;

public interface IGameFactory : IService
{
    GameObject CreateLevelHud();
    void CreateVolumeControl();
    DiceData_SO GetDiceStaticData(string dataPath);
    ModifierData_SO[] GetModifiersStaticData(string dataPath);
}
