public interface IRollDiceService : IService
{
    int DiceSides { get; }
    int RollDifficulty { get; }
    DiceData_SO DiceSettings { get; }

    void SetRandomRollDifficulty();
}
