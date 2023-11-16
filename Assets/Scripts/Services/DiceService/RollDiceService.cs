using UnityEngine;
public class RollDiceService : IRollDiceService
{
   public int DiceSides { get; private set; }
   public int RollDifficulty { get; private set; }

    public DiceData_SO DiceSettings { get; private set; }

    private readonly IGameFactory _gameFactory;

    public RollDiceService(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;

        InitService();
    }

    private void InitService()
    {
        DiceSettings = _gameFactory.GetDiceStaticData(AssetPath.DICE_D20_STATIC_DATA);

        try
        {
            DiceSides = DiceSettings.sidesAmount;
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }

        SetRandomRollDifficulty();
    }

    public void SetRandomRollDifficulty()
    {
        int rnd = Random.Range(0, DiceSides);
        RollDifficulty = rnd;
    }
}
