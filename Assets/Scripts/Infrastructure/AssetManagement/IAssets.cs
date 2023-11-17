using UnityEngine;

public interface IAssets : IService
{
    DiceData_SO GetDiceData(string dataPath);
    ModifierData_SO[] GetModifiersData(string dataPath);
    GameObject Instantiate(string path);
}