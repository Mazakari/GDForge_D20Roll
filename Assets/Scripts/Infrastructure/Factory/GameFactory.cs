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

    private GameObject InstantiatePrefab(string prefabPath)
    {
        GameObject obj = _assets.Instantiate(prefabPath);

        return obj;
    }






    private GameObject InstantiateRegistered(string prefabPath, Transform parent)
    {
        GameObject obj = _assets.Instantiate(prefabPath, parent);

        return obj;
    }

    private GameObject InstantiateRegistered(string prefabPath, Vector2 at)
    {
        GameObject obj = _assets.Instantiate(prefabPath, at);

        return obj;
    }

   

    private GameObject InstantiateRegistered(GameObject prefab, Vector2 at)
    {
        GameObject obj = _assets.Instantiate(prefab, at);

        return obj;
    }
}
