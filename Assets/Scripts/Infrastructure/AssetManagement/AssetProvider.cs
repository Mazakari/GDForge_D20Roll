using UnityEngine;

public class AssetProvider : IAssets
{
    public GameObject Instantiate(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab);
    }

    public DiceData_SO GetDiceData(string dataPath) => 
        Resources.Load<DiceData_SO>(dataPath);

    public ModifierData_SO[] GetModifiersData(string dataPath) =>
        Resources.LoadAll<ModifierData_SO>(dataPath);
}