using UnityEngine;

/// <summary>
/// Сервис для хранения данных о кубике и настроек сложности броска 
/// </summary>
public class RollDiceService : IRollDiceService
{
    /// <summary>
    /// Количество граней кубика
    /// </summary>
   public int DiceSides { get; private set; }

    /// <summary>
    /// Сложность броска кубика
    /// </summary>
    public int RollDifficulty { get; private set; }

    /// <summary>
    /// Static Data с настройками кубика
    /// </summary>
    public DiceData_SO DiceSettings { get; private set; }

    /// <summary>
    /// Результат последнего броска кубика
    /// </summary>
    public int RollResult {  get; private set; }

    private readonly IGameFactory _gameFactory;

    public RollDiceService(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;

        InitService();
    }

    private void InitService()
    {
        // Получаем Static Data с настройками выбранного кубика
        DiceSettings = _gameFactory.GetDiceStaticData(AssetPath.DICE_D20_STATIC_DATA);

        try
        {
            // Устанавливаем количество граней для кубика
            DiceSides = DiceSettings.sidesAmount;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Устанавливаем сложность броска в зависимости от количества граней кубика
    /// </summary>
    public void SetRandomRollDifficulty()
    {
        RollDifficulty = UnityEngine.Random.Range(1, DiceSides + 1);
        Debug.Log($"Roll difficulty = {RollDifficulty}");
    }

    /// <summary>
    /// Получаем результат ролла кубика
    /// </summary>
    /// <returns>Произвольное значение от 1 до DiceSides кубика</returns>
    public int RollDice() =>
        GetRollResult();

    /// <summary>
    /// Сохраняем результат ролла в свойство сервиса
    /// </summary>
    /// <param name="result">Результат броска кубика</param>
    public void SaveRollResult(int result) => 
        RollResult = result;

    /// <summary>
    /// Добавляем бонус от модификаторов к результату ролла кубика
    /// </summary>
    /// <param name="bonus">Значение бонуса от модификаторов</param>
    public void AddModifierBonusToRollResult(int bonus)
    {
        Debug.Log($"Roll result = {RollResult} + Bonus = {bonus}");
        RollResult += bonus;
        Debug.Log($"Roll+Bonus = {RollResult}");
    }

    private int GetRollResult() =>
       Random.Range(1, DiceSides + 1);
}
