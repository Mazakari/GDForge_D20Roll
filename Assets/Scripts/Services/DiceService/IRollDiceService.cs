using System;

public interface IRollDiceService : IService
{
    int DiceSides { get; }
    int RollDifficulty { get; }
    DiceData_SO DiceSettings { get; }
    int RollResult { get; }

    void AddModifierBonusToRollResult(int bonus);
    int RollDice();
    void SaveRollResult(int result);
    void SetRandomRollDifficulty();
}
