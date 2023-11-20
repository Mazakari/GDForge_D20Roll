using UnityEngine;

/// <summary>
/// ������ ��� �������� ������ � ������ � �������� ��������� ������ 
/// </summary>
public class RollDiceService : IRollDiceService
{
    /// <summary>
    /// ���������� ������ ������
    /// </summary>
   public int DiceSides { get; private set; }

    /// <summary>
    /// ��������� ������ ������
    /// </summary>
    public int RollDifficulty { get; private set; }

    /// <summary>
    /// Static Data � ����������� ������
    /// </summary>
    public DiceData_SO DiceSettings { get; private set; }

    /// <summary>
    /// ��������� ���������� ������ ������
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
        // �������� Static Data � ����������� ���������� ������
        DiceSettings = _gameFactory.GetDiceStaticData(AssetPath.DICE_D20_STATIC_DATA);

        try
        {
            // ������������� ���������� ������ ��� ������
            DiceSides = DiceSettings.sidesAmount;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// ������������� ��������� ������ � ����������� �� ���������� ������ ������
    /// </summary>
    public void SetRandomRollDifficulty()
    {
        RollDifficulty = UnityEngine.Random.Range(1, DiceSides + 1);
        Debug.Log($"Roll difficulty = {RollDifficulty}");
    }

    /// <summary>
    /// �������� ��������� ����� ������
    /// </summary>
    /// <returns>������������ �������� �� 1 �� DiceSides ������</returns>
    public int RollDice() =>
        GetRollResult();

    /// <summary>
    /// ��������� ��������� ����� � �������� �������
    /// </summary>
    /// <param name="result">��������� ������ ������</param>
    public void SaveRollResult(int result) => 
        RollResult = result;

    /// <summary>
    /// ��������� ����� �� ������������� � ���������� ����� ������
    /// </summary>
    /// <param name="bonus">�������� ������ �� �������������</param>
    public void AddModifierBonusToRollResult(int bonus)
    {
        Debug.Log($"Roll result = {RollResult} + Bonus = {bonus}");
        RollResult += bonus;
        Debug.Log($"Roll+Bonus = {RollResult}");
    }

    private int GetRollResult() =>
       Random.Range(1, DiceSides + 1);
}
