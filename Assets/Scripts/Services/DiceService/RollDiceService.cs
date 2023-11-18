using UnityEngine;
public class RollDiceService : IRollDiceService
{
   public int DiceSides { get; private set; }
   public int RollDifficulty { get; private set; }

    public DiceData_SO DiceSettings { get; private set; }

    public int RollResult {  get; private set; }

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
    }

    public void SetRandomRollDifficulty()
    {
        RollDifficulty = UnityEngine.Random.Range(1, DiceSides + 1);
        Debug.Log($"Roll difficulty = {RollDifficulty}");
    }

    public int RollDice() =>
        GetRollResult();

    public void SaveRollResult(int result) => 
        RollResult = result;

    public void AddModifierBonusToRollResult(int bonus)
    {
        Debug.Log($"Roll result = {RollResult} + Bonus = {bonus}");
        RollResult += bonus;
        Debug.Log($"Roll+Bonus = {RollResult}");
    }

    private int GetRollResult() =>
       Random.Range(1, DiceSides + 1);
}
