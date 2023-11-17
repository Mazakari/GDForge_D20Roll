using UnityEngine;

public class GameFactory : IGameFactory
{
    private readonly IAssets _assets;

    public GameFactory(IAssets assets) =>
        _assets = assets;

    public GameObject CreateLevelHud() =>
       InstantiatePrefab(AssetPath.LEVEL_CANVAS_PATH);

    public void CreateVolumeControl() =>
        InstantiatePrefab(AssetPath.VOLUME_CONTROL_PREFAB_PATH);

    public DiceData_SO GetDiceStaticData(string dataPath) => 
        _assets.GetDiceData(dataPath);

    public ModifierData_SO[] GetModifiersStaticData(string dataPath) =>
        _assets.GetModifiersData(dataPath);

    private GameObject InstantiatePrefab(string prefabPath)
    {
        GameObject obj = _assets.Instantiate(prefabPath);

        return obj;
    }
}
